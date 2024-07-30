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
using System.Linq;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.dseng.service;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class InvokeService_EngInstance_UnitTests : InvokeServiceTestsSetup
   {
      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task DetachInstances(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engineeringService = ServiceEngItemFactoryCreate(passport);
         InvokeService invokeService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engineeringService.Search<IEngItemDefaultMask>(searchCriteria);
         Assert.IsNotNull(engItemSearchResult);
         Assert.IsNotNull(engItemSearchResult.First());

         IEnumerable<IEngInstanceDefaultMask> retInstances = await engineeringService.GetInstances<IEngInstanceDefaultMask>(engItemSearchResult.First().Id, 0, 10);
         Assert.IsNotNull(retInstances);
         Assert.IsNotNull(retInstances.First());

         string[] request = new string[] { retInstances.First().Id };

         try
         {
            IGenericResponse ret = await invokeService.DetachInstances(request);

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