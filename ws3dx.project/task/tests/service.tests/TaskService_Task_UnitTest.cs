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
using NUnit.Framework;
using System.Collections.Generic;
using ws3dx.core.exception;
using ws3dx.project.task.core.data.impl;
using ws3dx.project.task.core.service;
using ws3dx.project.task.data;
using Task = System.Threading.Tasks.Task;
using WS3DX = ws3dx.project.task.core.data.impl;

namespace NUnitTestProject
{
   public class TaskService_Task_UnitTests : TaskServiceTestsSetup
   {

      [TestCase("")]
      public async Task GetTaskReferences(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseReferenceData> ret = await taskService.GetTaskReferences(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("A0EA6A14EC2400006363763A0004E226")]
      public async Task GetTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IResponseTaskData ret = await taskService.GetTask(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("A0EA6A14EC2400006363763A0004E226")]
      public async Task GetTaskAssignees(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseAssigneeData> ret = await taskService.GetTaskAssignees(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("795A0F6C3253000061FDA1A70013466B")]
      public async Task GetTaskScopes(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseScopeData> ret = await taskService.GetTaskScopes(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("FDBEB6D4D7020000639849FE0001DE07")]
      public async Task GetTasksWithScope(string scopeId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseTaskData> ret = await taskService.GetTasksWithScope(scopeId);

         Assert.IsNotNull(ret);
      }

      [TestCase("A0EA6A14EC2400006363763A0004E226")]
      public async Task GetTaskDeliverables(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseDeliverableData> ret = await taskService.GetTaskDeliverables(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase(true)]
      public async Task GetUserTasks(bool showProjectTasks)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseTaskData> ret = await taskService.GetUserTasks(showProjectTasks);

         foreach (IResponseTaskData taskData in ret)
         {
            IResponseTaskData taskDetail = await taskService.GetTask(taskData.Id);
            Assert.IsNotNull(taskDetail);

            Assert.AreEqual(taskDetail.Id, taskData.Id);
         }
      }

      [TestCase()]
      public async Task GetTasks()
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         // Comma-separated list of IDs to retrieve.
         const string idPayload = "A0EA6A14EC2400006363763A0004E226";

         try
         {
            IList<IResponseTaskData> ret = await taskService.GetTasks(idPayload);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddAssigneesToTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IAssignees assignees = new Assignees();

         try
         {
            IList<IResponseAssigneeData> ret = await taskService.AddAssigneesToTask(taskId, assignees);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddReferencesToTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IReferences references = new References();

         try
         {
            IList<IResponseReferenceData> ret = await taskService.AddReferencesToTask(taskId, references);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddDeliverablesToTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IDeliverables deliverables = new Deliverables();

         try
         {
            IList<IResponseDeliverableData> ret = await taskService.AddDeliverablesToTask(taskId, deliverables);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddScopesToTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());

         IScopes scopes = new Scopes();

         try
         {
            IList<IResponseScopeData> ret = await taskService.AddScopesToTask(taskId, scopes);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }


      [TestCase("Task III from ws", "Task IV from ws")]
      public async Task CreateTask(string _task1Title, string _task2Title)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());


         ITaskData taskData1 = new WS3DX.TaskData();
         taskData1.Title = _task1Title;

         ITaskData taskData2 = new WS3DX.TaskData();
         taskData2.Title = _task2Title;

         ITask task1 = new WS3DX.Task();
         task1.Data = taskData1;

         ITask task2 = new WS3DX.Task();
         task2.Data = taskData2;

         ITasks tasks = new Tasks();
         tasks.Data = new List<ITask>();
         tasks.Data.Add(task1);
         tasks.Data.Add(task2);

         try
         {
            IList<IResponseTaskData> ret = await taskService.CreateTask(tasks);
            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DeleteTask(string taskId)
      {
         TaskService taskService = ServiceFactoryCreate(await Authenticate());


         try
         {
            IRESULTS_EMPTY ret = await taskService.DeleteTask(taskId);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}