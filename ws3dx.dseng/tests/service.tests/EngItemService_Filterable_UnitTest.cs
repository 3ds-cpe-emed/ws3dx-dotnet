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
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.dseng.data.impl;
using ws3dx.shared.data.dscfg;
using ws3dx.utils;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_Filterable_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstanceEffectivity(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
               Assert.IsNotNull(ret);

               foreach (IEngInstanceDefaultMask engInstance in ret)
               {
                  IEnumerable<IFilterableDetailMask> filterInstance = await engItemService.GetInstanceEffectivity(engItemSearchResult.First().Id, engInstance.Id);

                  Assert.IsNotNull(filterInstance);
               }
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task SetInstanceEvolutionEffectivity(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         string lastEffectivityEvolutionValue = null;
         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
               Assert.IsNotNull(ret);

               foreach (IEngInstanceDefaultMask engInstance in ret)
               {
                  IEnumerable<IFilterableDetailMask> filterInstanceResponse = await engItemService.GetInstanceEffectivity(engItemSearchResult.First().Id, engInstance.Id);

                  Assert.IsNotNull(filterInstanceResponse);
                  Assert.Greater(filterInstanceResponse.Count(), 0);
                  Assert.IsNotNull(filterInstanceResponse.First());

                  IFilterableDetailMask filterDetailMask = filterInstanceResponse.First();

                  JsonElement effectivityContent = (JsonElement)filterDetailMask.EffectivityContent;
                  JsonElement effectivityContentPropertyValue;
                  if (!effectivityContent.TryGetProperty("Effectivity_Evolution", out effectivityContentPropertyValue))
                  {
                     throw new System.Exception("Missing EffectivityEvolution property");
                  }

                  string effectivityContentString = effectivityContentPropertyValue.GetString();

                  if (!effectivityContentString.IsNullOrEmpty())
                  {
                     lastEffectivityEvolutionValue = effectivityContentString;
                  }

                  if ((lastEffectivityEvolutionValue != null) && effectivityContentString.IsNullOrEmpty())
                  {
                     ISetEvolutionEffectivities request = new SetEvolutionEffectivities();
                     request.EvolutionContent = lastEffectivityEvolutionValue;

                     ISetEvolutionResponse instanceEvolutionEffectivity = await engItemService.SetInstanceEvolutionEffectivity(engItem.Id, engInstance.Id, request);

                     Assert.IsNotNull(instanceEvolutionEffectivity);
                  }
               }
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceVariantEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            IResponseUnsetVariantEffectivity ret = await engItemService.UnsetInstanceVariantEffectivity(engItemId, instanceId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task SetInstanceVariantEffectivity(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         string lastEffectivityVariantValue = null;
         try
         {
            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
               Assert.IsNotNull(ret);

               foreach (IEngInstanceDefaultMask engInstance in ret)
               {
                  IEnumerable<IFilterableDetailMask> filterInstanceResponse = await engItemService.GetInstanceEffectivity(engItemSearchResult.First().Id, engInstance.Id);

                  Assert.IsNotNull(filterInstanceResponse);
                  Assert.Greater(filterInstanceResponse.Count(), 0);
                  Assert.IsNotNull(filterInstanceResponse.First());

                  IFilterableDetailMask filterDetailMask = filterInstanceResponse.First();

                  JsonElement effectivityContent = (JsonElement)filterDetailMask.EffectivityContent;
                  JsonElement effectivityContentPropertyValue;
                  if (!effectivityContent.TryGetProperty("Effectivity_Variant", out effectivityContentPropertyValue))
                  {
                     throw new System.Exception("Missing Effectivity_Variant property");
                  }

                  string effectivityContentString = effectivityContentPropertyValue.GetString();

                  if (!effectivityContentString.IsNullOrEmpty())
                  {
                     lastEffectivityVariantValue = effectivityContentString;
                  }

                  if ((lastEffectivityVariantValue != null) && effectivityContentString.IsNullOrEmpty())
                  {
                     ISetVariantEffectivities request = new SetVariantEffectivities();
                     request.VariantContent = lastEffectivityVariantValue;

                     ISetVariantResponse instanceVariantEffectivity = await engItemService.SetInstanceVariantEffectivity(engItem.Id, engInstance.Id, request);

                     Assert.IsNotNull(instanceVariantEffectivity);
                  }
               }
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceEvolutionEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            IResponseUnsetEvolutionEffectivity ret = await engItemService.UnsetInstanceEvolutionEffectivity(engItemId, instanceId);

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