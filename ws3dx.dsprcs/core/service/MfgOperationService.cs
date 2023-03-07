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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.data.collection.impl;
using ws3dx.dsprcs.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;

namespace ws3dx.dsprcs.core.service
{
   // SDK Service
   public class MfgOperationService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

      public MfgOperationService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:InstructionInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an Instruction Instance Summary: Gets an Instruction Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:InstructionInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetInstructionInstance<T>(string mfgOperationId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstructionInstanceMask), typeof(IInstructionInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:InstructionInstance/{instanceId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Manufacturing Operation Secondary Capable Resource Summary: Gets all 
      // Manufacturing Operation Secondary Capable Resource
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<ISecondaryCapableResourceMask>> GetSecondaryCapableResources(string mfgOperationId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetGroup<ISecondaryCapableResourceMask, NlsLabeledItemSet<ISecondaryCapableResourceMask>>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Secondary Capable Resource Summary: Gets a Manufacturing 
      // Operation Secondary Capable Resource
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="secondaryResourceId">
      // Description: dsprcs:SecondaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<ISecondaryCapableResourceMask> GetSecondaryCapableResource(string mfgOperationId, string secondaryResourceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource/{secondaryResourceId}";

         return await GetIndividual<ISecondaryCapableResourceMask, NlsLabeledItemSet<ISecondaryCapableResourceMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Time Constraint Summary: Gets a Manufacturing Operation 
      // Time Constraint
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="timeConstraintId">
      // Description: dsprcs:TimeConstraint object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<ITimeConstraintMask> GetTimeConstraint(string mfgOperationId, string timeConstraintId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint/{timeConstraintId}";

         return await GetIndividual<ITimeConstraintMask, NlsLabeledItemSet<ITimeConstraintMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:AssignedRequirement/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get specified assigned requirement connection for the specified manufacturing operation. 
      // Summary: Get specified assigned requirement connection for the specified manufacturing operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="PID">
      // Description: dsprcs:AssignedRequirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IAssignedRequirementMask> GetAssignedRequirement(string mfgOperationId, string PID)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AssignedRequirement/{PID}";

         return await GetIndividual<IAssignedRequirementMask, NlsLabeledItemSet<IAssignedRequirementMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an DataCollect Instance Summary: Gets an DataCollect Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:DataCollectInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetDataCollectInstance<T>(string mfgOperationId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectInstanceMask), typeof(IDataCollectInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectInstance/{instanceId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:ScopeRequirementSpec/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get specified requirement specification connection for the specified manufacturing 
      // operation. Summary: Get specified requirement specification connection for the specified 
      // manufacturing operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="PID">
      // Description: dsprcs:ScopeRequirementSpec object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IScopeRequirementSpecMask> GetScopeRequirementSpec(string mfgOperationId, string PID)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ScopeRequirementSpec/{PID}";

         return await GetIndividual<IScopeRequirementSpecMask, NlsLabeledItemSet<IScopeRequirementSpecMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the DataCollectPlan Instance Summary: Gets all the DataCollectPlan Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetDataCollectPlanInstances<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:SignOffInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an SignOff Instance Summary: Gets an SignOff Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:SignOffInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetSignOffInstance<T>(string mfgOperationId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ISignOffInstanceMask), typeof(ISignOffInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SignOffInstance/{instanceId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:AlertInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Alert Instance Summary: Gets all the Alert Instances.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetAlertInstances<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlertInstanceMask), typeof(IAlertInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AlertInstance";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Primary Capable Resource Summary: Gets a Manufacturing 
      // Operation Primary Capable Resource
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="primaryResourceId">
      // Description: dsprcs:PrimaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IPrimaryCapableResourceMask> GetPrimaryCapableResource(string mfgOperationId, string primaryResourceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

         return await GetIndividual<IPrimaryCapableResourceMask, NlsLabeledItemSet<IPrimaryCapableResourceMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs::AssignedRequirement
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the assigned Requirement connections for the specified manufacturing operation. 
      // Summary: Gets all the assigned Requirement connections for the specified manufacturing operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAssignedRequirementMask>> GetAssignedRequirements(string mfgOperationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs::AssignedRequirement";

         return await GetGroup<IAssignedRequirementMask, NlsLabeledItemSet<IAssignedRequirementMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Manufacturing Operation Primary Capable Resource Summary: Gets all Manufacturing 
      // Operation Primary Capable Resource
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IPrimaryCapableResourceMask>> GetPrimaryCapableResources(string mfgOperationId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetGroup<IPrimaryCapableResourceMask, NlsLabeledItemSet<IPrimaryCapableResourceMask>>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the effectivity of an Object instance/relationship Summary: Gets 
      // a Instance effectivity information.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable";

         return await GetGroup<IFilterableDetail, NlsLabeledItemSet<IFilterableDetail>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Manufacturing Operation Time Constraint Summary: Gets all Manufacturing 
      // Operation Time Constraint
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<ITimeConstraintMask>> GetTimeConstraints(string mfgOperationId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetGroup<ITimeConstraintMask, NlsLabeledItemSet<ITimeConstraintMask>>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:AlertInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an Alert Instance Summary: Gets an Alert Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:AlertInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetAlertInstance<T>(string mfgOperationId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlertInstanceMask), typeof(IAlertInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AlertInstance/{instanceId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an DataCollectPlan Instance Summary: Gets an DataCollectPlan Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:DataCollectInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetDataCollectPlanInstance<T>(string mfgOperationId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance/{instanceId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dsprcs:ScopeRequirementSpec
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the requirement specification connections for the specified manufacturing 
      // operation. Summary: Gets all the requirement specification connections for the specified 
      // manufacturing operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IScopeRequirementSpecMask>> GetScopeRequirementSpecs(string mfgOperationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ScopeRequirementSpec";

         return await GetGroup<IScopeRequirementSpecMask, NlsLabeledItemSet<IScopeRequirementSpecMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the DataCollect Instance Summary: Gets all the DataCollect Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetDataCollectInstances<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectInstanceMask), typeof(IDataCollectInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectInstance";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Instance Summary: Gets a Manufacturing Operation 
      // Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IMfgOperationInstanceMask> GetInstance(string mfgOperationId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

         return await GetIndividual<IMfgOperationInstanceMask, NlsLabeledItemSet<IMfgOperationInstanceMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:InstructionInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Instruction Instance Summary: Gets all the Instruction Instances.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetInstructionInstances<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstructionInstanceMask), typeof(IInstructionInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:InstructionInstance";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the Enabled Criteria and Configuration Contexts of Configured 
      // object Summary: Gets a Object Configuration information
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an Manufacturing Process Summary: Gets a Change Control of 
      // an Manufacturing Process
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgOperationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

         return await GetGroup<IChangeControlStatusMask, NlsLabeledItemSet<IChangeControlStatusMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Summary: Gets a Manufacturing Operation
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}";
         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:SignOffInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the SignOff Instance Summary: Gets all the SignOff Instance
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetSignOffInstances<T>(string mfgOperationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ISignOffInstanceMask), typeof(ISignOffInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SignOffInstance";

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{ID}/dscfg:Configured/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a list of configuration context to a single reference. Summary: 
      // Service to attach a list of configuration context to a single reference.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> AttachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/attach";

         return await PostGroup<ITypedUriIdentifier, ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control Summary: Activate the Change Control
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string mfgOperationId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivities evolution expression (XML). WARNING: Coherency 
      // between Evolution and Variant Expression are under users responsibility. Summary: Service to set 
      // the effectivities evolution expression (XML).
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> SetInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId, ISetEvolutionEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Manufacturing Operation. Summary: Creates Manufacturing Operation.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Create<T>(ICreateMfgOperation request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation";

         return await PostIndividual<T, NlsLabeledItemSet<T>, ICreateMfgOperation>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{ID}/dscfg:Configured/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a list of configuration context from a single reference. Summary: 
      // Service to detach a list of configuration context from a single reference.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> DetachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/detach";

         return await PostGroup<ITypedUriIdentifier, ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the variant effectivities. If unsetVariant service is executed under 
      // Work Under (Change Action) then it may lead to a new evolution of existing relationship. Summary: 
      // Service to unset the variant effectivities
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> UnsetInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/variant";

         return await PostIndividual<IUnitaryVariantEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivities variant expression (XML). If setVariant service is 
      // executed under Work Under (Change Action) then it may lead to a new evolution of existing 
      // relationship. WARNING: Coherency between Evolution and Variant Expression are under users 
      // responsibility. The web service will return the http 200 status code for success, partially 
      // failure and all manageable failure. errorCode and errorMessage attributes will be present in the 
      // response payload if the set variant effectivity failed for that relationship. errorMessage 
      // attribute in the response payload indicates the reason for set variant effectivity failure. If 
      // the exception occurs then the web service will completely failed with 400 http status code. 
      // Summary: Service to set the effectivities variant expression (XML).
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> SetInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId, ISetVariantEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/variant";

         return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the evolution effectivities. Summary: Service to unset the evolution 
      // effectivities.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> UnsetInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgOperation/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Enables the criteria of single reference Summary: Modifies Configuration Information 
      // of configured object
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgOperationId, IConfiguredPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured";

         return await PatchGroup<T, NlsLabeledItemSet<T>, IConfiguredPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgOperation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Operation attributes Summary: Modifies the Manufacturing 
      // Operation attributes
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string mfgOperationId, IMfgOperationPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}";

         return await PatchIndividual<T, NlsLabeledItemSet<T>, IMfgOperationPatch>(resourceURI, request);
      }
   }
}