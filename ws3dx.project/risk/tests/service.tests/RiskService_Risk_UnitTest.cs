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
using ws3dx.project.risk.core.data.impl;
using ws3dx.project.risk.core.service;
using ws3dx.project.risk.data;

namespace NUnitTestProject
{
   public class RiskService_Risk_UnitTests : RiskServiceTestsSetup
   {

      [TestCase("false", "false", 0, "Create,Assign,Active,Review,Complete")]
      public async Task GetRisks(string owned, string assigned, int completed, string state)
      {
         RiskService riskService = ServiceFactoryCreate(await Authenticate());

         IList<IResponseRiskData> ret = await riskService.GetRisks(owned, assigned, completed, state);

         Assert.IsNotNull(ret);
      }

      [TestCase("DFD6F085F3530000630E19F8000A7EE0")]
      public async Task GetRisk(string riskId)
      {
         RiskService riskService = ServiceFactoryCreate(await Authenticate());

         IResponseRiskData ret = await riskService.GetRisk(riskId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task CreateRisk()
      {
         RiskService riskService = ServiceFactoryCreate(await Authenticate());

         //MANDATORY for Create: { probability, impact, effectiveDate, }
         IRiskData riskData = new RiskData
         {
            Title = "New Risk Created from Web Services",
            Probability = "1", //1-Rare, 2-Unlikely, 3-Possible, 4-Likely, and 5-Almost Certain
            Impact = "2",
            EffectiveDate = "2023-03-18T00:00:00.000Z", //ISO-8601
            ContextId = "41DF2E16046E00006278C0B200000350"
         };

         IRisk risks = new Risk
         {
            Data = new List<IRiskData>
            {
               riskData
            }
         };

         try
         {
            IList<IResponseRiskData> ret = await riskService.CreateRisk(risks);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DeleteRisk(string riskId)
      {
         RiskService riskService = ServiceFactoryCreate(await Authenticate());


         try
         {
            IResponseRisk ret = await riskService.DeleteRisk(riskId);

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