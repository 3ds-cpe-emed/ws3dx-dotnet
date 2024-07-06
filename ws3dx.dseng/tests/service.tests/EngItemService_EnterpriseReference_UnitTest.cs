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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;

namespace NUnitTestProject
{
   public class EngItemService_EnterpriseReference_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("3784C760967A00006409AA5B000160E9")]
      public async Task GetEnterpriseItemNumber(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnterpriseItemNumberMask ret = await engItemService.GetEnterpriseItemNumber(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("3784C760967A00006409AA5B000160E9", "AAA27:2000001")]
      public async Task UpdateEnterpriseItemNumber(string engItemId, string enterpriseItemNumber)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnterpriseItemNumber request = new EnterpriseItemNumber();
         request.PartNumber = enterpriseItemNumber;

         try
         {
            IEnterpriseItemNumberMask ret = await engItemService.UpdateEnterpriseItemNumber(engItemId, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("4D0376286BCC3600666C0DC800018113", "AAA27:1000001")]
      public async Task AttachEnterpriseItemNumber(string engItemId, string enterpriseItemNumber)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnterpriseItemNumber request = new EnterpriseItemNumber();
         request.PartNumber = enterpriseItemNumber;

         try
         {
            IEnterpriseItemNumberMask ret = await engItemService.AttachEnterpriseItemNumber(engItemId, request);

            Assert.IsNotNull(ret);
            Assert.AreEqual(enterpriseItemNumber, ret.PartNumber);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}