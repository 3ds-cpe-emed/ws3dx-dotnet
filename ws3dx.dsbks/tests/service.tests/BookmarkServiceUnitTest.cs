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
using ws3dx.dsbks.core.data.impl;
using ws3dx.dsbks.core.service;
using ws3dx.dsbks.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class BookmarkServiceTests
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

      public BookmarkService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         BookmarkService __bookmarkService = new BookmarkService(_serviceUrl, _passport)
         {
            Tenant = _tenant,
            SecurityContext = GetDefaultSecurityContext()
         };
         return __bookmarkService;
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IBookmarkMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkMask> ret = await bookmarkService.Search<IBookmarkMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IBookmarkMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkMask> ret = await bookmarkService.Search<IBookmarkMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IBookmarkDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Search<IBookmarkDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IBookmarkDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Search<IBookmarkDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IBookmarkMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IBookmarkMask> ret = await bookmarkService.Get<IBookmarkMask>(bookmarkId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IBookmarkDetailMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Get<IBookmarkDetailMask>(bookmarkId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IBookmarkItemsMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Get<IBookmarkItemsMask>(bookmarkId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IBookmarkSubBookmarksMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Get<IBookmarkSubBookmarksMask>(bookmarkId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IBookmarkParentMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Get<IBookmarkParentMask>(bookmarkId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create_IBookmarkMask()
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateBookmarks request = new CreateBookmarks();

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Create<IBookmarkMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IBookmarkDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateBookmarks request = new CreateBookmarks();

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Create<IBookmarkDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IBookmarkLinkableMask()
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateBookmarks request = new CreateBookmarks();

         try
         {
            IEnumerable<IBookmarkLinkableMask> ret = await bookmarkService.Create<IBookmarkLinkableMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Attach<IBookmarkMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IBookmarkDetailMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Attach<IBookmarkDetailMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IBookmarkItemsMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Attach<IBookmarkItemsMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IBookmarkSubBookmarksMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Attach<IBookmarkSubBookmarksMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IBookmarkParentMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Attach<IBookmarkParentMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase()]
      //public async Task Locate()
      //{
      //   IPassportAuthentication passport = await Authenticate();

      //   BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   ITypedUriIdentifier request = new TypedUriIdentifier();

      //   try
      //   {
      //      ret = await bookmarkService.Locate(request);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("")]
      public async Task Detach_IBookmarkMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Detach<IBookmarkMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IBookmarkDetailMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Detach<IBookmarkDetailMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IBookmarkItemsMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Detach<IBookmarkItemsMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IBookmarkSubBookmarksMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Detach<IBookmarkSubBookmarksMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IBookmarkParentMask(string bookmarkId)
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Detach<IBookmarkParentMask>(bookmarkId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IBookmarkMask()
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IUpdateBookmark[] request = new UpdateBookmark[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.BulkUpdate<IBookmarkMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task BulkUpdate_IBookmarkDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         BookmarkService bookmarkService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IUpdateBookmark[] request = new UpdateBookmark[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.BulkUpdate<IBookmarkDetailMask>(request);

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