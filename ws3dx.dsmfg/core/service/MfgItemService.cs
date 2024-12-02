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

namespace ws3dx.dsmfg.service
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

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Item
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string mfgItemId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemMask), typeof(IMfgItemDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete the Manufacturing Item
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> Delete(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Item attributes.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsmfg:MfgItem/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Update<T>(string mfgItemId, IMfgItemPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemMask), typeof(IMfgItemDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}";

            return await PatchCollectionFromResponseMemberProperty<T, IMfgItemPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Manufacturing Items.
        ///  Only 1 item could be created per call 'on cloud'.
        ///  Only 50 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateMfgItems request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemMask), typeof(IMfgItemDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem";

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgItems>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Locate or find set of Manufacturing Items dsmfg:MfgItem based on the matched search criteria and
        /// other filter criteria.
        /// Provides the capability to locate or find set of Manufacturing Items dsmfg:MfgItem and navigate
        /// to target types based on the matched search criteria and other filter criteria.
        ///  Following are the capabilities provided:-
        ///  1. Locate Mfg Item matching the search criteria 'searchCriteria' alone.
        ///  2. Locate Mfg Item matching the search criteria 'searchCriteria' and filter using query param
        /// $top and $skip.
        ///  3. Locate Mfg Item matching both the search criteria 'searchCriteria' and list of Mfg Items Object
        /// references passed in the request payload.
        ///  Additionally once the Manufacturing item is located based on matching criteria we return list of
        /// Manufacturing item references and also return its associated objects defined in 'navigateTo'. By
        /// default it will return where used Manufacturing item instances if exists.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/locate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ILocateMfgItemsResponse>> Locate(int top, int skip, ILocateMfgItemsRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/locate";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await PostCollectionFromResponseMemberProperty<ILocateMfgItemsResponse, ILocateMfgItemsRequest>(resourceURI, request, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Locate or find set of Manufacturing Items dsmfg:MfgItem based on the matched search criteria and
        /// other filter criteria.
        /// Provides the capability to locate or find set of Manufacturing Items dsmfg:MfgItem and navigate
        /// to target types based on the matched search criteria and other filter criteria.
        ///  Following are the capabilities provided:-
        ///  1. Locate Mfg Item matching the search criteria 'searchCriteria' alone.
        ///  2. Locate Mfg Item matching the search criteria 'searchCriteria' and filter using query param
        /// $top and $skip.
        ///  3. Locate Mfg Item matching both the search criteria 'searchCriteria' and list of Mfg Items Object
        /// references passed in the request payload.
        ///  Additionally once the Manufacturing item is located based on matching criteria we return list of
        /// Manufacturing item references and also return its associated objects defined in 'navigateTo'. By
        /// default it will return where used Manufacturing item instances if exists.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/locate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ILocateMfgItemsResponse>> Locate(int top, int skip, ILocateMfgItems request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/locate";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await PostCollectionFromResponseMemberProperty<ILocateMfgItemsResponse, ILocateMfgItems>(resourceURI, request, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Expand specified Manufacturing Item dsmfg:MfgItem to retrive all its references, instances and
        /// other content types which are Public types only.
        /// Expand specified Manufacturing Item dsmfg:MfgItem to retrive all its references and instances
        /// which are Public types only.
        ///  API Works only for Indexed Data only.
        ///  Number of Paths or Occurrences in response is restricted to 10000 only.
        ///  Other content types returned are HistorizationLinkRefRef,DELFmiMfgSubstituteCnx,DELMfgResponsibilityCnx
        /// ,MfgProcessAlternate only using using detailed mask
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/expand
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<object>> Expand(string mfgItemId, IMfgItemExpandRequestPayloadV1 request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/expand";

            return await PostCollectionNoMaskFromResponseMemberProperty<object, IMfgItemExpandRequestPayloadV1>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets multiple Manufacturing Items which are Indexed.
        ///  API Works only for Indexed Data only.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/bulkfetch
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemMask), typeof(IMfgItemDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/bulkfetch";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$mva", "true" }
            };

            return await PostBulkCollection<T, string[]>(resourceURI, request, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Manufacturing Item Instances
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:MfgItemInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetInstances<T>(string mfgItemId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Manufacturing Item Instance to an Manufacturing Item.
        ///  Only 1 item could be created per call 'on cloud'.
        ///  Only 50 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:MfgItemInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Work Under Change Authoring
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddInstance<T>(string mfgItemId, ICreateMfgInstancesRef request, string changeAuthoringContext = null)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgInstancesRef>(resourceURI, request, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Item Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetInstance<T>(string mfgItemId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Item Instance attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateInstance<T>(string mfgItemId, string instanceId, IMfgItemInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}";

            return await PatchCollectionFromResponseMemberProperty<T, IMfgItemInstancePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Replace the Manufacturing Item Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/replace
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Work Under Change Authoring
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddInstanceReplace<T>(string mfgItemId, string instanceId, IMfgItemInstanceReplace request, string changeAuthoringContext = null)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/replace";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostCollectionFromResponseMemberProperty<T, IMfgItemInstanceReplace>(resourceURI, request, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Resulting Engineering Items
        /// Gets all the resulting Engineering Item from the Manufacturing reference dsmfg:MfgItem.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetResultingEngItems<T>(string mfgItemId, int? top = null, int? skip = null)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemMask), typeof(IResultingEngItemUtcMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem";

            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (top != null) {
                queryParams.Add("$top", top.ToString());
            }

            if (skip != null) {
                queryParams.Add("$skip", skip.ToString());
            }

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Resulting Engineering Item Link to an Engineering Item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddResultingEngItem<T>(string mfgItemId, ICreateResultingEngItems request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemMask), typeof(IResultingEngItemUtcMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem";

            return await PostCollectionFromResponseMemberProperty<T, ICreateResultingEngItems>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets specific resulting Engineering Items from the Manufacturing reference dsmfg:MfgItem.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="engItemId">
        /// dsmfg:ResultingEngItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetResultingEngItem<T>(string mfgItemId, string engItemId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemMask), typeof(IResultingEngItemUtcMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete the Resulting EngItem Link to Engineering Iteml.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="engItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:ResultingEngItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteResultingEngItem(string engItemId, string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Resulting Eng Item Link attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsmfg:MfgItem/{ID}/dsmfg:ResultingEngItem/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="engItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:ResultingEngItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateResultingEngItem<T>(string engItemId, string mfgItemId, IResultingEngItemPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResultingEngItemMask), typeof(IResultingEngItemUtcMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ResultingEngItem/{engItemId}";

            return await PatchCollectionFromResponseMemberProperty<T, IResultingEngItemPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Scoped Engineering Item of an dsmfg:MfgItem
        /// Gets the scoped Engineering Item from the Manufacturing reference dsmfg:MfgItem
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetScopeEngItem<T>(string mfgItemId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IScopeEngItemMask), typeof(IScopeEngItemUtcMask) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a Scope Engineering Item to a Manufacturing Item reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachScopeEngItem(string mfgItemId, IAttachScopedEngItem request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/attach";

            return await PostIndividual<IGenericResponse, IAttachScopedEngItem>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a Scope Engineering Item from a Manufacturing Item reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachScopeEngItem(string mfgItemId, IDetachScopedEngItem request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/detach";

            return await PostIndividual<IGenericResponse, IDetachScopedEngItem>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to reconnect a Scope Engineering Item to a Manufacturing Item reference.
        ///  Reconnect Scope is supported only for 'Provide' Mfg Item types.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeEngItem/set/reconnect
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> ReconnectScopeEngItem(string mfgItemId, IAttachScopedEngItem request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeEngItem/set/reconnect";

            return await PostIndividual<IGenericResponse, IAttachScopedEngItem>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Assignment filters from the Manufacturing reference dsmfg:MfgItem.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAssignmentFilterMask>> GetAssignmentFilters(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter";

            return await GetCollectionFromResponseMemberProperty<IAssignmentFilterMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach assignment filters (list of engineering occurrences) to a Manufacturing Item
        /// reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachAssignmentFilter(string mfgItemId, IAttachAssignmentFilterV1 request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/attach";

            return await PostIndividual<IGenericResponse, IAttachAssignmentFilterV1>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach assignment filters (list of engineering occurrences) to a Manufacturing Item
        /// reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachAssignmentFilter(string mfgItemId, IAttachAssignmentFilter request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/attach";

            return await PostIndividual<IGenericResponse, IAttachAssignmentFilter>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach AssignmentFilter Link (list of engineering Occurrences) from an single Manufacturing
        /// Item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachAssignmentFilter(string mfgItemId, IDetachAssignmentFilterV1 request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/detach";

            return await PostIndividual<IGenericResponse, IDetachAssignmentFilterV1>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach AssignmentFilter Link (list of engineering Occurrences) from an single Manufacturing
        /// Item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignmentFilter/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachAssignmentFilter(string mfgItemId, IDetachAssignmentFilter request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignmentFilter/detach";

            return await PostIndividual<IGenericResponse, IDetachAssignmentFilter>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an Implemented Engineering Item Instances Occurrence
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IImplementedEngOccurrenceMask>> GetInstanceImplementedEngOccurrence(string mfgItemId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence";

            return await GetCollectionFromResponseMemberProperty<IImplementedEngOccurrenceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach implemented Engineering Item Occurrence to an single Manufacturing Item instance.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachImplementedEngOccurrenceToInstance(string instanceId, string mfgItemId, IItemOccurrence request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence/attach";

            return await PostIndividual<IGenericResponse, IItemOccurrence>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach implemented Engineering Item Occurrence from an single Manufacturing Item instance.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:ImplementedEngOccurrence/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachImplementedEngOccurrenceFromInstance(string instanceId, string mfgItemId, IItemOccurrence request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:ImplementedEngOccurrence/detach";

            return await PostIndividual<IGenericResponse, IItemOccurrence>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Partial Scoped Engineering Item of an dsmfg:MfgItem
        /// Gets the Partial scoped Engineering Item from the Manufacturing reference dsmfg:MfgItem
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPartialScopeEngItemMask>> GetPartialScopeEngItem(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem";

            return await GetCollectionFromResponseMemberProperty<IPartialScopeEngItemMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a Partial Scope Engineering Item to a Manufacturing Item reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachPartialScopeEngItem(string mfgItemId, ITypedUriIdentifier request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem/attach";

            return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a Scope Engineering Item from a Manufacturing Item reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:PartialScopeEngItem/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachPartialScopeEngItem(string mfgItemId, IUriIdentifier request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:PartialScopeEngItem/detach";

            return await PostIndividual<IGenericResponse, IUriIdentifier>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified assigned requirement connection for the specified manufacturing item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="requirementId">
        /// dsmfg:AssignedRequirement object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IAssignedRequirementMask> GetAssignedRequirement(string mfgItemId, string requirementId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement/{requirementId}";

            return await GetIndividualFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete the specified assigned requirement Link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="requirementId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:AssignedRequirement object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteAssignedRequirement(string requirementId, string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement/{requirementId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the assigned Requirement connections for the specified manufacturing item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAssignedRequirementMask>> GetAssignedRequirements(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement";

            return await GetCollectionFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates assigned requirement link between manufacturing Item and specified requirement.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:AssignedRequirement
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAssignedRequirementMask>> AddAssignedRequirement(string mfgItemId, ICreateAssignedRequirements request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:AssignedRequirement";

            return await PostCollectionFromResponseMemberProperty<IAssignedRequirementMask, ICreateAssignedRequirements>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified requirement specification connection for the specified manufacturing item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="requirementId">
        /// dsmfg:ScopeRequirementSpec object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IScopeRequirementSpecMask> GetScopeRequirementSpec(string mfgItemId, string requirementId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec/{requirementId}";

            return await GetIndividualFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete the specified requirement specification Link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="requirementId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="mfgItemId">
        /// dsmfg:ScopeRequirementSpec object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteScopeRequirementSpec(string requirementId, string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec/{requirementId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the requirement specification connections for the specified manufacturing item.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IScopeRequirementSpecMask>> GetScopeRequirementSpecs(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec";

            return await GetCollectionFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates requirement specification link between manufacturing Item and specified requirement.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:ScopeRequirementSpec
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IScopeRequirementSpecMask>> AddScopeRequirementSpec(string mfgItemId, ICreateScopeRequirementSpecs request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:ScopeRequirementSpec";

            return await PostCollectionFromResponseMemberProperty<IScopeRequirementSpecMask, ICreateScopeRequirementSpecs>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Origin Items link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Origin
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IOriginMask>> GetOrigin(string mfgItemId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Origin";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await GetCollectionFromResponseMemberProperty<IOriginMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets specific Origin Item link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Origin/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="originId">
        /// dsmfg:Origin object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IOriginMask>> GetOrigin(string mfgItemId, string originId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Origin/{originId}";

            return await GetCollectionFromResponseMemberProperty<IOriginMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Substitute Items link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Substitute
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ISubstituteMask>> GetSubstitute(string mfgItemId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Substitute";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await GetCollectionFromResponseMemberProperty<ISubstituteMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets specific Substitute Item link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Substitute/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="substituteId">
        /// dsmfg:Substitute object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ISubstituteMask>> GetSubstitute(string mfgItemId, string substituteId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Substitute/{substituteId}";

            return await GetCollectionFromResponseMemberProperty<ISubstituteMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the MfgResponsibility Items link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:MfgResponsibility
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IMfgResponsibilityMask>> GetMfgResponsibility(string mfgItemId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgResponsibility";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await GetCollectionFromResponseMemberProperty<IMfgResponsibilityMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets specific MfgResponsibility Item link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:MfgResponsibility/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="mfgResponsibilityId">
        /// dsmfg:MfgResponsibility object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IMfgResponsibilityMask>> GetMfgResponsibility(string mfgItemId, string mfgResponsibilityId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgResponsibility/{mfgResponsibilityId}";

            return await GetCollectionFromResponseMemberProperty<IMfgResponsibilityMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Alternate Items link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Alternate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAlternateMask>> GetAlternate(string mfgItemId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Alternate";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
                { "$top", top.ToString() },

            { "$skip", skip.ToString() }
         };

            return await GetCollectionFromResponseMemberProperty<IAlternateMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Manufacturing Alternate Process link. Only 1 item could be created per call 'on cloud'.
        /// Only 10 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dsmfg:Alternate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAlternateMask>> AddAlternate(string mfgItemId, ICreateMfgAlternate request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Alternate";

            return await PostCollectionFromResponseMemberProperty<IAlternateMask, ICreateMfgAlternate>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets specific Alternate Item link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dsmfg:Alternate/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="alternateId">
        /// dsmfg:Alternate object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAlternateMask>> GetAlternate(string mfgItemId, string alternateId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Alternate/{alternateId}";

            return await GetCollectionFromResponseMemberProperty<IAlternateMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes specific Alternate Item link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}/dsmfg:Alternate/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="alternateId">
        /// dsmfg:Alternate object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteAlternate(string mfgItemId, string alternateId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:Alternate/{alternateId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of an dsmfg:MfgItem
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachChangeControl(string mfgItemId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachChangeControl(string mfgItemId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of a dsmfg:MfgItemInstance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object PID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlStatusMask>> GetInstanceChangeControl(string mfgItemId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object PID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddInstanceChangeControl(string mfgItemId, string instanceId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object PID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteInstanceChangeControl(string mfgItemId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Object Configuration information
        /// This extension gets the Enabled Criteria and Configuration Contexts of Configured object
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgItemId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies Configuration Information of configured object
        /// Enables the criteria of single reference
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsmfg:MfgItem/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgItemId, IConfiguredPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured";

            return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a list of configuration context to a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dscfg:Configured/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgItemId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured/attach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a list of configuration context from a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{ID}/dscfg:Configured/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgItemId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dscfg:Configured/detach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Instance effectivity information.
        /// This extension gets the effectivity of an Object instance/relationship
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dscfg:Filterable
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgItemId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dscfg:Filterable";

            return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to get the Manufacturing Instance direct dependencies.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem Parent object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance Successor object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IDependencyMask>> GetInstanceDependency(string mfgItemId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency";

            return await GetCollectionFromResponseMemberProperty<IDependencyMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach dependency constraint to a specified Manufacturing Item instance.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem Parent object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance Successor object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachDependencyToInstance(string mfgItemId, string instanceId, IAttachDependencyPayload request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency/attach";

            return await PostIndividual<IGenericResponse, IAttachDependencyPayload>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach dependency constraint from a specified Manufacturing Item instance.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsmfg:MfgItem/{PID}/dsmfg:MfgItemInstance/{ID}/dsmfg:Dependency/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgItemId">
        /// dsmfg:MfgItem Parent object ID
        /// </param>
        /// <param name="instanceId">
        /// dsmfg:MfgItemInstance Successor object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachDependencyFromInstance(string mfgItemId, string instanceId, IDetachDependencyPayload request)
        {
            string resourceURI = $"{GetBaseResource()}dsmfg:MfgItem/{mfgItemId}/dsmfg:MfgItemInstance/{instanceId}/dsmfg:Dependency/detach";

            return await PostIndividual<IGenericResponse, IDetachDependencyPayload>(resourceURI, request);
        }
    }
}