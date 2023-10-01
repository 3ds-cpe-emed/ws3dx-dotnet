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
using ws3dx.dsdo.core.service;
using ws3dx.dsdo.data;

namespace NUnitTestProject
{
   public class DerivedOutputRuleService_DerivedOutputRules_UnitTests : DerivedOutputRuleServiceTestsSetup
   {
      [TestCase("", "ondemand")] //onXCADSave, ondemand
      public async Task GetAll(string category, string ruleType)
      {
         DerivedOutputRuleService derivedOutputRuleService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDerivedOutputRuleDetailMask> ret = await derivedOutputRuleService.GetAll(category, ruleType);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get(string iD)
      {
         DerivedOutputRuleService derivedOutputRuleService = ServiceFactoryCreate(await Authenticate());

         IDerivedOutputRuleDetailMask ret = await derivedOutputRuleService.Get(iD);

         Assert.IsNotNull(ret);
      }
   }
}