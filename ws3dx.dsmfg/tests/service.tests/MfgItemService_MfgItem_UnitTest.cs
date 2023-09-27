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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dsmfg;
using ws3dx.dsmfg.core.data.impl;
using ws3dx.dsmfg.core.service;
using ws3dx.dsmfg.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class MfgItemService_MfgItem_UnitTests : MfgItemServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IMfgItemMask(string search, int skip, int top)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IMfgItemMask(string search)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgItemDetailMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IMfgItemDetailMask ret = await mfgItemService.Get<IMfgItemDetailMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgItemMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IMfgItemMask ret = await mfgItemService.Get<IMfgItemMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AddExpand(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         IMfgItemExpandRequestPayloadV1 request = new MfgItemExpandRequestPayloadV1();

         try
         {
            IEnumerable<IMfgItemExpandV1> ret = await mfgItemService.Expand(mfgItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IMfgItemDetailMask()
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         INewMfgItem newMfgItem = new NewMfgItem();
         newMfgItem.Attributes = new MfgItem();
         newMfgItem.Attributes.Type = MFGResourceNames.MANUFACTURING_ASSEMBLY_TYPE;
         newMfgItem.Attributes.Title = "AAA27 Mfg Assembly";
         newMfgItem.Attributes.Description = "New Mfg Assembly from Web Services";

         ICreateMfgItems request = new CreateMfgItems();
         request.Items = new List<INewMfgItem>();
         request.Items.Add(newMfgItem);

         try
         {
            IEnumerable<IMfgItemMask> ret = await mfgItemService.Create<IMfgItemMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IMfgItemMask()
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ICreateMfgItems request = new CreateMfgItems();

         try
         {
            IEnumerable<IMfgItemMask> ret = await mfgItemService.Create<IMfgItemMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Bulkfetch_IMfgItemDetailMask()
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            IEnumerable<IMfgItemDetailMask> ret = await mfgItemService.Bulkfetch<IMfgItemDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Bulkfetch_IMfgItemMask()
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            IEnumerable<IMfgItemMask> ret = await mfgItemService.Bulkfetch<IMfgItemMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task LocateRequest(int top, int skip)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ILocateMfgItemsRequest request = new LocateMfgItemsRequest();

         try
         {
            IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(top, skip, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate(int top, int skip)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

         ILocateMfgItems request = new LocateMfgItems();

         try
         {
            IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(top, skip, request);

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