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
using ws3dx.shared.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsxcad.service
{
    // SDK Service
    public class RepresentationService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

        public RepresentationService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsxcad:Representation/Search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) };
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
        /// Gets a download ticket for an existing CAD Specific Data authoring file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/dsxcad:AuthoringFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string representationId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an upload ticket for an existing CAD Specific Data. This service should be used when files
        /// needs to be updated. The ticket will be valid to upload the 1 file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/dsxcad:AuthoringFile/CheckinTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string representationId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile/CheckinTicket";

            return await PostIndividual<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Authoring File of an dsxcad:Representation
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Representation/{ID}/dsxcad:AuthoringFile
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string representationId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile";

            return await GetCollectionFromResponseMemberProperty<IAuthoringFileMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Detach an object from the CAD Specific Data by deleting the dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/Detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Detach<T>(string representationId, IDetachXCADRepresentation request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Detach";

            return await PostCollectionFromResponseMemberProperty<T, IDetachXCADRepresentation>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Attach an object to the CAD Specific Data with a dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/Attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Attach<T>(string representationId, IAttachXCADRepresentation request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Attach";

            return await PostCollectionFromResponseMemberProperty<T, IAttachXCADRepresentation>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creating a CAD Specific Data from attribute list
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateXCADReferences request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation";

            return await PostCollectionFromResponseMemberProperty<T, ICreateXCADReferences>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Representation/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string representationId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Representation/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> Delete(string representationId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the CAD Specific Data attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsxcad:Representation/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string representationId, IModifyXCADRepresentation request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

            return await PatchIndividualFromResponseMemberProperty<T, IModifyXCADRepresentation>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Update a CAD Specific Data attributes and files
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/Modify
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string representationId, IModifyXCADRepresentationWithFiles request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Modify";

            return await PostIndividualFromResponseMemberProperty<T, IModifyXCADRepresentationWithFiles>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Locate a CAD Specific Data from an Engineering Item
        /// Locate the CAD Specific Data from an Engineering Item by navigating the dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/Locate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IEnterpriseItemNumberMask>> Locate(ILocateXCADRepresentations request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/Locate";

            return await PostCollectionFromResponseMemberProperty<IEnterpriseItemNumberMask, ILocateXCADRepresentations>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Representation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string representationId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control of a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Representation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachChangeControl(string representationId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Change Control of a a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Representation/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteChangeControl(string representationId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets CAD specific attributes of a CAD Specific Data
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Representation/{ID}/dsxcad:xCADAttributes
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="representationId">
        /// dsxcad:Representation object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IXCADAttributesMask> GetXCADAttributes(string representationId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:xCADAttributes";

            return await GetIndividualFromResponseMemberProperty<IXCADAttributesMask>(resourceURI);
        }
    }
}