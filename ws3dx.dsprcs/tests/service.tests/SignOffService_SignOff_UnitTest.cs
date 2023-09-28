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
using ws3dx.utils.search;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.authentication.data;
using ws3dx.core.exception;

namespace NUnitTestProject
{
   public class SignOffService_SignOff_UnitTests : SignOffServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_ISignOffMask(string signOffId)
      {
         SignOffService signOffService = ServiceFactoryCreate(await Authenticate());

         ISignOffMask ret = await signOffService.Get<ISignOffMask>(signOffId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_ISignOffDetailMask(string signOffId)
      {
         SignOffService signOffService = ServiceFactoryCreate(await Authenticate());

         ISignOffDetailMask ret = await signOffService.Get<ISignOffDetailMask>(signOffId);

         Assert.IsNotNull(ret);
      }

      [TestCase("sign", 0, 50)]
      public async Task Search_Paged_ISignOffMask(string search, int skip, int top)
      {
         SignOffService signOffService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<ISignOffMask> ret = await signOffService.Search<ISignOffMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (ISignOffMask signOff in ret)
            {
               ISignOffDetailMask signOffDetail = await signOffService.Get<ISignOffDetailMask>(signOff.Id);

               Assert.AreEqual(signOff.Id, signOffDetail.Id);

               i++;

               if (i > 20) return;
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("sign")]
      public async Task Search_Full_ISignOffMask(string search)
      {
         SignOffService signOffService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<ISignOffMask> ret = await signOffService.Search<ISignOffMask>(searchByFreeText);
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