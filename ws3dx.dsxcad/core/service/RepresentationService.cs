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
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Representation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of a CAD Specific Data Summary: Gets a Change Control of a CAD 
      // Specific Data
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlMask>> GetChangeControl(string representationId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

         return await GetMultiple<IChangeControlMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Representation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Specific Data Summary: Gets a CAD Specific Data
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string representationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Representation/{ID}/dsxcad:xCADAttributes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets CAD specific attributes of a CAD Specific Data Summary: Gets CAD specific 
      // attributes of a CAD Specific Data
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IXCADAttributesMask>> GetXCADAttributes(string representationId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:xCADAttributes";

         return await GetMultiple<IXCADAttributesMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:Representation/{ID}/dsxcad:AuthoringFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Authoring File of an dsxcad:Representation Summary: Gets a CAD Authoring 
      // File of an dsxcad:Representation
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string representationId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile";

         return await GetMultiple<IAuthoringFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/dsxcad:AuthoringFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing CAD Specific Data authoring file Summary: Gets 
      // a download ticket for an existing CAD Specific Data authoring file
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string representationId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile/DownloadTicket";

         return await PostRequest<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control of a CAD Specific Data Summary: Activate the Change Control
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> ChangeControl(string representationId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

         return await PostRequest<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/Attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Attach an object to the CAD Specific Data with a dependency link Summary: Attach an 
      // object
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Attach<T>(string representationId, IAttachXCADRepresentation request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Attach";

         return await PostRequestMultiple<T, IAttachXCADRepresentation>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a CAD Specific Data from attribute list Summary: Creating a CAD Specific 
      // Data
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADReferences request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation";

         return await PostRequestMultiple<T, ICreateXCADReferences>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/dsxcad:AuthoringFile/CheckinTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets an upload ticket for an existing CAD Specific Data. This service should be used 
      // when files needs to be updated. The ticket will be valid to upload the 1 file Summary: Gets an 
      // upload ticket for an existing CAD Specific Data
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileCheckinTicket> GetAuthoringFileCheckinTicket(string representationId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dsxcad:AuthoringFile/CheckinTicket";

         return await PostRequest<IFileCheckinTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/Locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Locate the CAD Specific Data from an Engineering Item by navigating the dependency 
      // link Summary: Locate a CAD Specific Data from an Engineering Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IEnterpriseItemNumberMask>> Locate(ILocateXCADRepresentations request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/Locate";

         return await PostRequestMultiple<IEnterpriseItemNumberMask, ILocateXCADRepresentations>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/Modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Update a CAD Specific Data attributes and files Summary: Update a CAD Specific Data 
      // attributes and files
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Modify<T>(string representationId, IModifyXCADRepresentationWithFiles request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Modify";

         return await PostRequestMultiple<T, IModifyXCADRepresentationWithFiles>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Representation/{ID}/Detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach an object from the CAD Specific Data by deleting the dependency link Summary: 
      // Detach an object
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Detach<T>(string representationId, IDetachXCADRepresentation request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/Detach";

         return await PostRequestMultiple<T, IDetachXCADRepresentation>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsxcad:Representation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the CAD Specific Data attributes Summary: Modifies the CAD Specific Data 
      // attributes
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Modify<T>(string representationId, IModifyXCADRepresentation request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADRepresentationMask), typeof(IXCADRepresentationDetailMask), typeof(IXCADRepresentationBasicMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

         return await PatchGroup<T, IModifyXCADRepresentation>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Representation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a CAD Specific Data Summary: Delete a CAD Specific Data
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string representationId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsxcad:Representation/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Change Control of a a CAD Specific Data Summary: Delete a Change Control
      // <param name="representationId">
      // Description: dsxcad:Representation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteChangeControl(string representationId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Representation/{representationId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}