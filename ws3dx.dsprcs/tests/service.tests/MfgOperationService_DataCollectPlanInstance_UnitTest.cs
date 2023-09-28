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
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;

namespace NUnitTestProject
{
   public class MfgOperationService_DataCollectPlanInstance_UnitTests : MfgOperationServiceTestsSetup
   {
      [TestCase("")]
      public async Task GetDataCollectPlanInstances_IDataCollectPlanInstanceMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDataCollectPlanInstanceMask> ret = await mfgOperationService.GetDataCollectPlanInstances<IDataCollectPlanInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetDataCollectPlanInstances_IDataCollectPlanInstanceDetailMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDataCollectPlanInstanceDetailMask> ret = await mfgOperationService.GetDataCollectPlanInstances<IDataCollectPlanInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectPlanInstance_IDataCollectPlanInstanceMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IDataCollectPlanInstanceMask ret = await mfgOperationService.GetDataCollectPlanInstance<IDataCollectPlanInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetDataCollectPlanInstance_IDataCollectPlanInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IDataCollectPlanInstanceDetailMask ret = await mfgOperationService.GetDataCollectPlanInstance<IDataCollectPlanInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }
   }
}