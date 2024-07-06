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
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.dseng.data.impl;
using ws3dx.shared.data.primitive;
using ws3dx.utils;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_ConfiguredInstance_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetConfiguredInstance(string _title, string _rev)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> instancesResponse = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(instancesResponse);

            foreach (IEngInstanceDetailsMask engInstanceDetailsMask in instancesResponse)
            {
               if (!engInstanceDetailsMask.HasConfiguredInstance.IsNullOrEmpty())
               {
                  if (engInstanceDetailsMask.HasConfiguredInstance.Equals("YES", System.StringComparison.InvariantCultureIgnoreCase))
                  {
                     IGetConfiguredInstance ret = await engItemService.GetConfiguredInstance(engItem.Id, engInstanceDetailsMask.Id);

                     Assert.IsNotNull(ret);
                     Assert.IsNotNull(ret.AssociatedFilter);
                  }
               }
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1", "4D03762808D539006687D54200000851")]
      public async Task UnsetConfiguredInstance(string _title, string _rev, string _instanceId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               IEngInstanceDetailsMask instance = await engItemService.GetInstance<IEngInstanceDetailsMask>(engItem.Id, _instanceId);
               Assert.IsNotNull(instance);

               if (!instance.HasConfiguredInstance.IsNullOrEmpty() && instance.HasConfiguredInstance.Equals("YES", System.StringComparison.InvariantCultureIgnoreCase))
               {
                  IPhysicalId ret = await engItemService.UnsetConfiguredInstance(engItem.Id, instance.Id);

                  Assert.IsNotNull(ret);

                  break;
               }
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1", "4D03762808D539006687D54200000851", "4D0376286BCC3600666D5B700009DCF8")]
      public async Task SetConfiguredInstance(string _title, string _rev, string _instanceId, string _filterId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {

               IEngInstanceDetailsMask instance = await engItemService.GetInstance<IEngInstanceDetailsMask>(engItem.Id, _instanceId);
               Assert.IsNotNull(instance);

               if (!instance.HasConfiguredInstance.IsNullOrEmpty() && instance.HasConfiguredInstance.Equals("NO", System.StringComparison.InvariantCultureIgnoreCase))
               {
                  ISetConfiguredInstance request = new SetConfiguredInstance();

                  request.FilterIdentifier = _filterId;

                  IPhysicalId ret = await engItemService.SetConfiguredInstance(engItem.Id, instance.Id, request);
                  Assert.IsNotNull(ret);

                  break;
               }
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1", "4D03762808D539006687D54200000851", "4D0376286BCC3600666D5B640009DCCC")]
      public async Task UpdateConfiguredInstance(string _title, string _rev, string _instanceId, string _filterId)
      {
         EngItemService engItemService = ServiceFactoryCreate(await Authenticate());

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         ISetConfiguredInstance request = new SetConfiguredInstance();
         request.FilterIdentifier = _filterId;

         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               IPhysicalId ret = await engItemService.UpdateConfiguredInstance(engItem.Id, _instanceId, request);
               Assert.IsNotNull(ret);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}