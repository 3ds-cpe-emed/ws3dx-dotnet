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
using System;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.project.task.core.data.impl;
using ws3dx.project.task.core.service;
using ws3dx.project.task.data;
using Task = System.Threading.Tasks.Task;

namespace NUnitTestProject
{
   public class TaskServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";
      const string SECURITY_CONTEXT = "VPLMProjectLeader.Company Name.AAA27 Personal";

      const string CUSTOM_PROP_NAME_1_DBL = "AAA27_REAL_TEST";
      const string CUSTOM_PROP_NAME_2_INT = "AAA27_INT_TEST";

      string m_username = string.Empty;
      string m_password = string.Empty;
      string m_passportUrl = string.Empty;
      string m_serviceUrl = string.Empty;
      string m_tenant = string.Empty;

      UserInfo m_userInfo = null;

      public async Task<IPassportAuthentication> Authenticate()
      {
         UserPassport passport = new UserPassport(m_passportUrl);

         UserInfoRedirection userInfoRedirection = new UserInfoRedirection(m_serviceUrl, m_tenant)
         {
            Current = true,
            IncludeCollaborativeSpaces = true,
            IncludePreferredCredentials = true
         };

         m_userInfo = await passport.CASLoginWithRedirection<UserInfo>(m_username, m_password, false, userInfoRedirection);

         Assert.IsNotNull(m_userInfo);

         StringAssert.AreEqualIgnoringCase(m_userInfo.name, m_username);

         Assert.IsTrue(passport.IsCookieAuthenticated);

         return passport;
      }

      [SetUp]
      public void Setup()
      {
         m_username = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_USERNAME, EnvironmentVariableTarget.User); // e.g. AAA27
         m_password = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSWORD, EnvironmentVariableTarget.User); // e.g. your password
         m_passportUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSPORT, EnvironmentVariableTarget.User); // e.g. https://eu1-ds-iam.3dexperience.3ds.com:443/3DPassport

         m_serviceUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_ENOVIA, EnvironmentVariableTarget.User); // e.g. https://r1132100982379-eu1-space.3dexperience.3ds.com:443/enovia
         m_tenant = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_TENANT, EnvironmentVariableTarget.User); // e.g. R1132100982379
      }

      public string GetDefaultSecurityContext()
      {
         return m_userInfo.preferredcredentials.ToString();
      }

      public TaskService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         TaskService __taskService = new TaskService(_serviceUrl, _passport);
         __taskService.Tenant = _tenant;
         __taskService.SecurityContext = GetDefaultSecurityContext();
         return __taskService;
      }

      [TestCase("")]
      public async Task GetTaskReferences(string taskId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseReference ret = await taskService.GetTaskReferences(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetTask(string taskId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseTask ret = await taskService.GetTask(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetTaskAssignees(string taskId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseAssignee ret = await taskService.GetTaskAssignees(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetTaskScopes(string taskId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseScope ret = await taskService.GetTaskScopes(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetTasksWithScope(string scopeId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseTask ret = await taskService.GetTasksWithScope(scopeId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetTaskDeliverables(string taskId)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseDeliverable ret = await taskService.GetTaskDeliverables(taskId);

         Assert.IsNotNull(ret);
      }

      [TestCase(true)]
      public async Task GetUserTasks(bool showProjectTasks)
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseTask ret = await taskService.GetUserTasks(showProjectTasks);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetTasks()
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IResponseTask ret = await taskService.GetTasks();

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
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAssignees assignees = new Assignees();

         try
         {
            IResponseAssignee ret = await taskService.AddAssigneesToTask(taskId, assignees);

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
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IReferences references = new References();

         try
         {
            IResponseReference ret = await taskService.AddReferencesToTask(taskId, references);

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
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDeliverables deliverables = new Deliverables();

         try
         {
            IResponseDeliverable ret = await taskService.AddDeliverablesToTask(taskId, deliverables);

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
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IScopes scopes = new Scopes();

         try
         {
            IResponseScope ret = await taskService.AddScopesToTask(taskId, scopes);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task CreateTask()
      {
         IPassportAuthentication passport = await Authenticate();

         TaskService taskService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITasks tasks = new Tasks();

         try
         {
            IResponseTask ret = await taskService.CreateTask(tasks);

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