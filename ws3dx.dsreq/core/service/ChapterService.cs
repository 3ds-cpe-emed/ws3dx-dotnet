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
using ws3dx.dsreq.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace ws3dx.dsreq.core.service
{
   // SDK Service
   public class ChapterService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsreq/";

      public ChapterService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsreq:Chapter/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IChapterBaseMask) };
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
      // (GET) /dsreq:Chapter/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Chapter with an attributes list. Summary: Gets a Chapter
      // <param name="chapterId">
      // Description: dsreq:Chapter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChapterBaseMask>> Get(string chapterId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Chapter/{chapterId}";

         return await GetCollectionFromResponseMemberProperty<IChapterBaseMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsreq:Chapter/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an dsreq:Chapter Summary: Gets a Change Control of an 
      // dsreq:Chapter
      // <param name="chapterId">
      // Description: dsreq:Chapter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string chapterId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Chapter/{chapterId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:Chapter/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate Change Control. Once object is change controlled, a change is required to 
      // perform any modification on the object. Summary: Activate Change Control
      // <param name="chapterId">
      // Description: dsreq:Chapter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string chapterId, IEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Chapter/{chapterId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:Chapter
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Chapters using payload items. A maximum of 10 items is allowed. Summary: Create 
      // Chapters
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IChapterBaseMask>> Create(ICreateChapter request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Chapter";

         return await PostCollectionFromResponseMemberProperty<IChapterBaseMask, ICreateChapter>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsreq:Chapter/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Chapter with an attributes list. attributes Summary: Modifies the Chapter 
      // attributes
      // <param name="chapterId">
      // Description: dsreq:Chapter object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IChapterBaseMask> Update(string chapterId, IModifyChapter request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Chapter/{chapterId}";

         return await PatchIndividualFromResponseMemberProperty<IChapterBaseMask, IModifyChapter>(resourceURI, request);
      }
   }
}