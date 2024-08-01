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
using ws3dx.dsmfg.data;
using ws3dx.dsmfg.data.impl;
using ws3dx.dsmfg.service;
using ws3dx.shared.data;

namespace NUnitTestProject
{
    public class MfgItemService_ScopeRequirementSpec_UnitTests : MfgItemServiceTestsSetup
    {
        //TODO
        [TestCase("")]
        public async Task GetScopeRequirementSpecs(string mfgItemId)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IScopeRequirementSpecMask> ret = await mfgItemService.GetScopeRequirementSpecs(mfgItemId);

            Assert.IsNotNull(ret);
        }

        //TODO
        [TestCase("", "")]
        public async Task GetScopeRequirementSpec(string mfgItemId, string requirementId)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            IScopeRequirementSpecMask ret = await mfgItemService.GetScopeRequirementSpec(mfgItemId, requirementId);

            Assert.IsNotNull(ret);
        }

        //TODO
        [TestCase("")]
        public async Task AddScopeRequirementSpec(string mfgItemId)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            ICreateScopeRequirementSpecs request = new CreateScopeRequirementSpecs();

            try
            {
                IEnumerable<IScopeRequirementSpecMask> ret = await mfgItemService.AddScopeRequirementSpec(mfgItemId, request);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        //TODO
        [TestCase("", "")]
        public async Task DeleteScopeRequirementSpec(string requirementId, string mfgItemId)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            try
            {
                IGenericResponse ret = await mfgItemService.DeleteScopeRequirementSpec(requirementId, mfgItemId);

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