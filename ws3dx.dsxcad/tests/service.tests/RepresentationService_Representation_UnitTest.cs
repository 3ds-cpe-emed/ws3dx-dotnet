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
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class RepresentationService_Representation_UnitTests : RepresentationServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IXCADRepresentationMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IXCADRepresentationMask ret = await representationService.Get<IXCADRepresentationMask>(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADRepresentationDetailMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IXCADRepresentationDetailMask ret = await representationService.Get<IXCADRepresentationDetailMask>(representationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADRepresentationBasicMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IXCADRepresentationBasicMask ret = await representationService.Get<IXCADRepresentationBasicMask>(representationId);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationMask(string search, int skip, int top)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationMask> ret = await representationService.Search<IXCADRepresentationMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationMask(string search)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationMask> ret = await representationService.Search<IXCADRepresentationMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationDetailMask(string search, int skip, int top)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Search<IXCADRepresentationDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationDetailMask(string search)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Search<IXCADRepresentationDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADRepresentationBasicMask(string search, int skip, int top)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Search<IXCADRepresentationBasicMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADRepresentationBasicMask(string search)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Search<IXCADRepresentationBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Attach_IXCADRepresentationMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Attach<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADRepresentationDetailMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Attach<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IXCADRepresentationBasicMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IAttachXCADRepresentation request = new AttachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Attach<IXCADRepresentationBasicMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADRepresentationMask()
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Create<IXCADRepresentationMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADRepresentationDetailMask()
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Create<IXCADRepresentationDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IXCADRepresentationBasicMask()
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         ICreateXCADReferences request = new CreateXCADReferences();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Create<IXCADRepresentationBasicMask>(request);

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
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         ILocateXCADRepresentations request = new LocateXCADRepresentations();

         try
         {
            IEnumerable<IEnterpriseItemNumberMask> ret = await representationService.Locate(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADRepresentationMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Modify<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADRepresentationDetailMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Modify<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Modify_IXCADRepresentationBasicMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IModifyXCADRepresentationWithFiles request = new ModifyXCADRepresentationWithFiles();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Modify<IXCADRepresentationBasicMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADRepresentationMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationMask> ret = await representationService.Detach<IXCADRepresentationMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADRepresentationDetailMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationDetailMask> ret = await representationService.Detach<IXCADRepresentationDetailMask>(representationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IXCADRepresentationBasicMask(string representationId)
      {
         RepresentationService representationService = ServiceFactoryCreate(await Authenticate());

         IDetachXCADRepresentation request = new DetachXCADRepresentation();

         try
         {
            IEnumerable<IXCADRepresentationBasicMask> ret = await representationService.Detach<IXCADRepresentationBasicMask>(representationId, request);

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