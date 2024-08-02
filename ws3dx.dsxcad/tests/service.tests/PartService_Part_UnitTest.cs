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
   public class PartService_Part_UnitTests : PartServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IXCADPartMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IXCADPartMask ret = await partService.Get<IXCADPartMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartBasicMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IXCADPartBasicMask ret = await partService.Get<IXCADPartBasicMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartEnterpriseDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IXCADPartEnterpriseDetailMask ret = await partService.Get<IXCADPartEnterpriseDetailMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADPartDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IXCADPartDetailMask ret = await partService.Get<IXCADPartDetailMask>(partId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADPartMask(string search, int skip, int top)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartMask> ret = await partService.Search<IXCADPartMask>(searchByFreeText, skip, top);
         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartMask(string search)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartMask> ret = await partService.Search<IXCADPartMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("solidworks", 0, 50)]
      public async Task Search_Paged_IXCADPartBasicMask(string search, int skip, int top)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartBasicMask> ret = await partService.Search<IXCADPartBasicMask>(searchByFreeText, skip, top);

         int i = 0;

         foreach (IXCADPartBasicMask partFound in ret)
         {
            IXCADPartDetailMask part = await partService.Get<IXCADPartDetailMask>(partFound.Id);

            Assert.AreEqual(partFound.Id, part.Id);

            i++;

            if (i > 20) return;
         }

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartBasicMask(string search)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartBasicMask> ret = await partService.Search<IXCADPartBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADPartEnterpriseDetailMask(string search, int skip, int top)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartEnterpriseDetailMask> ret = await partService.Search<IXCADPartEnterpriseDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartEnterpriseDetailMask(string search)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartEnterpriseDetailMask> ret = await partService.Search<IXCADPartEnterpriseDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADPartDetailMask(string search, int skip, int top)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartDetailMask> ret = await partService.Search<IXCADPartDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADPartDetailMask(string search)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADPartDetailMask> ret = await partService.Search<IXCADPartDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Attach_IXCADPartMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartMask ret = await partService.Attach<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADPartBasicMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartBasicMask ret = await partService.Attach<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADPartEnterpriseDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Attach<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADPartDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADPart request = new AttachXCADPart();

         try
         {
            IXCADPartDetailMask ret = await partService.Attach<IXCADPartDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADPartMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartMask ret = await partService.Modify<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADPartBasicMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartBasicMask ret = await partService.Modify<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADPartEnterpriseDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Modify<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADPartDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADPartWithFiles request = new ModifyXCADPartWithFiles();

         try
         {
            IEnumerable<IXCADPartDetailMask> ret = (IEnumerable<IXCADPartDetailMask>)await partService.Modify<IXCADPartDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADPartMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartMask ret = await partService.Detach<IXCADPartMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADPartBasicMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartBasicMask ret = await partService.Detach<IXCADPartBasicMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADPartEnterpriseDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartEnterpriseDetailMask ret = await partService.Detach<IXCADPartEnterpriseDetailMask>(partId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADPartDetailMask(string partId)
      {
         PartService partService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADPart request = new DetachXCADPart();

         try
         {
            IXCADPartDetailMask ret = await partService.Detach<IXCADPartDetailMask>(partId, request);

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