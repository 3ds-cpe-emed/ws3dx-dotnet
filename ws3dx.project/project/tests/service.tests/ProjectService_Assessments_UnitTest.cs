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
using System.Threading.Tasks;
using ws3dx.core.exception;
using ws3dx.project.project.core.data.impl;
using ws3dx.project.project.core.service;
using ws3dx.project.project.data;

namespace NUnitTestProject
{
   public class ProjectService_Assessments_UnitTests : ProjectServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetProjectAssessment(string projectId, string assessmentId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IResponseAssessmentData ret = await projectService.GetProjectAssessment(projectId, assessmentId);

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C0B200000350", "true")]
      public async Task GetProjectAssessments(string projectId, string allAssessments)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         System.Collections.Generic.IList<IResponseAssessmentData> ret = await projectService.GetProjectAssessments(projectId, allAssessments);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddProjectAssessment(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

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

      [TestCase("", "")]
      public async Task DeleteProjectAssessment(string projectId, string assessmentId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IResponseEmpty ret = await projectService.DeleteProjectAssessment(projectId, assessmentId);

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