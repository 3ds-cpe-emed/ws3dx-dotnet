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
using ws3dx.dsxcad.core.data.impl;
using ws3dx.dsxcad.core.service;
using ws3dx.dsxcad.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class DrawingService_Drawing_UnitTests : DrawingServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingMask(string search, int skip, int top)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingMask> ret = await drawingService.Search<IXCADDrawingMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingMask(string search)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingMask> ret = await drawingService.Search<IXCADDrawingMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingDetailMask(string search, int skip, int top)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Search<IXCADDrawingDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingDetailMask(string search)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingDetailMask> ret = await drawingService.Search<IXCADDrawingDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADDrawingEnterpriseDetailMask(string search, int skip, int top)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Search<IXCADDrawingEnterpriseDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingEnterpriseDetailMask(string search)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingEnterpriseDetailMask> ret = await drawingService.Search<IXCADDrawingEnterpriseDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("solidworks", 0, 50)]
      public async Task Search_Paged_IXCADDrawingBasicMask(string search, int skip, int top)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Search<IXCADDrawingBasicMask>(searchByFreeText, skip, top);

         int i = 0;
         foreach (IXCADDrawingBasicMask drawingFound in ret)
         {
            IXCADDrawingDetailMask drawing = await drawingService.Get<IXCADDrawingDetailMask>(drawingFound.Id);

            Assert.AreEqual(drawingFound.Id, drawing.Id);

            i++;

            if (i > 20) return;
         }

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADDrawingBasicMask(string search)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADDrawingBasicMask> ret = await drawingService.Search<IXCADDrawingBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IXCADDrawingMask ret = await drawingService.Get<IXCADDrawingMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IXCADDrawingDetailMask ret = await drawingService.Get<IXCADDrawingDetailMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IXCADDrawingEnterpriseDetailMask ret = await drawingService.Get<IXCADDrawingEnterpriseDetailMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADDrawingBasicMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IXCADDrawingBasicMask ret = await drawingService.Get<IXCADDrawingBasicMask>(drawingId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Attach_IXCADDrawingMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IXCADDrawingMask ret = await drawingService.Attach<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADDrawingDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IXCADDrawingDetailMask ret = await drawingService.Attach<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IXCADDrawingEnterpriseDetailMask ret = await drawingService.Attach<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADDrawingBasicMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADDrawing request = new AttachXCADDrawing();

         try
         {
            IXCADDrawingBasicMask ret = await drawingService.Attach<IXCADDrawingBasicMask>(drawingId, request);

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
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         ILocateXCADDrawing request = new LocateXCADDrawing();

         try
         {
            IEnumerable<IRelatedId> ret = await drawingService.Locate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADDrawingMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IXCADDrawingMask ret = await drawingService.Modify<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADDrawingDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IXCADDrawingDetailMask ret = await drawingService.Modify<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IXCADDrawingEnterpriseDetailMask ret = await drawingService.Modify<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADDrawingBasicMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADDrawingWithFiles request = new ModifyXCADDrawingWithFiles();

         try
         {
            IXCADDrawingBasicMask ret = await drawingService.Modify<IXCADDrawingBasicMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADDrawingMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IXCADDrawingMask ret = await drawingService.Detach<IXCADDrawingMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADDrawingDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IXCADDrawingDetailMask ret = await drawingService.Detach<IXCADDrawingDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADDrawingEnterpriseDetailMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IXCADDrawingEnterpriseDetailMask ret = await drawingService.Detach<IXCADDrawingEnterpriseDetailMask>(drawingId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADDrawingBasicMask(string drawingId)
      {
         DrawingService drawingService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADDrawing request = new DetachXCADDrawing();

         try
         {
            IXCADDrawingBasicMask ret = await drawingService.Detach<IXCADDrawingBasicMask>(drawingId, request);

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