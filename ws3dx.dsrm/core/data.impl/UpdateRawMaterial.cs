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
using ws3dx.data;
using ws3dx.dsrm.data;
using ws3dx.shared.data;
using ws3dx.shared.data.extension;

namespace ws3dx.dsrm.core.data.impl
{
   public class UpdateRawMaterial : IUpdateRawMaterial
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Raw Material Description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Title of the RM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Dimension Type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("dimensionType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DimensionType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Timestamp id
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      [JsonPropertyName("customerAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICustomerAttributes CustomerAttributes { get; set; }

      [JsonPropertyName("dslc:changeControl")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IChangeControl ChangeControl { get; set; }

      [JsonPropertyName("dsrm:EnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IExtendedAttributes EnterpriseAttributes { get; set; }

      [JsonPropertyName("dseng:EnterpriseReference")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IEnterpriseItemNumber EnterpriseReference { get; set; }
   }
}