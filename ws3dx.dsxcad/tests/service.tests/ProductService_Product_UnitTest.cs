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
using ws3dx.dsxcad.core.data.impl;
using ws3dx.dsxcad.core.service;
using ws3dx.dsxcad.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class ProductService_Product_UnitTests : ProductServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADProductMask(string search, int skip, int top)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductMask> ret = await productService.Search<IXCADProductMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADProductMask(string search)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductMask> ret = await productService.Search<IXCADProductMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADProductDetailMask(string search, int skip, int top)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductDetailMask> ret = await productService.Search<IXCADProductDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADProductDetailMask(string search)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductDetailMask> ret = await productService.Search<IXCADProductDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADProductEnterpriseDetailMask(string search, int skip, int top)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductEnterpriseDetailMask> ret = await productService.Search<IXCADProductEnterpriseDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADProductEnterpriseDetailMask(string search)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADProductEnterpriseDetailMask> ret = await productService.Search<IXCADProductEnterpriseDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADProductMask(string productId)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         IXCADProductMask ret = await productService.Get<IXCADProductMask>(productId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADProductDetailMask(string productId)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         IXCADProductDetailMask ret = await productService.Get<IXCADProductDetailMask>(productId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADProductEnterpriseDetailMask(string productId)
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         IXCADProductEnterpriseDetailMask ret = await productService.Get<IXCADProductEnterpriseDetailMask>(productId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create_IXCADProductMask()
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADProductsFromTemplate request = new CreateXCADProductsFromTemplate();

         try
         {
            IEnumerable<IXCADProductMask> ret = await productService.Create<IXCADProductMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADProductDetailMask()
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADProductsFromTemplate request = new CreateXCADProductsFromTemplate();

         try
         {
            IEnumerable<IXCADProductDetailMask> ret = await productService.Create<IXCADProductDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADProductEnterpriseDetailMask()
      {
         ProductService productService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADProductsFromTemplate request = new CreateXCADProductsFromTemplate();

         try
         {
            IEnumerable<IXCADProductEnterpriseDetailMask> ret = await productService.Create<IXCADProductEnterpriseDetailMask>(request);

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