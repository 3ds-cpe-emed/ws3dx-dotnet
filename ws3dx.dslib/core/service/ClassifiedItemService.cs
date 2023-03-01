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
using ws3dx.shared.data;
using ws3dx.shared.utils;

namespace ws3dx.dslib.core.service
{
   // SDK Service
   public class ClassifiedItemService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dslib/";

      public ClassifiedItemService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dslib:ClassifiedItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets either the 'classification attributes (dslib:ClassificationAttributesMask)' or 
      // the 'reverse classification path (dslib:ReverseClassificationMask)' of the given Classified Item 
      // object depending on the mask used. Summary: Gets a given Classified Item information
      // <param name="clsItemId">
      // Description: dslib:ClassifiedItem object ID
      // </param>
      // <param name="classId">
      // Description: Applicable only when using the mask - dslib:ClassificationAttributesMask. To fetch 
      // the classification attributes (associated with a particular class in which this classified item 
      // is classified) along with their values, send the id of the required class in this parameter
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string clsItemId, string classId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IClassifiedItemBaseMask), typeof(IClassificationAttributesMask), typeof(IReverseClassificationMask) });

         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem/{clsItemId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$classId", classId);

         return await GetMultiple<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dslib:ClassifiedItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Classifies multiple external objects (public http resources) in a given Class and 
      // returns the object reference of respective Classified Item or failure message for each object. 
      // Maximum 50 objects are only allowed in a service call. Summary: Classifies the list of external 
      // objects (public http resources) in a given Class.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IClassificationStatusResponse> Create(IAddClassifiedItems request)
      {
         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem";

         return await PostRequest<IClassificationStatusResponse, IAddClassifiedItems>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dslib:ClassifiedItem/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Fetches the object reference of the Classified Item of a given external object (public 
      // http resource) if it exists. Summary: Fetches the Classified Item of a given object (public http 
      // resource)
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IClassifiedItemLocateResponse> Locate(ITypedUriIdentifier request)
      {
         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem/locate";

         return await PostRequest<IClassifiedItemLocateResponse, ITypedUriIdentifier>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dslib:ClassifiedItem/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the values of classification attributes of the given list of Classified Item 
      // objects. Maximum 50 objects are only allowed in a service call. Summary: Modifies the classification 
      // attributes of the given list of Classified Item objects
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Modify<T>(IModifyClassifiedItems[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IClassifiedItemBaseMask), typeof(IClassificationAttributesMask), typeof(IReverseClassificationMask) });

         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem/modify";

         return await PostRequestMultiple<T, IModifyClassifiedItems[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dslib:ClassifiedItem/remove
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Declassifies multiple external objects (public http resources) from a given Class 
      // and returns OK or failure message for each object. Maximum 50 objects are only allowed in a 
      // service call. Summary: Declassifies the external objects (public http resources) from a given 
      // Class
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDeclassificationStatusResponse> Remove(IRemoveClassifiedItem request)
      {
         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem/remove";

         return await PostRequest<IDeclassificationStatusResponse, IRemoveClassifiedItem>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dslib:ClassifiedItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the values of classification attributes of a given Classified Item object 
      // Summary: Modifies the classification attributes of a given Classified Item object
      // <param name="clsItemId">
      // Description: dslib:ClassifiedItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Update<T>(string clsItemId, IClassifiedItemAttributes request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IClassifiedItemBaseMask), typeof(IClassificationAttributesMask), typeof(IReverseClassificationMask) });

         string resourceURI = $"{GetBaseResource()}/dslib:ClassifiedItem/{clsItemId}";

         return await PatchGroup<T, IClassifiedItemAttributes>(resourceURI, request);
      }


   }
}