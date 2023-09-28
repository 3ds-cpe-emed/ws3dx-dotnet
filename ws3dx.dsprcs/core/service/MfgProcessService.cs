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
using ws3dx.utils.search;

namespace ws3dx.dsprcs.core.service
{
   // SDK Service
   public class MfgProcessService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

      public MfgProcessService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsprcs:MfgProcess/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IMfgProcessMask) };
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
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Operation Instance Summary: Gets a Manufacturing Operation 
      // Instance
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IMfgOperationInstanceMask> GetMfgOperationInstance(string mfgProcessId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

         return await GetIndividualFromResponseMemberProperty<IMfgOperationInstanceMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Process Time Constraint Summary: Gets a Manufacturing Process 
      // Time Constraint
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="timeConstraintId">
      // Description: dsprcs:TimeConstraint object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<ITimeConstraintMask> GetTimeConstraint(string mfgProcessId, string timeConstraintId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint/{timeConstraintId}";

         return await GetIndividualFromResponseMemberProperty<ITimeConstraintMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all preassigned work center link of the manufacturing process. Summary: Gets 
      // all preassigned work center link of the manufacturing process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
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
      public async Task<IEnumerable<IPreAssignedWorkCenterMask>> GetPreAssignedWorkCenters(string mfgProcessId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<IPreAssignedWorkCenterMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all item specification of the manufacturing process. Summary: Gets all item 
      // specification of the manufacturing process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
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
      public async Task<IEnumerable<IItemSpecificationMask>> GetItemSpecifications(string mfgProcessId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<IItemSpecificationMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Process Instance Summary: Gets a Manufacturing Process Instance
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcessobject ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetInstance<T>(string mfgProcessId, string mfgProcessInstanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:AssetContext
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get the reference to the asset context of the manufacturing process. Summary: Get 
      // the reference to the asset context of the manufacturing process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAssetContextMask>> GetAssetContext(string mfgProcessId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext";

         return await GetCollectionFromResponseMemberProperty<IAssetContextMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the effectivity of an Object instance/relationship Summary: Gets 
      // a Instance effectivity information.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IFilterableDetail>> GetMfgOperationInstanceEffectivity(string mfgProcessId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable";

         return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Process Summary: Gets a Manufacturing Process
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string mfgProcessId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask), typeof(IMfgProcessStructureModelViewIndexMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the Enabled Criteria and Configuration Contexts of Configured 
      // object Summary: Gets a Object Configuration information
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgProcessId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an Manufacturing Process Summary: Gets a Change Control of 
      // an Manufacturing Process
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgProcessId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturing Process Primary Capable Resource Summary: Gets a Manufacturing 
      // Process Primary Capable Resource
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="primaryResourceId">
      // Description: dsprcs:PrimaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IPrimaryCapableResourceMask> GetPrimaryCapableResource(string mfgProcessId, string primaryResourceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

         return await GetIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Manufacturing Process Primary Capable Resource Summary: Gets all Manufacturing 
      // Process Primary Capable Resource
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
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
      public async Task<IEnumerable<IPrimaryCapableResourceMask>> GetPrimaryCapableResources(string mfgProcessId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the effectivity of an Object instance/relationship Summary: Gets 
      // a Instance effectivity information.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgProcessId, string mfgProcessInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable";

         return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get the preassigned work center link of the manufacturing process. Summary: Get the 
      // preassigned work center link of the manufacturing process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="workCenterId">
      // Description: dsprcs:PreAssignedWorkCenter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IPreAssignedWorkCenterMask> GetPreAssignedWorkCenter(string mfgProcessId, string workCenterId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter/{workCenterId}";

         return await GetIndividualFromResponseMemberProperty<IPreAssignedWorkCenterMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Manufacturing Process Time Constraint. Summary: Gets all Manufacturing 
      // Process Time Constraint.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
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
      public async Task<IEnumerable<ITimeConstraintMask>> GetTimeConstraints(string mfgProcessId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<ITimeConstraintMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get the item specification of the manufacturing process. Summary: Get the item 
      // specification of the manufacturing process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="itemSpecificationId">
      // Description: dsprcs:ItemSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IItemSpecificationMask> GetItemSpecification(string mfgProcessId, string itemSpecificationId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification/{itemSpecificationId}";

         return await GetIndividualFromResponseMemberProperty<IItemSpecificationMask>(resourceURI);
      }


      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the evolution effectivities. Summary: Service to unset the evolution 
      // effectivities.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> UnsetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control Summary: Activate the Change Control
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string mfgProcessId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dsprcs:MfgOperationInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Manufacturing Operation Instance under an Manufacturing Process. Summary: 
      // Create Manufacturing Operation Instance under an Manufacturing Process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddMfgOperationInstance<T>(string mfgProcessId, ICreateMfgOperationInstancesRefObject request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgOperationInstancesRefObject>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/bulkfetch
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets multiple Manufacturing Processes which are Indexed. 
      //  API Works only for Indexed Data only. 
      //  The customer attributes or enterprise extension attributes are returned only with default sixw 
      // mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. 
      // Summary: Gets multiple Manufacturing Processes which are Indexed.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/bulkfetch";

         return await PostBulkCollection<T, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dsprcs:AssetContext/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a dsprcs:AssetContextto a single reference. Summary: Service to 
      // attach a dsprcs:AssetContext to a single reference.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachAssetContext(string mfgProcessId, ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext/attach";

         return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dsprcs:AssetContext/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a dsprcs:AssetContext from a single reference. Summary: Service to 
      // detach a dsprcs:AssetContext from a single reference.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachAssetContext(string mfgProcessId, ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext/detach";

         return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Provides the capability to locate or find set of Manufacturing Processes dsprcs:MfgProcess 
      // and navigate to target types based on the matched search criteria and other filter criteria. 
      //  Following are the capabilities provided:-
      //  1. Locate Mfg Process matching the search criteria 'searchCriteria' alone.
      //  2. Locate Mfg Process matching the search criteria 'searchCriteria' and filter using query param 
      // $top and $skip.
      //  3. Locate Mfg Process matching both the search criteria 'searchCriteria' and list of Mfg Process 
      // Object references 'ObjectReferences' passed in the request payload.
      //  Additionally once the Manufacturing process is located based on matching criteria then response 
      // contains list of valid Manufacturing process references and also return its associated objects 
      // if defined in 'navigateTo' and 'navigateFrom'.
      //  The supported types in 'navigateTo' is 'dsprcs:MfgProcessInstance' and 'dsrsc:ScopeLink'.
      //  And the supported types in 'navigateFrom' are dsprcs:PrimaryCapableResource, and dsprcs:ItemSpecification 
      // Summary: Locate or find set of Manufacturing Process dsprcs:MfgProcess based on the matched search 
      // criteria and other filter criteria.
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 10.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMfgProcessLocateUTCMask>> Locate(int top, int skip, ILocateMfgProcessRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/locate";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await PostCollectionFromResponseMemberProperty<IMfgProcessLocateUTCMask, ILocateMfgProcessRequest>(resourceURI, request, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/expand
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Expand specified Manufacturing Process dsprcs:MfgProcess to retrive all its references 
      // and instances which are Public types only.
      //  API Works only for Indexed Data only.
      //  Number of Paths or Occurrences in response is restricted to 10000 only. Summary: Expand specified 
      // Manufacturing Process dsprcs:MfgProcess to retrive all its references and instances.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Expand<T>(string mfgProcessId, IMfgProcessExpandRequestPayloadV1 request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessExpandMaskV1), typeof(IMfgProcessExpandMaskDetailV1) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/expand";

         return await PostCollectionFromResponseMemberProperty<T, IMfgProcessExpandRequestPayloadV1>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivities evolution expression (XML). WARNING: Coherency 
      // between Evolution and Variant Expression are under users responsibility. Summary: Service to set 
      // the effectivities evolution expression (XML).
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> SetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId, ISetEvolutionEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/replace
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Replace the Manufacturing Process Instance Summary: Replace the Manufacturing Process 
      // Instance
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcessobject ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> ReplaceInstance<T>(string mfgProcessId, string mfgProcessInstanceId, IMfgProcessInstanceReplace request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/replace";

         return await PostIndividualFromResponseMemberProperty<T, IMfgProcessInstanceReplace>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create PreAssignedWorkCenter Link. Summary: Create PreAssignedWorkCenter Link.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IPreAssignedWorkCenterMask>> AttachPreAssignedWorkCenter(string mfgProcessId, ICreatePreAssignedWorkCenterRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter";

         return await PostCollectionFromResponseMemberProperty<IPreAssignedWorkCenterMask, ICreatePreAssignedWorkCenterRequest>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dscfg:Configured/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a list of configuration context to a single reference. Summary: 
      // Service to attach a list of configuration context to a single reference.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgProcessId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured/attach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Primary Capable Resource link to an Manufacturing Process. Summary: Create 
      // Primary Capable Resource link to an Manufacturing Process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IPrimaryCapableResourceMask>> AttachPrimaryCapableResource(string mfgProcessId, ICreatePrimaryCapableResourceRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource";

         return await PostCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask, ICreatePrimaryCapableResourceRequest>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/set/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivities evolution expression (XML). WARNING: Coherency 
      // between Evolution and Variant Expression are under users responsibility. Summary: Service to set 
      // the effectivities evolution expression (XML).
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> SetInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId, ISetEvolutionEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/set/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Manufacturing Process. Summary: Creates Manufacturing Process.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateMfgProcess request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess";

         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgProcess>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dscfg:Configured/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a list of configuration context from a single reference. Summary: 
      // Service to detach a list of configuration context from a single reference.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgProcessId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured/detach";

         return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/variant
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
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> SetMfgOperationInstanceVariantEffectivity(string mfgProcessId, string mfgOperationInstanceId, ISetVariantEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/variant";

         return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/set/variant
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
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> SetInstanceVariantEffectivity(string mfgProcessId, string mfgProcessInstanceId, ISetVariantEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/set/variant";

         return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{ID}/dsprcs:MfgProcessInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Manufacturing Process Instance to an Manufacturing Process. Summary: Create 
      // Manufacturing Process Instance.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstance<T>(string mfgProcessId, ICreateMfgProcessInstance request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateMfgProcessInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/unset/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the evolution effectivities. Summary: Service to unset the evolution 
      // effectivities.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryEvolutionEffectivity> UnsetInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/unset/evolution";

         return await PostIndividual<IUnitaryEvolutionEffectivity, NlsLabeledItemSet<IUnitaryEvolutionEffectivity>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Process Instance attributes Summary: Modifies the 
      // Manufacturing Process Instance attributes
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcessobject ID
      // </param>
      // <param name="mfgProcessInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateInstance<T>(string mfgProcessId, string mfgProcessInstanceId, IMfgProcessInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IMfgProcessInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the dsprcs:ItemSpecification Implement link attributes under process Summary: 
      // Modifies the dsprcs:ItemSpecification Implement link attributes under process
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="itemSpecificationId">
      // Description: dsprcs:ItemSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IItemSpecificationMask>> UpdateItemSpecification(string mfgProcessId, string itemSpecificationId, IItemSpecificationPatch request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification/{itemSpecificationId}";

         return await PatchCollectionFromResponseMemberProperty<IItemSpecificationMask, IItemSpecificationPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Enables the criteria of single reference Summary: Modifies Configuration Information 
      // of configured object
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgProcessId, IConfiguredPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured";

         return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Process attributes Summary: Modifies the Manufacturing 
      // Process attributes
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string mfgProcessId, IMfgProcessPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}";

         return await PatchIndividual<T, IMfgProcessPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource/{PID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies a Manufacturing Process Primary Capable Resource Summary: Modifies a 
      // Manufacturing Process Primary Capable Resource attributes
      // <param name="primaryResourceId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgProcessId">
      // Description: dsprcs:PrimaryCapableResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IPrimaryCapableResourceMask> UpdatePrimaryCapableResource(string primaryResourceId, string mfgProcessId, IPrimaryCapableResourcePatch request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

         return await PatchIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask, IPrimaryCapableResourcePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturing Operation Instance attributes under MfgProcess Summary: 
      // Modifies the Manufacturing Operation Instance attributes under MfgProcess
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcessobject ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgOperationInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateMfgOperationInstance<T>(string mfgProcessId, string mfgOperationInstanceId, IMfgOperationInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IMfgOperationInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsprcs:MfgProcess/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deactivate the Change Control. Summary: Deactivate the Change Control.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachChangeControl(string mfgProcessId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates dsprcs:ItemSpecification scope Link or implement link under process. Summary: 
      // Creates dsprcs:ItemSpecification scope Link or implement link under process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object PID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IItemSpecificationMask>> AttachItemSpecification(string mfgProcessId, IScopeItemCreateRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

         return await PostCollectionFromResponseMemberProperty<IItemSpecificationMask, IScopeItemCreateRequest>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates dsprcs:ItemSpecification scope Link or implement link under process. Summary: 
      // Creates dsprcs:ItemSpecification scope Link or implement link under process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object PID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IItemSpecificationMask>> AttachItemSpecification(string mfgProcessId, IScopeItemWithContextCreateRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

         return await PostCollectionFromResponseMemberProperty<IItemSpecificationMask, IScopeItemWithContextCreateRequest>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates dsprcs:ItemSpecification scope Link or implement link under process. Summary: 
      // Creates dsprcs:ItemSpecification scope Link or implement link under process.
      // <param name="mfgProcessId">
      // Description: dsprcs:MfgProcess object PID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IItemSpecificationMask>> AttachItemSpecification(string mfgProcessId, IImplementLinkCreateRequest request)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

         return await PostCollectionFromResponseMemberProperty<IItemSpecificationMask, IImplementLinkCreateRequest>(resourceURI, request);
      }
   }
}