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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.project.project.core.data.impl;
using ws3dx.project.project.core.service;
using ws3dx.project.project.data;

namespace NUnitTestProject
{
   public class ProjectService_Project_UnitTests : ProjectServiceTestsSetup
   {
      [TestCase("41DF2E16046E00006278C0B200000350")]
      public async Task GetProjectIssues(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseIssueData> ret = await projectService.GetProjectIssues(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAllProjects()
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseProjectData> ret = await projectService.GetAllProjects();

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProjectIssue(string projectId, string issueId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IResponseIssueData ret = await projectService.GetProjectIssue(projectId, issueId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProgramProjects(string programId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseProjectData> ret = await projectService.GetProgramProjects(programId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProject(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IResponseProjectData ret = await projectService.GetProject(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("Project I from ws")]
      public async Task CreateProject(string _projectTitle)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IProject project = new Project
         {
            Data = new ProjectData()
            {
               Title = _projectTitle,
            }
         };

         IProjects projects = new Projects
         {
            Data = new List<IProject>
            {
               project
            }
         };

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
      public async Task DeleteProject(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IResponseEmpty ret = await projectService.DeleteProject(projectId);

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