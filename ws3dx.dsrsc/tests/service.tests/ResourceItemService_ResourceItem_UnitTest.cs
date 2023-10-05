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
   public class ResourceItemService_ResourceItem_UnitTests : ResourceItemServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IResourceItemMask(string resItemId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IResourceItemMask ret = await resourceItemService.Get<IResourceItemMask>(resItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IResourceItemDetailMask(string resItemId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IResourceItemDetailMask ret = await resourceItemService.Get<IResourceItemDetailMask>(resItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task ResourceItem_IResourceItemMask()
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResourceItems request = new CreateResourceItems();

         try
         {
            IEnumerable<IResourceItemMask> ret = await resourceItemService.ResourceItem<IResourceItemMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task ResourceItem_IResourceItemDetailMask()
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         ICreateResourceItems request = new CreateResourceItems();

         try
         {
            IEnumerable<IResourceItemDetailMask> ret = await resourceItemService.ResourceItem<IResourceItemDetailMask>(request);

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
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         IBulkUpdateResourceItem[] request = new BulkUpdateResourceItem[] { };

         try
         {
            IGenericResponse ret = await resourceItemService.BulkUpdate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Delete(string resItemId)
      {
         ResourceItemService resourceItemService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IGenericResponse ret = await resourceItemService.Delete(resItemId);

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