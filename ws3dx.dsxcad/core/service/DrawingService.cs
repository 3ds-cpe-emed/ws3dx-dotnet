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

namespace ws3dx.dsxcad.core.service
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

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Drawing/{ID}/dsxcad:VisualizationFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Visualization File of an dsxcad:Drawing Summary: Gets a CAD Visualization 
      // File of an dsxcad:Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IVisualizationFileMask>> GetVisualizationFile(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:VisualizationFile";

         return await GetCollectionFromResponseMemberProperty<IVisualizationFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Drawing/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Drawing Summary: Gets a Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string drawingId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Drawing/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of a Drawing Summary: Gets a Change Control of an Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Drawing/{ID}/dsxcad:xCADAttributes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Extension of an dsxcad:Drawing Summary: Gets a CAD Extension of an 
      // dsxcad:Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IXCADAttributesMask>> GetXCADAttributes(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:xCADAttributes";

         return await GetCollectionFromResponseMemberProperty<IXCADAttributesMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Authoring File of an dsxcad:Drawing Summary: Gets a CAD Authoring File of 
      // an dsxcad:Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile";

         return await GetCollectionFromResponseMemberProperty<IAuthoringFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing Drawing authoring file Summary: Gets a download 
      // ticket for an existing drawing authoring file
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string drawingId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile/DownloadTicket";

         return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/dsxcad:AuthoringFile/CheckinTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an upload ticket for an existing Drawing. This service should be used when files 
      // needs to be updated. The ticket will be valid to upload 2 files. Summary: Gets an upload ticket 
      // for an existing Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string drawingId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:AuthoringFile/CheckinTicket";

         return await PostIndividual<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/Attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Attach an object to the Drawing with a dependency link Summary: Attach an object
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Attach<T>(string drawingId, IAttachXCADDrawing request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Attach";

         return await PostIndividualFromResponseMemberProperty<T, IAttachXCADDrawing>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control of a Drawing Summary: Activate the Change Control
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> ChangeControl(string drawingId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/Locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Locate the drawing from an Engineering Item by completing the dependency link Summary: 
      // Locate the drawing from an Engineering Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IRelatedId>> Locate(ILocateXCADDrawing request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/Locate";

         return await PostCollectionFromResponseMemberProperty<IRelatedId, ILocateXCADDrawing>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/Modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Update a Drawing attributes and files Summary: Update a Drawing attributes and files
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Modify<T>(string drawingId, IModifyXCADDrawingWithFiles request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Modify";

         return await PostIndividualFromResponseMemberProperty<T, IModifyXCADDrawingWithFiles>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/dsxcad:VisualizationFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing Drawing visualization file Summary: Gets a 
      // download ticket for an existing Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetVisualizationFileDownloadTicket(string drawingId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dsxcad:VisualizationFile/DownloadTicket";

         return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing/{ID}/Detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach an object from the Drawing by deleting the dependency link Summary: Detach an 
      // object
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Detach<T>(string drawingId, IDetachXCADDrawing request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/Detach";

         return await PostIndividualFromResponseMemberProperty<T, IDetachXCADDrawing>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsxcad:Drawing/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Drawing attributes Summary: Modifies the Drawing attributes
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Modify<T>(string drawingId, IModifyXCADDrawing request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADDrawingMask), typeof(IXCADDrawingDetailMask), typeof(IXCADDrawingEnterpriseDetailMask), typeof(IXCADDrawingBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

         return await PatchIndividualFromResponseMemberProperty<T, IModifyXCADDrawing>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Drawing/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Drawing Summary: Delete a Drawing
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Drawing/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Change Control of a Drawing Summary: Delete a Change Control
      // <param name="drawingId">
      // Description: dsxcad:Drawing object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteChangeControl(string drawingId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing/{drawingId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a Drawing from attribute list Summary: Creating a Drawing
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADDrawings request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing";

         return await PostCollectionFromResponseMemberProperty<T, ICreateXCADDrawings>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Drawing
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a Drawing from attribute list Summary: Creating a Drawing
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADDrawingsFromTemplate request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Drawing";

         return await PostCollectionFromResponseMemberProperty<T, ICreateXCADDrawingsFromTemplate>(resourceURI, request);
      }
   }
}