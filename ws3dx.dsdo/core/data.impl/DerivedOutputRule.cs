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
using ws3dx.dsdo.data;

namespace ws3dx.dsdo.core.data.impl
{
   public class DerivedOutputRule : IDerivedOutputRule
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 3DEXPERIENCE
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("converter")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Converter { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example:
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("targetToDisplay")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TargetToDisplay { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: authoring
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("inputStreamId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string InputStreamId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: SLDDRW
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("source")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Source { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: UDL
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("target")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Target { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example:
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("sourceToDisplay")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SourceToDisplay { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Drawing
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("sourceType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SourceType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: onXCADSave
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ruleType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RuleType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: authoringvisu
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("outputStreamId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string OutputStreamId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example:
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 9bd24c2657e61137e918f02347c051ef55f4e16fe466ff4e6545b7877964cd3c
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ruleId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RuleId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: SOLIDWORKS
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("category")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Category { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: forcedactive
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("activation")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Activation { get; set; }
   }
}