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
using ws3dx.dsmfg;
using ws3dx.dsmfg.core.data.impl;
using ws3dx.dsmfg.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;
using ws3dx.dsmfg.core.service;

namespace NUnitTestProject
{
   public class MfgItemServiceTests
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

      public MfgItemService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         MfgItemService __mfgItemService = new MfgItemService(_serviceUrl, _passport);
         __mfgItemService.Tenant = _tenant;
         __mfgItemService.SecurityContext = GetDefaultSecurityContext();
         return __mfgItemService;
      }

      [TestCase("")]
      public async Task GetScopeEngItem_IScopeEngItemUtcMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeEngItemUtcMask> ret = await mfgItemService.GetScopeEngItem<IScopeEngItemUtcMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetScopeEngItem_IScopeEngItemMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeEngItemMask> ret = await mfgItemService.GetScopeEngItem<IScopeEngItemMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetScopeRequirementSpecs(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeRequirementSpecMask> ret = await mfgItemService.GetScopeRequirementSpecs(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 100, 0)]
      public async Task GetResultingEngItems_IResultingEngItemUtcMask(string mfgItemId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResultingEngItemUTCMask> ret = await mfgItemService.GetResultingEngItems<IResultingEngItemUTCMask>(mfgItemId, top, skip );

         Assert.IsNotNull(ret);
      }

      [TestCase("", 100, 0)]
      public async Task GetResultingEngItems_IResultingEngItemMask(string mfgItemId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResultingEngItemMask> ret = await mfgItemService.GetResultingEngItems<IResultingEngItemMask>(mfgItemId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("44C2728FE131000064099D210015C8CD", "A437358E00006B0C6409BC5800010224")]
      public async Task GetAssignedRequirement(string mfgItemId, string assignedRequirementId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IAssignedRequirementMask ret = await mfgItemService.GetAssignedRequirement(mfgItemId, assignedRequirementId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task GetInstanceDependency(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDependencyMask> ret = await mfgItemService.GetInstanceDependency(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IMfgItemInstanceMask(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgItemInstanceMask ret = await mfgItemService.GetInstance<IMfgItemInstanceMask>(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IMfgItemInstanceDetailMask(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgItemInstanceDetailMask ret = await mfgItemService.GetInstance<IMfgItemInstanceDetailMask>(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetScopeRequirementSpec(string mfgItemId, string requirementId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IScopeRequirementSpecMask ret = await mfgItemService.GetScopeRequirementSpec(mfgItemId, requirementId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlStatusMask> ret = await mfgItemService.GetChangeControl(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgItemDetailMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgItemDetailMask ret = await mfgItemService.Get<IMfgItemDetailMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgItemMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgItemMask ret = await mfgItemService.Get<IMfgItemMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredDetail(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredDetail> ret = await mfgItemService.GetConfiguration<IConfiguredDetail>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredBasics(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredBasics> ret = await mfgItemService.GetConfiguration<IConfiguredBasics>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetPartialScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IPartialScopeEngItemMask> ret = await mfgItemService.GetPartialScopeEngItem(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("44C2728FE131000064099D210015C8CD")]
      public async Task GetAssignedRequirements(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAssignedRequirementMask> ret = await mfgItemService.GetAssignedRequirements(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstanceImplementedEngOccurrence(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IImplementedEngOccurrenceMask ret = await mfgItemService.GetInstanceImplementedEngOccurrence(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstanceEffectivity(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IFilterableDetail> ret = await mfgItemService.GetInstanceEffectivity(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResultingEngItem_IResultingEngItemUtcMask(string mfgItemId, string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResultingEngItemUTCMask> ret = await mfgItemService.GetResultingEngItem<IResultingEngItemUTCMask>(mfgItemId, engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResultingEngItem_IResultingEngItemMask(string mfgItemId, string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IResultingEngItemMask> ret = await mfgItemService.GetResultingEngItem<IResultingEngItemMask>(mfgItemId, engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IMfgItemInstanceMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.GetInstances<IMfgItemInstanceMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IMfgItemInstanceDetailMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.GetInstances<IMfgItemInstanceDetailMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAssignmentFilters(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAssignmentFilterMask> ret = await mfgItemService.GetAssignmentFilters(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AttachChangeControl(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachChangeControl(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task ReconnectScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier request = new TypedUriIdentifier();

         try
         {
            IGenericResponse ret = await mfgItemService.ReconnectScopeEngItem(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddAssignedRequirement(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateAssignedRequirements request = new CreateAssignedRequirements();

         try
         {
            IEnumerable<IAssignedRequirementMask> ret = await mfgItemService.AddAssignedRequirement(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachPartialScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IUriIdentifier request = new UriIdentifier();

         try
         {
            IGenericResponse ret = await mfgItemService.DetachPartialScopeEngItem(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddResultingEngItem_IResultingEngItemUtcMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateResultingEngItems request = new CreateResultingEngItems();

         try
         {
            IEnumerable<IResultingEngItemUTCMask> ret = await mfgItemService.AddResultingEngItem<IResultingEngItemUTCMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddResultingEngItem_IResultingEngItemMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateResultingEngItems request = new CreateResultingEngItems();

         try
         {
            IEnumerable<IResultingEngItemMask> ret = await mfgItemService.AddResultingEngItem<IResultingEngItemMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task DetachDependencyFromInstance(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachDependencyPayload request = new DetachDependencyPayload();

         try
         {
            IGenericResponse ret = await mfgItemService.DetachDependencyFromInstance(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddExpand(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IMfgItemExpandRequestPayloadV1 request = new MfgItemExpandRequestPayloadV1();

         try
         {
            IEnumerable<IMfgItemExpandV1> ret = await mfgItemService.AddExpand(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IUriIdentifier request = new UriIdentifier();

         try
         {
            IGenericResponse ret = await mfgItemService.DetachScopeEngItem(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AttachDependencyToInstance(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachDependencyPayload request = new AttachDependencyPayload();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachDependencyToInstance(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AddInstanceReplace_IMfgItemInstanceMask(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IMfgItemInstanceReplace request = new MfgItemInstanceReplace();

         try
         {
            IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.AddInstanceReplace<IMfgItemInstanceMask>(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task AddInstanceReplace_IMfgItemInstanceDetailMask(string mfgItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IMfgItemInstanceReplace request = new MfgItemInstanceReplace();

         try
         {
            IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.AddInstanceReplace<IMfgItemInstanceDetailMask>(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachConfiguration(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgItemService.AttachConfiguration(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IMfgItemMaskDetails()
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateMfgItems request = new CreateMfgItems();

         try
         {
            IEnumerable<IMfgItemDetailMask> ret = await mfgItemService.Create<IMfgItemDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IMfgItemMask()
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewMfgItem newMfgItem = new NewMfgItem();
         newMfgItem.Attributes = new MfgItem();
         newMfgItem.Attributes.Type = MFGResourceNames.MANUFACTURING_ASSEMBLY_TYPE;
         newMfgItem.Attributes.Title = "AAA27 Mfg Assembly";
         newMfgItem.Attributes.Description = "New Mfg Assembly from Web Services";

         ICreateMfgItems request = new CreateMfgItems();
         request.Items = new List<INewMfgItem>();
         request.Items.Add(newMfgItem);

         try
         {
            IEnumerable<IMfgItemMask> ret = await mfgItemService.Create<IMfgItemMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachPartialScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier request = new TypedUriIdentifier();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachPartialScopeEngItem(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachConfiguration(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgItemService.DetachConfiguration(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachScopeEngItem(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier request = new TypedUriIdentifier();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachScopeEngItem(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IMfgItemInstanceMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateMfgInstancesRef request = new CreateMfgInstancesRef();

         try
         {
            IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.AddInstance<IMfgItemInstanceMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddInstance_IMfgItemInstanceDetailMask(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateMfgInstancesRef request = new CreateMfgInstancesRef();

         try
         {
            IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.AddInstance<IMfgItemInstanceDetailMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddScopeRequirementSpec(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateScopeRequirementSpecs request = new CreateScopeRequirementSpecs();

         try
         {
            IEnumerable<IScopeRequirementSpecMask> ret = await mfgItemService.AddScopeRequirementSpec(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate(int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ILocateMfgItemsRequest request = new LocateMfgItemsRequest();

         try
         {
            IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(top, skip, request);

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

      //   MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   ILocateMfgItems request = new LocateMfgItems();

      //   try
      //   {
      //      IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(request, top, skip);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("")]
      public async Task DetachAssignmentFilter(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachAssignmentFilterV1 request = new DetachAssignmentFilterV1();

         try
         {
            IGenericResponse ret = await mfgItemService.DetachAssignmentFilter(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase("")]
      //public async Task DetachAssignmentFilter(string mfgItemId)
      //{
      //   IPassportAuthentication passport = await Authenticate();

      //   MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   IDetachAssignmentFilter request = new DetachAssignmentFilter();

      //   try
      //   {
      //      IGenericResponse ret = await mfgItemService.DetachAssignmentFilter(request, mfgItemId);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("", "")]
      public async Task AttachImplementedEngOccurrenceToInstance(string instanceId, string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IItemOccurrence request = new ItemOccurrence();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachImplementedEngOccurrenceToInstance(instanceId, mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase("", "")]
      //public async Task AttachImplementedEngOccurrenceToInstance(string instanceId, string mfgItemId)
      //{
      //   IPassportAuthentication passport = await Authenticate();

      //   MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   IItemOccurrence request = new ItemOccurrence();

      //   try
      //   {
      //      IGenericResponse ret = await mfgItemService.AttachImplementedEngOccurrenceToInstance(request, instanceId, mfgItemId);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("", "")]
      public async Task DetachImplementedEngOccurrenceFromInstance(string instanceId, string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IItemOccurrence request = new ItemOccurrence();

         try
         {
            IGenericResponse ret = await mfgItemService.DetachImplementedEngOccurrenceFromInstance(instanceId, mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase("", "")]
      //public async Task DetachImplementedEngOccurrenceFromInstance(string instanceId, string mfgItemId)
      //{
      //   IPassportAuthentication passport = await Authenticate();

      //   MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   IItemOccurrence request = new ItemOccurrence();

      //   try
      //   {
      //      IGenericResponse ret = await mfgItemService.DetachImplementedEngOccurrenceFromInstance(request, instanceId, mfgItemId);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("")]
      public async Task AttachAssignmentFilter(string mfgItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachAssignmentFilterV1 request = new AttachAssignmentFilterV1();

         try
         {
            IGenericResponse ret = await mfgItemService.AttachAssignmentFilter(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase("")]
      //public async Task AttachAssignmentFilter(string mfgItemId)
      //{
      //   IPassportAuthentication passport = await Authenticate();

      //   MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

      //   IAttachAssignmentFilter request = new AttachAssignmentFilter();

      //   try
      //   {
      //      IGenericResponse ret = await mfgItemService.AttachAssignmentFilter(request, mfgItemId);

      //      Assert.IsNotNull(ret);
      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("item")]
      public async Task Search_Full_MfgItemMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("mass-R1132100982379-00007497", 0, 50)]
      public async Task Search_Paged_MfgItemMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, skip, top);
         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IMfgItemMask mfgItem in ret)
         {
            IMfgItemDetailMask mfgItemDetails = await mfgItemService.Get<IMfgItemDetailMask>(mfgItem.Id);

            Assert.AreEqual(mfgItem.Id, mfgItemDetails.Id);

            i++;

            if (i > 20) return;
         }
      }

      [TestCase("44C2728FE131000064099D210015C8CD", "44C2728FE131000064099D210015C8CD", "44C2728FE131000064099D210015C8CD")]
      public async Task BulkFetch_GetDefaultMask(string id1, string id2, string id3)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         string[] bulkFetchInput = new[] { id1, id2, id3 };

         IEnumerable<IMfgItemMask> ret = await mfgItemService.Bulkfetch<IMfgItemMask>(bulkFetchInput);

         Assert.IsNotNull(ret);
      }


      [TestCase("44C2728FE131000064099D210015C8CD", "44C2728FE131000064099D210015C8CD", "44C2728FE131000064099D210015C8CD")]
      public async Task BulkFetch_GetDetailMask(string id1, string id2, string id3)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgItemService mfgItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         string[] bulkFetchInput = new[] { id1, id2, id3 };

         IEnumerable<IMfgItemDetailMask> ret = await mfgItemService.Bulkfetch<IMfgItemDetailMask>(bulkFetchInput);

         Assert.IsNotNull(ret);
      }
   }
}