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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.dsbks.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsbks.core.service
{
   // SDK Service
   public class BookmarkService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsbks/";

      public BookmarkService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/dsbks:Bookmark/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IBookmarkMask), typeof(IBookmarkDetailMask) };
      }

      protected override string GetSearchSkipParamName()
      {
         return "$skip";
      }

      protected override string GetSearchTopParamName()
      {
         return "$top";
      }

      protected override string GetSearchCriteriaParamName()
      {
         return "$searchStr";
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery)
      {
         return await SearchCollection<T>("member", searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await SearchCollection<T>("member", searchQuery, _skip, _top);
      }
      #endregion

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsbks:Bookmark/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a bookmark object referencing items Summary: Gets a bookmark
      // <param name="bookmarkId">
      // Description: dsbks:Bookmark object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned under the bookmark, accepts a maximum 
      // value of 1000 (to be used along with $mask query parameter having values dsbks:BksMask.Items and 
      // dsbks:BksMask.Bookmarks)
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string bookmarkId, string top, string skip)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask), typeof(IBookmarkItemsMask), typeof(IBookmarkSubBookmarksMask), typeof(IBookmarkParentMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/{bookmarkId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top);
         queryParams.Add("$skip", skip);

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsbks:Bookmark
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates Bookmark with given input attributes. Only single creation is allowed in a 
      // service call. Summary: Create Bookmark.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateBookmarks request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask), typeof(IBookmarkLinkableMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark";

         return await PostCollectionFromResponseMemberProperty<T, ICreateBookmarks>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsbks:Bookmark/{ID}/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Attaches multiple external items from a given bookmark and returns the bookmark or 
      // failure message in case of error. Maximum 50 items are allowed in a service call. Summary: Attaches 
      // the list of items in the given bookmark.
      // <param name="bookmarkId">
      // Description: dsbks:Bookmark object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned under the bookmark, accepts a maximum 
      // value of 1000 (to be used along with $mask query parameter having values dsbks:BksMask.Items and 
      // dsbks:BksMask.Bookmarks)
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Attach<T>(string bookmarkId, string top, string skip, ITypedUriIdentifier[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask), typeof(IBookmarkItemsMask), typeof(IBookmarkSubBookmarksMask), typeof(IBookmarkParentMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/{bookmarkId}/attach";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top);
         queryParams.Add("$skip", skip);

         return await PostCollectionFromResponseMemberProperty<T, ITypedUriIdentifier[]>(resourceURI, request, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsbks:Bookmark/locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Fetches the object reference of bookmarks for a given classified item Summary: Fetches 
      // the bookmarks where the input items are classified.
      // </summary>
      //---------------------------------------------------------------------------------------------

      //THE SOURCE OPENAPI DOCUMENTATION DOES NOT DEFINE THE SCHEMA JUST AN EXAMPLE.
      //public async Task Locate(ITypedUriIdentifier[] request)
      //{
      //   string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/locate";
      //   return await PostRequest <, ITypedUriIdentifier[]> (resourceURI, request);
      //}

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsbks:Bookmark/{ID}/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detaches multiple external items from a given bookmark and returns the bookmark or 
      // failure message in case of error. Maximum 50 items are allowed in a service call. Summary: Detaches 
      // the list of items in the given bookmark.
      // <param name="bookmarkId">
      // Description: dsbks:Bookmark object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned under the bookmark, accepts a maximum 
      // value of 1000 (to be used along with $mask query parameter having values dsbks:BksMask.Items and 
      // dsbks:BksMask.Bookmarks)
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Detach<T>(string bookmarkId, string top, string skip, ITypedUriIdentifier[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask), typeof(IBookmarkItemsMask), typeof(IBookmarkSubBookmarksMask), typeof(IBookmarkParentMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/{bookmarkId}/detach";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top);
         queryParams.Add("$skip", skip);

         return await PostCollectionFromResponseMemberProperty<T, ITypedUriIdentifier[]>(resourceURI, request, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsbks:Bookmark/BULKUPDATE
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Bulk update of Bookmark object referencing items. Maximum 50 items are allowed in a 
      // service call. Summary: Bulk update of Bookmark
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> BulkUpdate<T>(IUpdateBookmark[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/BULKUPDATE";

         return await PostCollectionFromResponseMemberProperty<T, IUpdateBookmark[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsbks:Bookmark/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Bookmark object referencing items attributes Summary: Modifies the 
      // Bookmark attributes
      // <param name="bookmarkId">
      // Description: dsbks:Bookmark object ID
      // </param>
      // <param name="top">
      // Description: Represents the total number of items returned under the bookmark, accepts a maximum 
      // value of 1000 (to be used along with $mask query parameter having values dsbks:BksMask.Items and 
      // dsbks:BksMask.Bookmarks)
      // </param>
      // <param name="skip">
      // Description: Represents the number of items to skip (to be used along with $top query parameter)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string bookmarkId, string top, string skip, IModifyBookmark request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IBookmarkMask), typeof(IBookmarkDetailMask), typeof(IBookmarkItemsMask), typeof(IBookmarkSubBookmarksMask), typeof(IBookmarkParentMask), typeof(IBookmarkLinkableMask) });

         string resourceURI = $"{GetBaseResource()}/dsbks:Bookmark/{bookmarkId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("$top", top);
         queryParams.Add("$skip", skip);

         return await PatchIndividualFromResponseMemberProperty<T, IModifyBookmark>(resourceURI, request, queryParams: queryParams);
      }
   }
}