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
using ws3dx.dsprcs.core.data.impl;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class MfgProcessServiceTests
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

		public MfgProcessService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
		{
			MfgProcessService __mfgProcessService = new MfgProcessService(_serviceUrl, _passport);
			__mfgProcessService.Tenant = _tenant;
			__mfgProcessService.SecurityContext = GetDefaultSecurityContext();
			return __mfgProcessService;
		}

		[TestCase("", "")]
		public async Task GetMfgOperationInstance(string mfgProcessId, string mfgOperationInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgOperationInstanceMask ret = await mfgProcessService.GetMfgOperationInstance(mfgProcessId, mfgOperationInstanceId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetTimeConstraint(string mfgProcessId, string timeConstraintId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         ITimeConstraintMask ret = await mfgProcessService.GetTimeConstraint(mfgProcessId, timeConstraintId);

			Assert.IsNotNull(ret);
		}

      [TestCase("", 0, 0)]
		public async Task GetPreAssignedWorkCenters(string mfgProcessId, int top, int skip)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IPreAssignedWorkCenterMask> ret = await mfgProcessService.GetPreAssignedWorkCenters(mfgProcessId, top, skip);

			Assert.IsNotNull(ret);
		}

      [TestCase("", 0, 0)]
		public async Task GetItemSpecifications(string mfgProcessId, int top, int skip)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IItemSpecificationMask> ret = await mfgProcessService.GetItemSpecifications(mfgProcessId, top, skip);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetInstance_IMfgProcessInstanceMask(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgProcessInstanceMask ret = await mfgProcessService.GetInstance<IMfgProcessInstanceMask>(mfgProcessId, mfgProcessInstanceId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetInstance_IMfgProcessInstanceDetailMask(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgProcessInstanceDetailMask ret = await mfgProcessService.GetInstance<IMfgProcessInstanceDetailMask>(mfgProcessId, mfgProcessInstanceId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task GetAssetContext(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IAssetContextMask> ret = await mfgProcessService.GetAssetContext(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetMfgOperationInstanceEffectivity(string mfgProcessId, string mfgOperationInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IFilterableDetail> ret = await mfgProcessService.GetMfgOperationInstanceEffectivity(mfgProcessId, mfgOperationInstanceId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task Get_IMfgProcessMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgProcessMask ret = await mfgProcessService.Get<IMfgProcessMask>(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task Get_IMfgProcessDetailMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgProcessDetailMask ret = await mfgProcessService.Get<IMfgProcessDetailMask>(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task Get_IMfgProcessStructureModelViewIndexMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMfgProcessStructureModelViewIndexMask ret = await mfgProcessService.Get<IMfgProcessStructureModelViewIndexMask>(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task GetConfiguration_IConfiguredDetail(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IConfiguredDetail> ret = await mfgProcessService.GetConfiguration<IConfiguredDetail>(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task GetConfiguration_IConfiguredBasics(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IConfiguredBasics> ret = await mfgProcessService.GetConfiguration<IConfiguredBasics>(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task GetChangeControl(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IChangeControlStatusMask> ret = await mfgProcessService.GetChangeControl(mfgProcessId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetPrimaryCapableResource(string mfgProcessId, string primaryResourceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IPrimaryCapableResourceMask ret = await mfgProcessService.GetPrimaryCapableResource(mfgProcessId, primaryResourceId);

			Assert.IsNotNull(ret);
		}

      [TestCase("", 0, 0)]
		public async Task GetPrimaryCapableResources(string mfgProcessId, int top, int skip)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IPrimaryCapableResourceMask> ret = await mfgProcessService.GetPrimaryCapableResources(mfgProcessId, top, skip);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetInstanceEffectivity(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<IFilterableDetail> ret = await mfgProcessService.GetInstanceEffectivity(mfgProcessId, mfgProcessInstanceId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetPreAssignedWorkCenter(string mfgProcessId, string workCenterId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IPreAssignedWorkCenterMask ret = await mfgProcessService.GetPreAssignedWorkCenter(mfgProcessId, workCenterId);

			Assert.IsNotNull(ret);
		}

		[TestCase("", 0, 0)]
		public async Task GetTimeConstraints(string mfgProcessId, int top, int skip)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
			IEnumerable<ITimeConstraintMask> ret = await mfgProcessService.GetTimeConstraints(mfgProcessId, top, skip);

			Assert.IsNotNull(ret);
		}

		[TestCase("", "")]
		public async Task GetItemSpecification(string mfgProcessId, string itemSpecificationId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IItemSpecificationMask ret = await mfgProcessService.GetItemSpecification(mfgProcessId, itemSpecificationId);

			Assert.IsNotNull(ret);
		}

		[TestCase("")]
		public async Task AttachItemSpecification(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ICreateItemSpecificationRequest request = new CreateItemSpecificationRequest();

			try
			{
				IEnumerable<IItemSpecificationScopeMask> ret = await mfgProcessService.AttachItemSpecification(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task UnsetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			try
			{
				IUnitaryEvolutionEffectivity ret = await mfgProcessService.UnsetMfgOperationInstanceEvolutionEffectivity(mfgProcessId, mfgOperationInstanceId);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
		public async Task AttachChangeControl(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			IAddEmpty request = new AddEmpty();

			try
			{
				IGenericResponse ret = await mfgProcessService.AttachChangeControl(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
		public async Task AddMfgOperationInstance_IMfgOperationInstanceMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ICreateMfgOperationInstancesRefObject request = new CreateMfgOperationInstancesRefObject();

			try
			{
				IEnumerable<IMfgOperationInstanceMask> ret = await mfgProcessService.AddMfgOperationInstance<IMfgOperationInstanceMask>(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
		[TestCase("")]
		public async Task AddMfgOperationInstance_IMfgOperationInstanceDetailMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ICreateMfgOperationInstancesRefObject request = new CreateMfgOperationInstancesRefObject();

			try
			{
				IEnumerable<IMfgOperationInstanceDetailMask> ret = await mfgProcessService.AddMfgOperationInstance<IMfgOperationInstanceDetailMask>(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase()]
		public async Task BulkFetch_IMfgProcessMask()
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         string[] request = new string[] { };

         try
			{
				IEnumerable<IMfgProcessMask> ret = await mfgProcessService.BulkFetch<IMfgProcessMask>(request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
		[TestCase()]
		public async Task BulkFetch_IMfgProcessDetailMask()
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         string[] request = new string[] { };

         try
			{
				IEnumerable<IMfgProcessDetailMask> ret = await mfgProcessService.BulkFetch<IMfgProcessDetailMask>(request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase(50, 0)]
      public async Task Locate(int top, int skip)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ILocateMfgProcessRequest request = new LocateMfgProcessRequest();

			try
			{
				IEnumerable<IMfgProcessLocateUTCMask> ret = await mfgProcessService.Locate(top, skip, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
      public async Task AddExpand(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			IMfgProcessExpandRequestPayloadV1 request = new MfgProcessExpandRequestPayloadV1();

			try
			{
            IEnumerable<IMfgProcessExpandMaskV1> ret = await mfgProcessService.AddExpand(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
		
		[TestCase("", "")]
		public async Task SetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

			try
			{
				IUnitaryEvolutionEffectivity ret = await mfgProcessService.SetMfgOperationInstanceEvolutionEffectivity(mfgProcessId, mfgOperationInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task AddInstanceReplace_IMfgProcessInstanceMask(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			IMfgProcessInstanceReplace request = new MfgProcessInstanceReplace();

			try
			{
				IMfgProcessInstanceMask ret = await mfgProcessService.AddInstanceReplace<IMfgProcessInstanceMask>(mfgProcessId, mfgProcessInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
		[TestCase("", "")]
		public async Task AddInstanceReplace_IMfgProcessInstanceDetailMask(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			IMfgProcessInstanceReplace request = new MfgProcessInstanceReplace();

			try
			{
				IMfgProcessInstanceDetailMask ret = await mfgProcessService.AddInstanceReplace<IMfgProcessInstanceDetailMask>(mfgProcessId, mfgProcessInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
		public async Task AttachConfiguration(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

			try
			{
				ITypedUriIdentifierResources ret = await mfgProcessService.AttachConfiguration(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task SetInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

			try
			{
				IUnitaryEvolutionEffectivity ret = await mfgProcessService.SetInstanceEvolutionEffectivity(mfgProcessId, mfgProcessInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

      [TestCase(MFGResourceNames.WORKPLAN_TYPE, "AAA27 Process Name")]
      public async Task Create_IMfgProcessMask(string _processType, string _processName)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewMfgProcess process = new NewMfgProcess();
         process.Attributes = new MfgProcess();
         process.Attributes.Type = _processType;
         process.Attributes.Title = _processName;

			ICreateMfgProcess request = new CreateMfgProcess();
         request.Items = new List<INewMfgProcess>() { process };


			try
			{
				IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Create<IMfgProcessMask>(request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
      [TestCase(MFGResourceNames.WORKPLAN_TYPE, "AAA27 Workplan Process Name")]
      public async Task Create_IMfgProcessDetailMask(string _processType, string _processName)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewMfgProcess process = new NewMfgProcess();
         process.Attributes = new MfgProcess();
         process.Attributes.Type = _processType;
         process.Attributes.Title = _processName;

			ICreateMfgProcess request = new CreateMfgProcess();
         request.Items = new List<INewMfgProcess>() { process };

			try
			{
				IEnumerable<IMfgProcessDetailMask> ret = await mfgProcessService.Create<IMfgProcessDetailMask>(request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
		public async Task DetachConfiguration(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

			try
			{
				ITypedUriIdentifierResources ret = await mfgProcessService.DetachConfiguration(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task SetMfgOperationInstanceVariantEffectivity(string mfgProcessId, string mfgOperationInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ISetVariantEffectivities request = new SetVariantEffectivities();

			try
			{
				IUnitaryVariantEffectivity ret = await mfgProcessService.SetMfgOperationInstanceVariantEffectivity(mfgProcessId, mfgOperationInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task SetInstanceVariantEffectivity(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ISetVariantEffectivities request = new SetVariantEffectivities();

			try
			{
				IUnitaryVariantEffectivity ret = await mfgProcessService.SetInstanceVariantEffectivity(mfgProcessId, mfgProcessInstanceId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("")]
		public async Task AddInstance_IMfgProcessInstanceMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ICreateMfgProcessInstance request = new CreateMfgProcessInstance();

			try
			{
				IEnumerable<IMfgProcessInstanceMask> ret = await mfgProcessService.AddInstance<IMfgProcessInstanceMask>(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}
		[TestCase("")]
		public async Task AddInstance_IMfgProcessInstanceDetailMask(string mfgProcessId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			ICreateMfgProcessInstance request = new CreateMfgProcessInstance();

			try
			{
				IEnumerable<IMfgProcessInstanceDetailMask> ret = await mfgProcessService.AddInstance<IMfgProcessInstanceDetailMask>(mfgProcessId, request);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

		[TestCase("", "")]
		public async Task UnsetInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
		{
			IPassportAuthentication passport = await Authenticate();

			MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

			try
			{
				IUnitaryEvolutionEffectivity ret = await mfgProcessService.UnsetInstanceEvolutionEffectivity(mfgProcessId, mfgProcessInstanceId);

				Assert.IsNotNull(ret);
			}
			catch (HttpResponseException _ex)
			{
				string errorMessage = await _ex.GetErrorMessage();
				Assert.Fail(errorMessage);
			}
		}

      [TestCase("process")]
      public async Task Search_Full_Mask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
		
         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Search<IMfgProcessMask>(searchByFreeText);
            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
		
      [TestCase("process", 0, 50)]
      public async Task Search_Paged_Mask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgProcessService mfgProcessService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
		
         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Search<IMfgProcessMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);
		
            int i = 0;
            foreach (IMfgProcessMask process in ret)
            {
               IMfgProcessDetailMask processDetail = await mfgProcessService.Get<IMfgProcessDetailMask>(process.Id);

               Assert.AreEqual(process.Id, processDetail.Id);
		
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