//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2022 Dassault Systèmes - CPE EMED
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//------------------------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.project.risk.core.data.impl;
using ws3dx.project.risk.core.service;
using ws3dx.project.risk.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class RiskServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";
      const string SECURITY_CONTEXT = "VPLMProjectLeader.Company Name.AAA27 Personal";

      const string CUSTOM_PROP_NAME_1_DBL = "AAA27_REAL_TEST";
      const string CUSTOM_PROP_NAME_2_INT = "AAA27_INT_TEST";

      string m_username = string.Empty;
      string m_password = string.Empty;
      string m_passportUrl = string.Empty;
      string m_serviceUrl = string.Empty;
      string m_tenant = string.Empty;

      UserInfo m_userInfo = null;

      public async Task<IPassportAuthentication> Authenticate()
      {
         UserPassport passport = new UserPassport(m_passportUrl);

         UserInfoRedirection userInfoRedirection = new UserInfoRedirection(m_serviceUrl, m_tenant)
         {
            Current = true,
            IncludeCollaborativeSpaces = true,
            IncludePreferredCredentials = true
         };

         m_userInfo = await passport.CASLoginWithRedirection<UserInfo>(m_username, m_password, false, userInfoRedirection);

         Assert.IsNotNull(m_userInfo);

         StringAssert.AreEqualIgnoringCase(m_userInfo.name, m_username);

         Assert.IsTrue(passport.IsCookieAuthenticated);

         return passport;
      }

      [SetUp]
      public void Setup()
      {
         m_username = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_USERNAME, EnvironmentVariableTarget.User); // e.g. AAA27
         m_password = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSWORD, EnvironmentVariableTarget.User); // e.g. your password
         m_passportUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSPORT, EnvironmentVariableTarget.User); // e.g. https://eu1-ds-iam.3dexperience.3ds.com:443/3DPassport

         m_serviceUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_ENOVIA, EnvironmentVariableTarget.User); // e.g. https://r1132100982379-eu1-space.3dexperience.3ds.com:443/enovia
         m_tenant = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_TENANT, EnvironmentVariableTarget.User); // e.g. R1132100982379
      }

      public string GetDefaultSecurityContext()
      {
         return m_userInfo.preferredcredentials.ToString();
      }

      public RiskService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         RiskService __riskService = new RiskService(_serviceUrl, _passport);
         __riskService.Tenant = _tenant;
         __riskService.SecurityContext = GetDefaultSecurityContext();
         return __riskService;
      }

      // <param name="owned">
      // Description: Retrieve Risks owned by me (Default: true)
      // </param>
      // <param name="assigned">
      // Description: Retrieve Risks assigned to me (Default: true)
      // </param>
      // <param name="completed">
      // Description: Retrieve Risks that have been Completed within this range (none, all, number of days; 
      // Default: none)
      // </param>
      // <param name="state">
      // Description: Filter Risks by one or more comma separated states: Create, Assign, Active, Review, 
      // Complete (Default: all but Complete)
      // </param>
      [TestCase("false", "false", 0, "Create,Assign,Active,Review,Complete")]
      public async Task GetRisks(string owned, string assigned, int completed, string state)
      {
         IPassportAuthentication passport = await Authenticate();

         RiskService riskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseRiskData> ret = await riskService.GetRisks(owned, assigned, completed, state);

         Assert.IsNotNull(ret);
      }

      [TestCase("DFD6F085F3530000630E19F8000A7EE0")]
      public async Task GetRisk(string riskId)
      {
         IPassportAuthentication passport = await Authenticate();

         RiskService riskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseRiskData ret = await riskService.GetRisk(riskId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task CreateRisk()
      {
         IPassportAuthentication passport = await Authenticate();

         RiskService riskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         //MANDATORY for Create: { probability, impact, effectiveDate, }
         IRiskData riskData = new RiskData();
         riskData.Title = "New Risk Created from Web Services";
         riskData.Probability = "1"; //1-Rare, 2-Unlikely, 3-Possible, 4-Likely, and 5-Almost Certain
         riskData.Impact = "2";
         riskData.EffectiveDate = "2023-03-18"; //?
         riskData.ContextId = "41DF2E16046E00006278C0B200000350";

         IRisk risks = new Risk();
         risks.Data = new List<IRiskData>();
         risks.Data.Add(riskData);

         try
         {
            IList<IResponseRiskData> ret = await riskService.CreateRisk(risks);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("risk")]
      public async Task SearchRisks(string _searchCriteria)
      {
         IPassportAuthentication passport = await Authenticate();

         RiskService riskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IList<IResponseRiskData> ret = await riskService.Search(new SearchByFreeText(_searchCriteria));

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}