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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseArrayProperty<ISecondaryCapableResourceMask>(resourceURI, "member", queryParams: queryParams);
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

         return await GetIndividualFromResponseMemberProperty<ISecondaryCapableResourceMask>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<ITimeConstraintMask>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
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

         return await GetCollectionFromResponseArrayProperty<IPrimaryCapableResourceMask>(resourceURI, "member", queryParams: queryParams);
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

         return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get the dsprcs:ItemSpecification link under an operation. Summary: Get the 
      // dsprcs:ItemSpecification link under an operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="itemSpecificationId">
      // Description: dsprcs:ItemSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IItemSpecificationMask> GetItemSpecification(string mfgOperationId, string itemSpecificationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification/{itemSpecificationId}";

         return await GetIndividualFromResponseMemberProperty<IItemSpecificationMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all dsprcs:ItemSpecification link under operation. Summary: Gets all 
      // dsprcs:ItemSpecification link under operation.
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
      public async Task<IEnumerable<IItemSpecificationMask>> GetItemSpecifications(string mfgOperationId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<IItemSpecificationMask>(resourceURI, queryParams: queryParams);
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

         return await GetCollectionFromResponseMemberProperty<ITimeConstraintMask>(resourceURI, queryParams: queryParams);
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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<IMfgOperationInstanceMask>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
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

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
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

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
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
      public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/attach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
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
      // (POST) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Primary Capable Resource link to an Manufacturing Operation. Summary: Create 
      // Primary Capable Resource link to an Manufacturing Operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IPrimaryCapableResourceMask>> AttachPrimaryCapableResource(string mfgOperationId, ICreatePrimaryCapableResourceRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource";

         return await PostCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask, ICreatePrimaryCapableResourceRequest>(resourceURI, request);
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

         return await PostIndividualFromResponseMemberProperty<T, ICreateMfgOperation>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/bulkfetch
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets multiple Manufacturing Operations which are Indexed. 
      //  API Works only for Indexed Data only. 
      //  The customer attributes or enterprise extension attributes are returned only with default sixw 
      // mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. 
      // Summary: Gets multiple Manufacturing Operations which are Indexed.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/bulkfetch";

         return await PostBulkCollection<T, string[]>(resourceURI, request);

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
      public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/detach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Primary Capable Resource to an Manufacturing Operation. Summary: Create 
      // Secondary Capable Resource to an Manufacturing Operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ISecondaryCapableResourceMask>> AttachSecondaryCapableResource(string mfgOperationId, ICreateSecondaryCapableResourceRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource";

         return await PostCollectionFromResponseMemberProperty<ISecondaryCapableResourceMask, ICreateSecondaryCapableResourceRequest>(resourceURI, request);
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
      // (POST) dsprcs:MfgOperation/{ID}/dsprcs:MfgOperationInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Manufacturing Operation Instance under an Manufacturing Operation. Summary: 
      // Create Manufacturing Operation Instance under an Manufacturing Operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstance<T>(string mfgOperationId, ICreateMfgOperationInstancesRefObject request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance";


         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgOperationInstancesRefObject>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates dsprcs:ItemSpecification implement link under operation. Summary: Creates 
      // dsprcs:ItemSpecification implement link under operation.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object PID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IItemSpecificationMask>> AttachItemSpecification(string mfgOperationId, IImplementLinkCreateRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification";

         return await PostCollectionFromResponseMemberProperty<IItemSpecificationMask, IImplementLinkCreateRequest>(resourceURI, request);
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
      // (PATCH) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Operation Instance attributes under MfgOperation Summary: 
      // Modifies the Manufacturing Operation Instance attributes under MfgOperation
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperationobject ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateInstance<T>(string mfgOperationId, string mfgOperationInstanceId, IMfgOperationInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

         return await PatchCollectionFromResponseMemberProperty<T, IMfgOperationInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the dsprcs:ItemSpecification Implement link attributes under operation 
      // Summary: Modifies the dsprcs:ItemSpecification Implement link attributes under operation
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="itemSpecificationId">
      // Description: dsprcs:ItemSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IItemSpecificationMask> UpdateItemSpecification(string mfgOperationId, string itemSpecificationId, IItemSpecificationPatch request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification/{itemSpecificationId}";

         return await PatchIndividualFromResponseMemberProperty<IItemSpecificationMask, IItemSpecificationPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies a Manufacturing Operation Secondary Capable Resource attributes Summary: 
      // Modifies a Manufacturing Operation Secondary Capable Resource attributes
      // <param name="secondaryResourceId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationId">
      // Description: dsprcs:SecondaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ISecondaryCapableResourceMask> UpdateSecondaryCapableResource(string mfgOperationId, string secondaryResourceId, ISecondaryCapableResourcePatch request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource/{secondaryResourceId}";

         return await PatchIndividualFromResponseMemberProperty<ISecondaryCapableResourceMask, ISecondaryCapableResourcePatch>(resourceURI, request);
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

         return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
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

         return await PatchIndividualFromResponseMemberProperty<T, IMfgOperationPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies a Manufacturing Operation Primary Capable Resource Summary: Modifies a 
      // Manufacturing Operation Primary Capable Resource attributes
      // <param name="primaryResourceId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // <param name="mfgOperationId">
      // Description: dsprcs:PrimaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IPrimaryCapableResourceMask> UpdatePrimaryCapableResource(string mfgOperationId, string primaryResourceId, IPrimaryCapableResourcePatch request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

         return await PatchIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask, IPrimaryCapableResourcePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsprcs:MfgOperation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deactivate the Change Control. Summary: Deactivate the Change Control.
      // <param name="mfgOperationId">
      // Description: dsprcs:MfgOperation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachChangeControl(string mfgOperationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}