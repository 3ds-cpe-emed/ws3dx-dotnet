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

namespace NUnitTestProject
{
   public class AlertService_Alert_UnitTests : AlertServiceTestsSetup
   {
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IAlertMask(string search, int skip, int top)
      {
         AlertService alertService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IAlertMask> ret = await alertService.Search<IAlertMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IAlertMask(string search)
      {
         AlertService alertService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IAlertMask> ret = await alertService.Search<IAlertMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IAlertMask(string alertId)
      {
         AlertService alertService = ServiceFactoryCreate(await Authenticate());

         IAlertMask ret = await alertService.Get<IAlertMask>(alertId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IAlertDetailMask(string alertId)
      {
         AlertService alertService = ServiceFactoryCreate(await Authenticate());

         IAlertDetailMask ret = await alertService.Get<IAlertDetailMask>(alertId);

         Assert.IsNotNull(ret);
      }
   }
}