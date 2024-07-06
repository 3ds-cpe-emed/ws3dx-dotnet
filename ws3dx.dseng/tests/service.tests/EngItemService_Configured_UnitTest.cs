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
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.shared.data;
using ws3dx.shared.data.dscfg;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_Configured_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetConfiguration_IConfiguredDetail(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         try
         {
            IEnumerable<IConfiguredDetail> ret = await engItemService.GetConfiguration<IConfiguredDetail>(engItemSearchResult.First().Id);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException ex)
         {
            Assert.Fail(await ex.GetErrorMessage());
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetConfiguration_IConfiguredBasics(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         try
         {
            IEnumerable<IConfiguredBasics> ret = await engItemService.GetConfiguration<IConfiguredBasics>(engItemSearchResult.First().Id);
         }
         catch (HttpResponseException ex)
         {
            Assert.Fail(await ex.GetErrorMessage());
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1", "Model", "4D0376286BCC3600666C101E000950CC", "/resources/v1/modeler/dspfl/dspfl:Model/4D0376286BCC3600666C101E000950CC")]
      public async Task AttachConfiguration(string _title, string _rev, string _cfgType, string _cfgId, string _cfgRelPath)
      {

         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         try
         {
            ITypedUriIdentifier cfg = new TypedUriIdentifier
            {
               Type = _cfgType,
               Identifier = _cfgId,
               RelativePath = _cfgRelPath,
               Source = engItemService.EnoviaServiceURL
            };

            ITypedUriIdentifier[] cfgRequest = [cfg];

            IEnumerable<ITypedUriIdentifier> attachConfigurationReturn = await engItemService.AttachConfiguration(engItemSearchResult.First().Id, cfgRequest);

            Assert.IsNotNull(attachConfigurationReturn);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task DetachConfiguration(string _title, string _rev)
      {
         EngItemService engItemService = await GetAuthenticatedEngineeringServiceAsync();

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         Assert.IsNotNull(engItemSearchResult);
         Assert.Greater(engItemSearchResult.Count(), 0);
         Assert.IsNotNull(engItemSearchResult.First());

         try
         {
            IEnumerable<IConfiguredDetail> ret = await engItemService.GetConfiguration<IConfiguredDetail>(engItemSearchResult.First().Id);

            Assert.IsNotNull(ret);
            Assert.Greater(ret.Count(), 0);
            Assert.IsNotNull(ret.First());

            Assert.IsNotNull(ret.First().ConfigurationCtxt);
            Assert.Greater(ret.First().ConfigurationCtxt.Count(), 0);
            Assert.IsNotNull(ret.First().ConfigurationCtxt.First());

            IConfigurationContext configurationContext = ret.First().ConfigurationCtxt.First();

            TypedUriIdentifier configurationObject = new TypedUriIdentifier
            {
               Type = configurationContext.Type,
               Identifier = configurationContext.Identifier,
               RelativePath = configurationContext.RelativePath,
               Source = engItemService.EnoviaServiceURL
            };

            ITypedUriIdentifier[] request = [configurationObject];

            IEnumerable<ITypedUriIdentifier> detachConfigurationReturn = await engItemService.DetachConfiguration(engItemSearchResult.First().Id, request);

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