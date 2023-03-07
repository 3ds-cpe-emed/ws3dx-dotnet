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
using ws3dx.dsxcad.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsxcad.core.service
{
   // SDK Service
   public class ProductService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

      public ProductService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsxcad:Product/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IXCADProductMask), typeof(IXCADProductDetailMask), typeof(IXCADProductEnterpriseDetailMask) };
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
      // (GET) dsxcad:Product/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Product Summary: Gets a CAD Product
      // <param name="productId">
      // Description: dsxcad:Product object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string productId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADProductMask), typeof(IXCADProductDetailMask), typeof(IXCADProductEnterpriseDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Product/{productId}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Product/{ID}/dsxcad:AuthoringFile/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a download ticket for an existing Assembly authoring file Summary: Gets a download 
      // ticket for an existing Assembly authoring file
      // <param name="productId">
      // Description: dsxcad:Part object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileDownloadTicket> GetAuthoringFileDownloadTicket(string productId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Product/{productId}/dsxcad:AuthoringFile/DownloadTicket";

         return await PostIndividual<IFileDownloadTicket, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsxcad:Product
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creating a Product from a CAD Template Summary: Creating a Product
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateXCADProductsFromTemplate request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IXCADProductMask), typeof(IXCADProductDetailMask), typeof(IXCADProductEnterpriseDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsxcad:Product";

         return await PostGroup<T, NlsLabeledItemSet<T>, ICreateXCADProductsFromTemplate>(resourceURI, request);
      }
   }
}