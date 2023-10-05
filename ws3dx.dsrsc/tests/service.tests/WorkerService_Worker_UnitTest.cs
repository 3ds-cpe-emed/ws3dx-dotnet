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
using ws3dx.dsrsc.core.service;
using ws3dx.dsrsc.data;
using ws3dx.shared.data;
using ws3dx.core.exception;
using ws3dx.dsrsc.core.data.impl;

namespace NUnitTestProject
{
   public class WorkerService_Worker_UnitTests : WorkerServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IWorkerResourceMask(string workerId)
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         IWorkerResourceMask ret = await workerService.Get<IWorkerResourceMask>(workerId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IWorkerResourceDetailMask(string workerId)
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         IWorkerResourceDetailMask ret = await workerService.Get<IWorkerResourceDetailMask>(workerId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create_IWorkerResourceMask()
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         ICreateWorkerResources request = new CreateWorkerResources();

         try
         {
            IEnumerable<IWorkerResourceMask> ret = await workerService.Create<IWorkerResourceMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IWorkerResourceDetailMask()
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         ICreateWorkerResources request = new CreateWorkerResources();

         try
         {
            IEnumerable<IWorkerResourceDetailMask> ret = await workerService.Create<IWorkerResourceDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate()
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         IBulkUpdateWorkerResource[] request = new BulkUpdateWorkerResource[] {};

         try
         {
            IGenericResponse ret = await workerService.BulkUpdate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Delete(string workerId)
      {
         WorkerService workerService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IGenericResponse ret = await workerService.Delete(workerId);

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