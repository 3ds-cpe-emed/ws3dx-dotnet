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
using ws3dx.core.exception;

namespace NUnitTestProject
{
   public class DataCollectService_DataCollect_UnitTests : DataCollectServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IDataCollectMask(string dataCollectId)
      {
         DataCollectService dataCollectService = ServiceFactoryCreate(await Authenticate());

         IDataCollectMask ret = await dataCollectService.Get<IDataCollectMask>(dataCollectId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IDataCollectDetailMask(string dataCollectId)
      {
         DataCollectService dataCollectService = ServiceFactoryCreate(await Authenticate());

         IDataCollectDetailMask ret = await dataCollectService.Get<IDataCollectDetailMask>(dataCollectId);

         Assert.IsNotNull(ret);
      }
      [TestCase("data", 0, 50)]
      public async Task Search_Paged_IDataCollectMask(string search, int skip, int top)
      {
         DataCollectService dataCollectService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IDataCollectMask> ret = await dataCollectService.Search<IDataCollectMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (IDataCollectMask dataCollect in ret)
            {
               IDataCollectDetailMask dataCollectDetail = await dataCollectService.Get<IDataCollectDetailMask>(dataCollect.Id);

               Assert.AreEqual(dataCollect.Id, dataCollectDetail.Id);

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
      public async Task Search_Full_IDataCollectMask(string search)
      {
         DataCollectService dataCollectService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDataCollectMask> ret = await dataCollectService.Search<IDataCollectMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
   }
}