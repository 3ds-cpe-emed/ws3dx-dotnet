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
using ws3dx.dsprcs.data;
using ws3dx.dsprcs.service;

namespace NUnitTestProject
{
    public class ResourceParameterPlanService_ResourceParameterRow_UnitTests : ResourceParameterPlanServiceTestsSetup
    {

        [TestCase("", 0, 0)]
        public async Task GetResourceParameterRow(string id, int top, int skip)
        {
            ResourceParameterPlanService resourceParameterPlanService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IResourceParameterRowMask> ret = await resourceParameterPlanService.GetResourceParameterRows(id, top, skip);

            Assert.IsNotNull(ret);
        }

        [TestCase("", "")]
        public async Task GetResourceParameterRow(string id, string pId)
        {
            ResourceParameterPlanService resourceParameterPlanService = ServiceFactoryCreate(await Authenticate());

            IResourceParameterRowMask ret = await resourceParameterPlanService.GetResourceParameterRow(id, pId);

            Assert.IsNotNull(ret);
        }
    }
}