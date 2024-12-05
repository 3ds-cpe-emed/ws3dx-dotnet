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
    public class DataCollectPlanService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

        public DataCollectPlanService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsprcs:DataCollectPlan/search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IDataCollectPlanMask) };
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
        /// Gets a Work instruction DataCollectPlan reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:DataCollectPlan/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string dataCollectPlanId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanMask), typeof(IDataCollectPlanDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a Work instruction DataCollectPlan reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsprcs:DataCollectPlan/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> Remove(string dataCollectPlanId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifys a Work instruction DataCollectPlan reference.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsprcs:DataCollectPlan/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Update<T>(string dataCollectPlanId, IDataCollectPlanUpdate request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanMask), typeof(IDataCollectPlanDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}";

            return await PatchCollectionFromResponseMemberProperty<T, IDataCollectPlanUpdate>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Work instruction DataCollectPlan reference. Only 1 item could be created per call 'on
        /// cloud'. Only 10 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:DataCollectPlan
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateDataCollectPlan request)
		{
			GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDataCollectPlanMask), typeof(IDataCollectPlanDetailMask)});

			string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan";

			return await PostCollectionFromResponseMemberProperty<T, ICreateDataCollectPlan>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all Work instruction DataCollectRow assigned to a DataCollectPlan.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:DataCollectPlan/{ID}/dsprcs:DataCollectRow
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IDataCollectRowMask>> GetDataCollectRows(string dataCollectPlanId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}/dsprcs:DataCollectRow";

            return await GetCollectionFromResponseMemberProperty<IDataCollectRowMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates Work instruction DataCollectRows under DataCollectPlan. Only 1 item could be created per
        /// call 'on cloud'. Only 10 items could be created per call 'on premise'.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:DataCollectPlan/{ID}/dsprcs:DataCollectRow
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IDataCollectRowMask>> CreateDataCollectRows(string dataCollectPlanId, ICreateDataCollectRow request)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}/dsprcs:DataCollectRow";

            return await PostCollectionFromResponseMemberProperty<IDataCollectRowMask, ICreateDataCollectRow>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Work instruction DataCollectRow details assigned to a DataCollectPlan.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:DataCollectPlan/{PID}/dsprcs:DataCollectRow/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="dataCollectPlanId">
        /// dsprcs:DataCollectPlan object ID
        /// </param>
        /// <param name="dataCollectRowId">
        /// dsprcs:DataCollectRow object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IDataCollectRowMask> GetDataCollectRow(string dataCollectPlanId, string dataCollectRowId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:DataCollectPlan/{dataCollectPlanId}/dsprcs:DataCollectRow/{dataCollectRowId}";

            return await GetIndividualFromResponseMemberProperty<IDataCollectRowMask>(resourceURI);
        }
	}
}