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

namespace ws3dx.utils
{
   public static class HelperExtensions
   {
      /// <summary>
      /// Inspired by https://stackoverflow.com/questions/2132562/merging-dictionary-containing-a-list-in-c-sharp
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="dictLeft"></param>
      /// <param name="dictRight"></param>
      public static void Merge<T>(this IDictionary<string, IList<T>> dictLeft, IDictionary<string, IList<T>> dictRight)
      {
         foreach (var kvp2 in dictRight)
         {
            // If the dictionary already contains the key then merge them
            if (dictLeft.ContainsKey(kvp2.Key))
            {
               foreach (T v in kvp2.Value)
               {
                  dictLeft[kvp2.Key].Add(v);
               }
               continue;
            }

            dictLeft.Add(kvp2);
         }
      }

      /// <summary>
      /// Merge 2 Dictionary contents
      /// </summary>
      /// <param name="dictLeft"></param>
      /// <param name="dictRight"></param>
      public static void Merge<T>(this IDictionary<string, IDictionary<string, IList<T>>> dictLeft, IDictionary<string, IDictionary<string, IList<T>>> dictRight)
      {
         foreach (var kvpOuter in dictRight)
         {
            // If the dictionary already contains the key then merge them
            if (dictLeft.ContainsKey(kvpOuter.Key))
            {
               IDictionary<string, IList<T>> innerRightDictionary = kvpOuter.Value;
               IDictionary<string, IList<T>> innerLeftDictionary = dictLeft[kvpOuter.Key];

               foreach (var kvpInner in innerRightDictionary)
               {
                  if (!innerLeftDictionary.ContainsKey(kvpInner.Key))
                  {
                     innerLeftDictionary.Add(kvpInner);
                  }
                  else
                  {
                     IList<T> innerLeftList = innerLeftDictionary[kvpInner.Key];
                     IList<T> innerRightList = innerRightDictionary[kvpInner.Key];

                     //Assuming that they are not null
                     foreach (T t in innerRightList)
                     {
                        //Do not insert duplicates
                        if (!innerLeftList.Contains(t))
                        {
                           innerLeftList.Add(t);
                        }
                     }
                  }
               }
               continue;
            }

            dictLeft.Add(kvpOuter);
         }
      }
   }
}

