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
using ws3dx.dsxcad.core.data.impl;
using ws3dx.dsxcad.core.service;
using ws3dx.dsxcad.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class DrawingServiceTests
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

      public DrawingService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         DrawingService __drawingService = new DrawingService(_serviceUrl, _passport);
         __drawingService.Tenant = _tenant;
         __drawingService.SecurityContext = GetDefaultSecurityContext();
         return __drawingService;
      }

      [TestCase("")]
      public async Task GetVisualizationFile(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVisualizationFileMask> ret = await drawingService.GetVisualizationFile(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingMask> ret = await drawingService.Search<IXCADDrawingMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingMask> ret = await drawingService.Search<IXCADDrawingMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Search<IXCADDrawingDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Search<IXCADDrawingDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingEnterpriseDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Search<IXCADDrawingEnterpriseDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingEnterpriseDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Search<IXCADDrawingEnterpriseDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingBasicMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Search<IXCADDrawingBasicMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingBasicMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Search<IXCADDrawingBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADDrawingMask> ret = await drawingService.Get<IXCADDrawingMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Get<IXCADDrawingDetailMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Get<IXCADDrawingEnterpriseDetailMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingBasicMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Get<IXCADDrawingBasicMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlMask> ret = await drawingService.GetChangeControl(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetXCADAttributes(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADAttributesMask> ret = await drawingService.GetXCADAttributes(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFile(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAuthoringFileMask> ret = await drawingService.GetAuthoringFile(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFileDownloadTicket(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileDownloadTicket ret = await drawingService.GetAuthoringFileDownloadTicket(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task GetAuthoringFileCheckinTicket(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileCheckinTicket ret = await drawingService.GetAuthoringFileCheckinTicket(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADDrawingMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingMask> ret = await drawingService.Attach<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADDrawingDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Attach<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Attach<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADDrawingBasicMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Attach<IXCADDrawingBasicMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task ChangeControl(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await drawingService.ChangeControl(drawingId, request);

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

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ILocateXCADDrawing request = new LocateXCADDrawing();

         try
         {
            IEnumerable<IEnterpriseItemNumberMask> ret = await drawingService.Locate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADDrawingMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IEnumerable<IXCADDrawingMask> ret = await drawingService.Modify<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADDrawingDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Modify<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Modify<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADDrawingBasicMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Modify<IXCADDrawingBasicMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task GetVisualizationFileDownloadTicket(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileDownloadTicket ret = await drawingService.GetVisualizationFileDownloadTicket(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADDrawingMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingMask> ret = await drawingService.Detach<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADDrawingDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Detach<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Detach<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADDrawingBasicMask(string drawingId)
      {
         IPassportAuthentication passport = await Authenticate();

         DrawingService drawingService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Detach<IXCADDrawingBasicMask>(drawingId, request);

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