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
using ws3dx.utils.search;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.authentication.data;
using ws3dx.core.exception;

namespace NUnitTestProject
{
   public class CheckListService_CheckList_UnitTests : CheckListServiceTestsSetup
   {
      [TestCase("")]
      public async Task GetDataCollectRows(string iD)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<ICheckListRowMask> ret = await checkListService.GetDataCollectRows(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectRow(string checkListId, string dataCollectRowId)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());

         ICheckListRowMask ret = await checkListService.GetDataCollectRow(checkListId, dataCollectRowId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_ICheckListMask(string iD)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());

         ICheckListMask ret = await checkListService.Get<ICheckListMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_ICheckListDetailMask(string iD)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());

        ICheckListDetailMask ret = await checkListService.Get<ICheckListDetailMask>(iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("check", 0, 50)]
      public async Task Search_Paged_ICheckListMask(string search, int skip, int top)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());
     
         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<ICheckListMask> ret = await checkListService.Search<ICheckListMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (ICheckListMask checkList in ret)
            {
               ICheckListDetailMask checkListDetail = await checkListService.Get<ICheckListDetailMask>(checkList.Id);

               Assert.AreEqual(checkList.Id, checkListDetail.Id);

               i++;

               if (i > 20) return;
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("search")]
      public async Task Search_Full_ICheckListMask(string search)
      {
         CheckListService checkListService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ICheckListMask> ret = await checkListService.Search<ICheckListMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
   }
}