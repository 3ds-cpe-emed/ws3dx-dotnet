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
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.project.task.data;

namespace ws3dx.project.task.core.service
{
   // SDK Service
   public class TaskService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler";

      public TaskService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      protected override string GetMaskParamName() { return null; }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/{taskId}/references
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the task references.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseReferenceData>> GetTaskReferences(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/references";

         return await GetGroup<IResponseReferenceData, IResponseReference>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/{taskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Retrive an existing task information.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseTaskData> GetTask(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

         return await GetIndividual<IResponseTaskData, IResponseTask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/{taskId}/assignees
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Retrieve assignees for an existing task.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseAssigneeData>> GetTaskAssignees(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/assignees";

         return await GetGroup<IResponseAssigneeData, IResponseAssignee>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/{taskId}/scopes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Retrieve tha tasks context/scope object(s).
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseScopeData>> GetTaskScopes(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/scopes";

         return await GetGroup<IResponseScopeData, IResponseScope>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/scopeId/{scopeId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Retrieve tha tasks for a given context/scope object.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseTaskData>> GetTasksWithScope(string scopeId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/scopeId/{scopeId}";

         return await GetGroup<IResponseTaskData, IResponseTask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks/{taskId}/deliverables
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the task deliverables.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseDeliverableData>> GetTaskDeliverables(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/deliverables";

         return await GetGroup<IResponseDeliverableData, IResponseDeliverable>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /tasks
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the user assigned/owned tasks.
      // <param name="showProjectTasks">
      // Description: whether to include project tasks
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IList<IResponseTaskData>> GetUserTasks(bool showProjectTasks)
      {
         string resourceURI = $"{GetBaseResource()}/tasks";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "showProjectTasks", showProjectTasks.ToString() }
         };

         return await GetGroup<IResponseTaskData, IResponseTask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks/ids
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the user assigned tasks for the specified task objects.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseTaskData>> GetTasks(string _idPayload)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/ids";

         return await PostGroup<IResponseTaskData, IResponseTask, string>(resourceURI, _idPayload);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks/{taskId}/assignees
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Add new assignees for an existing task.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseAssigneeData>> AddAssigneesToTask(string taskId, IAssignees assignees)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/assignees";

         return await PostGroup<IResponseAssigneeData, IResponseAssignee, IAssignees>(resourceURI, assignees);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks/{taskId}/references
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Add new task references.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseReferenceData>> AddReferencesToTask(string taskId, IReferences references)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/references";

         return await PostGroup<IResponseReferenceData, IResponseReference, IReferences>(resourceURI, references);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks/{taskId}/deliverables
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Add new task deliverables.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseDeliverableData>> AddDeliverablesToTask(string taskId, IDeliverables deliverables)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/deliverables";

         return await PostGroup<IResponseDeliverableData, IResponseDeliverable, IDeliverables>(resourceURI, deliverables);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks/{taskId}/scopes
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Add specified Scope object(s) to the specific Task object.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseScopeData>> AddScopesToTask(string taskId, IScopes scopes)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/scopes";

         return await PostGroup<IResponseScopeData, IResponseScope, IScopes>(resourceURI, scopes);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /tasks
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Create new task(s).
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseTaskData>> CreateTask(ITasks tasks)
      {
         string resourceURI = $"{GetBaseResource()}/tasks";

         return await PostGroup<IResponseTaskData, IResponseTask, ITasks>(resourceURI, tasks);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /tasks/{taskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update an existing task information.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseTaskData> UpdateTask(string taskId, ITasks tasks)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

         return await PutIndividual<IResponseTaskData, IResponseTask, ITasks>(resourceURI, tasks);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /tasks
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Modify existing task(s).
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IList<IResponseTaskData>> UpdateTasks(ITasks tasks)
      {
         string resourceURI = $"{GetBaseResource()}/tasks";

         return await PutGroup<IResponseTaskData, IResponseTask, ITasks>(resourceURI, tasks);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /tasks/{taskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete an existing task.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IRESULTS_EMPTY> DeleteTask(string taskId)
      {
         string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

         return await DeleteIndividual<IRESULTS_EMPTY>(resourceURI);
      }
   }
}