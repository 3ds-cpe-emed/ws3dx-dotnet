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
   public class DataCollectPlanService_DataCollectPlan_UnitTests : DataCollectPlanServiceTestsSetup
   {
      [TestCase("")]
      public async Task GetDataCollectRows(string dataCollectPlanId)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDataCollectRowMask> ret = await dataCollectPlanService.GetDataCollectRows(dataCollectPlanId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectRow(string dataCollectPlanId, string dataCollectRowId)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         IDataCollectRowMask ret = await dataCollectPlanService.GetDataCollectRow(dataCollectPlanId, dataCollectRowId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IDataCollectPlanMask(string dataCollectPlanId)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         IDataCollectPlanMask ret = await dataCollectPlanService.Get<IDataCollectPlanMask>(dataCollectPlanId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IDataCollectPlanDetailMask(string dataCollectPlanId)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         IDataCollectPlanDetailMask ret = await dataCollectPlanService.Get<IDataCollectPlanDetailMask>(dataCollectPlanId);

         Assert.IsNotNull(ret);
      }

      [TestCase("plan", 0, 50)]
      public async Task Search_Paged_IDataCollectPlanMask(string search, int skip, int top)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IDataCollectPlanMask> ret = await dataCollectPlanService.Search<IDataCollectPlanMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (IDataCollectPlanMask dataCollectPlan in ret)
            {
               IDataCollectPlanDetailMask dataCollectPlanDetail = await dataCollectPlanService.Get<IDataCollectPlanDetailMask>(dataCollectPlan.Id);

               Assert.AreEqual(dataCollectPlan.Id, dataCollectPlanDetail.Id);

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
      public async Task Search_Full_IDataCollectPlanMask(string search)
      {
         DataCollectPlanService dataCollectPlanService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDataCollectPlanMask> ret = await dataCollectPlanService.Search<IDataCollectPlanMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
   }
}