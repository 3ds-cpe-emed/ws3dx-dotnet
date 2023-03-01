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
using ws3dx.dsprcs.core.data.impl;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;

namespace NUnitTestProject
{
   public class MfgOperationServiceTests
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

      public MfgOperationService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         MfgOperationService __mfgOperationService = new MfgOperationService(_serviceUrl, _passport);
         __mfgOperationService.Tenant = _tenant;
         __mfgOperationService.SecurityContext = GetDefaultSecurityContext();
         return __mfgOperationService;
      }

      [TestCase("", "")]
      public async Task GetInstructionInstance_IInstructionInstanceMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IInstructionInstanceMask> ret = await mfgOperationService.GetInstructionInstance<IInstructionInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstructionInstance_IInstructionInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IInstructionInstanceDetailMask> ret = await mfgOperationService.GetInstructionInstance<IInstructionInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetSecondaryCapableResources(string mfgOperationId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISecondaryCapableResourceMask> ret = await mfgOperationService.GetSecondaryCapableResources(mfgOperationId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetSecondaryCapableResource(string mfgOperationId, string secondaryResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISecondaryCapableResourceMask> ret = await mfgOperationService.GetSecondaryCapableResource(mfgOperationId, secondaryResourceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetTimeConstraint(string mfgOperationId, string timeConstraintId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ITimeConstraintMask> ret = await mfgOperationService.GetTimeConstraint(mfgOperationId, timeConstraintId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetAssignedRequirement(string mfgOperationId, string pID)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAssignedRequirementMask> ret = await mfgOperationService.GetAssignedRequirement(mfgOperationId, pID);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectInstance_IDataCollectInstanceMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectInstanceMask> ret = await mfgOperationService.GetDataCollectInstance<IDataCollectInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectInstance_IDataCollectInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectInstanceDetailMask> ret = await mfgOperationService.GetDataCollectInstance<IDataCollectInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetScopeRequirementSpec(string mfgOperationId, string pID)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeRequirementSpecMask> ret = await mfgOperationService.GetScopeRequirementSpec(mfgOperationId, pID);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetDataCollectPlanInstances_IDataCollectPlanInstanceMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectPlanInstanceMask> ret = await mfgOperationService.GetDataCollectPlanInstances<IDataCollectPlanInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetDataCollectPlanInstances_IDataCollectPlanInstanceDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectPlanInstanceDetailMask> ret = await mfgOperationService.GetDataCollectPlanInstances<IDataCollectPlanInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetSignOffInstance_ISignOffInstanceMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISignOffInstanceMask> ret = await mfgOperationService.GetSignOffInstance<ISignOffInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetSignOffInstance_ISignOffInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISignOffInstanceDetailMask> ret = await mfgOperationService.GetSignOffInstance<ISignOffInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAlertInstances_IAlertInstanceMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlertInstanceMask> ret = await mfgOperationService.GetAlertInstances<IAlertInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAlertInstances_IAlertInstanceDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlertInstanceDetailMask> ret = await mfgOperationService.GetAlertInstances<IAlertInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetPrimaryCapableResource(string mfgOperationId, string primaryResourceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IPrimaryCapableResourceMask> ret = await mfgOperationService.GetPrimaryCapableResource(mfgOperationId, primaryResourceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetAssignedRequirements(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAssignedRequirementMask> ret = await mfgOperationService.GetAssignedRequirements(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetPrimaryCapableResources(string mfgOperationId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IPrimaryCapableResourceMask> ret = await mfgOperationService.GetPrimaryCapableResources(mfgOperationId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstanceEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IFilterableDetail> ret = await mfgOperationService.GetInstanceEffectivity(mfgOperationId, mfgOperationInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetTimeConstraints(string mfgOperationId, int top, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ITimeConstraintMask> ret = await mfgOperationService.GetTimeConstraints(mfgOperationId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetAlertInstance_IAlertInstanceMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlertInstanceMask> ret = await mfgOperationService.GetAlertInstance<IAlertInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetAlertInstance_IAlertInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlertInstanceDetailMask> ret = await mfgOperationService.GetAlertInstance<IAlertInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectPlanInstance_IDataCollectPlanInstanceMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectPlanInstanceMask> ret = await mfgOperationService.GetDataCollectPlanInstance<IDataCollectPlanInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectPlanInstance_IDataCollectPlanInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectPlanInstanceDetailMask> ret = await mfgOperationService.GetDataCollectPlanInstance<IDataCollectPlanInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetScopeRequirementSpecs(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IScopeRequirementSpecMask> ret = await mfgOperationService.GetScopeRequirementSpecs(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetDataCollectInstances_IDataCollectInstanceMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectInstanceMask> ret = await mfgOperationService.GetDataCollectInstances<IDataCollectInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetDataCollectInstances_IDataCollectInstanceDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDataCollectInstanceDetailMask> ret = await mfgOperationService.GetDataCollectInstances<IDataCollectInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMfgOperationInstanceMask> ret = await mfgOperationService.GetInstance(mfgOperationId, mfgOperationInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstructionInstances_IInstructionInstanceMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IInstructionInstanceMask> ret = await mfgOperationService.GetInstructionInstances<IInstructionInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstructionInstances_IInstructionInstanceDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IInstructionInstanceDetailMask> ret = await mfgOperationService.GetInstructionInstances<IInstructionInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredDetail(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredDetail> ret = await mfgOperationService.GetConfiguration<IConfiguredDetail>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredBasics(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredBasics> ret = await mfgOperationService.GetConfiguration<IConfiguredBasics>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IChangeControlStatusMask> ret = await mfgOperationService.GetChangeControl(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgOperationMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMfgOperationMask> ret = await mfgOperationService.Get<IMfgOperationMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgOperationDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMfgOperationDetailMask> ret = await mfgOperationService.Get<IMfgOperationDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetSignOffInstances_ISignOffInstanceMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISignOffInstanceMask> ret = await mfgOperationService.GetSignOffInstances<ISignOffInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetSignOffInstances_ISignOffInstanceDetailMask(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<ISignOffInstanceDetailMask> ret = await mfgOperationService.GetSignOffInstances<ISignOffInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AttachConfiguration(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgOperationService.AttachConfiguration(mfgOperationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachChangeControl(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await mfgOperationService.AttachChangeControl(mfgOperationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task SetInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

         try
         {
            IUnitaryEvolutionEffectivity ret = await mfgOperationService.SetInstanceEvolutionEffectivity(mfgOperationId, mfgOperationInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IMfgOperationMask()
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateMfgOperation request = new CreateMfgOperation();

         try
         {
            IEnumerable<IMfgOperationMask> ret = await mfgOperationService.Create<IMfgOperationMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IMfgOperationDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateMfgOperation request = new CreateMfgOperation();

         try
         {
            IEnumerable<IMfgOperationDetailMask> ret = await mfgOperationService.Create<IMfgOperationDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachConfiguration(string mfgOperationId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgOperationService.DetachConfiguration(mfgOperationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IUnitaryVariantEffectivity ret = await mfgOperationService.UnsetInstanceVariantEffectivity(mfgOperationId, mfgOperationInstanceId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task SetInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ISetVariantEffectivities request = new SetVariantEffectivities();

         try
         {
            IUnitaryVariantEffectivity ret = await mfgOperationService.SetInstanceVariantEffectivity(mfgOperationId, mfgOperationInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         MfgOperationService mfgOperationService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IUnitaryEvolutionEffectivity ret = await mfgOperationService.UnsetInstanceEvolutionEffectivity(mfgOperationId, mfgOperationInstanceId);

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