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
using ws3dx.dsmfg.core.data.impl;
using ws3dx.dsmfg.core.service;
using ws3dx.dsmfg.data;

namespace NUnitTestProject
{
   public class MfgItemService_AssignedRequirement_UnitTests : MfgItemServiceTestsSetup
   {
      [TestCase("44C2728FE131000064099D210015C8CD", "A437358E00006B0C6409BC5800010224")]
      public async Task GetAssignedRequirement(string mfgItemId, string requirementId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         IAssignedRequirementMask ret = await mfgItemService.GetAssignedRequirement(mfgItemId, requirementId);

         Assert.IsNotNull(ret);
      }

      [TestCase("44C2728FE131000064099D210015C8CD")]
      public async Task GetAssignedRequirements(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IAssignedRequirementMask> ret = await mfgItemService.GetAssignedRequirements(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddAssignedRequirement(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateAssignedRequirements request = new CreateAssignedRequirements();

         try
         {
            IEnumerable<IAssignedRequirementMask> ret = await mfgItemService.AddAssignedRequirement(mfgItemId, request);

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