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
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class CheckListServiceTests
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

      public CheckListService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         CheckListService __checkListService = new CheckListService(_serviceUrl, _passport);
         __checkListService.Tenant = _tenant;
         __checkListService.SecurityContext = GetDefaultSecurityContext();
         return __checkListService;
      }

      [TestCase("")]
      public async Task GetDataCollectRows(string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ICheckListRowMask> ret = await checkListService.GetDataCollectRows(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectRow(string checkListId, string dataCollectRowId)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         ICheckListRowMask ret = await checkListService.GetDataCollectRow(checkListId, dataCollectRowId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_ICheckListMask(string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         ICheckListMask ret = await checkListService.Get<ICheckListMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_ICheckListDetailMask(string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         ICheckListDetailMask ret = await checkListService.Get<ICheckListDetailMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("check")]
      public async Task Search_Full_Mask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<ICheckListMask> ret = await checkListService.Search<ICheckListMask>(searchByFreeText);
            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("check", 0, 50)]
      public async Task Search_Paged_Mask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         CheckListService checkListService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<ICheckListMask> ret = await checkListService.Search<ICheckListMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (ICheckListMask checkList in ret)
            {
               ICheckListDetailMask checkListDetail = await checkListService.Get<ICheckListDetailMask>(checkList.Id);

               Assert.AreEqual(checkList.Id, checkListDetail.Id);

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
   }
}