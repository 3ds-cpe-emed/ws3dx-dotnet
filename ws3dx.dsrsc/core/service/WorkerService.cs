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
   public class WorkerService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrsc/";

      public WorkerService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:Worker/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Worker Resource type Summary: Gets a Worker Resource
      // <param name="workerId">
      // Description: dsrsc:WorkerResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string workerId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerResourceMask), typeof(IWorkerResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:Worker/{workerId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:Worker
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Worker reference. Summary: Creates Worker reference.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateWorkerResources request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerResourceMask), typeof(IWorkerResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:Worker";

         return await PostRequestMultiple<T, ICreateWorkerResources>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:Worker/bulkUpdate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to update Worker Resources Reference attributes. Summary: Service to update 
      // Worker Resources attributes.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> BulkUpdate(IBulkUpdateWorkerResource[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:Worker/bulkUpdate";

         return await PostRequest<IGenericResponse, IBulkUpdateWorkerResource[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:Worker/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies a Worker Reference attributes Summary: Modifies a Worker Reference attributes
      // <param name="workerId">
      // Description: dsrsc:WorkerResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Update<T>(string workerId, IUpdateOrganizationalResource request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerResourceMask), typeof(IWorkerResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:Worker/{workerId}";

         return await PatchGroup<T, IUpdateOrganizationalResource>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsrsc:Worker/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Worker Resource Reference Summary: Delete a Worker Resource Reference
      // <param name="workerId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string workerId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:Worker/{workerId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}