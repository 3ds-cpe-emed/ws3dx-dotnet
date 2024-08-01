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

namespace ws3dx.project.task.service
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

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the user assigned/owned tasks.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="showProjectTasks">
        /// whether to include project tasks
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseTaskData>> GetUserTasks(bool showProjectTasks)
        {
            string resourceURI = $"{GetBaseResource()}/tasks";

            IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "showProjectTasks", showProjectTasks.ToString() }
         };

            return await GetCollectionFromResponseDataProperty<IResponseTaskData>(resourceURI, queryParams: queryParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Modify existing task(s).
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PUT) /tasks
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="tasks">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseTaskData>> UpdateTasks(ITasks tasks)
        {
            string resourceURI = $"{GetBaseResource()}/tasks";

            return await PutCollectionFromResponseDataProperty<IResponseTaskData, ITasks>(resourceURI, tasks);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Create new task(s).
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="tasks">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseTaskData>> CreateTask(ITasks tasks)
        {
            string resourceURI = $"{GetBaseResource()}/tasks";

            return await PostCollectionFromResponseDataProperty<IResponseTaskData, ITasks>(resourceURI, tasks);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieve assignees for an existing task.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/{taskId}/assignees
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseAssigneeData>> GetTaskAssignees(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/assignees";

            return await GetCollectionFromResponseDataProperty<IResponseAssigneeData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Add new assignees for an existing task.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks/{taskId}/assignees
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        /// <param name="assignees">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseAssigneeData>> AddAssigneesToTask(string taskId, IAssignees assignees)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/assignees";

            return await PostCollectionFromResponseDataProperty<IResponseAssigneeData, IAssignees>(resourceURI, assignees);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the task deliverables.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/{taskId}/deliverables
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseDeliverableData>> GetTaskDeliverables(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/deliverables";

            return await GetCollectionFromResponseDataProperty<IResponseDeliverableData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Add new task deliverables.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks/{taskId}/deliverables
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        /// <param name="deliverables">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseDeliverableData>> AddDeliverablesToTask(string taskId, IDeliverables deliverables)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/deliverables";

            return await PostCollectionFromResponseDataProperty<IResponseDeliverableData, IDeliverables>(resourceURI, deliverables);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the user assigned tasks for the specified task objects.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks/ids
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// 
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseTaskData>> GetTasks(string _idPayload)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/ids";

            return await PostCollectionFromResponseDataProperty<IResponseTaskData, string>(resourceURI, _idPayload);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the task references.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/{taskId}/references
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseReferenceData>> GetTaskReferences(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/references";

            return await GetCollectionFromResponseDataProperty<IResponseReferenceData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Add new task references.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks/{taskId}/references
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        /// <param name="references">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseReferenceData>> AddReferencesToTask(string taskId, IReferences references)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/references";

            return await PostCollectionFromResponseDataProperty<IResponseReferenceData, IReferences>(resourceURI, references);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieve tha tasks context/scope object(s).
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/{taskId}/scopes
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseScopeData>> GetTaskScopes(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/scopes";

            return await GetCollectionFromResponseDataProperty<IResponseScopeData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Add specified Scope object(s) to the specific Task object.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) /tasks/{taskId}/scopes
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        /// <param name="scopes">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseScopeData>> AddScopesToTask(string taskId, IScopes scopes)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}/scopes";

            return await PostCollectionFromResponseDataProperty<IResponseScopeData, IScopes>(resourceURI, scopes);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieve tha tasks for a given context/scope object.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/scopeId/{scopeId}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="scopeId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IList<IResponseTaskData>> GetTasksWithScope(string scopeId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/scopeId/{scopeId}";

            return await GetCollectionFromResponseDataProperty<IResponseTaskData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrive an existing task information.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (GET) /tasks/{taskId}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IResponseTaskData> GetTask(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

            return await GetIndividualFromResponseDataProperty<IResponseTaskData>(resourceURI);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Update an existing task information.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (PUT) /tasks/{taskId}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        /// <param name="tasks">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IResponseTaskData> UpdateTask(string taskId, ITasks tasks)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

            return await PutIndividualFromResponseDataProperty<IResponseTaskData, ITasks>(resourceURI, tasks);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete an existing task.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (DELETE) /tasks/{taskId}
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="taskId">
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IRESULTS_EMPTY> DeleteTask(string taskId)
        {
            string resourceURI = $"{GetBaseResource()}/tasks/{taskId}";

            return await DeleteIndividual<IRESULTS_EMPTY>(resourceURI);
        }
    }
}