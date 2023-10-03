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
using ws3dx.dsreq.core.data.impl;
using ws3dx.dsreq.core.service;
using ws3dx.dsreq.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class RequirementSpecificationService_RequirementSpecification_UnitTests : RequirementSpecificationServiceTestsSetup
   {

      [TestCase("44C2728F273000006414E802000DBEFC")]
      public async Task Get(string reqSpecId)
      {
         RequirementSpecificationService requirementSpecificationService = ServiceFactoryCreate(await Authenticate());

         INewRequirementSpecificationMask ret = await requirementSpecificationService.Get(reqSpecId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_INewRequirementSpecificationMask(string search, int skip, int top)
      {
         RequirementSpecificationService requirementSpecificationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<INewRequirementSpecificationMask> ret = await requirementSpecificationService.Search<INewRequirementSpecificationMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_INewRequirementSpecificationMask(string search)
      {
         RequirementSpecificationService requirementSpecificationService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<INewRequirementSpecificationMask> ret = await requirementSpecificationService.Search<INewRequirementSpecificationMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create()
      {
         RequirementSpecificationService requirementSpecificationService = ServiceFactoryCreate(await Authenticate());

         ICreateRequirementSpecification request = new CreateRequirementSpecification();

         request.Items = new List<INewRequirementSpecification>();

         INewRequirementSpecification newRequirementSpec = new NewRequirementSpecification
         {
            Type = "Requirement Specification",
            VersionName = "1.1",
            Attributes = new NewRequirementSpecificationData()
         };
         newRequirementSpec.Attributes.Title = "New Requirement Specification from Web Services";
         newRequirementSpec.Attributes.Description = "New Requirement Specification  Description from Web Services";

         request.Items.Add(newRequirementSpec);

         try
         {
            IEnumerable<INewRequirementSpecificationMask> ret = await requirementSpecificationService.Create(request);

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