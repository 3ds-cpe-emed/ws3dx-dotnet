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
   public class OrganizationalResourceService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrsc/";

      public OrganizationalResourceService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{ID}/dsrsc:ResourceItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Resource Item Instances Summary: Gets all the Resource Item Instances
      // <param name="orgResourceId">
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
      public async Task<IEnumerable<T>> GetResourceItemInstances<T>(string orgResourceId, int top, int skip)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:ResourceItemInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{PID}/dsrsc:ScopeLink
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get Mfg Process reference from Organizational Resource Summary: Get Mfg Process 
      // reference from Organizational Resource
      // <param name="orgResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IScopeLinkMask>> GetScopeLinks(string orgResourceId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:ScopeLink";

         return await GetCollectionFromResponseMemberProperty<IScopeLinkMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{PID}/dsrsc:OrganizationalResourceInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource Instance Summary: Gets a Resource Instance
      // <param name="organizationalResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:OrganizationalResourceInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IOrganizationalResourceInstanceMask> GetInstance(string organizationalResourceId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:OrganizationalResourceInstance/{instanceId}";

         return await GetIndividualFromResponseMemberProperty<IOrganizationalResourceInstanceMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{PID}/dsrsc:WorkerInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource Instance Summary: Gets a Resource Instance
      // <param name="organizationalResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:WorkerInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetWorkerInstance<T>(string organizationalResourceId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerInstanceMask), typeof(IWorkerInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:WorkerInstance/{instanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{PID}/dsrsc:ResourceItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource Instance Summary: Gets a Resource Instance
      // <param name="organizationalResourceId">
      // Description: dsrsc:ResourceItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:ResourceItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetResourceItemInstance<T>(string organizationalResourceId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:ResourceItemInstance/{instanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Resource type Summary: Gets a Resource
      // <param name="orgResourceId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string orgResourceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOrganizationalResourceMask), typeof(IOrganizationalResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{PID}/dsrsc:ImplementLink/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get implemented Mfg Process and implementing Resources Summary: Get implemented Mfg 
      // Process and implementing Resources
      // <param name="orgResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // <param name="implementLinkId">
      // Description: Implement Link ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IImplementLinkMask> GetImplementLink(string orgResourceId, string implementLinkId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:ImplementLink/{implementLinkId}";

         return await GetIndividualFromResponseMemberProperty<IImplementLinkMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{ID}/dsrsc:OrganizationalResourceInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Organizational Resource Instances Summary: Gets all the Organizational 
      // Resource Instances
      // <param name="orgResourceId">
      // Description: dsrsc:OrganizationalResource object ID
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
      public async Task<IEnumerable<IOrganizationalResourceInstanceMask>> GetInstances(string orgResourceId, int top, int skip)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:OrganizationalResourceInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<IOrganizationalResourceInstanceMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsrsc:OrganizationalResource/{ID}/dsrsc:WorkerInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all the Worker Instances Summary: Gets all the Worker Instances
      // <param name="orgResourceId">
      // Description: dsrsc:Worker object ID
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
      public async Task<IEnumerable<T>> GetWorkerInstances<T>(string orgResourceId, int top, int skip)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerInstanceMask), typeof(IWorkerInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:WorkerInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top.ToString());
         queryParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:OrganizationalResource
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Resource reference Items. Summary: Creates Resource reference Items.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateOrganizationalResources request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOrganizationalResourceMask), typeof(IOrganizationalResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource";

         return await PostCollectionFromResponseMemberProperty<T, ICreateOrganizationalResources>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:OrganizationalResource/{ID}/dsrsc:WorkerInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Worker Instance to a Resource Item Reference. Summary: Create Worker Instance.
      // <param name="orgResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> CreateWorkerInstance<T>(string orgResourceId, ICreateWorkerInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerInstanceMask), typeof(IWorkerInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:WorkerInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateWorkerInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:OrganizationalResource/{ID}/dsrsc:ResourceItemInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Resource Item Instance to a Resource Item Reference. Summary: Create Resource 
      // Item Instance.
      // <param name="orgResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> CreateResourceItemInstance<T>(string orgResourceId, ICreateResourceItemInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:ResourceItemInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateResourceItemInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:OrganizationalResource/{ID}/dsrsc:OrganizationalResourceInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Organizational Resource Instance to a Organizational Resource Reference. 
      // Summary: Create Organizational Resource Instance.
      // <param name="orgResourceId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IOrganizationalResourceInstanceMask>> CreateInstance(string orgResourceId, ICreateOrganizationalResourceInstances request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}/dsrsc:OrganizationalResourceInstance";

         return await PostCollectionFromResponseMemberProperty<IOrganizationalResourceInstanceMask, ICreateOrganizationalResourceInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsrsc:OrganizationalResource/bulkUpdate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to update Organizational Resources Reference attributes. Summary: Service to 
      // update Organizational Resources attributes.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> BulkUpdate(IBulkUpdateOrganizationalResource[] request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/bulkUpdate";

         return await PostIndividual<IGenericResponse, IBulkUpdateOrganizationalResource[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:OrganizationalResource/{PID}/dsrsc:ResourceItemInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Resource Item Instance attributes Summary: Modifies the Resource Item 
      // Instance attributes
      // <param name="organizationalResourceId">
      // Description: dsrsc:ResourceItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:ResourceItemInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateResourceItemInstance<T>(string organizationalResourceId, string instanceId, IUpdateResourceItemInstance request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IResourceItemInstanceMask), typeof(IResourceItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:ResourceItemInstance/{instanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IUpdateResourceItemInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:OrganizationalResource/{PID}/dsrsc:WorkerInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Worker Instance attributes Summary: Modifies the Worker Instance attributes
      // <param name="organizationalResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:WorkerInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateWorkerInstance<T>(string organizationalResourceId, string instanceId, IUpdateWorkerInstance request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IWorkerInstanceMask), typeof(IWorkerInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:WorkerInstance/{instanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IUpdateWorkerInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:OrganizationalResource/{PID}/dsrsc:OrganizationalResourceInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Organizational Resource Instance attributes Summary: Modifies the 
      // Organizational Resource Instance attributes
      // <param name="organizationalResourceId">
      // Description: dsrsc:OrganizationalResource object ID
      // </param>
      // <param name="instanceId">
      // Description: dsrsc:OrganizationalResourceInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IOrganizationalResourceInstanceMask> UpdateInstance(string organizationalResourceId, string instanceId, IUpdateOrganizationalResourceInstance request)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{organizationalResourceId}/dsrsc:OrganizationalResourceInstance/{instanceId}";

         return await PatchIndividualFromResponseMemberProperty<IOrganizationalResourceInstanceMask, IUpdateOrganizationalResourceInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dsrsc:OrganizationalResource/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies an Organizational Resource Reference attributes Summary: Modifies an 
      // Organizational Resource Reference attributes
      // <param name="orgResourceId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string orgResourceId, IUpdateOrganizationalResource request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOrganizationalResourceMask), typeof(IOrganizationalResourceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IUpdateOrganizationalResource>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsrsc:OrganizationalResource/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete an Organizational Resource Reference Summary: Delete an Organizational Resource 
      // Reference
      // <param name="orgResourceId">
      // Description: dsrsc:Resource object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string orgResourceId)
      {
         string resourceURI = $"{GetBaseResource()}dsrsc:OrganizationalResource/{orgResourceId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}