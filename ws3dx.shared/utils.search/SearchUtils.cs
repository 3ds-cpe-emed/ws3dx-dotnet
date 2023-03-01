// ------------------------------------------------------------------------------------------------------------------------------------
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
// ------------------------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using ws3dx.data.collection.impl;

namespace ws3dx.utils.search
{
   public interface I3DXSearchable<T>
   {
      Task<NlsLabeledItemSet<T>> SearchAsync(SearchQuery _searchString, long _skip, long _top, string _mask = null);
   }
   public static class SearchUtils<T>
   {
      const long MAX_VALS_PER_QUERY = 1000;

      //<summary>Notes from public documentation
      // Engineering Web Services 1.3.0 - Gets a list of Engineering Items. By default, returns a total of up to 50 items, can be optionally increased upto 1000 items using $top query parameter.
      // Recommendation: Use $searchStr query parameter with a minimum of two characters for better performances.</summary>
      public static async Task<List<NlsLabeledItemSet<T>>> SearchAllAsync(I3DXSearchable<T> _refSearchable, SearchQuery _searchString, string _mask = null, long _top = MAX_VALS_PER_QUERY)
      {
         long skip = 0;

         List<NlsLabeledItemSet<T>> __searchBookReturn = new List<NlsLabeledItemSet<T>>();

         NlsLabeledItemSet<T> page;

         do
         {
            page = await _refSearchable.SearchAsync(_searchString, skip, _top, _mask);

            skip += _top;

            //TODO: Add an interval

            __searchBookReturn.Add(page);
         }
         while ((page != null) && (page.TotalItems == _top));

         //remove the last page if there are more than one pages and the last one is zero
         if ((__searchBookReturn.Count > 1) && (__searchBookReturn[__searchBookReturn.Count - 1].TotalItems == 0))
         {
            __searchBookReturn.RemoveAt(__searchBookReturn.Count - 1);
         }

         return __searchBookReturn;
      }
   }
}
