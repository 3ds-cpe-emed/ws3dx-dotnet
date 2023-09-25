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
using System.Threading.Tasks;

using ws3dx.authentication.data;

using ws3dx.utils.search;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.data.impl;
using ws3dx.shared.data.impl;
using System.Linq;

namespace NUnitTestProject
{
   public class EngItemService_EngItem_UnitTests : EngItemServiceSetup
   {
      [TestCase("", "")]
      public async Task Get_IEngItemDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemDefaultMask ret = await engItemService.Get<IEngItemDefaultMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task Get_IEngItemConfigMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemConfigMask ret = await engItemService.Get<IEngItemConfigMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task Get_IEngItemDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemDetailsMask ret = await engItemService.Get<IEngItemDetailsMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task Get_IEngItemCommonMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemCommonMask ret = await engItemService.Get<IEngItemCommonMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
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

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IEngItemDetailsMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IEngItemDetailsMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IEngItemCommonMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IEngItemCommonMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      // Exercises Bulk Fetch by passing the ids of the result of search into it.
      // It does this for all the three masks available types.
      [TestCase("AAA27", 0, 10)]
      public async Task BulkFetch(string _search, int _skip, int _top)
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
            IEnumerable<IEngItemCommonMask> returnSetWithCommonMask = null;
            IEnumerable<IEngItemDetailsMask> returnSetWithDetailMask = null;

            (returnSetWithDefaultMask, errorIdList) = await engItemService.BulkFetch<IEngItemDefaultMask>(engItemIdArray);

            (returnSetWithCommonMask, errorIdList)  = await engItemService.BulkFetch<IEngItemCommonMask>(engItemIdArray);

            (returnSetWithDetailMask, errorIdList)  = await engItemService.BulkFetch<IEngItemDetailsMask>(engItemIdArray);

            Assert.AreEqual(returnSetWithDefaultMask.Count(), returnSetWithCommonMask.Count(), returnSetWithDetailMask.Count());
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IEngItemDefaultMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         string[] request = new string[] { };

         try
         {
            (IEnumerable<IEngItemDefaultMask> ret, IList<string> errorIdList) = await engItemService.BulkFetch<IEngItemDefaultMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IEngItemDetailsMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         string[] request = new string[] { };

         try
         {
            (IEnumerable<IEngItemDetailsMask> ret, IList<string> errorIdList) = await engItemService.BulkFetch<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IEngItemCommonMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         string[] request = new string[] { };

         try
         {
            (IEnumerable<IEngItemCommonMask> ret, IList<string> errorIdList) = await engItemService.BulkFetch<IEngItemCommonMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      // Exercises Bulk Fetch by modifying the description of all results of the search into it.
      // It does this for all the three masks available types.
      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            Tuple<string, string>[] engItemIdArray = engItemSearchResult.Select(engItem => new Tuple<string, string>(engItem.Id, engItem.Cestamp)).ToArray();

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

      [TestCase()]
      public async Task BulkUpdate_IEngItemDefaultMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            (IEnumerable<IEngItemDefaultMask> ret, IList<string> errorIdList) = await engItemService.BulkUpdate<IEngItemDefaultMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IEngItemConfigMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            (IEnumerable<IEngItemConfigMask> ret, IList<string> errorIdList) = await engItemService.BulkUpdate<IEngItemConfigMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IEngItemDetailsMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            (IEnumerable<IEngItemDetailsMask> ret, IList<string> errorIdList) = await engItemService.BulkUpdate<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IEngItemCommonMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEngItemBulkUpdateItem[] request = new EngItemBulkUpdateItem[] { };

         try
         {
            (IEnumerable<IEngItemCommonMask> ret, IList<string> errorIdList) = await engItemService.BulkUpdate<IEngItemCommonMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemDefaultMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDefaultMask> ret = await engItemService.Create<IEngItemDefaultMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemConfigMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);
         
         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

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
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemDetailsMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

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
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemCommonMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemCommonMask> ret = await engItemService.Create<IEngItemCommonMask>(request);

            Assert.IsNotNull(ret);

            foreach (IEngItemCommonMask engItem in ret)
            {
               Assert.IsNotNull(engItem.Usage);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemDetailsMask_WithEnterpriseReference()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.EnterpriseReference = new EnterpriseItemNumber();

         newEngItem.Attributes.Title = "New Engineering item created from Web Service";
         newEngItem.Attributes.EnterpriseReference.PartNumber = "AAA27:000001";

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
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Expand(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IExpand request = new Expand();

         try
         {
            IExpandResponse ret = await engItemService.Expand(engItemId, request);

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