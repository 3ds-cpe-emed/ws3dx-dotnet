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
using ws3dx.dsmfg.data;
using ws3dx.shared.data;

namespace ws3dx.dsmfg.core.data.impl
{
   public class MfgItemReconnectRequestPayloadResultingEngItemRef : IMfgItemReconnectRequestPayloadResultingEngItemRef
   {
      [JsonPropertyName("dseng:EngItem")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier EngItem { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The physical id of dsmfg:MfgItem Example: AB44429C00003E7C6023064C0000ZX74
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("mfgItemId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MfgItemId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The relation type with the Engineering Item Example: dsmfg:ResultingEngItem
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("relationType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RelationType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The physical id of dsmfg:ResultingEngItem connection and is required only for relation 
      // type dsmfg:ResultingEngItem Example: AZY4429C00003E7C6023064C0000ZCCC
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("resultingEngItemId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ResultingEngItemId { get; set; }
   }
}