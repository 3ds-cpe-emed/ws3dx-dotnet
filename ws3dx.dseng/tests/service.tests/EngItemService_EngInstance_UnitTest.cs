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
using ws3dx.dseng.core.data.impl;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;

namespace NUnitTestProject
{
   public class EngItemService_EngInstance_UnitTests : EngItemServiceSetup
   {
      [TestCase("", "", "")]
      public async Task GetInstance_IEngInstanceFilterableMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngInstanceFilterableMask ret = await engItemService.GetInstance<IEngInstanceFilterableMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task GetInstance_IEngInstancePositionMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);
         IEngInstancePositionMask ret = await engItemService.GetInstance<IEngInstancePositionMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task GetInstance_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);
         IEngInstanceDefaultMask ret = await engItemService.GetInstance<IEngInstanceDefaultMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task GetInstance_IEngInstanceDetailsMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);
         IEngInstanceDetailsMask ret = await engItemService.GetInstance<IEngInstanceDetailsMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstances_IEngInstanceFilterableMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.GetInstances<IEngInstanceFilterableMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstances_IEngInstancePositionMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnumerable<IEngInstancePositionMask> ret = await engItemService.GetInstances<IEngInstancePositionMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstances_IEngInstanceDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstances_IEngInstanceDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);
         IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceFilterableMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.ReplaceInstance<IEngInstanceFilterableMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.ReplaceInstance<IEngInstanceDefaultMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceDetailsMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.ReplaceInstance<IEngInstanceDetailsMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IEngInstanceFilterableMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.AddInstance<IEngInstanceFilterableMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IEngInstancePositionMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstancePositionMask> ret = await engItemService.AddInstance<IEngInstancePositionMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IEngInstanceDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.AddInstance<IEngInstanceDefaultMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IEngInstanceDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.AddInstance<IEngInstanceDetailsMask>(engItemId, request);

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