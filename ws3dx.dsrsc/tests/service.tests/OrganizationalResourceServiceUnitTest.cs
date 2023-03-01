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
using ws3dx.dsrsc.core.data.impl;
using ws3dx.dsrsc.core.service;
using ws3dx.dsrsc.data;
using ws3dx.shared.data;

namespace NUnitTestProject
{
   public class OrganizationalResourceServiceTests
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

      public OrganizationalResourceService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         OrganizationalResourceService __organizationalResourceService = new OrganizationalResourceService(_serviceUrl, _passport);
         __organizationalResourceService.Tenant = _tenant;
         __organizationalResourceService.SecurityContext = GetDefaultSecurityContext();
         return __organizationalResourceService;
      }

      [TestCase("", 0, 0)]
      public async Task GetResourceItemInstances_IResourceItemInstanceMask(string orgResourceId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResourceItemInstanceMask> ret = await organizationalResourceService.GetResourceItemInstances<IResourceItemInstanceMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetResourceItemInstances_IResourceItemInstanceDetailMask(string orgResourceId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResourceItemInstanceDetailMask> ret = await organizationalResourceService.GetResourceItemInstances<IResourceItemInstanceDetailMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetScopeLinks(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeLinkMask> ret = await organizationalResourceService.GetScopeLinks(orgResourceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance(string organizationalResourceId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOrganizationalResourceInstanceMask> ret = await organizationalResourceService.GetInstance(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetWorkerInstance_IWorkerInstanceMask(string organizationalResourceId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IWorkerInstanceMask> ret = await organizationalResourceService.GetWorkerInstance<IWorkerInstanceMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetWorkerInstance_IWorkerInstanceDetailMask(string organizationalResourceId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IWorkerInstanceDetailMask> ret = await organizationalResourceService.GetWorkerInstance<IWorkerInstanceDetailMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResourceItemInstance_IResourceItemInstanceMask(string organizationalResourceId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResourceItemInstanceMask> ret = await organizationalResourceService.GetResourceItemInstance<IResourceItemInstanceMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResourceItemInstance_IResourceItemInstanceDetailMask(string organizationalResourceId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResourceItemInstanceDetailMask> ret = await organizationalResourceService.GetResourceItemInstance<IResourceItemInstanceDetailMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IOrganizationalResourceMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOrganizationalResourceMask> ret = await organizationalResourceService.Get<IOrganizationalResourceMask>(orgResourceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IOrganizationalResourceDetailMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOrganizationalResourceDetailMask> ret = await organizationalResourceService.Get<IOrganizationalResourceDetailMask>(orgResourceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetImplementLink(string orgResourceId, string implementLinkId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IImplementLinkMask> ret = await organizationalResourceService.GetImplementLink(orgResourceId, implementLinkId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetInstances(string orgResourceId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOrganizationalResourceInstanceMask> ret = await organizationalResourceService.GetInstances(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetWorkerInstances_IWorkerInstanceMask(string orgResourceId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IWorkerInstanceMask> ret = await organizationalResourceService.GetWorkerInstances<IWorkerInstanceMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetWorkerInstances_IWorkerInstanceDetailMask(string orgResourceId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IWorkerInstanceDetailMask> ret = await organizationalResourceService.GetWorkerInstances<IWorkerInstanceDetailMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create_IOrganizationalResourceMask()
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateOrganizationalResources request = new CreateOrganizationalResources();

         try
         {
            IEnumerable<IOrganizationalResourceMask> ret = await organizationalResourceService.Create<IOrganizationalResourceMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IOrganizationalResourceDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateOrganizationalResources request = new CreateOrganizationalResources();

         try
         {
            IEnumerable<IOrganizationalResourceDetailMask> ret = await organizationalResourceService.Create<IOrganizationalResourceDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateWorkerInstance_IWorkerInstanceMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateWorkerInstances request = new CreateWorkerInstances();

         try
         {
            IEnumerable<IWorkerInstanceMask> ret = await organizationalResourceService.CreateWorkerInstance<IWorkerInstanceMask>(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task CreateWorkerInstance_IWorkerInstanceDetailMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateWorkerInstances request = new CreateWorkerInstances();

         try
         {
            IEnumerable<IWorkerInstanceDetailMask> ret = await organizationalResourceService.CreateWorkerInstance<IWorkerInstanceDetailMask>(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateResourceItemInstance_IResourceItemInstanceMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateResourceItemInstances request = new CreateResourceItemInstances();

         try
         {
            IEnumerable<IResourceItemInstanceMask> ret = await organizationalResourceService.CreateResourceItemInstance<IResourceItemInstanceMask>(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task CreateResourceItemInstance_IResourceItemInstanceDetailMask(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateResourceItemInstances request = new CreateResourceItemInstances();

         try
         {
            IEnumerable<IResourceItemInstanceDetailMask> ret = await organizationalResourceService.CreateResourceItemInstance<IResourceItemInstanceDetailMask>(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateInstance(string orgResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateOrganizationalResourceInstances request = new CreateOrganizationalResourceInstances();

         try
         {
            IEnumerable<IOrganizationalResourceInstanceMask> ret = await organizationalResourceService.CreateInstance(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate()
      {
         IPassportAuthentication passport = await Authenticate();

         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IBulkUpdateOrganizationalResource[] request = new BulkUpdateOrganizationalResource[] { };

         try
         {
            IGenericResponse ret = await organizationalResourceService.BulkUpdate(request);

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