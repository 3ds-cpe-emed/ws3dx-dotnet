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
using ws3dx.utils.search;

namespace ws3dx.dsxcad.core.service
{
   // SDK Service
   public class TemplateService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsxcad/";

      public TemplateService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsxcad:Template/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IXCADTemplateMask) };
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
      // (GET) dsxcad:Template/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a CAD Template Summary: Gets a CAD Template
      // <param name="templateId">
      // Description: dsxcad:Template object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IXCADTemplateMask> Get(string templateId)
      {
         string resourceURI = $"{GetBaseResource()}dsxcad:Template/{templateId}";

         return await GetIndividual<IXCADTemplateMask, NlsLabeledItemSet<IXCADTemplateMask>>(resourceURI);
      }
   }
}