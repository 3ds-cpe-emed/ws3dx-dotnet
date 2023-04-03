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
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.project.project.core.data.impl;
using ws3dx.project.project.core.service;
using ws3dx.project.project.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class ProjectServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";
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

      public ProjectService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         ProjectService __projectService = new ProjectService(_serviceUrl, _passport);
         __projectService.Tenant = _tenant;
         __projectService.SecurityContext = GetDefaultSecurityContext();
         return __projectService;
      }

      [TestCase("", "")]
      public async Task GetProjectRisk(string projectId, string riskId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseRiskData ret = await projectService.GetProjectRisk(projectId, riskId);

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350")]
      public async Task GetProjectIssues(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseIssueData> ret = await projectService.GetProjectIssues(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProjectAssessment(string projectId, string assessmentId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseAssessmentData ret = await projectService.GetProjectAssessment(projectId, assessmentId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAllProjects()
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseProjectData> ret = await projectService.GetAllProjects();

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350", "true")]
      public async Task GetProjectAssessments(string projectId, string allAssessments)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseAssessmentData> ret = await projectService.GetProjectAssessments(projectId, allAssessments);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProjectIssue(string projectId, string issueId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseIssueData ret = await projectService.GetProjectIssue(projectId, issueId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProgramProjects(string programId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseProjectData> ret = await projectService.GetProgramProjects(programId);

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350")]
      public async Task GetProjectRisks(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseRiskData> ret = await projectService.GetProjectRisks(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("795A0F6C8258000061EE87240011621A")]
      public async Task GetProjectFolder(string folderId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseFolderData ret = await projectService.GetProjectFolder(folderId);

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350")]
      public async Task GetProject(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IResponseProjectData ret = await projectService.GetProject(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350")]
      public async Task GetProjectFolders(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IList<IResponseFolderData> ret = await projectService.GetProjectFolders(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddProjectAssessment(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAssessments assessments = new Assessments();

         try
         {
            IResponseAssessmentData ret = await projectService.AddProjectAssessment(projectId, assessments);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("Project I from ws")]
      public async Task CreateProject(string _projectTitle)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IProject project = new Project();
         project.Data = new ProjectData();
         project.Data.Title = _projectTitle;

         IProjects projects = new Projects();
         projects.Data = new List<IProject>();
         projects.Data.Add(project);

         try
         {
            IResponseProjectData ret = await projectService.CreateProject(projects);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddProjectFolder(string projectId)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IFolders folders = new Folders();

         try
         {
            IResponseFolderData ret = await projectService.AddProjectFolder(projectId, folders);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27")]
      public async Task SearchProject(string _searchCriteria)
      {
         IPassportAuthentication passport = await Authenticate();

         ProjectService projectService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IList<IResponseProjectData> ret = await projectService.Search(new SearchByFreeText(_searchCriteria));

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