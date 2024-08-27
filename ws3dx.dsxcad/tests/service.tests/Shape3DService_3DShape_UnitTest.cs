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
using ws3dx.dsxcad.data;
using ws3dx.dsxcad.service;
using ws3dx.utils.search;

namespace NUnitTestProject
{
    public class Shape3DService_3DShape_UnitTests : Shape3DServiceTestsSetup
    {
        [TestCase("search", 0, 50)]
        public async Task Search_Paged_IXCADShapeMask(string search, int skip, int top)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IXCADShapeMask> ret = await shape3DService.Search<IXCADShapeMask>(searchByFreeText, skip, top);

            Assert.IsNotNull(ret);
        }

        [TestCase("search")]
        public async Task Search_Full_IXCADShapeMask(string search)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IXCADShapeMask> ret = await shape3DService.Search<IXCADShapeMask>(searchByFreeText);

            Assert.IsNotNull(ret);
        }
        [TestCase("search", 0, 50)]
        public async Task Search_Paged_IXCADShapeMaskEnterpriseDetail(string search, int skip, int top)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IXCADShapeMaskEnterpriseDetail> ret = await shape3DService.Search<IXCADShapeMaskEnterpriseDetail>(searchByFreeText, skip, top);

            Assert.IsNotNull(ret);
        }

        [TestCase("search")]
        public async Task Search_Full_IXCADShapeMaskEnterpriseDetail(string search)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IXCADShapeMaskEnterpriseDetail> ret = await shape3DService.Search<IXCADShapeMaskEnterpriseDetail>(searchByFreeText);

            Assert.IsNotNull(ret);
        }

        [TestCase("")]
        public async Task Get_IXCADShapeMask(string shapeId)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            IXCADShapeMask ret = await shape3DService.Get<IXCADShapeMask>(shapeId);

            Assert.IsNotNull(ret);
        }

        [TestCase("")]
        public async Task Get_IXCADShapeMaskEnterpriseDetail(string shapeId)
        {
            Shape3DService shape3DService = ServiceFactoryCreate(await Authenticate());

            IXCADShapeMaskEnterpriseDetail ret = await shape3DService.Get<IXCADShapeMaskEnterpriseDetail>(shapeId);

            Assert.IsNotNull(ret);
        }
    }
}