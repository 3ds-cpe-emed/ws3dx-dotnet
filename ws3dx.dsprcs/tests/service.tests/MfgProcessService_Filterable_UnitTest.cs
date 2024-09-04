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
using ws3dx.dsprcs.data;
using ws3dx.dsprcs.data.impl;
using ws3dx.dsprcs.service;

namespace NUnitTestProject
{
    public class MfgProcessService_Filterable_UnitTests : MfgProcessServiceTestsSetup
    {
        [TestCase("", "")]
        public async Task GetMfgOperationInstanceEffectivity(string mfgProcessId, string mfgOperationInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IFilterableDetail> ret = await mfgProcessService.GetMfgOperationInstanceEffectivity(mfgProcessId, mfgOperationInstanceId);

            Assert.IsNotNull(ret);
        }

        [TestCase("", "")]
        public async Task GetInstanceEffectivity(string mfgProcessId, string mfgProcessInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IFilterableDetail> ret = await mfgProcessService.GetInstanceEffectivity(mfgProcessId, mfgProcessInstanceId);

            Assert.IsNotNull(ret);
        }

        [TestCase("", "")]
        public async Task UnsetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            try
            {
                IUnitaryEvolutionEffectivity ret = await mfgProcessService.UnsetMfgOperationInstanceEvolutionEffectivity(mfgProcessId, mfgOperationInstanceId);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task UnsetMfgProcessInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            try
            {
                IUnitaryEvolutionEffectivity ret = await mfgProcessService.UnsetMfgProcessInstanceEvolutionEffectivity(mfgProcessId, mfgProcessInstanceId);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task SetMfgOperationInstanceEvolutionEffectivity(string mfgProcessId, string mfgOperationInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

            try
            {
                IUnitaryEvolutionEffectivity ret = await mfgProcessService.SetMfgOperationInstanceEvolutionEffectivity(mfgProcessId, mfgOperationInstanceId, request);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task SetMfgProcessInstanceEvolutionEffectivity(string mfgProcessId, string mfgProcessInstanceId)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

            try
            {
                IUnitaryEvolutionEffectivity ret = await mfgProcessService.SetMfgProcessInstanceEvolutionEffectivity(mfgProcessId, mfgProcessInstanceId, request);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task SetMfgProcessInstanceVariantEffectivity(string mfgProcessId, string mfgProcessInstanceId, string changeAuthoringContext)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            ISetVariantEffectivities request = new SetVariantEffectivities();

            try
            {
                IUnitaryVariantEffectivity ret = await mfgProcessService.SetMfgProcessInstanceVariantEffectivity(mfgProcessId, mfgProcessInstanceId, request, changeAuthoringContext);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task SetMfgOperationInstanceVariantEffectivity(string mfgProcessId, string mfgOperationInstanceId, string changeAuthoringContext)
        {
            MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

            ISetVariantEffectivities request = new SetVariantEffectivities();

            try
            {
                IUnitaryVariantEffectivity ret = await mfgProcessService.SetMfgOperationInstanceVariantEffectivity(mfgProcessId, mfgOperationInstanceId, request, changeAuthoringContext);

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