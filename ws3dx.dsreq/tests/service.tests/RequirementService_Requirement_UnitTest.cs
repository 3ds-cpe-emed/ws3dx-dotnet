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
using ws3dx.dsreq.core.data.impl;
using ws3dx.dsreq.core.service;
using ws3dx.dsreq.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class RequirementService_Requirement_UnitTests : RequirementServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_INewRequirementMask(string search, int skip, int top)
      {
         RequirementService requirementService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<INewRequirementMask> ret = await requirementService.Search<INewRequirementMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_INewRequirementMask(string search)
      {
         RequirementService requirementService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<INewRequirementMask> ret = await requirementService.Search<INewRequirementMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("C39D5789C074000061F02D540012B654")]
      public async Task Get(string reqId)
      {
         RequirementService requirementService = ServiceFactoryCreate(await Authenticate());

         INewRequirementMask ret = await requirementService.Get(reqId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task Create()
      {
         RequirementService requirementService = ServiceFactoryCreate(await Authenticate());

         ICreateRequirement request = new CreateRequirement
         {
            Items = new List<INewRequirement>()
         };

         INewRequirement newRequirement = new NewRequirement
         {
            Type = "Requirement",
            VersionName = "1.1",
            Attributes = new NewRequirementData
            {
               Title = "New Requirement from Web Services",
               Description = "New Requirement Description from Web Services"
            }
         };

         request.Items.Add(newRequirement);

         try
         {
            IEnumerable<INewRequirementMask> ret = await requirementService.Create(request);

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