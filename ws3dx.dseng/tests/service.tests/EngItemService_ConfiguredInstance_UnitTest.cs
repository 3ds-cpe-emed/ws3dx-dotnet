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
using ws3dx.core.exception;
using ws3dx.dseng.core.data.impl;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.shared.data;

namespace NUnitTestProject
{
   public class EngItemService_ConfiguredInstance_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("", "")]
      public async Task GetConfiguredInstance(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         IGetConfiguredInstance ret = await engItemService.GetConfiguredInstance(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task UnsetConfiguredInstance(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IPhysicalId ret = await engItemService.UnsetConfiguredInstance(engItemId, instanceId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task SetConfiguredInstance(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         ISetConfiguredInstance request = new SetConfiguredInstance();

         try
         {
            IPhysicalId ret = await engItemService.SetConfiguredInstance(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UpdateConfiguredInstance(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         ISetConfiguredInstance request = new SetConfiguredInstance();

         try
         {
            IPhysicalId ret = await engItemService.UpdateConfiguredInstance(engItemId, instanceId, request);

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