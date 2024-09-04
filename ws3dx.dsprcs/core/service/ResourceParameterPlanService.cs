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
using ws3dx.utils.search;

namespace ws3dx.dsprcs.service
{
    // SDK Service
    public class ResourceParameterPlanService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

        public ResourceParameterPlanService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsprcs:ResourceParameterPlan/search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IResourceParameterPlanMask) };
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
        /// Gets a Resource Parameter Plan Reference
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:ResourceParameterPlan/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="ID">
        /// dsprcs:ResourceParameterPlan object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IResourceParameterPlanMask> Get(string resourceParameterPlanId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:ResourceParameterPlan/{resourceParameterPlanId}";

            return await GetIndividualFromResponseMemberProperty<IResourceParameterPlanMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get All Resource Parameter Plan Entries assigned to Parameter Plan
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:ResourceParameterPlan/{ID}/dsprcs:ResourceParameterRow
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="ID">
        /// dsprcs:ResourceParameterPlan object ID
        /// </param>
        /// <param name="top">
        /// Represents the total number of items returned from the search, accepts a maximum value of 10.
        /// </param>
        /// <param name="skip">
        /// Represents the number of items to skip (to be used along with $top query parameter)
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IResourceParameterRowMask>> GetResourceParameterRows(string resourceParameterPlanId, int top, int skip)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:ResourceParameterPlan/{resourceParameterPlanId}/dsprcs:ResourceParameterRow";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };

            return await GetCollectionFromResponseMemberProperty<IResourceParameterRowMask>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Resource Parameter Plan Entry assigned to Parameter Plan
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsprcs:ResourceParameterPlan/{ID}/dsprcs:ResourceParameterRow/{PID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="ID">
        /// dsprcs:ResourceParameterPlan object ID
        /// </param>
        /// <param name="PID">
        /// dsprcs:ResourceParameterRow object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IResourceParameterRowMask> GetResourceParameterRow(string resourceParameterPlanId, string resourceParameterRowId)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:ResourceParameterPlan/{resourceParameterPlanId}/dsprcs:ResourceParameterRow/{resourceParameterRowId}";

            return await GetIndividualFromResponseMemberProperty<IResourceParameterRowMask>(resourceURI);
        }
    }
}