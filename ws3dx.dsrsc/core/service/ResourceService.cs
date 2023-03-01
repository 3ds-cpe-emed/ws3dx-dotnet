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
using ws3dx.dsrsc.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;

namespace ws3dx.dsrsc.core.service
{
   // SDK Service
   public class ResourceService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrsc/";

      public ResourceService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsrsc:Resource/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IItem), typeof(IResourceDetail) };
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
      // (GET) dsrsc:Resource/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource type Summary: Gets a Resource
      // <param name="resId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string resId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceMask), typeof(IResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:Resource/{resId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:Resource/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets the Resource object reference (the URL path for Resource corpus) of the given 
      // external objects if they exist. Summary: Locate/find external objects in Resource corpus.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IResourceLocated>> Locate(ILocateResource request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:Resource/locate";

         return await PostRequestMultiple<IResourceLocated, ILocateResource>(resourceURI, request);
      }
   }
}