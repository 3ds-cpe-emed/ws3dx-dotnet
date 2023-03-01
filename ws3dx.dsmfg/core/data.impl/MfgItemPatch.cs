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
using ws3dx.dsmfg.data.extension;

namespace ws3dx.dsmfg.core.data.impl
{
   public class MfgItemPatch : IMfgItemPatch
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Reference name Example: My name
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates Yes(2) or No(1) value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("outsourced")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Outsourced { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates Yes(2) or No(1) value Example: 2
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("planningRequired")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PlanningRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: checks whether lot number is required Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isLotNumberRequired")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool IsLotNumberRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: checks whether serial number is required Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isSerialNumberRequired")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool IsSerialNumberRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedTime value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double EstimatedTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedCost value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double EstimatedCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedCostCurrency value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedCostCurrency")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedCostCurrency { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedLeadTimeDescription value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedLeadTimeDescription")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedLeadTimeDescription { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedWeight value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedWeight")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double EstimatedWeight { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object manufacturedItemClassification value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manufacturedItemClassification")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ManufacturedItemClassification { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object materialCategory value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("materialCategory")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MaterialCategory { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object spareManufacturedItem value Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("spareManufacturedItem")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool SpareManufacturedItem { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object targetReleaseDate value Example: 2021/09/27@12:00:00:GMT
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("targetReleaseDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TargetReleaseDate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object depthOfFeature value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("depthOfFeature")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double DepthOfFeature { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object diameterOfFeature value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("diameterOfFeature")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double DiameterOfFeature { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object mfgFastenerStrategy value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("mfgFastenerStrategy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MfgFastenerStrategy { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object magnitude value, supported values Area,Length, Mass, Volume. Applicable only 
      // for continous Manufacturing Item Types. Example: MASS
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("magnitude")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Magnitude { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Object cestamp value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      [JsonPropertyName("dsmfg:MfgEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMfgItemEnterpriseAttributes MfgEnterpriseAttributes { get; set; }

      [JsonPropertyName("customerAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICustomerAttributes CustomerAttributes { get; set; }
   }
}