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
using ws3dx.core.redirection;
using ws3dx.dslib.core.service;
using ws3dx.dslib.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class LibraryServiceTests
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

      public LibraryService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         LibraryService __libraryService = new LibraryService(_serviceUrl, _passport);
         __libraryService.Tenant = _tenant;
         __libraryService.SecurityContext = GetDefaultSecurityContext();
         return __libraryService;
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_ISimpleMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ISimpleMask> ret = await libraryService.Search<ISimpleMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_ISimpleMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ISimpleMask> ret = await libraryService.Search<ISimpleMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("library", 0, 50)]
      public async Task Search_Paged_ILibraryDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ISimpleMask> ret = await libraryService.Search<ISimpleMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);

         int i = 0;
         foreach (ISimpleMask libFound in ret)
         {
            IEnumerable<ILibraryDetailMask> libFamily = await libraryService.Get<ILibraryDetailMask>(libFound.Id, "1");

            if (libFamily != null)
            {
               foreach (ILibraryDetailMask libFamilyDetailMask in libFamily)
               {
                  Assert.AreEqual(libFound.Id, libFamilyDetailMask.Id);
               }
            }

            i++;

            if (i > 20) return;
         }
      }

      [TestCase("library")]
      public async Task Search_Full_ILibraryDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ILibraryDetailMask> ret = await libraryService.Search<ILibraryDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "5")]
      public async Task Get_ISimpleMask(string libId, string depth)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISimpleMask> ret = await libraryService.Get<ISimpleMask>(libId, depth);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "5")]
      public async Task Get_IExpandClassifiableClassesMask(string libId, string depth)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IExpandClassifiableClassesMask> ret = await libraryService.Get<IExpandClassifiableClassesMask>(libId, depth);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "5")]
      public async Task Get_IExpandClassesDetailMask(string libId, string depth)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IExpandClassesDetailMask> ret = await libraryService.Get<IExpandClassesDetailMask>(libId, depth);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "5")]
      public async Task Get_IExpandClassesMask(string libId, string depth)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IExpandClassesMask> ret = await libraryService.Get<IExpandClassesMask>(libId, depth);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "5")]
      public async Task Get_ILibraryDetailMask(string libId, string depth)
      {
         IPassportAuthentication passport = await Authenticate();

         LibraryService libraryService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ILibraryDetailMask> ret = await libraryService.Get<ILibraryDetailMask>(libId, depth);

         Assert.IsNotNull(ret);
      }
   }
}