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
using ws3dx.dsbks.core.data.impl;
using ws3dx.dsbks.core.service;
using ws3dx.dsbks.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class BookmarkService_Bookmark_UnitTests : BookmarkServiceTestsSetup
   {
      [TestCase("bookmark", 0, 50)]
      public async Task Search_Paged_IBookmarkMask(string search, int skip, int top)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkMask> ret = await bookmarkService.Search<IBookmarkMask>(searchByFreeText, skip, top);
         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IBookmarkMask bksMask in ret)
         {
            IEnumerable<IBookmarkDetailMask> bksEnum = await bookmarkService.Get<IBookmarkDetailMask>(bksMask.Id, top.ToString(), skip.ToString());

            foreach (IBookmarkDetailMask bksMaskDetail in bksEnum)
            {
               Assert.AreEqual(bksMaskDetail.Id, bksMask.Id);
            }

            i++;

            if (i > 20) return;
         }
      }

      [TestCase("search")]
      public async Task Search_Full_IBookmarkMask(string search)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkMask> ret = await bookmarkService.Search<IBookmarkMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IBookmarkDetailMask(string search, int skip, int top)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Search<IBookmarkDetailMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IBookmarkDetailMask(string search)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Search<IBookmarkDetailMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task Get_IBookmarkMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IBookmarkMask> ret = await bookmarkService.Get<IBookmarkMask>(bookmarkId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task Get_IBookmarkDetailMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Get<IBookmarkDetailMask>(bookmarkId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task Get_IBookmarkItemsMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Get<IBookmarkItemsMask>(bookmarkId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task Get_IBookmarkSubBookmarksMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Get<IBookmarkSubBookmarksMask>(bookmarkId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "", "")]
      public async Task Get_IBookmarkParentMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Get<IBookmarkParentMask>(bookmarkId, top, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27WSBOOKMARK1", "Description of bookmark")]
      public async Task Create_IBookmarkMask(string bookMarkTitle, string bookMarkDescription)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         INewBookmark newBookmark = new NewBookmark
         {
            Attributes = new NewBookmarkData()
         };
         newBookmark.Attributes.Title = bookMarkTitle;
         newBookmark.Attributes.Description = bookMarkDescription;

         ICreateBookmarks request = new CreateBookmarks();
         request.Items = new List<INewBookmark>() { newBookmark };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Create<IBookmarkMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      // Create SUB-BOOKMARK
      [TestCase("44C2728FF159000064183E6E001CC996", "AAA27WS-SUB-BOOKMARK1", "Description of sub bookmark")]
      public async Task Create_IBookmarkDetailMask(string parentId, string bookMarkTitle, string bookMarkDescription)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         INewBookmark newBookmark = new NewBookmark
         {
            Attributes = new NewBookmarkData()
         };
         newBookmark.Attributes.Title = bookMarkTitle;
         newBookmark.Attributes.Description = bookMarkDescription;

         ICreateBookmarks request = new CreateBookmarks();
         request.Items = new List<INewBookmark>() { newBookmark };
         request.ParentId = parentId;

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Create<IBookmarkDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }


      [TestCase()]
      public async Task Create_IBookmarkLinkableMask()
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ICreateBookmarks request = new CreateBookmarks();

         try
         {
            IEnumerable<IBookmarkLinkableMask> ret = await bookmarkService.Create<IBookmarkLinkableMask>(request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Attach<IBookmarkMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkDetailMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Attach<IBookmarkDetailMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkItemsMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Attach<IBookmarkItemsMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkSubBookmarksMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Attach<IBookmarkSubBookmarksMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Attach_IBookmarkParentMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Attach<IBookmarkParentMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      //[TestCase()]
      //public async Task Locate()
      //{
      //   BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

      //   ITypedUriIdentifier request = new TypedUriIdentifier();

      //   try
      //   {
      //      ret = await bookmarkService.Locate(request);

      //      Assert.IsNotNull(ret);

      //   }
      //   catch (HttpResponseException _ex)
      //   {
      //      string errorMessage = await _ex.GetErrorMessage();
      //      Assert.Fail(errorMessage);
      //   }
      //}

      [TestCase("")]
      public async Task Detach_IBookmarkMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.Detach<IBookmarkMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IBookmarkDetailMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.Detach<IBookmarkDetailMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IBookmarkItemsMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkItemsMask> ret = await bookmarkService.Detach<IBookmarkItemsMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IBookmarkSubBookmarksMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkSubBookmarksMask> ret = await bookmarkService.Detach<IBookmarkSubBookmarksMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Detach_IBookmarkParentMask(string bookmarkId, string top, string skip)
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<IBookmarkParentMask> ret = await bookmarkService.Detach<IBookmarkParentMask>(bookmarkId, top, skip, request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IBookmarkMask()
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IUpdateBookmark[] request = new UpdateBookmark[] { };

         try
         {
            IEnumerable<IBookmarkMask> ret = await bookmarkService.BulkUpdate<IBookmarkMask>(request);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkUpdate_IBookmarkDetailMask()
      {
         BookmarkService bookmarkService = ServiceFactoryCreate(await Authenticate());

         IUpdateBookmark[] request = new UpdateBookmark[] { };

         try
         {
            IEnumerable<IBookmarkDetailMask> ret = await bookmarkService.BulkUpdate<IBookmarkDetailMask>(request);

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