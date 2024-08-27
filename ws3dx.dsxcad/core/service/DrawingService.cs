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
    public class DrawingService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

        public DrawingService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsxcad:Drawing/Search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) };
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
        /// Gets a download ticket for an existing Drawing authoring file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string drawingId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an upload ticket for an existing Drawing. This service should be used when files needs to be
        /// updated. The ticket will be valid to upload 2 files.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile/CheckinTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string drawingId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile/CheckinTicket";

            return await PostIndividual<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Authoring File of an dsxcad:Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile";

            return await GetCollectionFromResponseMemberProperty<IAuthoringFileMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Update a Drawing attributes and files
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/Modify
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string drawingId, IModifyXCADDrawingWithFiles request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Modify";

            return await PostIndividualFromResponseMemberProperty<T, IModifyXCADDrawingWithFiles>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Drawing/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string drawingId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Drawing/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> Delete(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Drawing attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsxcad:Drawing/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string drawingId, IModifyXCADDrawing request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

            return await PatchIndividualFromResponseMemberProperty<T, IModifyXCADDrawing>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creating a Drawing from attribute list
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateXCADDrawings request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing";

            return await PostCollectionFromResponseMemberProperty<T, ICreateXCADDrawings>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creating a Drawing from attribute list
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateXCADDrawingsFromTemplate request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing";

            return await PostCollectionFromResponseMemberProperty<T, ICreateXCADDrawingsFromTemplate>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Attach an object to the Drawing with a dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/Attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Attach<T>(string drawingId, IAttachXCADDrawing request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Attach";

            return await PostIndividualFromResponseMemberProperty<T, IAttachXCADDrawing>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Detach an object from the Drawing by deleting the dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/Detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Detach<T>(string drawingId, IDetachXCADDrawing request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Detach";

            return await PostIndividualFromResponseMemberProperty<T, IDetachXCADDrawing>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Locate the drawing from an Engineering Item by completing the dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/Locate
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IRelatedId>> Locate(ILocateXCADDrawing request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/Locate";

            return await PostCollectionFromResponseMemberProperty<IRelatedId, ILocateXCADDrawing>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a download ticket for an existing Drawing visualization file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/dsxcad:VisualizationFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetVisualizationFileDownloadTicket(string drawingId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:VisualizationFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Visualization File of an dsxcad:Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Drawing/{ID}/dsxcad:VisualizationFile
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IVisualizationFileMask>> GetVisualizationFile(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:VisualizationFile";

            return await GetCollectionFromResponseMemberProperty<IVisualizationFileMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of a Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Drawing/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control of a Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Drawing/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> ChangeControl(string drawingId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Change Control of a Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Drawing/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteChangeControl(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Extension of an dsxcad:Drawing
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Drawing/{ID}/dsxcad:xCADAttributes
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="drawingId">
        /// dsxcad:Drawing object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IXCADAttributesMask> GetXCADAttributes(string drawingId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:xCADAttributes";

            return await GetIndividualFromResponseMemberProperty<IXCADAttributesMask>(resourceURI);
        }
    }
}