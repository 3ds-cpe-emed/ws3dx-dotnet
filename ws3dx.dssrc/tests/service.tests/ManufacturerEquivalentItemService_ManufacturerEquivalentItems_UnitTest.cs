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
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dssrc.core.data.impl;
using ws3dx.dssrc.core.service;
using ws3dx.dssrc.data;
using ws3dx.shared.data.impl;

namespace NUnitTestProject
{
   public class ManufacturerEquivalentItemService_ManufacturerEquivalentItems_UnitTests : ManufacturerEquivalentItemServiceTestsSetup
   {

      [TestCase("")]
      public async Task Get(string meiId)
      {
         ManufacturerEquivalentItemService manufacturerEquivalentItemService = ServiceFactoryCreate(await Authenticate());

         IManufacturerEquivalentItemMask ret = await manufacturerEquivalentItemService.Get(meiId);

         Assert.IsNotNull(ret);
      }

      [TestCase("3784C7605B3B0000642470A000143BB7", "uuid:Supplier A")]
      public async Task Create(string _engItemId, string _supplierId)
      {
         ManufacturerEquivalentItemService manufacturerEquivalentItemService = ServiceFactoryCreate(await Authenticate());

         INewManufacturerEquivalentItem mei = new NewManufacturerEquivalentItem();

         mei.EngItem = new TypedUriIdentifier();
         mei.EngItem.Identifier = _engItemId;
         mei.EngItem.Type = "VPMReference";
         mei.EngItem.RelativePath = "resource/v1/dseng/dseng:EngItem/" + _engItemId;
         mei.EngItem.Source = GetServiceUrl();

         mei.ManufacturerCompany = new TypedUriIdentifier();
         mei.ManufacturerCompany.Identifier = _supplierId;
         mei.ManufacturerCompany.RelativePath = $"/3drdfpersist/resources/v1/modeler/dsvnp/dsvnp:SupplierCompany/{_supplierId}";
         mei.ManufacturerCompany.Type = "SupplierCompany";
         mei.ManufacturerCompany.Source = "https://r1132100982379-eu1-3dnetwork.3dexperience.3ds.com";
         //mei.ManufacturerCompany.Source = m_serviceUrl;

         mei.Manufacturer = "Supplier A";
         mei.ManufacturerPartNumber = "RE-98372";
         mei.PartSourceURL = "";
         mei.PartSource = "Texas Instruments NAM";

         INewManufacturerEquivalentItem[] request = new INewManufacturerEquivalentItem[1] { mei };

         try
         {
            IEnumerable<IManufacturerEquivalentItemMask> ret = await manufacturerEquivalentItemService.Create(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate()
      {
         ManufacturerEquivalentItemService manufacturerEquivalentItemService = ServiceFactoryCreate(await Authenticate());

         ILocateManufacturerEquivalentItems request = new LocateManufacturerEquivalentItems();

         try
         {
            IEnumerable<IManufacturerEquivalentItemMask> ret = await manufacturerEquivalentItemService.Locate(request);

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