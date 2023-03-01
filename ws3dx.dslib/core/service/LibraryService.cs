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
using ws3dx.dslib.data;
using ws3dx.shared.utils;

namespace ws3dx.dslib.core.service
{
   // SDK Service
   public class LibraryService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dslib/";

      public LibraryService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/dslib:Library/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(ISimpleMask), typeof(ILibraryDetailMask) };
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
      // (GET) /dslib:Library/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets any of the following information of the given Library as per the mask used. 
      // 1 - The basic (dslib:SimpleMask) or additional information (dslib:LibraryDetailsMask) of given 
      // Library. 
      // 2 - Only those subclasses to which the user has Classify Access (dslib:ExpandClassifiableClassesMask). 
      // 3 - the basic (dslib:ExpandClassesMask) or additional information (dslib:ExpandClassesDetailsMask) 
      // of the subclasses under the given Library. Summary: Gets a given Library information
      // <param name="libId">
      // Description: dslib:Library object ID
      // </param>
      // <param name="depth">
      // Description: Applicable only while using the masks - dslib:ExpandClassesMask or dslib:ExpandClassesDetailsMask 
      // or dslib:ExpandClassifiableClassesMask. It is the number of levels to expand under the given 
      // Library. Default value is 5. Use a non-zero positive integer. Maximum allowed value is 20. Default 
      // value 5 will be used if more than 20 is provided. NOT recommended for taxonomies with more than 
      // 50 items.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string libId, string depth)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ISimpleMask), typeof(IExpandClassifiableClassesMask), typeof(IExpandClassesDetailMask), typeof(IExpandClassesMask), typeof(ILibraryDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dslib:Library/{libId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$depth", depth);

         return await GetMultiple<T>(resourceURI, queryParams: queryParams);
      }



   }
}