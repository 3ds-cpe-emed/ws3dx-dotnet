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
using ws3dx.dslc.data;

namespace ws3dx.dslc.core.data.impl
{
   public class Version : IVersion
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The identifier of the version Example: 5045B056C51000005EA6A93000166A76
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The identifier of the new object. Example: 5045B056C51000005EA6A93000166A76
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("identifier")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Identifier { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The source of the new object. Example: https://ve4al702dsy.dsone.3ds.com:443/3DSpace
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("source")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Source { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The type of the new object. Example: VPMReference
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The relative path of the new object. Example: /resources/v1/modeler/dseng/dseng:EngItem/5045B056C51000005EA6A93000166A76
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("relativePath")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RelativePath { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The maturity state of the version. Example: IN_WORK
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("maturityState")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MaturityState { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Revision name Example: B.1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("ancestors")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IVersionAncestor> Ancestors { get; set; }
   }
}