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
   public class MfgOperationService_SignOffInstance_UnitTests : MfgOperationServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetSignOffInstance_ISignOffInstanceMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         ISignOffInstanceMask ret = await mfgOperationService.GetSignOffInstance<ISignOffInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetSignOffInstance_ISignOffInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         ISignOffInstanceDetailMask ret = await mfgOperationService.GetSignOffInstance<ISignOffInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetSignOffInstances_ISignOffInstanceMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<ISignOffInstanceMask> ret = await mfgOperationService.GetSignOffInstances<ISignOffInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetSignOffInstances_ISignOffInstanceDetailMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<ISignOffInstanceDetailMask> ret = await mfgOperationService.GetSignOffInstances<ISignOffInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }
   }
}