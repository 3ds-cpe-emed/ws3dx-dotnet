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
using ws3dx.dsxcad.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsxcad.service
{
    // SDK Service
    public class Shape3DService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

        public Shape3DService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsxcad:3DShape/search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IXCADShapeMask), typeof(IXCADShapeMaskEnterpriseDetail) };
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
        /// Gets a download ticket for an existing 3DShape authoring file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:3DShape/{ID}/dsxcad:AuthoringFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="ID">
        /// dsxcad:3DShape object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string ID, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:3DShape/{ID}/dsxcad:AuthoringFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Shape
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:3DShape/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="ID">
        /// dsxcad:3DShape object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string ID)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADShapeMask), typeof(IXCADShapeMaskEnterpriseDetail) });

            string resourceURI = $"{GetBaseResource()}dsxcad:3DShape/{ID}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }
    }
}