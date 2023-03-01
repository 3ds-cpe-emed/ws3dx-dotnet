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
   public class RepresentationServiceTests
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

      public RepresentationService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         RepresentationService __representationService = new RepresentationService(_serviceUrl, _passport);
         __representationService.Tenant = _tenant;
         __representationService.SecurityContext = GetDefaultSecurityContext();
         return __representationService;
      }

      [TestCase("")]
      public async Task GetChangeControl(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlMask> ret = await representationService.GetChangeControl(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADRepresentationMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADRepresentationMask> ret = await representationService.Get<IXCADRepresentationMask>(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADRepresentationDetailMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Get<IXCADRepresentationDetailMask>(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADRepresentationBasicMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Get<IXCADRepresentationBasicMask>(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationMask> ret = await representationService.Search<IXCADRepresentationMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationMask> ret = await representationService.Search<IXCADRepresentationMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Search<IXCADRepresentationDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Search<IXCADRepresentationDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationBasicMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Search<IXCADRepresentationBasicMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationBasicMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Search<IXCADRepresentationBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetXCADAttributes(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IXCADAttributesMask> ret = await representationService.GetXCADAttributes(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFile(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAuthoringFileMask> ret = await representationService.GetAuthoringFile(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFileDownloadTicket(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileDownloadTicket ret = await representationService.GetAuthoringFileDownloadTicket(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task ChangeControl(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await representationService.ChangeControl(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADRepresentationMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Attach<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADRepresentationDetailMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Attach<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADRepresentationBasicMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Attach<IXCADRepresentationBasicMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADRepresentationMask()
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Create<IXCADRepresentationMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IXCADRepresentationDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Create<IXCADRepresentationDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IXCADRepresentationBasicMask()
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Create<IXCADRepresentationBasicMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task GetAuthoringFileCheckinTicket(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileCheckinTicket ret = await representationService.GetAuthoringFileCheckinTicket(representationId, request);

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

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ILocateXCADRepresentations request = new LocateXCADRepresentations();

         try
         {
            IEnumerable<IEnterpriseItemNumberMask> ret = await representationService.Locate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADRepresentationMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Modify<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADRepresentationDetailMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Modify<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADRepresentationBasicMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Modify<IXCADRepresentationBasicMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADRepresentationMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Detach<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADRepresentationDetailMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Detach<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADRepresentationBasicMask(string representationId)
      {
         IPassportAuthentication passport = await Authenticate();

         RepresentationService representationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Detach<IXCADRepresentationBasicMask>(representationId, request);

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