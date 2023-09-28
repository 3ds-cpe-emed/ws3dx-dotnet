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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.core.exception;
using ws3dx.dsprcs.core.data.impl;
using ws3dx.authentication.data;
using ws3dx.dsmfg;

namespace NUnitTestProject
{
   public class MfgOperationService_MfgOperation_UnitTests : MfgOperationServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IMfgOperationMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IMfgOperationMask ret = await mfgOperationService.Get<IMfgOperationMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgOperationDetailMask(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IMfgOperationDetailMask ret = await mfgOperationService.Get<IMfgOperationDetailMask>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task BulkFetch_IMfgOperationMask()
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            (IList<IMfgOperationMask>, IList<string>) ret = await mfgOperationService.BulkFetch<IMfgOperationMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IMfgOperationDetailMask()
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            (IList<IMfgOperationDetailMask>, IList<string>) ret = await mfgOperationService.BulkFetch<IMfgOperationDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase(MFGResourceNames.GENERAL_OP_TYPE, "AAA27 Operation Title")]
      public async Task Create_IMfgOperationMask(string _operationType, string _operationName)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());


         INewMfgOperation operation = new NewMfgOperation();
         operation.Attributes = new MfgOperationRequest();
         operation.Attributes.Type = _operationType;
         operation.Attributes.Name = _operationName;

         ICreateMfgOperation request = new CreateMfgOperation();
         request.Items = new List<INewMfgOperation>() { operation };


         try
         {
            IMfgOperationMask ret = await mfgOperationService.Create<IMfgOperationMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase(MFGResourceNames.GENERAL_OP_TYPE, "AAA27 Another Operation 2 Title")]
      public async Task Create_IMfgOperationDetailMask(string _operationType, string _operationName)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         INewMfgOperation operation = new NewMfgOperation();
         operation.Attributes = new MfgOperationRequest();
         operation.Attributes.Type = _operationType;
         operation.Attributes.Name = _operationName;

         ICreateMfgOperation request = new CreateMfgOperation();
         request.Items = new List<INewMfgOperation>() { operation };

         try
         {
            IMfgOperationDetailMask ret = await mfgOperationService.Create<IMfgOperationDetailMask>(request);

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