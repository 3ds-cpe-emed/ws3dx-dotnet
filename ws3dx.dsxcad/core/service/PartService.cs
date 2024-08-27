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
    public class PartService : SearchService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

        public PartService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
        {
        }

        protected string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        #region SearchService overrides
        protected override string GetSearchResource()
        {
            return $"{GetBaseResource()}dsxcad:Part/Search";
        }

        protected override IEnumerable<Type> SearchConstraintTypes()
        {
            return new List<Type>() { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) };
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
        /// Gets a download ticket for an existing Part authoring file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/dsxcad:AuthoringFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string partId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets an upload ticket for an existing Part. This service should be used when files needs to be
        /// updated. The ticket will be valid to upload 2 files.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/dsxcad:AuthoringFile/CheckinTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string partId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile/CheckinTicket";

            return await PostIndividual<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a CAD Authoring File of an dsxcad:Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}/dsxcad:AuthoringFile
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile";

            return await GetCollectionFromResponseMemberProperty<IAuthoringFileMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Update a Part attributes and files
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/Modify
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string partId, IModifyXCADPartWithFiles request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Modify";

            return await PostIndividualFromResponseMemberProperty<T, IModifyXCADPartWithFiles>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creating a Part from attribute list
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateXCADParts request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part";

            return await PostCollectionFromResponseMemberProperty<T, ICreateXCADParts>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Creating a Part from attribute list
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> Create<T>(ICreateXCADPartsFromTemplate request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part";

            return await PostCollectionFromResponseMemberProperty<T, ICreateXCADPartsFromTemplate>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Get<T>(string partId)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

            return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a 3D Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Part/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> Delete(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Part attributes
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsxcad:Part/{ID}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Modify<T>(string partId, IModifyXCADPart request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

            return await PatchIndividualFromResponseMemberProperty<T, IModifyXCADPart>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Attach an object to the Part with a dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/Attach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Attach<T>(string partId, IAttachXCADPart request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Attach";

            return await PostIndividualFromResponseMemberProperty<T, IAttachXCADPart>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Detach an object from the Part by deleting the dependency link
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/Detach
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<T> Detach<T>(string partId, IDetachXCADPart request)
        {
            GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Detach";

            return await PostIndividualFromResponseMemberProperty<T, IDetachXCADPart>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a download ticket for an existing Part visualization file
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/dsxcad:VisualizationFile/DownloadTicket
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IFileDownloadTicket> GetVisualizationFileDownloadTicket(string partId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:VisualizationFile/DownloadTicket";

            return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets Visualization File of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}/dsxcad:VisualizationFile
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IVisualizationFileMask>> GetVisualizationFile(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:VisualizationFile";

            return await GetCollectionFromResponseMemberProperty<IVisualizationFileMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Change Control of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

            return await GetCollectionFromResponseMemberProperty<IChangeControlMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Activate the Change Control on a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> AttachChangeControl(string partId, IAddEmpty request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

            return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete a Change Control of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) dsxcad:Part/{ID}/dslc:changeControl
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IGenericResponse> DeleteChangeControl(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

            return await DeleteIndividual<IGenericResponse>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets a Enterprise Reference of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}/dseng:EnterpriseReference
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnterpriseItemNumberMask> GetEnterpriseItemNumber(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

            return await GetIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Adding Enterprise Reference to a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsxcad:Part/{ID}/dseng:EnterpriseReference
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnterpriseItemNumberMask> AddEnterpriseItemNumber(string partId, IEnterpriseItemNumber request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

            return await PostIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifies the Enterprise Reference of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PATCH) dsxcad:Part/{ID}/dseng:EnterpriseReference
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        /// <param name="request">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IEnterpriseItemNumberMask> ModifyEnterpriseItemNumber(string partId, IEnterpriseItemNumber request)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

            return await PatchIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets CAD specific attributes of a Part
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) dsxcad:Part/{ID}/dsxcad:xCADAttributes
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="partId">
        /// dsxcad:Part object ID
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IXCADAttributesMask> GetXCADAttributes(string partId)
        {
            string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:xCADAttributes";

            return await GetIndividualFromResponseMemberProperty<IXCADAttributesMask>(resourceURI);
        }
    }
}