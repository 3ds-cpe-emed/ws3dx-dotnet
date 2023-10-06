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
   public class ProjectService_Folders_UnitTests : ProjectServiceTestsSetup
   {
      [TestCase("")]
      public async Task GetProjectFolder(string folderId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         IResponseFolderData ret = await projectService.GetProjectFolder(folderId);

         Assert.IsNotNull(ret);
      }

      [TestCase("795A0F6C8258000061EE87240011621A")]
      public async Task GetProjectFolders(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         System.Collections.Generic.IList<IResponseFolderData> ret = await projectService.GetProjectFolders(projectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddProjectFolder(string projectId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

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

      [TestCase("", "")]
      public async Task DeleteProjectFolder(string projectId, string folderId)
      {
         ProjectService projectService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IResponseEmpty ret = await projectService.DeleteProjectFolder(projectId, folderId);

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