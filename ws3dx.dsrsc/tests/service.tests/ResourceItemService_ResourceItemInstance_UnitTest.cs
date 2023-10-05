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
   public class ResourceItemService_ResourceItemInstance_UnitTests : ResourceItemServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetInstance_IResourceItemInstanceMask(string resourceItemId, string instanceId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IResourceItemInstanceMask ret = await resourceItemService.GetInstance<IResourceItemInstanceMask>(resourceItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IResourceItemInstanceDetailMask(string resourceItemId, string instanceId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IResourceItemInstanceDetailMask ret = await resourceItemService.GetInstance<IResourceItemInstanceDetailMask>(resourceItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetInstances_IResourceItemInstanceMask(string resItemId, int top, int skip)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IResourceItemInstanceMask> ret = await resourceItemService.GetInstances<IResourceItemInstanceMask>(resItemId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", 0, 0)]
      public async Task GetInstances_IResourceItemInstanceDetailMask(string resItemId, int top, int skip)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IResourceItemInstanceDetailMask> ret = await resourceItemService.GetInstances<IResourceItemInstanceDetailMask>(resItemId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task CreateInstance_IResourceItemInstanceMask(string resItemId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResourceItemInstances request = new CreateResourceItemInstances();

         try
         {
            IEnumerable<IResourceItemInstanceMask> ret = await resourceItemService.CreateInstance<IResourceItemInstanceMask>(resItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateInstance_IResourceItemInstanceDetailMask(string resItemId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResourceItemInstances request = new CreateResourceItemInstances();

         try
         {
            IEnumerable<IResourceItemInstanceDetailMask> ret = await resourceItemService.CreateInstance<IResourceItemInstanceDetailMask>(resItemId, request);

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