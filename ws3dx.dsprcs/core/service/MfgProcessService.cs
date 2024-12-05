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
    public class MfgProcessService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

        public MfgProcessService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
         //// Find a more dynamic way to register the relation between a "mask type" (e.g.IMfgProcessExpandMaskV1) and
         //// its deserializer object / instance JsonElementCollectionDeserializer.Instance
         //if (!MaskDeserializationHandler.IsDeserializerTypeRegistered(typeof(IMfgProcessExpandMaskV1)))
         //{
         //   MaskDeserializationHandler.RegisterDeserializer(typeof(IMfgProcessExpandMaskV1), JsonGenericCollectionDeserializer.Instance);
         //}

         //if (!MaskDeserializationHandler.IsDeserializerTypeRegistered(typeof(IMfgProcessExpandMaskDetailV1)))
         //{
         //   MaskDeserializationHandler.RegisterDeserializer(typeof(IMfgProcessExpandMaskDetailV1), JsonGenericCollectionDeserializer.Instance);
         //}
        }
      //~MfgProcessService()
      //{
      //if (MaskDeserializationHandler.IsDeserializerTypeRegistered(typeof(IMfgProcessExpandMaskV1)))
      //{
      //   MaskDeserializationHandler.DeregisterDeserializer(typeof(IMfgProcessExpandMaskV1));
      //}

      //if (MaskDeserializationHandler.IsDeserializerTypeRegistered(typeof(IMfgProcessExpandMaskDetailV1)))
      //{
      //   MaskDeserializationHandler.DeregisterDeserializer(typeof(IMfgProcessExpandMaskDetailV1));
      //}
      //}
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

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Process
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string mfgProcessId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask), typeof(IMfgProcessStructureModelViewIndexMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Process attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Update<T>(string mfgProcessId, IMfgProcessPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}";

            return await PatchIndividualFromResponseMemberProperty<T, IMfgProcessPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Manufacturing Process. Only 1 item could be created per call 'on cloud'. Only 50 items
        /// could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateMfgProcess request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess";

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgProcess>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Locate or find set of Manufacturing Process dsprcs:MfgProcess based on the matched search criteria
        /// and other filter criteria.
        /// Provides the capability to locate or find set of Manufacturing Processes dsprcs:MfgProcess and
        /// navigate to target types based on the matched search criteria and other filter criteria.
        ///  Following are the capabilities provided:-
        ///  1. Locate Mfg Process matching the search criteria 'searchCriteria' alone.
        ///  2. Locate Mfg Process matching the search criteria 'searchCriteria' and filter using query param
        /// $top and $skip.
        ///  3. Locate Mfg Process matching both the search criteria 'searchCriteria' and list of Mfg Process
        /// Object references 'ObjectReferences' passed in the request payload.
        ///  Additionally once the Manufacturing process is located based on matching criteria then response
        /// contains list of valid Manufacturing process references and also return its associated objects
        /// if defined in 'navigateTo' and 'navigateFrom'.
        ///  The supported types in 'navigateTo' is 'dsprcs:MfgProcessInstance' and 'dsrsc:ScopeLink'.
        ///  And the supported types in 'navigateFrom' are dsprcs:PrimaryCapableResource, and dsprcs:ItemSpecification
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/locate
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
        public async Task<IEnumerable<IMfgProcessLocateUTCMask>> Locate(int top, int skip, ILocateMfgProcessRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/locate";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },

                { "$skip", skip.ToString() }
            };

            return await PostCollectionFromResponseMemberProperty<IMfgProcessLocateUTCMask, ILocateMfgProcessRequest>(resourceURI, request, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Expand specified Manufacturing Process dsprcs:MfgProcess to retrive all its references and instances.
        /// Expand specified Manufacturing Process dsprcs:MfgProcess to retrieve all its references and
        /// instances which are Public types only.
        /// API works only for Indexed Data only.
        /// Number of Paths or Occurrences in response is restricted to 10000 only.
        /// Returns other content types 'dsprcs:MfgProcess', 'dsprcs:MfgProcessInstance', 'dsprcs:MfgOperationInstance',
        /// 'dsprcs:MfgOperation', 'dsprcs:ItemSpecification', 'dsprcs:TimeConstraint', 'dsprcs:TransientTimeCnxFilter',
        /// 'dsprcs:PrimaryCapableResource', 'dsprcs:SecondaryCapableResource', 'dsprcs:PreAssignedWorkCenter',
        /// 'dsprcs:AlertInstance', 'dsprcs:Alert', 'dsprcs:InstructionInstance', 'dsprcs:Instruction',
        /// 'dsprcs:SignOffInstance', 'dsprcs:SignOff', 'dsprcs:DataCollectInstance', 'dsprcs:DataCollect',
        /// 'dsprcs:DataCollectPlanInstance', 'dsprcs:DataCollectPlan', 'dsprcs:CheckList', 'dsprcs:DataCollectRow',
        /// 'dsprcs:ResourceParameterPlanInstance', 'dsprcs:ResourceParameterPlan', 'dsprcs:ResourceParameterRow'
        /// using detail mask.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/expand
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<object>> Expand<T>(string mfgProcessId, IMfgProcessExpandRequestPayloadV1 request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessExpandMaskV1), typeof(IMfgProcessExpandMaskDetailV1) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/expand";

            return await PostCollectionNoMaskFromResponseMemberProperty<object, IMfgProcessExpandRequestPayloadV1>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets multiple Manufacturing Processes which are Indexed.
        ///  API Works only for Indexed Data only.
        ///  The customer attributes or enterprise extension attributes are returned only with default sixw
        /// mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/bulkfetch
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessMask), typeof(IMfgProcessDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/bulkfetch";

            return await PostBulkCollection<T, string[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Manufacturing Process Instance to an Manufacturing Process. Only 1 item could be created
        /// per call 'on cloud'. Only 50 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:MfgProcessInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddMfgProcessInstance<T>(string mfgProcessId, ICreateMfgProcessInstance request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance";

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgProcessInstance>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Process Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcessobject ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> GetInstance<T>(string mfgProcessId, string mfgProcessInstanceId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Process Instance attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcessobject ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> UpdateInstance<T>(string mfgProcessId, string mfgProcessInstanceId, IMfgProcessInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}";

            return await PatchIndividualFromResponseMemberProperty<T, IMfgProcessInstancePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Replace the Manufacturing Process Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/replace
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcessobject ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> ReplaceMfgProcessInstance<T>(string mfgProcessId, string mfgProcessInstanceId, IMfgProcessInstanceReplace request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgProcessInstanceMask), typeof(IMfgProcessInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/replace";

            return await PostCollectionFromResponseMemberProperty<T, IMfgProcessInstanceReplace>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Manufacturing Operation Instance under an Manufacturing Process. Only 1 item could be
        /// created per call 'on cloud'. Only 50 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:MfgOperationInstance
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddMfgOperationInstance<T>(string mfgProcessId, ICreateMfgOperationInstancesRefObject request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance";

            return await PostCollectionFromResponseMemberProperty<T, ICreateMfgOperationInstancesRefObject>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Operation Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IMfgOperationInstanceMask> GetMfgOperationInstance(string mfgProcessId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

            return await GetIndividualFromResponseMemberProperty<IMfgOperationInstanceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Manufacturing Operation Instance attributes under MfgProcess
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcessobject ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> UpdateMfgOperationInstance<T>(string mfgProcessId, string mfgOperationInstanceId, IMfgOperationInstancePatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgOperationInstanceMask), typeof(IMfgOperationInstanceDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}";

            return await PatchIndividualFromResponseMemberProperty<T, IMfgOperationInstancePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Process Time Constraint
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="timeConstraintId">
        /// dsprcs:TimeConstraint object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITimeConstraintMask> GetTimeConstraint(string mfgProcessId, string timeConstraintId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint/{timeConstraintId}";

            return await GetIndividualFromResponseMemberProperty<ITimeConstraintMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Manufacturing Process Time Constraint Under MfgProcess
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="timeConstraintId">
        /// dsprcs:TimeConstraint object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveTimeConstraint(string mfgProcessId, string timeConstraintId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint/{timeConstraintId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Manufacturing Process Time Constraint.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ITimeConstraintMask>> GetTimeConstraints(string mfgProcessId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<ITimeConstraintMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Manufacturing Process Time Constraint Under MfgProcess.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:TimeConstraint
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ITimeConstraintMask>> AddTimeConstraint(string mfgProcessId, ICreateTimeConstraintRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:TimeConstraint";

            return await PostCollectionFromResponseMemberProperty<ITimeConstraintMask, ICreateTimeConstraintRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Manufacturing Process Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="primaryResourceId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IPrimaryCapableResourceMask> GetPrimaryCapableResource(string mfgProcessId, string primaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await GetIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a Manufacturing Process Primary Capable Resource assigned to Manufacturing Process
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="primaryResourceId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemovePrimaryCapableResource(string mfgProcessId, string primaryResourceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies a Manufacturing Process Primary Capable Resource attributes
        /// Modifies a Manufacturing Process Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="primaryResourceId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessId">
        /// dsprcs:PrimaryCapableResource object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IPrimaryCapableResourceMask> UpdatePrimaryCapableResource(string primaryResourceId, string mfgProcessId, IPrimaryCapableResourcePatch request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource/{primaryResourceId}";

            return await PatchIndividualFromResponseMemberProperty<IPrimaryCapableResourceMask, IPrimaryCapableResourcePatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Manufacturing Process Primary Capable Resource
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPrimaryCapableResourceMask>> GetPrimaryCapableResources(string mfgProcessId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create Primary Capable Resource link to an Manufacturing Process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:PrimaryCapableResource
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPrimaryCapableResourceMask>> AddPrimaryCapableResource(string mfgProcessId, ICreatePrimaryCapableResourceRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PrimaryCapableResource";

            return await PostCollectionFromResponseMemberProperty<IPrimaryCapableResourceMask, ICreatePrimaryCapableResourceRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the item specification of the manufacturing process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="itemSpecificationId">
        /// dsprcs:ItemSpecification object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IItemSpecificationMask> GetItemSpecification(string mfgProcessId, string itemSpecificationId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification/{itemSpecificationId}";

            return await GetIndividualFromResponseMemberProperty<IItemSpecificationMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the dsprcs:ItemSpecification Implement link attributes under process
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="itemSpecificationId">
        /// dsprcs:ItemSpecification object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IItemSpecificationMask>> UpdateItemSpecification(string mfgProcessId, string itemSpecificationId, IItemspecificationPatch request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification/{itemSpecificationId}";

            return await PatchCollectionFromResponseMemberProperty<IItemSpecificationMask, IItemspecificationPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all item specification of the manufacturing process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IItemSpecificationMask>> GetItemSpecifications(string mfgProcessId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IItemSpecificationMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates dsprcs:ItemSpecification scope Link or implement link under process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object PID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddItemSpecification<T>(string mfgProcessId, IScopeItemCreateRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

            return await PostCollectionFromResponseMemberProperty<T, IScopeItemCreateRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates dsprcs:ItemSpecification scope Link or implement link under process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object PID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddItemSpecification<T>(string mfgProcessId, IScopeItemWithContextCreateRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

            return await PostCollectionFromResponseMemberProperty<T, IScopeItemWithContextCreateRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates dsprcs:ItemSpecification scope Link or implement link under process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:ItemSpecification
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object PID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> AddItemSpecification<T>(string mfgProcessId, IImplementLinkCreateRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:ItemSpecification";

            return await PostCollectionFromResponseMemberProperty<T, IImplementLinkCreateRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the preassigned work center link of the manufacturing process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="workCenterId">
        /// dsprcs:PreAssignedWorkCenter object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IPreAssignedWorkCenterMask> GetPreAssignedWorkCenter(string mfgProcessId, string workCenterId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter/{workCenterId}";

            return await GetIndividualFromResponseMemberProperty<IPreAssignedWorkCenterMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all preassigned work center link of the manufacturing process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPreAssignedWorkCenterMask>> GetPreAssignedWorkCenters(string mfgProcessId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IPreAssignedWorkCenterMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create PreAssignedWorkCenter Link.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:PreAssignedWorkCenter
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IPreAssignedWorkCenterMask>> AddPreAssignedWorkCenter(string mfgProcessId, ICreatePreAssignedWorkCenterRequest request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:PreAssignedWorkCenter";

            return await PostCollectionFromResponseMemberProperty<IPreAssignedWorkCenterMask, ICreatePreAssignedWorkCenterRequest>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the reference to the asset context of the manufacturing process.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:AssetContext
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAssetContextMask>> GetAssetContext(string mfgProcessId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext";

            return await GetCollectionFromResponseMemberProperty<IAssetContextMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a dsprcs:AssetContext to a single reference.
        /// Service to attach a dsprcs:AssetContextto a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:AssetContext/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachAssetContext(string mfgProcessId, ITypedUriIdentifier request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext/attach";

            return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a dsprcs:AssetContext from a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dsprcs:AssetContext/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DetachAssetContext(string mfgProcessId, ITypedUriIdentifier request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:AssetContext/detach";

            return await PostIndividual<IGenericResponse, ITypedUriIdentifier>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Object Configuration information
        /// This extension gets the Enabled Criteria and Configuration Contexts of Configured object
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> GetConfiguration<T>(string mfgProcessId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured";

            return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies Configuration Information of configured object
        /// Enables the criteria of single reference
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:MfgProcess/{ID}/dscfg:Configured
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> UpdateConfiguration<T>(string mfgProcessId, IConfiguredPatch request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured";

            return await PatchCollectionFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to attach a list of configuration context to a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dscfg:Configured/attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> AttachConfiguration(string mfgProcessId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured/attach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to detach a list of configuration context from a single reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dscfg:Configured/detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<ITypedUriIdentifierResources> DetachConfiguration(string mfgProcessId, ITypedUriIdentifier[] request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dscfg:Configured/detach";

            return await PostIndividual<ITypedUriIdentifierResources, ITypedUriIdentifier[]>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of a Manufacturing Process
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string mfgProcessId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddChangeControl(string mfgProcessId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgProcess/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveChangeControl(string mfgProcessId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of an Manufacturing Process Instance
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IChangeControlStatusMask> GetInstanceChangeControl(string mfgProcessId, string mfgProcessInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dslc:changeControl";

            return await GetIndividualFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddMfgProcessInstanceChangeControl(string mfgProcessId, string mfgProcessInstanceId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveMfgProcessInstanceChangeControl(string mfgProcessId, string mfgProcessInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of an Manufacturing Operation Instance Under MfgProcess
        /// Gets a Change Control of an Manufacturing Process Instance Under MfgProcess
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IChangeControlStatusMask> GetMfgOperationInstanceChangeControl(string mfgProcessId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await GetIndividualFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AddMfgOperationInstanceChangeControl(string mfgProcessId, string mfgOperationInstanceId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deactivate the Change Control.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> RemoveMfgOperationInstanceChangeControl(string mfgProcessId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Instance effectivity information.
        /// This extension gets the effectivity of an Object instance/relationship
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IFilterableDetail>> GetInstanceEffectivity(string mfgProcessId, string mfgProcessInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable";

            return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to set the effectivities evolution expression (XML). WARNING: Coherency between Evolution
        /// and Variant Expression are under users responsibility.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/set/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> SetMfgProcessInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId, ISetEvolutionEffectivities request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/set/evolution";

            return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the evolution effectivities.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/unset/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> UnsetMfgProcessInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/unset/evolution";

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
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/set/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgProcessInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryVariantEffectivity> SetMfgProcessInstanceVariantEffectivity(string mfgProcessId, string mfgProcessInstanceId, ISetVariantEffectivities request, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgProcessInstance/{mfgProcessInstanceId}/dscfg:Filterable/set/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Instance effectivity information.
        /// This extension gets the effectivity of an Object instance/relationship
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IFilterableDetail>> GetMfgOperationInstanceEffectivity(string mfgProcessId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable";

            return await GetCollectionFromResponseMemberProperty<IFilterableDetail>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to set the effectivities evolution expression (XML). WARNING: Coherency between Evolution
        /// and Variant Expression are under users responsibility.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> SetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId, ISetEvolutionEffectivities request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/evolution";

            return await PostIndividual<IUnitaryEvolutionEffectivity, ISetEvolutionEffectivities>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the evolution effectivities.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/evolution
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgOperationInstance object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryEvolutionEffectivity> UnsetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/evolution";

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
        /// (POST) dsprcs:MfgProcess/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/set/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcessId">
        /// dsprcs:MfgProcess object ID
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
        public async Task<IUnitaryVariantEffectivity> SetMfgOperationInstanceVariantEffectivity(string mfgProcessId, string mfgOperationInstanceId, ISetVariantEffectivities request, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProcess/{mfgProcessId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/set/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity, ISetVariantEffectivities>(resourceURI, request, headerParams: headerParams);
        }
    }
}