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
using ws3dx.shared.data;

namespace NUnitTestProject
{
    public class MfgOperationService_changeControl_UnitTests : MfgOperationServiceTestsSetup
    {

        [TestCase("", "")]
        public async Task GetInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IChangeControlStatusMask> ret = await mfgOperationService.GetInstanceChangeControl(mfgOperationId, mfgOperationInstanceId);

            Assert.IsNotNull(ret);
        }

        [TestCase("")]
        public async Task GetChangeControl(string mfgOperationId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

            IEnumerable<IChangeControlStatusMask> ret = await mfgOperationService.GetChangeControl(mfgOperationId);

            Assert.IsNotNull(ret);
        }

        [TestCase("", "")]
        public async Task AddMfgOperationInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

            IAddEmpty request = new AddEmpty();

            try
            {
                IGenericResponse ret = await mfgOperationService.AddMfgOperationInstanceChangeControl(mfgOperationId, mfgOperationInstanceId, request);

                Assert.IsNotNull(ret);

            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("")]
        public async Task AddChangeControl(string mfgOperationId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

            IAddEmpty request = new AddEmpty();

            try
            {
                IGenericResponse ret = await mfgOperationService.AddChangeControl(mfgOperationId, request);

                Assert.IsNotNull(ret);

            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("", "")]
        public async Task RemoveMfgOperationInstanceChangeControl(string mfgOperationId, string mfgOperationInstanceId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());


            try
            {
                IGenericResponse ret = await mfgOperationService.RemoveMfgOperationInstanceChangeControl(mfgOperationId, mfgOperationInstanceId);

                Assert.IsNotNull(ret);

            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("")]
        public async Task RemoveChangeControl(string mfgOperationId)
        {
            MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());


            try
            {
                IGenericResponse ret = await mfgOperationService.RemoveChangeControl(mfgOperationId);

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