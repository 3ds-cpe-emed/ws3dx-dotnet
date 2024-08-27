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
   public class MfgProcessExpandRequestPayloadV1 : IMfgProcessExpandRequestPayloadV1
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Number of levels to be expanded. By default only first level is expanded. If -1 then 
      // expands all levels Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("expandDepth")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? ExpandDepth { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: If set return the occurence path of its children Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("withPath")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? WithPath { get; set; }
   }
}