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
using ws3dx.dsxcad.core.service;
using ws3dx.dsxcad.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class FamilyRepresentationService_FamilyRepresentation_UnitTests : FamilyRepresentationServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IXCADFamilyRepMask(string familyRepId)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         IXCADFamilyRepMask ret = await familyRepresentationService.Get<IXCADFamilyRepMask>(familyRepId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADFamilyRepBasicMask(string familyRepId)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         IXCADFamilyRepBasicMask ret = await familyRepresentationService.Get<IXCADFamilyRepBasicMask>(familyRepId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IXCADFamilyRepDetailMask(string familyRepId)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         IXCADFamilyRepDetailMask ret = await familyRepresentationService.Get<IXCADFamilyRepDetailMask>(familyRepId);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADFamilyRepMask(string search, int skip, int top)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepBasicMask> ret = await familyRepresentationService.Search<IXCADFamilyRepBasicMask>(searchByFreeText, skip, top);
         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IXCADFamilyRepBasicMask cadFamilyFound in ret)
         {
            IXCADFamilyRepDetailMask cadFamily = await familyRepresentationService.Get<IXCADFamilyRepDetailMask>(cadFamilyFound.Id);

            Assert.AreEqual(cadFamilyFound.Id, cadFamily.Id);

            i++;

            if (i > 20) return;
         }
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADFamilyRepMask(string search)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepMask> ret = await familyRepresentationService.Search<IXCADFamilyRepMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADFamilyRepBasicMask(string search, int skip, int top)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepBasicMask> ret = await familyRepresentationService.Search<IXCADFamilyRepBasicMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADFamilyRepBasicMask(string search)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepBasicMask> ret = await familyRepresentationService.Search<IXCADFamilyRepBasicMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IXCADFamilyRepDetailMask(string search, int skip, int top)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepDetailMask> ret = await familyRepresentationService.Search<IXCADFamilyRepDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IXCADFamilyRepDetailMask(string search)
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IXCADFamilyRepDetailMask> ret = await familyRepresentationService.Search<IXCADFamilyRepDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Locate()
      {
         FamilyRepresentationService familyRepresentationService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IRepresentationIdentifiers ret = await familyRepresentationService.Locate(request);

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