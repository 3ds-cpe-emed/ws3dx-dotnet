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
   public class MfgOperationService_InstructionInstance_UnitTests : MfgOperationServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetInstructionInstance_IInstructionInstanceMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IInstructionInstanceMask ret = await mfgOperationService.GetInstructionInstance<IInstructionInstanceMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstructionInstance_IInstructionInstanceDetailMask(string mfgOperationId, string instanceId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IInstructionInstanceDetailMask ret = await mfgOperationService.GetInstructionInstance<IInstructionInstanceDetailMask>(mfgOperationId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstructionInstances_IInstructionInstanceMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IInstructionInstanceMask> ret = await mfgOperationService.GetInstructionInstances<IInstructionInstanceMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstructionInstances_IInstructionInstanceDetailMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IInstructionInstanceDetailMask> ret = await mfgOperationService.GetInstructionInstances<IInstructionInstanceDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }
   }
}