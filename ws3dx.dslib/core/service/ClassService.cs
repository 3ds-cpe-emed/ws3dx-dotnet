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
using ws3dx.dslib.data;
using ws3dx.shared.utils;

namespace ws3dx.dslib.core.service
{
   // SDK Service
   public class ClassService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dslib/";

      public ClassService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dslib:Class/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets any of the following information based on the mask used.
      //  1 - Class and it's parent (dslib:ClassMask).
      //  2 - Class and it's parent with additional information (dslib:ClassDetailsMask).
      //  3 - Only those subclasses to which the user has Classify Access (dslib:ExpandClassifiableClassesMask).
      //  4 - Subclasses under the given Class with basic (dslib:ExpandClassesMask) or additional information 
      // (dslib:ExpandClassesDetailsMask).
      //  5 - Class Attributes of the given Class (dslib:ClassAttributesMask).
      //  6 - Classified Items in the given Class (dslib:ClassifiedItemsMask). Summary: Gets a given Class 
      // information
      // <param name="clsId">
      // Description: dslib:Class object ID
      // </param>
      // <param name="depth">
      // Description: Applicable only while using the masks - dslib:ExpandClassesMask or dslib:ExpandClassesDetailsMask 
      // or dslib:ExpandClassifiableClassesMask. It is the number of levels to expand under the given 
      // Class. Default value is 5. Use a non-zero positive integer. Maximum allowed value is 20. Default 
      // value 5 will be used if more than 20 is provided. NOT recommended for taxonomies with more than 
      // 50 items.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string clsId, string depth)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IClassMask), typeof(IClassifiedItemsMask), typeof(IExpandClassesDetailMask), typeof(IExpandClassifiableClassesMask), typeof(IExpandClassesMask), typeof(IClassAttributesMask), typeof(IClassDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dslib:Class/{clsId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$depth", depth);

         return await GetGroup<T, NlsLabeledItemSet<T>>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dslib:Class/{ID}/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Fetches the filtered list of classified items under the taxonomy of given Class by 
      // performing index search on the given query (in UQL format) which has classification attributes 
      // (of the given class) and values. For more details on query formation, refer the technical article 
      // section: "About IP Classification Web Services" Summary: Fetches the classified items in a Class 
      // by filtering on the given search query having classification attributes and values
      // <param name="clsId">
      // Description: dslib:Class object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned from the search, accepts a maximum 
      // value of 1000.
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IClassifiedItemsMask>> Locate(string clsId, string top, string skip, IFilterAndFetchClassifiedItems request)
      {
         string resourceURI = $"{GetBaseResource()}/dslib:Class/{clsId}/locate";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top);
         queryParams.Add("$skip", skip);

         return await PostGroup<IClassifiedItemsMask, NlsLabeledItemSet<IClassifiedItemsMask>, IFilterAndFetchClassifiedItems>(resourceURI, request, queryParams: queryParams);
      }
   }
}