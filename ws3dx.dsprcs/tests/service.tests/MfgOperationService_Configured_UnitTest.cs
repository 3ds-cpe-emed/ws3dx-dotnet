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
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.shared.data;
using ws3dx.core.exception;
using ws3dx.shared.data.impl;

namespace NUnitTestProject
{
   public class MfgOperationService_Configured_UnitTests : MfgOperationServiceTestsSetup
   {
      [TestCase("")]
      public async Task GetConfiguration_IConfiguredDetail(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IConfiguredDetail> ret = await mfgOperationService.GetConfiguration<IConfiguredDetail>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredBasics(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IConfiguredBasics> ret = await mfgOperationService.GetConfiguration<IConfiguredBasics>(mfgOperationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AttachConfiguration(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgOperationService.AttachConfiguration(mfgOperationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachConfiguration(string mfgOperationId)
      {
         MfgOperationService mfgOperationService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            ITypedUriIdentifierResources ret = await mfgOperationService.DetachConfiguration(mfgOperationId, request);

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