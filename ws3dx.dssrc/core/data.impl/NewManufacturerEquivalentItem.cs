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
using ws3dx.dssrc.data;
using ws3dx.shared.data;

namespace ws3dx.dssrc.core.data.impl
{
   public class NewManufacturerEquivalentItem : INewManufacturerEquivalentItem
   {
      [JsonPropertyName("engItem")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier EngItem { get; set; }

      [JsonPropertyName("manufacturerCompany")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier ManufacturerCompany { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Texas Instruments
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manufacturer")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Manufacturer { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: RE-98372
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manufacturerPartNumber")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ManufacturerPartNumber { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: https://3dpartsupply.3dexperience.3ds.com/search/category/eClass_9_1/ready-made-data-cable
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("partSourceURL")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PartSourceURL { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Texas Intruments - North America
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("partSource")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PartSource { get; set; }
   }
}