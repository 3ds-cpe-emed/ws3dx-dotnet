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
using ws3dx.data.collection.impl;
using ws3dx.dsrm.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsrm.core.service
{
   // SDK Service
   public class RawMaterialService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrm/";

      public RawMaterialService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/dsrm:RawMaterial/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IRawMaterialMask), typeof(IRawMaterialDetailMask) };
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
         return await Search<T, NlsLabeledItemSet<T>>(searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await Search<T, NlsLabeledItemSet<T>>(searchQuery, _skip, _top);
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsrm:RawMaterial/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets the Enterprise Reference of a Raw Material Summary: Gets the Enterprise Reference 
      // of a Raw Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnterpriseItemNumberMask> GetEnterpriseItemNumber(string rawMatId)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dseng:EnterpriseReference";

         return await GetIndividual<IEnterpriseItemNumberMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsrm:RawMaterial/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of a Raw Material Summary: Gets a Change Control of a Raw 
      // Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string rawMatId)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dslc:changeControl";

         return await GetGroup<IChangeControlStatusMask, NlsLabeledItemSet<IChangeControlStatusMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsrm:RawMaterial/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Raw Material Summary: Gets a Raw Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string rawMatId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IRawMaterialMask), typeof(IRawMaterialDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsrm:RawMaterial/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control Summary: Activate the Change Control
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> ActivateChangeControl(string rawMatId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsrm:RawMaterial
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Raw Material item (default values type:Raw_Material and dimensionType:Mass). 
      // Summary: Creates Raw Material item.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Create<T>(ICreateRawMaterial request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IRawMaterialMask), typeof(IRawMaterialDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial";

         return await PostIndividual<T, NlsLabeledItemSet<T>, ICreateRawMaterial>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsrm:RawMaterial/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Adding Enterprise Reference to a Raw Material Summary: Adding Enterprise Reference 
      // to a Raw Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> AddEnterpriseItemNumber(string rawMatId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dseng:EnterpriseReference";

         return await PostIndividual<IEnterpriseItemNumberMask, NlsLabeledItemSet<IEnterpriseItemNumberMask>, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsrm:RawMaterial/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Enterprise Reference of a Raw Material Summary: Modifies the Enterprise 
      // Reference of a Raw Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> UpdateEnterpriseItemNumber(string rawMatId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dseng:EnterpriseReference";

         return await PatchIndividual<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsrm:RawMaterial/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Raw Material attributes Summary: Modifies the Raw Material attributes
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string rawMatId, IUpdateRawMaterial request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IRawMaterialMask), typeof(IRawMaterialDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}";

         return await PatchIndividual<T, IUpdateRawMaterial>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /dsrm:RawMaterial/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Raw Material Summary: Delete a Raw Material
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string rawMatId)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /dsrm:RawMaterial/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deactivate the Change Control Summary: Deactivate the Change Control
      // <param name="rawMatId">
      // Description: dsrm:RawMaterial object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeactivateChangeControl(string rawMatId)
      {
         string resourceURI = $"{GetBaseResource()}/dsrm:RawMaterial/{rawMatId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}