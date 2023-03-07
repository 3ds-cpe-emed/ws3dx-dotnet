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
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class PartServiceTests
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

      public PartService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         PartService __partService = new PartService(_serviceUrl, _passport);
         __partService.Tenant = _tenant;
         __partService.SecurityContext = GetDefaultSecurityContext();
         return __partService;
      }

      [TestCase("")]
      public async Task GetVisualizationFile(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVisualizationFileMask> ret = await partService.GetVisualizationFile(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetEnterpriseItemNumber(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnterpriseItemNumberMask ret = await partService.GetEnterpriseItemNumber(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IXCADPartMask ret = await partService.Get<IXCADPartMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartBasicMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IXCADPartBasicMask ret = await partService.Get<IXCADPartBasicMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartEnterpriseDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IXCADPartEnterpriseDetailMask ret = await partService.Get<IXCADPartEnterpriseDetailMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IXCADPartDetailMask ret = await partService.Get<IXCADPartDetailMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlMask> ret = await partService.GetChangeControl(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("solidworks", 0, 50)]
      public async Task Search_Paged_IXCADPartMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartMask> ret = await partService.Search<IXCADPartMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartMask> ret = await partService.Search<IXCADPartMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("solidworks", 0, 50)]
      public async Task Search_Paged_IXCADPartBasicMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartBasicMask> ret = await partService.Search<IXCADPartBasicMask>(searchByFreeText, skip, top);

         int i = 0;

         foreach (IXCADPartBasicMask partFound in ret)
         {
            IXCADPartDetailMask part = await partService.Get<IXCADPartDetailMask>(partFound.Id);

            Assert.AreEqual(partFound.Id, part.Id);

            i++;

            if (i > 20) return;
         }

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartBasicMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartBasicMask> ret = await partService.Search<IXCADPartBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADPartEnterpriseDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartEnterpriseDetailMask> ret = await partService.Search<IXCADPartEnterpriseDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartEnterpriseDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartEnterpriseDetailMask> ret = await partService.Search<IXCADPartEnterpriseDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADPartDetailMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartDetailMask> ret = await partService.Search<IXCADPartDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartDetailMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartDetailMask> ret = await partService.Search<IXCADPartDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetXCADAttributes(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IXCADAttributesMask ret = await partService.GetXCADAttributes(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFile(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAuthoringFileMask> ret = await partService.GetAuthoringFile(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAuthoringFileDownloadTicket(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileDownloadTicket ret = await partService.GetAuthoringFileDownloadTicket(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task ChangeControl(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await partService.ChangeControl(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADPartMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartMask ret = await partService.Attach<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADPartBasicMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartBasicMask ret = await partService.Attach<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADPartEnterpriseDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Attach<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Attach_IXCADPartDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartDetailMask ret = await partService.Attach<IXCADPartDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task GetAuthoringFileCheckinTicket(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileCheckinTicket ret = await partService.GetAuthoringFileCheckinTicket(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADPartMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartMask ret = await partService.Modify<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADPartBasicMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartBasicMask ret = await partService.Modify<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADPartEnterpriseDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Modify<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Modify_IXCADPartDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartDetailMask ret = await partService.Modify<IXCADPartDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task GetVisualizationFileDownloadTicket(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IFileDownloadTicket ret = await partService.GetVisualizationFileDownloadTicket(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddEnterpriseItemNumber(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEnterpriseItemNumber request = new EnterpriseItemNumber();

         try
         {
            IEnterpriseItemNumberMask ret = await partService.AddEnterpriseItemNumber(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADPartMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartMask ret = await partService.Detach<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADPartBasicMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartBasicMask ret = await partService.Detach<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADPartEnterpriseDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Detach<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task Detach_IXCADPartDetailMask(string partId)
      {
         IPassportAuthentication passport = await Authenticate();

         PartService partService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartDetailMask ret = await partService.Detach<IXCADPartDetailMask>(partId, request);

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