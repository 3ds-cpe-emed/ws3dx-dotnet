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
using ws3dx.utils.search;

namespace ws3dx.dsprcs.service
{
    // SDK Service
    public class MfgOperationService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

        public MfgOperationService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsprcs:MfgOperation/search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IMfgOperationMask) };
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
        /// Gets a Manufacturing Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Operation attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Update<T>(string mfgOperationId, IMfgOperationPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}";

            return await PatchIndividualFromResponseMemberProperty<T, IMfgOperationPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Manufacturing Operation. Only 1 item could be created per call 'on cloud'. Only 50 items
        /// could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Create<T>(ICreateMfgOperation request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation";

            return await PostIndividualFromResponseMemberProperty<T, ICreateMfgOperation>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets multiple Manufacturing Operations which are Indexed.
        ///  API Works only for Indexed Data only.
        ///  The customer attributes or enterprise extension attributes are returned only with default sixw
        /// mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/bulkfetch
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationMask), typeof(IMfgOperationDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/bulkfetch";

            return await PostBulkCollection<T, string[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Manufacturing Operation Instance under an Manufacturing Operation. Only 1 item could be
        /// created per call 'on cloud'. Only 50 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dsprcs:MfgOperationInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddMfgOperationInstance<T>(string mfgOperationId, ICreateMfgOperationInstancesRefObject request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance";

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgOperationInstancesRefObject>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Operation Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IMfgOperationInstanceMask> GetInstance(string mfgOperationId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

            return await GetIndividualFromResponseMemberProperty<IMfgOperationInstanceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Operation Instance attributes under MfgOperation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperationobject ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateInstance<T>(string mfgOperationId, string mfgOperationInstanceId, IMfgOperationInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

            return await PatchCollectionFromResponseMemberProperty<T, IMfgOperationInstancePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Operation Time Constraint
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="timeConstraintId">
        /// dsprcs:TimeConstraint object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITimeConstraintMask> GetTimeConstraint(string mfgOperationId, string timeConstraintId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint/{timeConstraintId}";

            return await GetIndividualFromResponseMemberProperty<ITimeConstraintMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a Manufacturing Operation Time Constraint under MfgOperation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="timeConstraintId">
        /// dsprcs:TimeConstraint object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveTimeConstraint(string mfgOperationId, string timeConstraintId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint/{timeConstraintId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Manufacturing Operation Time Constraint
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ITimeConstraintMask>> GetTimeConstraints(string mfgOperationId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<ITimeConstraintMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Manufacturing Process Time Constraint Under MfgOperation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dsprcs:TimeConstraint
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ITimeConstraintMask>> AddTimeConstraint(string mfgOperationId, ICreateTimeConstraintRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:TimeConstraint";

            return await PostCollectionFromResponseMemberProperty<ITimeConstraintMask, ICreateTimeConstraintRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Operation Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="primaryResourceId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IPrimaryCapableResourceMask> GetPrimaryCapableResource(string mfgOperationId, string primaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await GetIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a Manufacturing Operation Primary Capable Resource assigned to Manufacturing Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="primaryResourceId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemovePrimaryCapableResource(string mfgOperationId, string primaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies a Manufacturing Operation Primary Capable Resource attributes
        /// Modifies a Manufacturing Operation Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="primaryResourceId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IPrimaryCapableResourceMask> UpdatePrimaryCapableResource(string primaryResourceId, string mfgOperationId, IPrimaryCapableResourcePatch request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await PatchIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask, IPrimaryCapableResourcePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Manufacturing Operation Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPrimaryCapableResourceMask>> GetPrimaryCapableResources(string mfgOperationId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Primary Capable Resource link to an Manufacturing Operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dsprcs:PrimaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPrimaryCapableResourceMask>> AddPrimaryCapableResource(string mfgOperationId, ICreatePrimaryCapableResourceRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:PrimaryCapableResource";

            return await PostCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask, ICreatePrimaryCapableResourceRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Operation Secondary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="secondaryResourceId">
        /// dsprcs:SecondaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ISecondaryCapableResourceMask> GetSecondaryCapableResource(string mfgOperationId, string secondaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource/{secondaryResourceId}";

            return await GetIndividualFromResponseMemberProperty<ISecondaryCapableResourceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a Manufacturing Operation Secondary Capable Resource assigned to Manufacturing Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="secondaryResourceId">
        /// dsprcs:SecondaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveSecondaryCapableResource(string mfgOperationId, string secondaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource/{secondaryResourceId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies a Manufacturing Operation Secondary Capable Resource attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="secondaryResourceId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationId">
        /// dsprcs:SecondaryCapableResource object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ISecondaryCapableResourceMask> UpdateSecondaryCapableResource(string secondaryResourceId, string mfgOperationId, ISecondaryCapableResourcePatch request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource/{secondaryResourceId}";

            return await PatchIndividualFromResponseMemberProperty<ISecondaryCapableResourceMask, ISecondaryCapableResourcePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Manufacturing Operation Secondary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ISecondaryCapableResourceMask>> GetSecondaryCapableResources(string mfgOperationId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<ISecondaryCapableResourceMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Secondary Capable Resource to an Manufacturing Operation.
        /// Create Primary Capable Resource to an Manufacturing Operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dsprcs:SecondaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ISecondaryCapableResourceMask>> AddSecondaryCapableResource(string mfgOperationId, ICreateSecondaryCapableResourceRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SecondaryCapableResource";

            return await PostCollectionFromResponseMemberProperty<ISecondaryCapableResourceMask, ICreateSecondaryCapableResourceRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the dsprcs:ItemSpecification link under an operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="itemSpecificationId">
        /// dsprcs:ItemSpecification object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IItemSpecificationMask> GetItemSpecification(string mfgOperationId, string itemSpecificationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification/{itemSpecificationId}";

            return await GetIndividualFromResponseMemberProperty<IItemSpecificationMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the dsprcs:ItemSpecification Implement link attributes under operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="itemSpecificationId">
        /// dsprcs:ItemSpecification object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IItemSpecificationMask> UpdateItemSpecification(string mfgOperationId, string itemSpecificationId, IItemspecificationPatch request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification/{itemSpecificationId}";

            return await PatchIndividualFromResponseMemberProperty<IItemSpecificationMask, IItemspecificationPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all dsprcs:ItemSpecification link under operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IItemSpecificationMask>> GetItemSpecifications(string mfgOperationId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IItemSpecificationMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates dsprcs:ItemSpecification implement link under operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object PID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IItemSpecificationMask>> AddItemSpecification(string mfgOperationId, IImplementLinkCreateRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ItemSpecification";

            return await PostCollectionFromResponseMemberProperty<IItemSpecificationMask, IImplementLinkCreateRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Object Configuration information
        /// This extension gets the Enabled Criteria and Configuration Contexts of Configured object
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies Configuration Information of configured object
        /// Enables the criteria of single reference
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgOperationId, IConfiguredPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured";

            return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a list of configuration context to a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dscfg:Configured/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/attach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a list of configuration context from a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dscfg:Configured/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgOperationId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dscfg:Configured/detach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of an Manufacturing Operation Instance Under Mfg Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperation Instance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlStatusMask>> GetInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddMfgOperationInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveMfgOperationInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of an Manufacturing Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgOperationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddChangeControl(string mfgOperationId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveChangeControl(string mfgOperationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Instance effectivity information.
        /// This extension gets the effectivity of an Object instance/relationship
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgOperationId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable";

            return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to set the effectivities evolution expression (XML). WARNING: Coherency between Evolution
        /// and Variant Expression are under users responsibility.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> SetMfgOperationInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId, ISetEvolutionEffectivities request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/evolution";

            return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the evolution effectivities.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> UnsetMfgOperationInstanceEvolutionEffectivity(string mfgOperationId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/evolution";

            return await PostIndividual<IUnitaryEvolutionEffectivity>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to set the effectivities variant expression (XML). If setVariant service is executed under
        /// Work Under (Change Action) then it may lead to a new evolution of existing relationship. WARNING:
        /// Coherency between Evolution and Variant Expression are under users responsibility. The web service
        /// will return the http 200 status code for success, partially failure and all manageable failure.
        /// errorCode and errorMessage attributes will be present in the response payload if the set variant
        /// effectivity failed for that relationship. errorMessage attribute in the response payload indicates
        /// the reason for set variant effectivity failure. If the exception occurs then the web service will
        /// completely failed with 400 http status code.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryVariantEffectivity> SetMfgOperationInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId, ISetVariantEffectivities request, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the variant effectivities. If unsetVariant service is executed under Work Under
        /// (Change Action) then it may lead to a new evolution of existing relationship.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryVariantEffectivity> UnsetMfgOperationInstanceVariantEffectivity(string mfgOperationId, string mfgOperationInstanceId, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity>(resourceURI, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified assigned requirement connection for the specified manufacturing operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:AssignedRequirement/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="PID">
        /// dsprcs:AssignedRequirement object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IAssignedRequirementMask> GetAssignedRequirement(string mfgOperationId, string PID)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AssignedRequirement/{PID}";

            return await GetIndividualFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the assigned Requirement connections for the specified manufacturing operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs::AssignedRequirement
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAssignedRequirementMask>> GetAssignedRequirements(string mfgOperationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs::AssignedRequirement";

            return await GetCollectionFromResponseMemberProperty<IAssignedRequirementMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified requirement specification connection for the specified manufacturing operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:ScopeRequirementSpec/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="PID">
        /// dsprcs:ScopeRequirementSpec object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IScopeRequirementSpecMask> GetScopeRequirementSpec(string mfgOperationId, string PID)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ScopeRequirementSpec/{PID}";

            return await GetIndividualFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the requirement specification connections for the specified manufacturing operation.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:ScopeRequirementSpec
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IScopeRequirementSpecMask>> GetScopeRequirementSpecs(string mfgOperationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ScopeRequirementSpec";

            return await GetCollectionFromResponseMemberProperty<IScopeRequirementSpecMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an Instruction Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:InstructionInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:InstructionInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetInstructionInstance<T>(string mfgOperationId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstructionInstanceMask), typeof(IInstructionInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:InstructionInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Instruction Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:InstructionInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetInstructionInstances<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstructionInstanceMask), typeof(IInstructionInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:InstructionInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an Alert Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:AlertInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:AlertInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetAlertInstance<T>(string mfgOperationId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlertInstanceMask), typeof(IAlertInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AlertInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the Alert Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:AlertInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetAlertInstances<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlertInstanceMask), typeof(IAlertInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:AlertInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an SignOff Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:SignOffInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:SignOffInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetSignOffInstance<T>(string mfgOperationId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ISignOffInstanceMask), typeof(ISignOffInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SignOffInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the SignOff Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:SignOffInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetSignOffInstances<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ISignOffInstanceMask), typeof(ISignOffInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:SignOffInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an DataCollect Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:DataCollectInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetDataCollectInstance<T>(string mfgOperationId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectInstanceMask), typeof(IDataCollectInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the DataCollect Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetDataCollectInstances<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectInstanceMask), typeof(IDataCollectInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an DataCollectPlan Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:DataCollectInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetDataCollectPlanInstance<T>(string mfgOperationId, string instanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance/{instanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete an DataCollectPlan Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:DataCollectInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveDataCollectPlanInstance(string mfgOperationId, string instanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance/{instanceId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modify an DataCollectPlan Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:DataCollectInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateDataCollectPlanInstance<T>(string mfgOperationId, string instanceId, IDataCollectPlanInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance/{instanceId}";

            return await PatchCollectionFromResponseMemberProperty<T, IDataCollectPlanInstancePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all the DataCollectPlan Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetDataCollectPlanInstances<T>(string mfgOperationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates DataCollectPlan or CheckList Instances under the specified Operation Only 1 item could be
        /// created per call 'on cloud'. Only 10 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{PID}/dsprcs:DataCollectPlanInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddDataCollectPlanInstance<T>(string mfgOperationId, ICreateDataCollectPlanInstancesRefObject request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanInstanceMask), typeof(IDataCollectPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:DataCollectPlanInstance";

            return await PostCollectionFromResponseMemberProperty<T, ICreateDataCollectPlanInstancesRefObject>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Resource Parameter Plan Instances available on specified Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:ResourceParameterPlanInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IResourceParamPlanInstanceMask>> GetResourceParameterPlanInstances(string mfgOperationId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ResourceParameterPlanInstance";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IResourceParamPlanInstanceMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Resource Parameter Plan Instances under the specified Operation Only 1 item could be
        /// created per call 'on cloud'. Only 10 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgOperation/{ID}/dsprcs:ResourceParameterPlanInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddResourceParameterPlanInstance<T>(string mfgOperationId, ICreateResourceParameterPlanInstancesRefObject request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceParamPlanInstanceMask), typeof(IResourceParamPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ResourceParameterPlanInstance";

            return await PostCollectionFromResponseMemberProperty<T, ICreateResourceParameterPlanInstancesRefObject>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get a Resource Parameter Plan Instances available on specified Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgOperation/{ID}/dsprcs:ResourceParameterPlanInstance/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="resourceParameterPlanInstanceId">
        /// dsprcs:ResourceParameterPlanInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetResourceParameterPlanInstance<T>(string mfgOperationId, string resourceParameterPlanInstanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceParamPlanInstanceMask), typeof(IResourceParamPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ResourceParameterPlanInstance/{resourceParameterPlanInstanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Resource Parameter Plan Instances available on specified Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgOperation/{ID}/dsprcs:ResourceParameterPlanInstance/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="resourceParameterPlanInstanceId">
        /// dsprcs:ResourceParameterPlanInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveResourceParameterPlanInstance(string mfgOperationId, string resourceParameterPlanInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ResourceParameterPlanInstance/{resourceParameterPlanInstanceId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modify a Resource Parameter Plan Instances available on specified Operation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgOperation/{ID}/dsprcs:ResourceParameterPlanInstance/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgOperationId">
        /// dsprcs:MfgOperation object ID
        /// </param>
        /// <param name="resourceParameterPlanInstanceId">
        /// dsprcs:ResourceParameterPlanInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateResourceParameterPlanInstance<T>(string mfgOperationId, string resourceParameterPlanInstanceId, IResourceParameterPlanInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceParamPlanInstanceMask), typeof(IResourceParamPlanInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgOperation/{mfgOperationId}/dsprcs:ResourceParameterPlanInstance/{resourceParameterPlanInstanceId}";

            return await PatchCollectionFromResponseMemberProperty<T, IResourceParameterPlanInstancePatch>(resourceURI, request);
        }
    }
}