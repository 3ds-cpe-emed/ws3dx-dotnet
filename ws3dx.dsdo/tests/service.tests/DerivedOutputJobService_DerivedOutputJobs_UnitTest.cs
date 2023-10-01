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
using ws3dx.core.exception;
using ws3dx.dsdo.core.data.impl;
using ws3dx.dsdo.core.service;
using ws3dx.dsdo.data;
using ws3dx.dseng.core.data.impl;
using ws3dx.shared.data;

namespace NUnitTestProject
{
   public class DerivedOutputJobService_DerivedOutputJobs_UnitTests : DerivedOutputJobServiceTestsSetup
   {
      //prd-R1132100982379-00055636 - 35B0B3DB533100005F1999AD00164023
      //prd-R1132100982379-00073830 - 79DD880FF25300005F7F0CEA000E4CE1
      [TestCase("35B0B3DB533100005F1999AD00164023", "79DD880FF25300005F7F0CEA000E4CE1", "28f7c75783da39a0aca083a2be16a27b350736f4ceabc5f2cd318e323bbdc33a")]
      public async Task Create(string _referencedObjectId1, string _referencedObjectId2, string _derivedRuleId)
      {
         DerivedOutputJobService derivedOutputJobService = ServiceFactoryCreate(await Authenticate());

         ITypedUriId id1 = new EngItemUriId(_referencedObjectId1, GetServiceUrl());
         ITypedUriId id2 = new EngItemUriId(_referencedObjectId2, GetServiceUrl());

         IDerivedOutputConversionRequest derivedOutputConversionRequest1 = new DerivedOutputConversionRequest();
         derivedOutputConversionRequest1.ReferencedObject = id1;
         derivedOutputConversionRequest1.RuleID = _derivedRuleId;

         IDerivedOutputConversionRequest derivedOutputConversionRequest2 = new DerivedOutputConversionRequest();
         derivedOutputConversionRequest2.ReferencedObject = id2;
         derivedOutputConversionRequest2.RuleID = _derivedRuleId;

         ICreateDerivedOutputJobs request = new CreateDerivedOutputJobs();

         request.ConversionRequests = new List<IDerivedOutputConversionRequest>
         {
            derivedOutputConversionRequest1,
            derivedOutputConversionRequest2
         };

         try
         {
            IList<ICreateDerivedOutputJobsResponse> ret = await derivedOutputJobService.Create(request);

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