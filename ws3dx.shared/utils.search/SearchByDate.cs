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
using System.Collections.Generic;

namespace ws3dx.utils.search
{
   public abstract class SearchByDate : SearchQuery
   {
      private string m_startUTCDateTime = "YYYY-MM-DDT00:00:00.000Z";
      private string m_endUTCDateTime = "YYYY-MM-DDT00:00:00.000Z";

      private List<string> m_additionalCriteriaList = new List<string>();

      private string m_greaterOrEqual = ">=";
      private string m_lesserOrEqual = "<=";

      //example: [ds6w:created]>="2021-11-11T00:00:00.000Z" AND [ds6w:created]<="2021-11-11T23:59:59.999Z"

      //<summary>Search within a specific Day</summary>
      public SearchByDate(DateTime _localDate)
      {
         m_lesserOrEqual = "<";

         DateTime start = new DateTime(_localDate.Year, _localDate.Month, _localDate.Day, 0, 0, 0, 0);
         DateTime end = start.AddDays(1);

         DateTime startUTC = start.ToUniversalTime();
         DateTime endUTC = end.ToUniversalTime();

         m_startUTCDateTime = startUTC.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
         m_endUTCDateTime = endUTC.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
      }

      //<summary>Search within the last timespan</summary>
      public SearchByDate(TimeSpan _timeSpan)
      {
         DateTime endUTC = DateTime.UtcNow;

         DateTime startUTC = endUTC.Subtract(_timeSpan);

         m_startUTCDateTime = startUTC.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
         m_endUTCDateTime = endUTC.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
      }

      public void AddCriteria(string _criteriaString)
      {
         m_additionalCriteriaList.Add(_criteriaString);
      }

      protected abstract string Tag { get; }

      public override string GetSearchString()
      {
         string additionalCriteriaString = "";

         foreach (string additionalCriteria in m_additionalCriteriaList)
         {
            additionalCriteriaString += $" AND {additionalCriteria}";
         }

         return $"{Tag}{m_greaterOrEqual}\"{m_startUTCDateTime}\" AND {Tag}{m_lesserOrEqual}\"{m_endUTCDateTime}\"{additionalCriteriaString}";
      }
   }
}
