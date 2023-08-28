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
   public class CheckListRowMask : ICheckListRowMask
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic type value Example: My Type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object text value Example: Any text
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("text")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Text { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object label value Example: Any label
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("label")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Label { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates Real(1),Integer(2),Text(3),Boolean(4),Timestamp(5) value. Example: 4
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("dcType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? DcType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object possibleValues value Example: ["Yes", "No"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("possibleValues")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PossibleValues { get; set; }
   }
}