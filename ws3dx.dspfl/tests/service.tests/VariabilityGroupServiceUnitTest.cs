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
using ws3dx.dspfl.core.data.impl;
using ws3dx.dspfl.core.service;
using ws3dx.dspfl.data;

namespace NUnitTestProject
{
   public class VariabilityGroupServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";
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

      public VariabilityGroupService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         VariabilityGroupService __variabilityGroupService = new VariabilityGroupService(_serviceUrl, _passport);
         __variabilityGroupService.Tenant = _tenant;
         __variabilityGroupService.SecurityContext = GetDefaultSecurityContext();
         return __variabilityGroupService;
      }

      [TestCase()]
      public async Task GetVariabilityGroups()
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVariabilityGroupMask> ret = await variabilityGroupService.GetVariabilityGroups();

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetVariabilityGroup(string variabilityGroupId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IVariabilityGroupMask ret = await variabilityGroupService.GetVariabilityGroup(variabilityGroupId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetOption(string variabilityGroupId, string optionId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IOptionMask ret = await variabilityGroupService.GetOption(variabilityGroupId, optionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetOptions(string variabilityGroupId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOptionMask> ret = await variabilityGroupService.GetOptions(variabilityGroupId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task MoveOption(string variabilityGroupId, string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IOrdered request = new Ordered();

         try
         {
            IEnumerable<IOptionMask> ret = await variabilityGroupService.MoveOption(variabilityGroupId, iD, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27WS3DX Options Group")]
      public async Task Create(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewVariabilityGroup newVariabilityGroup = new NewVariabilityGroup();
         newVariabilityGroup.Type = "Variability Group";
         newVariabilityGroup.VersionName = "";
         newVariabilityGroup.Attributes = new NewVariabilityGroupData();

         newVariabilityGroup.Attributes.Title = _title;

         ICreateVariabilityGroup request = new CreateVariabilityGroup();
         request.Items = new List<INewVariabilityGroup>();
         request.Items.Add(newVariabilityGroup);

         try
         {
            IEnumerable<IVariabilityGroupMask> ret = await variabilityGroupService.Create(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("44C2728F76160000643662670012AF1C")]
      public async Task CreateOptions(string variabilityGroupId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariabilityGroupService variabilityGroupService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewVariabilityOption option1 = new NewVariabilityOption();
         option1.Type = "Variability Option";
         option1.VersionName = "";
         option1.Attributes = new NewVariabilityOptionData();
         option1.Attributes.SequenceNumber = 1;
         option1.Attributes.Name = "Option 1";

         INewVariabilityOption option2 = new NewVariabilityOption();
         option2.Type = "Variability Option";
         option2.VersionName = "";
         option2.Attributes = new NewVariabilityOptionData();
         option2.Attributes.Name = "Option 2";
         option2.Attributes.SequenceNumber = 2;

         ICreateVariabilityOption request = new CreateVariabilityOption();
         request.Items = new List<INewVariabilityOption>();
         request.Items.Add(option1);
         request.Items.Add(option2);

         try
         {
            IEnumerable<IOptionMask> ret = await variabilityGroupService.CreateOptions(variabilityGroupId, request);

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