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
using ws3dx.dsadvfilter.core.data.impl;
using ws3dx.dsadvfilter.core.service;
using ws3dx.dsadvfilter.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class AdvFilterServiceTests
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

      public AdvFilterService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         return new AdvFilterService(_serviceUrl, _passport)
         {
            Tenant = _tenant,
            SecurityContext = GetDefaultSecurityContext()
         };
      }

      [TestCase("filter", 0, 50)]
      public async Task Search_Paged_IAdvancedFilterMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IAdvancedFilterMask> ret = await advFilterService.Search<IAdvancedFilterMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;

            foreach (IAdvancedFilterMask filterFound in ret)
            {
               IAdvancedFilterMask filter0 = await advFilterService.Get<IAdvancedFilterMask>(filterFound.Id);

               //IAdvancedFilterSpecMask filter1 = await advFilterService.Get<IAdvancedFilterSpecMask>(filterFound.Id);

               Assert.AreEqual(filter0.Id, filterFound.Id);

               i++;

               if (i > 20) return;
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("search")]
      public async Task Search_Full_IAdvancedFilterMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IAdvancedFilterMask> ret = await advFilterService.Search<IAdvancedFilterMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IAdvancedFilterSpecMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IAdvancedFilterSpecMask> ret = await advFilterService.Search<IAdvancedFilterSpecMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IAdvancedFilterSpecMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IAdvancedFilterSpecMask> ret = await advFilterService.Search<IAdvancedFilterSpecMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IAdvancedFilterMask(string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IAdvancedFilterMask ret = await advFilterService.Get<IAdvancedFilterMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IAdvancedFilterSpecMask(string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IAdvancedFilterSpecMask ret = await advFilterService.Get<IAdvancedFilterSpecMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create_IAdvancedFilterMask()
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateAdvancedFilters request = new CreateAdvancedFilters();

         try
         {
            IEnumerable<IAdvancedFilterMask> ret = await advFilterService.Create<IAdvancedFilterMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IAdvancedFilterSpecMask()
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateAdvancedFilters request = new CreateAdvancedFilters();

         try
         {
            IEnumerable<IAdvancedFilterSpecMask> ret = await advFilterService.Create<IAdvancedFilterSpecMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate()
      {
         IPassportAuthentication passport = await Authenticate();

         AdvFilterService advFilterService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<ILocateAdvancedFilterResponse> ret = await advFilterService.Locate(request);

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