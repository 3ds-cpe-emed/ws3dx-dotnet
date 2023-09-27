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
using ws3dx.dsmfg.core.service;
using ws3dx.dsmfg.data;

namespace NUnitTestProject
{
   public class MfgItemService_ResultingEngItem_UnitTests : MfgItemServiceTestsSetup
   {
      [TestCase("", 0, 0)]
      public async Task GetResultingEngItems_IResultingEngItemUtcMask(string mfgItemId, int top, int skip)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IResultingEngItemUtcMask> ret = await mfgItemService.GetResultingEngItems<IResultingEngItemUtcMask>(mfgItemId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetResultingEngItems_IResultingEngItemMask(string mfgItemId, int top, int skip)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IResultingEngItemMask> ret = await mfgItemService.GetResultingEngItems<IResultingEngItemMask>(mfgItemId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResultingEngItem_IResultingEngItemUtcMask(string mfgItemId, string engItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IResultingEngItemUtcMask> ret = await mfgItemService.GetResultingEngItem<IResultingEngItemUtcMask>(mfgItemId, engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetResultingEngItem_IResultingEngItemMask(string mfgItemId, string engItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IResultingEngItemMask> ret = await mfgItemService.GetResultingEngItem<IResultingEngItemMask>(mfgItemId, engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddResultingEngItem_IResultingEngItemUtcMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResultingEngItems request = new CreateResultingEngItems();

         try
         {
            IEnumerable<IResultingEngItemUtcMask> ret = await mfgItemService.AddResultingEngItem<IResultingEngItemUtcMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddResultingEngItem_IResultingEngItemMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResultingEngItems request = new CreateResultingEngItems();

         try
         {
            IEnumerable<IResultingEngItemMask> ret = await mfgItemService.AddResultingEngItem<IResultingEngItemMask>(mfgItemId, request);

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