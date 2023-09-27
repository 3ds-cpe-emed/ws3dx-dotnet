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
using ws3dx.dsmfg.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsmfg.core.service
{
   // SDK Service
   public class MfgItemService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsmfg/";

      public MfgItemService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsmfg:MfgItem/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IMfgItemMask) };
      }

      protected override string GetSearchSkipParamName()
      {
         return "$skip";
      }

      protected override string GetSearchTopParamName()
      {
         return "$top";
      }

      protected override string GetSearchCriteriaParamName()
      {
         return "$searchStr";
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery)
      {
         return await SearchCollection<T>("member", searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await SearchCollection<T>("member", searchQuery, _skip, _top);
      }
      #endregion

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets the scoped Engineering Item from the Manufacturing reference dsmfg:MfgItem 
      // Summary: Gets a Scoped Engineering Item of an dsmfg:MfgItem
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetScopeEngItem<T>(string mfgItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IScopeEngItemUtcMask), typeof(IScopeEngItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the requirement specification connections for the specified manufacturing 
      // item. Summary: Gets all the requirement specification connections for the specified manufacturing 
      // item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IScopeRequirementSpecMask>> GetScopeRequirementSpecs(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec";

         return await GetCollectionFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the resulting Engineering Item from the Manufacturing reference dsmfg:MfgItem. 
      // Summary: Gets all the Resulting Engineering Items
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
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
      public async Task<IEnumerable<T>> GetResultingEngItems<T>(string mfgItemId, int top, int skip)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemUtcMask), typeof(IResultingEngItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get specified assigned requirement connection for the specified manufacturing item. 
      // Summary: Get specified assigned requirement connection for the specified manufacturing item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="requirementId">
      // Description: dsmfg:AssignedRequirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IAssignedRequirementMask> GetAssignedRequirement(string mfgItemId, string requirementId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement/{requirementId}";

         return await GetIndividualFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to get the Manufacturing Instance direct dependencies. Summary: Service to 
      // get the Manufacturing Instance direct dependencies.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem Parent object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance Successor object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IDependencyMask>> GetInstanceDependency(string mfgItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency";

         return await GetCollectionFromResponseMemberProperty<IDependencyMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Item Instance Summary: Gets a Manufacturing Item Instance
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetInstance<T>(string mfgItemId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get specified requirement specification connection for the specified manufacturing 
      // item. Summary: Get specified requirement specification connection for the specified manufacturing 
      // item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="requirementId">
      // Description: dsmfg:ScopeRequirementSpec object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IScopeRequirementSpecMask> GetScopeRequirementSpec(string mfgItemId, string requirementId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec/{requirementId}";

         return await GetIndividualFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an dsmfg:MfgItem Summary: Gets a Change Control of an 
      // dsmfg:MfgItem
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Item Summary: Gets a Manufacturing Item
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string mfgItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemDetailMask), typeof(IMfgItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the Enabled Criteria and Configuration Contexts of Configured 
      // object Summary: Gets a Object Configuration information
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets the Partial scoped Engineering Item from the Manufacturing reference dsmfg:MfgItem 
      // Summary: Gets a Partial Scoped Engineering Item of an dsmfg:MfgItem
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IPartialScopeEngItemMask>> GetPartialScopeEngItem(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem";

         return await GetCollectionFromResponseMemberProperty<IPartialScopeEngItemMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the assigned Requirement connections for the specified manufacturing item. 
      // Summary: Gets all the assigned Requirement connections for the specified manufacturing item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAssignedRequirementMask>> GetAssignedRequirements(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement";

         return await GetCollectionFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an Implemented Engineering Item Instances Occurrence Summary: Gets an Implemented 
      // Engineering Item Instances Occurrence
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IImplementedEngOccurrenceMask> GetInstanceImplementedEngOccurrence(string mfgItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence";

         return await GetIndividualFromResponseMemberProperty<IImplementedEngOccurrenceMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dscfg:Filterable
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the effectivity of an Object instance/relationship Summary: Gets 
      // a Instance effectivity information.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dscfg:Filterable";

         return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets specific resulting Engineering Items from the Manufacturing reference dsmfg:MfgItem. 
      // Summary: Gets specific Resulting Engineering Items
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="engItemId">
      // Description: dsmfg:ResultingEngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetResultingEngItem<T>(string mfgItemId, string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemUtcMask), typeof(IResultingEngItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:MfgItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Manufacturing Item Instances Summary: Gets all the Manufacturing Item 
      // Instances
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetInstances<T>(string mfgItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Assignment filters from the Manufacturing reference dsmfg:MfgItem. 
      // Summary: Gets all the Assignment filters from the Manufacturing reference dsmfg:MfgItem.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAssignmentFilterMask>> GetAssignmentFilters(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter";

         return await GetCollectionFromResponseMemberProperty<IAssignmentFilterMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control Summary: Activate the Change Control
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string mfgItemId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/set/reconnect
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to reconnect a Scope Engineering Item to a Manufacturing Item reference. 
      //  Reconnect Scope is supported only for 'Provide' Mfg Item types. Summary: Service to reconnect a 
      // Scope Engineering Item to a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> ReconnectScopeEngItem(string mfgItemId, ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/set/reconnect";

         return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates assigned requirement link between manufacturing Item and specified requirement. 
      // Summary: Creates assigned requirement link between manufacturing Item and specified requirement.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IAssignedRequirementMask>> AddAssignedRequirement(string mfgItemId, ICreateAssignedRequirements request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement";

         return await PostCollectionFromResponseMemberProperty<IAssignedRequirementMask, ICreateAssignedRequirements>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a Scope Engineering Item from a Manufacturing Item reference. 
      // Summary: Service to detach a Scope Engineering Item from a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachPartialScopeEngItem(string mfgItemId, IUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem/detach";

         return await PostIndividual<IGenericResponse, IUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Resulting Engineering Item Link to an Engineering Item. Summary: Creates 
      // Resulting Engineering Item Link to an Engineering Item
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddResultingEngItem<T>(string mfgItemId, ICreateResultingEngItems request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemUtcMask), typeof(IResultingEngItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem";

         return await PostCollectionFromResponseMemberProperty<T, ICreateResultingEngItems>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach dependency constraint from a specified Manufacturing Item instance. 
      // Summary: Service to detach dependency constraint from a specified Manufacturing Item instance.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem Parent object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance Successor object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachDependencyFromInstance(string mfgItemId, string instanceId, IDetachDependencyPayload request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency/detach";

         return await PostIndividual<IGenericResponse, IDetachDependencyPayload>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/expand
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Expand specified Manufacturing Item dsmfg:MfgItem to retrive all its references and 
      // instances which are Public types only.
      //  API Works only for Indexed Data only.
      //  Number of Paths or Occurrences in response is restricted to 10000 only. Summary: Expand specified 
      // Manufacturing Item dsmfg:MfgItem to retrive all its references and instances.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMfgItemExpandV1>> Expand(string mfgItemId, IMfgItemExpandRequestPayloadV1 request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/expand";

         return await PostCollectionFromResponseMemberProperty<IMfgItemExpandV1, IMfgItemExpandRequestPayloadV1>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a Scope Engineering Item from a Manufacturing Item reference. 
      // Summary: Service to detach a Scope Engineering Item from a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachScopeEngItem(string mfgItemId, IUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/detach";

         return await PostIndividual<IGenericResponse, IUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach dependency constraint to a specified Manufacturing Item instance. 
      // Summary: Service to attach dependency constraint to a specified Manufacturing Item instance.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem Parent object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance Successor object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachDependencyToInstance(string mfgItemId, string instanceId, IAttachDependencyPayload request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency/attach";

         return await PostIndividual<IGenericResponse, IAttachDependencyPayload>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/replace
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Replace the Manufacturing Item Instance Summary: Replace the Manufacturing Item 
      // Instance
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstanceReplace<T>(string mfgItemId, string instanceId, IMfgItemInstanceReplace request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/replace";

         return await PostCollectionFromResponseMemberProperty<T, IMfgItemInstanceReplace>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dscfg:Configured/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a list of configuration context to a single reference. Summary: 
      // Service to attach a list of configuration context to a single reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured/attach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Manufacturing Items. Summary: Creates Manufacturing Items.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateMfgItems request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemDetailMask), typeof(IMfgItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem";

         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgItems>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a Partial Scope Engineering Item to a Manufacturing Item reference. 
      // Summary: Service to attach a Partial Scope Engineering Item to a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachPartialScopeEngItem(string mfgItemId, ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem/attach";

         return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dscfg:Configured/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a list of configuration context from a single reference. Summary: 
      // Service to detach a list of configuration context from a single reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured/detach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/bulkfetch
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets multiple Manufacturing Items which are Indexed.
      //  API Works only for Indexed Data only. 
      //  The customer attributes or enterprise extension attributes are returned only with default sixw 
      // mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. 
      // Summary: Gets multiple Manufacturing Items which are Indexed.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Bulkfetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemDetailMask), typeof(IMfgItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/bulkfetch";

         return await PostCollectionFromResponseMemberProperty<T, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a Scope Engineering Item to a Manufacturing Item reference. Summary: 
      // Service to attach a Scope Engineering Item to a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachScopeEngItem(string mfgItemId, ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/attach";

         return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:MfgItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Manufacturing Item Instance to an Manufacturing Item. Summary: Create 
      // Manufacturing Item Instance.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstance<T>(string mfgItemId, ICreateMfgInstancesRef request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgInstancesRef>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates requirement specification link between manufacturing Item and specified 
      // requirement. Summary: Creates requirement specification link between manufacturing Item and 
      // specified requirement.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IScopeRequirementSpecMask>> AddScopeRequirementSpec(string mfgItemId, ICreateScopeRequirementSpecs request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec";

         return await PostCollectionFromResponseMemberProperty<IScopeRequirementSpecMask, ICreateScopeRequirementSpecs>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Item Instance attributes Summary: Modifies the Manufacturing 
      // Item Instance attributes
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateInstance<T>(string mfgItemId, string instanceId, IMfgItemInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IMfgItemInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsmfg:MfgItem/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Enables the criteria of single reference Summary: Modifies Configuration Information 
      // of configured object
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgItemId, IConfiguredPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured";

         return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsmfg:MfgItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Item attributes Summary: Modifies the Manufacturing Item 
      // attributes
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string mfgItemId, IMfgItemPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemDetailMask), typeof(IMfgItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

         return await PatchIndividual<T, IMfgItemPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Resulting Eng Item Link attributes Summary: Modifies the Resulting Eng 
      // Item Link attributes
      // <param name="engItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:ResultingEngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateResultingEngItem<T>(string engItemId, string mfgItemId, IResultingEngItemPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemUtcMask), typeof(IResultingEngItemMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

         return await PatchIndividualFromResponseMemberProperty<T, IResultingEngItemPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsmfg:MfgItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete the Manufacturing Item Summary: Delete the Manufacturing Item
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete the specified requirement specification Link. Summary: Delete the specified 
      // requirement specification Link.
      // <param name="requirementId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:ScopeRequirementSpec object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteScopeRequirementSpec(string requirementId, string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec/{requirementId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsmfg:MfgItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deactivate the Change Control. Summary: Deactivate the Change Control.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachChangeControl(string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete the Resulting EngItem Link to Engineering Iteml. Summary: Delete the Resulting 
      // EngItem Link to Engineering Item
      // <param name="engItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:ResultingEngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteResultingEngItem(string engItemId, string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete the specified assigned requirement Link. Summary: Delete the specified assigned 
      // requirement Link.
      // <param name="requirementId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:AssignedRequirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteAssignedRequirement(string requirementId, string mfgItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement/{requirementId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Provides the capability to locate or find set of Manufacturing Items dsmfg:MfgItem 
      // and navigate to target types based on the matched search criteria and other filter criteria. 
      //  Following are the capabilities provided:- 
      //  1. Locate Mfg Item matching the search criteria 'searchCriteria' alone. 
      //  2. Locate Mfg Item matching the search criteria 'searchCriteria' and filter using query param 
      // $top and $skip. 
      //  3. Locate Mfg Item matching both the search criteria 'searchCriteria' and list of Mfg Items Object 
      // references passed in the request payload.
      //  Additionally once the Manufacturing item is located based on matching criteria we return list of 
      // Manufacturing item references and also return its associated objects defined in 'navigateTo'. By 
      // default it will return where used Manufacturing item instances if exists. Summary: Locate or find 
      // set of Manufacturing Items dsmfg:MfgItem based on the matched search criteria and other filter 
      // criteria.
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ILocateMfgItemsResponse>> Locate(int top, int skip, ILocateMfgItemsRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/locate";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await PostCollectionFromResponseMemberProperty<ILocateMfgItemsResponse, ILocateMfgItemsRequest>(resourceURI, request, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Provides the capability to locate or find set of Manufacturing Items dsmfg:MfgItem 
      // and navigate to target types based on the matched search criteria and other filter criteria. 
      //  Following are the capabilities provided:- 
      //  1. Locate Mfg Item matching the search criteria 'searchCriteria' alone. 
      //  2. Locate Mfg Item matching the search criteria 'searchCriteria' and filter using query param 
      // $top and $skip. 
      //  3. Locate Mfg Item matching both the search criteria 'searchCriteria' and list of Mfg Items Object 
      // references passed in the request payload.
      //  Additionally once the Manufacturing item is located based on matching criteria we return list of 
      // Manufacturing item references and also return its associated objects defined in 'navigateTo'. By 
      // default it will return where used Manufacturing item instances if exists. Summary: Locate or find 
      // set of Manufacturing Items dsmfg:MfgItem based on the matched search criteria and other filter 
      // criteria.
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ILocateMfgItemsResponse>> Locate(int top, int skip, ILocateMfgItems request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/locate";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await PostCollectionFromResponseMemberProperty<ILocateMfgItemsResponse, ILocateMfgItems>(resourceURI, request, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach AssignmentFilter Link (list of engineering Occurrences) from an 
      // single Manufacturing Item. Summary: Service to detach AssignmentFilter Link (list of engineering 
      // occurrences) from an single Manufacturing Item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachAssignmentFilter(string mfgItemId, IDetachAssignmentFilterV1 request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/detach";

         return await PostIndividual<IGenericResponse, IDetachAssignmentFilterV1>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach AssignmentFilter Link (list of engineering Occurrences) from an 
      // single Manufacturing Item. Summary: Service to detach AssignmentFilter Link (list of engineering 
      // occurrences) from an single Manufacturing Item.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachAssignmentFilter(string mfgItemId, IDetachAssignmentFilter request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/detach";

         return await PostIndividual<IGenericResponse, IDetachAssignmentFilter>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach implemented Engineering Item Occurrence to an single Manufacturing 
      // Item instance. Summary: Service to attach implemented Engineering Item Occurrence to an single 
      // Manufacturing Item instance.
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachImplementedEngOccurrenceToInstance(string instanceId, string mfgItemId, IItemOccurrence request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence/attach";

         return await PostIndividual<IGenericResponse, IItemOccurrence>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach implemented Engineering Item Occurrence from an single Manufacturing 
      // Item instance. Summary: Service to detach implemented Engineering Item Occurrence from an single 
      // Manufacturing Item instance.
      // <param name="instanceId">
      // Description: dsmfg:MfgItemInstance object ID
      // </param>
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachImplementedEngOccurrenceFromInstance(string instanceId, string mfgItemId, IItemOccurrence request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence/detach";

         return await PostIndividual<IGenericResponse, IItemOccurrence>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach assignment filters (list of engineering occurrences) to a Manufacturing 
      // Item reference. Summary: Service to attach assignment filters (list of engineering occurrences) 
      // to a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachAssignmentFilter(string mfgItemId, IAttachAssignmentFilterV1 request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/attach";

         return await PostIndividual<IGenericResponse, IAttachAssignmentFilterV1>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach assignment filters (list of engineering occurrences) to a Manufacturing 
      // Item reference. Summary: Service to attach assignment filters (list of engineering occurrences) 
      // to a Manufacturing Item reference.
      // <param name="mfgItemId">
      // Description: dsmfg:MfgItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachAssignmentFilter(string mfgItemId, IAttachAssignmentFilter request)
      {
         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/attach";

         return await PostIndividual<IGenericResponse, IAttachAssignmentFilter>(resourceURI, request);
      }
   }
}