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
   public class FamilyRepresentationService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

      public FamilyRepresentationService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsxcad:FamilyRepresentation/Search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IXCADFamilyRepMask), typeof(IXCADFamilyRepBasicMask), typeof(IXCADFamilyRepDetailMask) };
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
      // (GET) dsxcad:FamilyRepresentation/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Family Summary: Gets a Family
      // <param name="familyRepId">
      // Description: dsxcad:FamilyRepresentation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string familyRepId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADFamilyRepMask), typeof(IXCADFamilyRepBasicMask), typeof(IXCADFamilyRepDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:FamilyRepresentation/{familyRepId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:FamilyRepresentation/{ID}/dsxcad:xCADAttributes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Extension of an dsxcad:FamilyRepresentation Summary: Gets a CAD Extension 
      // of an dsxcad:FamilyRepresentation
      // <param name="familyRepId">
      // Description: dsxcad:FamilyRepresentation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IXCADAttributesMask>> GetXCADAttributes(string familyRepId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:FamilyRepresentation/{familyRepId}/dsxcad:xCADAttributes";

         return await GetMultiple<IXCADAttributesMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsxcad:FamilyRepresentation/{ID}/dsxcad:AuthoringFile
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Authoring File of an dsxcad:FamilyRepresentation Summary: Gets a CAD 
      // Authoring File of an dsxcad:FamilyRepresentation
      // <param name="familyRepId">
      // Description: dsxcad:FamilyRepresentation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IAuthoringFileMask>> GetAuthoringFile(string familyRepId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:FamilyRepresentation/{familyRepId}/dsxcad:AuthoringFile";

         return await GetMultiple<IAuthoringFileMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:FamilyRepresentation/{ID}/dsxcad:AuthoringFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing family representation authoring file Summary: 
      // Gets a download ticket for an existing family representation authoring file
      // <param name="familyRepId">
      // Description: dsxcad:FamilyRepresentation object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string familyRepId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:FamilyRepresentation/{familyRepId}/dsxcad:AuthoringFile/DownloadTicket";

         return await PostRequest<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:FamilyRepresentation/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Locate the family from an Engineering Item by completing the dependency link Summary: 
      // Locate the family from an Engineering Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IRepresentationIdentifiers> Locate(ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:FamilyRepresentation/locate";

         return await PostRequest<IRepresentationIdentifiers, ITypedUriIdentifier[]>(resourceURI, request);
      }
   }
}