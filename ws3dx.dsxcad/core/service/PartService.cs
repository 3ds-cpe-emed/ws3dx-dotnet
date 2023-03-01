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

namespace ws3dx.dsxcad.core.service
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
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}/dsxcad:VisualizationFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets Visualization File of a Part Summary: Gets Visualization File of a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IVisualizationFileMask>> GetVisualizationFile(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:VisualizationFile";

         return await GetMultiple<IVisualizationFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Enterprise Reference of a Part Summary: Gets a Enterprise Reference of a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IEnterpriseItemNumberMask>> GetEnterpriseItemNumber(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

         return await GetMultiple<IEnterpriseItemNumberMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Part Summary: Gets a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string partId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of a Part Summary: Gets a Change Control of a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

         return await GetMultiple<IChangeControlMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}/dsxcad:xCADAttributes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets CAD specific attributes of a Part Summary: Gets CAD specific attributes of a 
      // Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IXCADAttributesMask>> GetXCADAttributes(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:xCADAttributes";

         return await GetMultiple<IXCADAttributesMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Part/{ID}/dsxcad:AuthoringFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Authoring File of an dsxcad:Part Summary: Gets a CAD Authoring File of an 
      // dsxcad:Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile";

         return await GetMultiple<IAuthoringFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/dsxcad:AuthoringFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing Part authoring file Summary: Gets a download 
      // ticket for an existing Part authoring file
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string partId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile/DownloadTicket";

         return await PostRequest<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control on a Part Summary: Activate the Change Control
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> ChangeControl(string partId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

         return await PostRequest<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/Attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Attach an object to the Part with a dependency link Summary: Attach an object
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Attach<T>(string partId, IAttachXCADPart request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Attach";

         return await PostRequestMultiple<T, IAttachXCADPart>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/dsxcad:AuthoringFile/CheckinTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an upload ticket for an existing Part. This service should be used when files 
      // needs to be updated. The ticket will be valid to upload 2 files. Summary: Gets an upload ticket 
      // for an existing Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string partId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:AuthoringFile/CheckinTicket";

         return await PostRequest<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/Modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Update a Part attributes and files Summary: Update a Part attributes and files
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Modify<T>(string partId, IModifyXCADPartWithFiles request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Modify";

         return await PostRequestMultiple<T, IModifyXCADPartWithFiles>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/dsxcad:VisualizationFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing Part visualization file Summary: Gets a download 
      // ticket for an existing Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetVisualizationFileDownloadTicket(string partId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dsxcad:VisualizationFile/DownloadTicket";

         return await PostRequest<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Adding Enterprise Reference to a Part Summary: Adding Enterprise Reference to a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IEnterpriseItemNumberMask>> AddEnterpriseItemNumber(string partId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

         return await PostRequestMultiple<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part/{ID}/Detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach an object from the Part by deleting the dependency link Summary: Detach an 
      // object
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Detach<T>(string partId, IDetachXCADPart request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/Detach";

         return await PostRequestMultiple<T, IDetachXCADPart>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsxcad:Part/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Enterprise Reference of a Part Summary: Modifies the Enterprise Reference 
      // of a Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IEnterpriseItemNumberMask>> ModifyEnterpriseItemNumber(string partId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dseng:EnterpriseReference";

         return await PatchGroup<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsxcad:Part/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Part attributes Summary: Modifies the Part attributes
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Modify<T>(string partId, IModifyXCADPart request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADPartMask), typeof(IXCADPartBasicMask), typeof(IXCADPartEnterpriseDetailMask), typeof(IXCADPartDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

         return await PatchGroup<T, IModifyXCADPart>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Part/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a 3D Part Summary: Delete a 3D Part
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Part/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Change Control of a Part Summary: Delete a Change Control
      // <param name="partId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteChangeControl(string partId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part/{partId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a Part from attribute list Summary: Creating a Part
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADParts request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part";

         return await PostRequestMultiple<T, ICreateXCADParts>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Part
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a Part from attribute list Summary: Creating a Part
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADPartsFromTemplate request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Part";

         return await PostRequestMultiple<T, ICreateXCADPartsFromTemplate>(resourceURI, request);
      }
   }
}