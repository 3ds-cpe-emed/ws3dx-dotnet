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
using ws3dx.core.exception;
using ws3dx.dsreq.core.data.impl;
using ws3dx.dsreq.core.service;
using ws3dx.dsreq.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class ChapterService_Chapter_UnitTests : ChapterServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IChapterBaseMask(string search, int skip, int top)
      {
         ChapterService chapterService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IChapterBaseMask> ret = await chapterService.Search<IChapterBaseMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IChapterBaseMask(string search)
      {
         ChapterService chapterService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IChapterBaseMask> ret = await chapterService.Search<IChapterBaseMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get(string chapterId)
      {
         ChapterService chapterService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IChapterBaseMask> ret = await chapterService.Get(chapterId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create()
      {
         ChapterService chapterService = ServiceFactoryCreate(await Authenticate());

         ICreateChapter request = new CreateChapter();

         try
         {
            IEnumerable<IChapterBaseMask> ret = await chapterService.Create(request);

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