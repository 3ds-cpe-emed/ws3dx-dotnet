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
using ws3dx.core.exception;
using ws3dx.dsrsc.core.data.impl;

namespace NUnitTestProject
{
   public class OrganizationalResourceService_WorkerInstance_UnitTests : OrganizationalResourceServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetWorkerInstance_IWorkerInstanceMask(string organizationalResourceId, string instanceId)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         IWorkerInstanceMask ret = await organizationalResourceService.GetWorkerInstance<IWorkerInstanceMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetWorkerInstance_IWorkerInstanceDetailMask(string organizationalResourceId, string instanceId)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         IWorkerInstanceDetailMask ret = await organizationalResourceService.GetWorkerInstance<IWorkerInstanceDetailMask>(organizationalResourceId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetWorkerInstances_IWorkerInstanceMask(string orgResourceId, int top, int skip)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IWorkerInstanceMask> ret = await organizationalResourceService.GetWorkerInstances<IWorkerInstanceMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetWorkerInstances_IWorkerInstanceDetailMask(string orgResourceId, int top, int skip)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IWorkerInstanceDetailMask> ret = await organizationalResourceService.GetWorkerInstances<IWorkerInstanceDetailMask>(orgResourceId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task CreateWorkerInstance_IWorkerInstanceMask(string orgResourceId)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         ICreateWorkerInstances request = new CreateWorkerInstances();

         try
         {
            IEnumerable<IWorkerInstanceMask> ret = await organizationalResourceService.CreateWorkerInstance<IWorkerInstanceMask>(orgResourceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateWorkerInstance_IWorkerInstanceDetailMask(string orgResourceId)
      {
         OrganizationalResourceService organizationalResourceService = ServiceFactoryCreate(await Authenticate());

         ICreateWorkerInstances request = new CreateWorkerInstances();

         try
         {
            IEnumerable<IWorkerInstanceDetailMask> ret = await organizationalResourceService.CreateWorkerInstance<IWorkerInstanceDetailMask>(orgResourceId, request);

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