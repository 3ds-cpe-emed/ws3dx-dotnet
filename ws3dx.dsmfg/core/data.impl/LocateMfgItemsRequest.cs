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
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ws3dx.dsmfg.data;
using ws3dx.shared.data;

namespace ws3dx.dsmfg.core.data.impl
{
   public class LocateMfgItemsRequest : ILocateMfgItemsRequest
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: List of Manufacturing Item objectReferences and number of entries passed is limited 
      // to 10. 
      //  Note: The request payload 'objectReferences' could also be alised as 'mfgItems' to be compatiable 
      // with previous version
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("objectReferences")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<ITypedUriIdentifier> ObjectReferences { get; set; }

      [JsonPropertyName("searchCriteria")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ISearchCriteria SearchCriteria { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: specify requested type Example: ["dsmfg:MfgItemInstance"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("navigateTo")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> NavigateTo { get; set; }
   }
}