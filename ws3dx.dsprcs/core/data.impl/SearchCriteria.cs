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
using System.Text.Json.Serialization;
using ws3dx.dsprcs.data;

namespace ws3dx.dsprcs.core.data.impl
{
   //------------------------------------------------------------------------------------------------
   // <summary>
   //
   // Description: Attributes supported is limited to attributes defined in default mask 
   // dsprcs:MfgProcessMask.Default. The Value of the attribute also supports the wild character * 
   // search as well.
   //
   // </summary>
   //------------------------------------------------------------------------------------------------
   public class SearchCriteria : ISearchCriteria
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object title value Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object type value Example: My type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object name value Example: My name
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object description value Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object revision value Example: My revision
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object state value Example: My state
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object owner value Example: My owner
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object organization value Example: My organization
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object collabspace value Example: My collabspace
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("collabspace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }
   }
}