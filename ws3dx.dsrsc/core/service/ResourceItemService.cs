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
   public class ResourceItemService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrsc/";

      public ResourceItemService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:ResourceItem/{PID}/dsrsc:ResourceItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource Instance Summary: Gets a Resource Instance
      // <param name="resourceItemId">
      // Description: dsrsc:ResourceItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:ResourceItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetInstance<T>(string resourceItemId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resourceItemId}/dsrsc:ResourceItemInstance/{instanceId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:ResourceItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource Item reference Summary: Gets a Resource Item reference
      // <param name="resItemId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string resItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemMask), typeof(IResourceItemDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resItemId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:ResourceItem/{ID}/dsrsc:ResourceItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Resource Item Instances Summary: Gets all the Resource Item Instances
      // <param name="resItemId">
      // Description: dsrsc:ResourceItem object ID
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
      public async Task<IEnumerable<T>> GetInstances<T>(string resItemId, int top, int skip)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resItemId}/dsrsc:ResourceItemInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetMultiple<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:ResourceItem/{ID}/dsrsc:ResourceItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Resource Item Instance to a Resource Item Reference. Summary: Create Resource 
      // Item Instance.
      // <param name="resItemId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> CreateInstance<T>(string resItemId, ICreateResourceItemInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resItemId}/dsrsc:ResourceItemInstance";

         return await PostRequestMultiple<T, ICreateResourceItemInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:ResourceItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Resource Item Reference. Summary: Creates Resource Item Reference.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> ResourceItem<T>(ICreateResourceItems request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemMask), typeof(IResourceItemDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem";

         return await PostRequestMultiple<T, ICreateResourceItems>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:ResourceItem/bulkUpdate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to update Resource Item Reference attributes. Summary: Service to update 
      // Resource Item attributes.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> BulkUpdate(IBulkUpdateResourceItem[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/bulkUpdate";

         return await PostRequest<IGenericResponse, IBulkUpdateResourceItem[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:ResourceItem/{PID}/dsrsc:ResourceItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Resource Item Instance attributes Summary: Modifies the Resource Item 
      // Instance attributes
      // <param name="resourceItemId">
      // Description: dsrsc:ResourceItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:ResourceItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateInstance<T>(string resourceItemId, string instanceId, IUpdateResourceItemInstance request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resourceItemId}/dsrsc:ResourceItemInstance/{instanceId}";

         return await PatchGroup<T, IUpdateResourceItemInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:ResourceItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies a Resource Item Reference attributes Summary: Modifies a Resource Item 
      // Reference attributes
      // <param name="resItemId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Update<T>(string resItemId, IUpdateResourceItem request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemMask), typeof(IResourceItemDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resItemId}";

         return await PatchGroup<T, IUpdateResourceItem>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsrsc:ResourceItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Resource Item Reference Summary: Delete a Resource Item Reference
      // <param name="resItemId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string resItemId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:ResourceItem/{resItemId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}