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
using ws3dx.dsrm.core.data.impl;
using ws3dx.dsrm.core.service;
using ws3dx.dsrm.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class RawMaterialServiceTests
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

      public RawMaterialService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         RawMaterialService __rawMaterialService = new RawMaterialService(_serviceUrl, _passport);
         __rawMaterialService.Tenant = _tenant;
         __rawMaterialService.SecurityContext = GetDefaultSecurityContext();
         return __rawMaterialService;
      }

      [TestCase("")]
      public async Task GetEnterpriseItemNumber(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IEnterpriseItemNumberMask> ret = await rawMaterialService.GetEnterpriseItemNumber(rawMatId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlStatusMask> ret = await rawMaterialService.GetChangeControl(rawMatId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IRawMaterialMask(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IRawMaterialMask> ret = await rawMaterialService.Get<IRawMaterialMask>(rawMatId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IRawMaterialDetailMask(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IRawMaterialDetailMask> ret = await rawMaterialService.Get<IRawMaterialDetailMask>(rawMatId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IRawMaterialMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IRawMaterialMask> ret = await rawMaterialService.Search<IRawMaterialMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IRawMaterialMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IRawMaterialMask> ret = await rawMaterialService.Search<IRawMaterialMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IRawMaterialDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IRawMaterialDetailMask> ret = await rawMaterialService.Search<IRawMaterialDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IRawMaterialDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IRawMaterialDetailMask> ret = await rawMaterialService.Search<IRawMaterialDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task ActivateChangeControl(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await rawMaterialService.ActivateChangeControl(rawMatId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IRawMaterialMask()
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateRawMaterial request = new CreateRawMaterial();

         try
         {
            IEnumerable<IRawMaterialMask> ret = await rawMaterialService.Create<IRawMaterialMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IRawMaterialDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateRawMaterial request = new CreateRawMaterial();

         try
         {
            IEnumerable<IRawMaterialDetailMask> ret = await rawMaterialService.Create<IRawMaterialDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddEnterpriseItemNumber(string rawMatId)
      {
         IPassportAuthentication passport = await Authenticate();

         RawMaterialService rawMaterialService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEnterpriseItemNumber request = new EnterpriseItemNumber();

         try
         {
            IEnumerable<IEnterpriseItemNumberMask> ret = await rawMaterialService.AddEnterpriseItemNumber(rawMatId, request);

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