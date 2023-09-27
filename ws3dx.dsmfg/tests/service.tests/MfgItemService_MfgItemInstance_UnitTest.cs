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
   public class MfgItemService_MfgItemInstance_UnitTests : MfgItemServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetInstance_IMfgItemInstanceMask(string mfgItemId, string instanceId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.GetInstance<IMfgItemInstanceMask>(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IMfgItemInstanceDetailMask(string mfgItemId, string instanceId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.GetInstance<IMfgItemInstanceDetailMask>(mfgItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IMfgItemInstanceMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.GetInstances<IMfgItemInstanceMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IMfgItemInstanceDetailMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.GetInstances<IMfgItemInstanceDetailMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task AddInstanceReplace_IMfgItemInstanceMask(string mfgItemId, string instanceId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         IMfgItemInstanceReplace request = new MfgItemInstanceReplace();

         try
         {
            IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.AddInstanceReplace<IMfgItemInstanceMask>(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AddInstanceReplace_IMfgItemInstanceDetailMask(string mfgItemId, string instanceId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         IMfgItemInstanceReplace request = new MfgItemInstanceReplace();

         try
         {
            IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.AddInstanceReplace<IMfgItemInstanceDetailMask>(mfgItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IMfgItemInstanceMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateMfgInstancesRef request = new CreateMfgInstancesRef();

         try
         {
            IEnumerable<IMfgItemInstanceMask> ret = await mfgItemService.AddInstance<IMfgItemInstanceMask>(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IMfgItemInstanceDetailMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateMfgInstancesRef request = new CreateMfgInstancesRef();

         try
         {
            IEnumerable<IMfgItemInstanceDetailMask> ret = await mfgItemService.AddInstance<IMfgItemInstanceDetailMask>(mfgItemId, request);

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