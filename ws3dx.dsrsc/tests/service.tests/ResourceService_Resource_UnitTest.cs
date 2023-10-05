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
using ws3dx.utils.search;
using ws3dx.dsrsc.core.service;
using ws3dx.dsrsc.data;
using ws3dx.shared.data;
using ws3dx.core.exception;
using ws3dx.authentication.data;
using ws3dx.dsrsc.core.data.impl;

namespace NUnitTestProject
{
   public class ResourceService_Resource_UnitTests : ResourceServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IResourceMask(string resId)
      {
         ResourceService resourceService = ServiceFactoryCreate(await Authenticate());

         IResourceMask ret = await resourceService.Get<IResourceMask>(resId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IResourceDetailMask(string resId)
      {
         ResourceService resourceService = ServiceFactoryCreate(await Authenticate());

         IResourceDetailMask ret = await resourceService.Get<IResourceDetailMask>(resId);

         Assert.IsNotNull(ret);
      }

      [TestCase("resource")]
      public async Task Search_Full_IResourceMask(string search)
      {
         ResourceService resourceService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IResourceMask> ret = await resourceService.Search<IResourceMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("resource", 0, 50)]
      public async Task Search_Paged_IResourceMask(string search, int skip, int top)
      {
         ResourceService resourceService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IResourceMask> ret = await resourceService.Search<IResourceMask>(searchByFreeText, skip, top);

         int i = 0;
         foreach (IResourceMask resourceFound in ret)
         {
            IResourceDetailMask resource = await resourceService.Get<IResourceDetailMask>(resourceFound.Id);

            Assert.AreEqual(resourceFound.Id, resource.Id);

            i++;

            if (i > 20) return;
         }

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Locate()
      {
         ResourceService resourceService = ServiceFactoryCreate(await Authenticate());

         ILocateResource request = new LocateResource();

         try
         {
            IEnumerable<IResourceLocated> ret = await resourceService.Locate(request);

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