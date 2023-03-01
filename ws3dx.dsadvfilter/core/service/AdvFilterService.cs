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
using ws3dx.dsadvfilter.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;

namespace ws3dx.dsadvfilter.core.service
{
   // SDK Service
   public class AdvFilterService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsadvfilter/";

      public AdvFilterService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/dsadvfilter:AdvFilter/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IAdvancedFilterMask), typeof(IAdvancedFilterSpecMask) };
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
      // (GET) /dsadvfilter:AdvFilter/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Advanced Filter Summary: Gets a Advanced Filter
      // <param name="ID">
      // Description: dsadvfilter:AdvFilter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string ID)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAdvancedFilterMask), typeof(IAdvancedFilterSpecMask) });

         string resourceURI = $"{GetBaseResource()}/dsadvfilter:AdvFilter/{ID}";


         return await GetMultiple<T>(resourceURI);
      }





      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsadvfilter:AdvFilter
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates an Advanced Filter Summary: Creates an Advanced Filter
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateAdvancedFilters request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAdvancedFilterMask), typeof(IAdvancedFilterSpecMask) });

         string resourceURI = $"{GetBaseResource()}/dsadvfilter:AdvFilter";


         return await PostRequestMultiple<T, ICreateAdvancedFilters>(resourceURI, request);

      }




      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsadvfilter:AdvFilter/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get all filters related to given object Summary: Get all filters related to given 
      // object
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ILocateAdvancedFilterResponse>> Locate(ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}/dsadvfilter:AdvFilter/locate";


         return await PostRequestMultiple<ILocateAdvancedFilterResponse, ITypedUriIdentifier[]>(resourceURI, request);

      }




      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsadvfilter:AdvFilter/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Advanced Filter attributes Summary: Modifies the Advanced Filter attributes
      // <param name="ID">
      // Description: dsadvfilter:AdvFilter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Update<T>(string ID, IUpdateAdvancedFilter request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAdvancedFilterMask), typeof(IAdvancedFilterSpecMask) });

         string resourceURI = $"{GetBaseResource()}/dsadvfilter:AdvFilter/{ID}";


         return await PatchGroup<T, IUpdateAdvancedFilter>(resourceURI, request);

      }



   }
}