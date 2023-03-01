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

using System;

namespace ws3dx.utils.search
{
   public class SearchByCreatedDate : SearchByDate
   {
      private const string CREATED_TAG = "[ds6w:created]";

      //example: [ds6w:created]>="2021-11-11T00:00:00.000Z" AND [ds6w:created]<="2021-11-11T23:59:59.999Z"

      //<summary>Search created in a given date</summary>
      public SearchByCreatedDate(DateTime _date) : base(_date)
      {
      }

      //<summary>Search created within the last timespan</summary>
      public SearchByCreatedDate(TimeSpan _timeSpan) : base(_timeSpan)
      {
      }

      protected override string Tag => CREATED_TAG;
   }
}
