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
using ws3dx.data.collection.impl;
using ws3dx.dsprcs.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dsprcs.core.service
{
   // SDK Service
   public class CheckListService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

      public CheckListService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsprcs:CheckList/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(ICheckListMask) };
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
         return await Search<T, NlsLabeledItemSet<T>>(searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await Search<T, NlsLabeledItemSet<T>>(searchQuery, _skip, _top);
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:CheckList/{ID}/dsprcs:DataCollectRow
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets all Work instruction DataCollectRow details assigned to a CheckList. Summary: 
      // Gets all Work instruction DataCollectRow details assigned to a CheckList.
      // <param name="ID">
      // Description: dsprcs:CheckList object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<ICheckListRowMask>> GetDataCollectRows(string ID)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:CheckList/{ID}/dsprcs:DataCollectRow";

         return await GetGroup<ICheckListRowMask, NlsLabeledItemSet<ICheckListRowMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:CheckList/{PID}/dsprcs:DataCollectRow/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Work instruction DataCollectRow details assigned to a CheckList. Summary: Gets 
      // a Work instruction DataCollectRow details assigned to a CheckList.
      // <param name="checkListId">
      // Description: dsprcs:CheckList object ID
      // </param>
      // <param name="dataCollectRowId">
      // Description: dsprcs:DataCollectRow object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<ICheckListRowMask> GetDataCollectRow(string checkListId, string dataCollectRowId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:CheckList/{checkListId}/dsprcs:DataCollectRow/{dataCollectRowId}";

         return await GetIndividual<ICheckListRowMask, NlsLabeledItemSet<ICheckListRowMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsprcs:CheckList/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Work instruction CheckList reference details. Summary: Gets a Work instruction 
      // CheckList reference details.
      // <param name="ID">
      // Description: dsprcs:CheckList object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string ID)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(ICheckListMask), typeof(ICheckListDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsprcs:CheckList/{ID}";

         return await GetIndividual<T, NlsLabeledItemSet<T>>(resourceURI);
      }
   }
}