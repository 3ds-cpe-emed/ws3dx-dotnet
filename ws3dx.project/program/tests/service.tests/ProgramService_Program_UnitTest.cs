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
using ws3dx.project.program.core.data.impl;
using ws3dx.project.program.core.service;
using ws3dx.project.program.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class ProgramService_Program_UnitTests : ProgramServiceTestsSetup
   {

      [TestCase("41DF2E16046E00006278C04E0018B05A")]
      public async Task GetProgram(string programId)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         IResponseProgramData ret = await programService.GetProgram(programId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IResponseProgram(string search, int skip, int top)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IResponseProgramData> ret = await programService.Search(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27")]
      public async Task Search_Full_IResponseProgram(string search)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IResponseProgramData> ret = await programService.Search(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAllPrograms()
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseProgramData> ret = await programService.GetAllPrograms();

         Assert.IsNotNull(ret);
      }

      [TestCase("41DF2E16046E00006278C04E0018B05A")]
      public async Task GetProgramProjects(string programId)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseProgramData> ret = await programService.GetProgramProjects(programId);

         Assert.IsNotNull(ret);
      }

      [TestCase("Program I title for ws")]
      public async Task CreateProgram(string _programTitle)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());

         IProgram program = new Program();
         program.Data = new ProgramData();
         program.Data.Title = _programTitle;
         IPrograms programs = new Programs();
         programs.Data = new List<IProgram>
         {
            program
         };

         try
         {
            IList<IResponseProgramData> ret = await programService.CreateProgram(programs);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }


      [TestCase("")]
      public async Task DeleteProgram(string programId)
      {
         ProgramService programService = ServiceFactoryCreate(await Authenticate());


         try
         {
            IResponseEmpty ret = await programService.DeleteProgram(programId);

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