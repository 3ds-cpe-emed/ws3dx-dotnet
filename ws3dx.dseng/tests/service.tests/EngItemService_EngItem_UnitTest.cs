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
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_EngItem_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27", 0, 10)]
      public async Task Get_IEngItemDefaultMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

         string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

         foreach (string engItemId in engItemIdArray)
         {
            IEngItemDefaultMask ret = await engItemService.Get<IEngItemDefaultMask>(engItemId);

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Id, engItemId);
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task Get_IEngItemConfigMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

         string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

         foreach (string engItemId in engItemIdArray)
         {
            IEngItemConfigMask ret = null;

            try
            {
               ret = await engItemService.Get<IEngItemConfigMask>(engItemId);
            }

            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Id, engItemId);
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task Get_IEngItemDetailsMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

         IEnumerable<IEngItemDetailsMask> engItemSearchResult = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText, _skip, _top);

         string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

         foreach (string engItemId in engItemIdArray)
         {
            IEngItemDetailsMask ret = await engItemService.Get<IEngItemDetailsMask>(engItemId);

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Id, engItemId);
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task Get_IEngItemCommonMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

         string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

         foreach (string engItemId in engItemIdArray)
         {
            IEngItemCommonMask ret = await engItemService.Get<IEngItemCommonMask>(engItemId);

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Id, engItemId);
         }

      }

      [TestCase("AAA27", 0, 10)]
      public async Task Search_Paged_IEngItemDefaultMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDefaultMask> ret = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Search_Full_IEngItemDefaultMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDefaultMask> ret = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);

         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IEngItemDefaultMask engItem in ret)
         {
            IEngItemDetailsMask engItemDetail = await engItemService.Get<IEngItemDetailsMask>(engItem.Id);

            Assert.AreEqual(engItem.Id, engItemDetail.Id);

            i++;

            if (i > 20) return;
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task Search_Paged_IEngItemDetailsMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27")]
      public async Task Search_Full_IEngItemDetailsMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IList<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText);

         TestContext.Out.Write("retrieved : " + ret.Count);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27", 0, 50)]
      public async Task Search_Paged_IEngItemCommonMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27")]
      public async Task Search_Full_IEngItemCommonMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IList<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText);

         TestContext.Out.Write("retrieved : " + ret.Count);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27", 0, 10)]
      public async Task BulkFetch_IEngItemDefaultMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

            IList<string> errorIdList = null;

            IEnumerable<IEngItemDefaultMask> returnSetWithDefaultMask = null;

            (returnSetWithDefaultMask, errorIdList) = await engItemService.BulkFetch<IEngItemDefaultMask>(engItemIdArray);

            Assert.IsNotNull(returnSetWithDefaultMask);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task BulkFetch_IEngItemDetailsMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

            IList<string> errorIdList = null;

            IEnumerable<IEngItemDetailsMask> returnSetWithDetailMask = null;

            (returnSetWithDetailMask, errorIdList) = await engItemService.BulkFetch<IEngItemDetailsMask>(engItemIdArray);

            Assert.IsNotNull(returnSetWithDetailMask);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 10)]
      public async Task BulkFetch_IEngItemCommonMask(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

            IList<string> errorIdList = null;

            IEnumerable<IEngItemCommonMask> returnSetWithCommonMask = null;

            (returnSetWithCommonMask, errorIdList) = await engItemService.BulkFetch<IEngItemCommonMask>(engItemIdArray);

            Assert.IsNotNull(returnSetWithCommonMask);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate_IEngItemDefaultMask(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            Tuple<string, string>[] engItemIdArray = engItemSearchResult.Where(engItem => engItem.State.Equals("IN_WORK")).Select(engItem => new Tuple<string, string>(engItem.Id, engItem.Cestamp)).ToArray();

            IEngItemBulkUpdateItem[] bulkUpdates = new IEngItemBulkUpdateItem[engItemIdArray.Length];

            for (int i = 0; i < engItemIdArray.Length; i++)
            {
               bulkUpdates[i] = new EngItemBulkUpdateItem();
               bulkUpdates[i].Id = engItemIdArray[i].Item1;
               bulkUpdates[i].Cestamp = engItemIdArray[i].Item2;
               bulkUpdates[i].Description = _description_update;
            }

            (IEnumerable<IEngItemDefaultMask> returnSetWithDefaultMask, IList<string> errIdList) = await engItemService.BulkUpdate<IEngItemDefaultMask>(bulkUpdates);

            Assert.That(returnSetWithDefaultMask, Is.All.Matches<IEngItemDefaultMask>(engItem => engItem.Description.Equals(_description_update)));
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate_IEngItemConfigMask(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            Tuple<string, string>[] engItemIdArray = engItemSearchResult.Where(engItem => engItem.State.Equals("IN_WORK")).Select(engItem => new Tuple<string, string>(engItem.Id, engItem.Cestamp)).ToArray();

            IEngItemBulkUpdateItem[] bulkUpdates = new IEngItemBulkUpdateItem[engItemIdArray.Length];

            for (int i = 0; i < engItemIdArray.Length; i++)
            {
               bulkUpdates[i] = new EngItemBulkUpdateItem();
               bulkUpdates[i].Id = engItemIdArray[i].Item1;
               bulkUpdates[i].Cestamp = engItemIdArray[i].Item2;
               bulkUpdates[i].Description = _description_update;
            }

            (IEnumerable<IEngItemConfigMask> returnSetWithDefaultMask, IList<string> errIdList) = await engItemService.BulkUpdate<IEngItemConfigMask>(bulkUpdates);

            Assert.That(returnSetWithDefaultMask, Is.All.Matches<IEngItemConfigMask>(engItem => engItem.Description.Equals(_description_update)));
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate_IEngItemDetailsMask(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDetailsMask> engItemSearchResult = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText, _skip, _top);

            Tuple<string, string>[] engItemIdArray = engItemSearchResult.Where(engItem => engItem.State.Equals("IN_WORK")).Select(engItem => new Tuple<string, string>(engItem.Id, engItem.Cestamp)).ToArray();

            IEngItemBulkUpdateItem[] bulkUpdates = new IEngItemBulkUpdateItem[engItemIdArray.Length];

            for (int i = 0; i < engItemIdArray.Length; i++)
            {
               bulkUpdates[i] = new EngItemBulkUpdateItem();
               bulkUpdates[i].Id = engItemIdArray[i].Item1;
               bulkUpdates[i].Cestamp = engItemIdArray[i].Item2;
               bulkUpdates[i].Description = _description_update;
            }

            (IEnumerable<IEngItemDetailsMask> returnSetWithDefaultMask, IList<string> errIdList) = await engItemService.BulkUpdate<IEngItemDetailsMask>(bulkUpdates);

            Assert.That(returnSetWithDefaultMask, Is.All.Matches<IEngItemDetailsMask>(engItem => engItem.Description.Equals(_description_update)));
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate_IEngItemCommonMask(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemCommonMask> engItemSearchResult = await engItemService.Search<IEngItemCommonMask>(searchByFreeText, _skip, _top);

            Tuple<string, string>[] engItemIdArray = engItemSearchResult.Where(engItem => engItem.State.Equals("IN_WORK")).Select(engItem => new Tuple<string, string>(engItem.Id, engItem.Cestamp)).ToArray();

            IEngItemBulkUpdateItem[] bulkUpdates = new IEngItemBulkUpdateItem[engItemIdArray.Length];

            for (int i = 0; i < engItemIdArray.Length; i++)
            {
               bulkUpdates[i] = new EngItemBulkUpdateItem();
               bulkUpdates[i].Id = engItemIdArray[i].Item1;
               bulkUpdates[i].Cestamp = engItemIdArray[i].Item2;
               bulkUpdates[i].Description = _description_update;
            }

            (IEnumerable<IEngItemCommonMask> returnSetWithDefaultMask, IList<string> errIdList) = await engItemService.BulkUpdate<IEngItemCommonMask>(bulkUpdates);

            Assert.That(returnSetWithDefaultMask, Is.All.Matches<IEngItemCommonMask>(engItem => engItem.Description.Equals(_description_update)));
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Create_IEngItemDefaultMask(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = _title;

         ICreateEngItem request = new CreateEngItem();
         request.Items = [newEngItem];

         try
         {
            IEnumerable<IEngItemDefaultMask> ret = await engItemService.Create<IEngItemDefaultMask>(request);

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Count(), 1);

            foreach (IEngItemDefaultMask item in ret)
            {
               Assert.AreEqual(item.Title, _title);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Create_IEngItemConfigMask(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = _title;

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemConfigMask> ret = await engItemService.Create<IEngItemConfigMask>(request);

            Assert.IsNotNull(ret);

            foreach (IEngItemConfigMask engItem in ret)
            {
               Assert.IsNotNull(engItem.ConfigurationContext);
               Assert.AreEqual(engItem.Title, _title);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Create_IEngItemDetailsMask(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = _title;

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDetailsMask> ret = await engItemService.Create<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
            foreach (IEngItemDetailsMask engItem in ret)
            {
               Assert.IsNotNull(engItem.EnterpriseAttributes);
               Assert.IsNotNull(engItem.EnterpriseReference);

               Assert.AreEqual(engItem.Title, _title);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Create_IEngItemCommonMask(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = _title;

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemCommonMask> ret = await engItemService.Create<IEngItemCommonMask>(request);

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Count(), 1);

            foreach (IEngItemCommonMask engItem in ret)
            {
               Assert.IsNotNull(engItem.Usage);
               Assert.AreEqual(engItem.Title, _title);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Engineering item created from Web Service", "AAA27:128")]
      public async Task Create_IEngItemDetailsMask_WithEnterpriseReference(string _title, string _partnumber)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.EnterpriseReference = new EnterpriseItemNumber();

         newEngItem.Attributes.Title = _title;
         newEngItem.Attributes.EnterpriseReference.PartNumber = _partnumber;

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDetailsMask> ret = await engItemService.Create<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
            foreach (IEngItemDetailsMask engItem in ret)
            {
               Assert.IsNotNull(engItem.EnterpriseAttributes);
               Assert.IsNotNull(engItem.EnterpriseReference);

               Assert.AreEqual(engItem.Title, _title);
               Assert.AreEqual(engItem.EnterpriseReference.PartNumber, _partnumber);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task Expand(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         try
         {
            SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

            foreach (IEngItemDefaultMask engItem in engItemSearchResult)
            {
               Expand expand = new Expand
               {
                  ExpandDepth = -1,
                  WithPath = true,
                  TypeFilterBo = ["VPMReference", "VPMRepReference"],
                  TypeFilterRel = ["VPMInstance", "VPMRepInstance"]
               };

               IEnumerable<object> ret = await engItemService.Expand(engItem.Id, expand);
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