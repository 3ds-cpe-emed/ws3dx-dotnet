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
using ws3dx.dseng.data;

namespace ws3dx.dseng.core.data.impl
{
   public class SetVariantEffectivities : ISetVariantEffectivities
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The variant effectivity expression in XML format. Example: <?xml version="1.0" 
      // encoding="UTF-8"?><CfgEffectivityExpression xs:schemaLocation = "urn:com:dassault_systemes:config 
      // CfgEffectivityExpression.xsd" xmlns:xs = "http://www.w3.org/2001/XMLSchema-instance" xmlns = 
      // "urn:com:dassault_systemes:config"><Expression><Context HolderType = "Model" HolderName = 
      // "Aircraft"><Feature Type="ConfigFeature" Name="Color"><Feature Type="ConfigFeature" 
      // Name="Red"/></Feature></Context></Expression></CfgEffectivityExpression>
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("variantContent")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string VariantContent { get; set; }
   }
}