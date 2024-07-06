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
using System.Linq;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.dseng.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_EngRepInstance_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27:TEST:0001", "A.1")]
      public async Task GetEngRepInstance_IEngRepInstanceDetailMask(string _title, string _revision)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchByFreeText = new SearchByTitleRevision(_title, _revision);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);

         IEngItemDefaultMask engItem = engItemSearchResult.First();

         IEnumerable<IEngInstanceDefaultMask> engRepInstances = await engItemService.GetRepInstances<IEngInstanceDefaultMask>(engItem.Id);

         Assert.IsNotNull(engRepInstances);
         Assert.Greater(engRepInstances.Count(), 0);

         foreach (IEngInstanceDefaultMask engRepInstance in engRepInstances)
         {
            IEngRepInstanceDetailMask ret = await engItemService.GetRepInstance<IEngRepInstanceDetailMask>(engItem.Id, engRepInstance.Id);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27:TEST:0001", "A.1")]
      public async Task GetEngRepInstance_IEngInstanceDefaultMask(string _title, string _revision)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchByFreeText = new SearchByTitleRevision(_title, _revision);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);

         IEngItemDefaultMask engItem = engItemSearchResult.First();

         IEnumerable<IEngInstanceDefaultMask> engRepInstances = await engItemService.GetRepInstances<IEngInstanceDefaultMask>(engItem.Id);

         Assert.IsNotNull(engRepInstances);
         Assert.Greater(engRepInstances.Count(), 0);

         foreach (IEngInstanceDefaultMask engRepInstance in engRepInstances)
         {
            IEngInstanceDefaultMask ret = await engItemService.GetRepInstance<IEngInstanceDefaultMask>(engItem.Id, engRepInstance.Id);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27:TEST:0001", "A.1")]
      public async Task GetEngRepInstances_IEngRepInstanceDetailMask(string _title, string _revision)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchByFreeText = new SearchByTitleRevision(_title, _revision);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);

         Assert.IsNotNull(engItemSearchResult);
         Assert.IsNotNull(engItemSearchResult.First());

         IEngItemDefaultMask engItem = engItemSearchResult.First();

         IEnumerable<IEngRepInstanceDetailMask> ret = await engItemService.GetRepInstances<IEngRepInstanceDetailMask>(engItem.Id);

         Assert.IsNotNull(ret);
         Assert.IsNotNull(ret.First());

      }

      [TestCase("AAA27:TEST:0001", "A.1")]
      public async Task GetEngRepInstances_IEngInstanceDefaultMask(string _title, string _revision)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchByFreeText = new SearchByTitleRevision(_title, _revision);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);

         Assert.IsNotNull(engItemSearchResult);
         Assert.IsNotNull(engItemSearchResult.First());

         IEngItemDefaultMask engItem = engItemSearchResult.First();

         IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetRepInstances<IEngInstanceDefaultMask>(engItem.Id);

         Assert.IsNotNull(ret);
         Assert.IsNotNull(ret.First());

      }

      [TestCase("", "")]
      public async Task AddEngRepInstanceReplace_IEngRepInstanceDetailMask(string engItemId, string repInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngRepInstanceReplace request = new EngRepInstanceReplace();

         try
         {
            IEngRepInstanceDetailMask ret = await engItemService.ReplaceRepInstance<IEngRepInstanceDetailMask>(engItemId, repInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AddEngRepInstanceReplace_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngRepInstanceReplace request = new EngRepInstanceReplace();

         try
         {
            IEngInstanceDefaultMask ret = await engItemService.ReplaceRepInstance<IEngInstanceDefaultMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddEngRepInstance_IEngRepInstanceDetailMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngRepInstances request = new CreateEngRepInstances();

         try
         {
            IEnumerable<IEngRepInstanceDetailMask> ret = await engItemService.AddRepInstance<IEngRepInstanceDetailMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddEngRepInstance_IEngInstanceDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         ICreateEngRepInstances request = new CreateEngRepInstances();

         try
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.AddRepInstance<IEngInstanceDefaultMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task ReplaceEngRepInstance_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         IEngRepInstanceReplace request = new EngRepInstanceReplace();

         try
         {
            IEngInstanceDefaultMask ret = await engItemService.ReplaceRepInstance<IEngInstanceDefaultMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task ReplaceEngRepInstance_IEngRepInstanceDetailMask(string engItemId, string instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         IEngRepInstanceReplace request = new EngRepInstanceReplace();

         try
         {
            IEngRepInstanceDetailMask ret = await engItemService.ReplaceRepInstance<IEngRepInstanceDetailMask>(engItemId, instanceId, request);

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