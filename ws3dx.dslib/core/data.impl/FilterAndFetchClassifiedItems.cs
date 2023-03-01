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
using ws3dx.dslib.data;

namespace ws3dx.dslib.core.data.impl
{
   public class FilterAndFetchClassifiedItems : IFilterAndFetchClassifiedItems
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Search query (in UQL format) with classification attributes (of given class) and 
      // values. Enclose the classification attributes in []. Example: [ClassificationAttribute1] : (Blue 
      // OR Red OR Green) AND ([ClassificationAttribute2] >= 100 OR [ClassificationAttribute2] < 10) AND 
      // NOT [ClassificationAttribute3] <= 2020/11/23
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Query")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Query { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: List of classification attributes of the given class which are used in the above 
      // query Example: ["ClassificationAttribute1","ClassificationAttribute2","ClassificationAttribute3"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ClassificationAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> ClassificationAttributes { get; set; }
   }
}