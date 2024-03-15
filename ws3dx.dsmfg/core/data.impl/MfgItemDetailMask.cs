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
using ws3dx.shared.data;

namespace ws3dx.dsmfg.core.data.impl
{
   public class MfgItemDetailMask : MfgItemMask, IMfgItemDetailMask
   {
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
      public bool? IsLotNumberRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: checks whether serial number is required Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isSerialNumberRequired")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsSerialNumberRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedCost value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedCost { get; set; }

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
      public double? EstimatedWeight { get; set; }

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
      public bool? SpareManufacturedItem { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object targetReleaseDate value Example: Dec 11, 2017 12:53 PM
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
      public double? DepthOfFeature { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object diameterOfFeature value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("diameterOfFeature")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? DiameterOfFeature { get; set; }

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

      [JsonPropertyName("dsmfg:EnterpriseReference")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IEnterpriseItemNumber EnterpriseReference { get; set; }

      [JsonPropertyName("refQuantity")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMagnitudeValueInput RefQuantity { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object essentiality value. This Attribute is applicable only for Service Items Example: 
      // essentiality value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("essentiality")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Essentiality { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time Between Failure. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedMTBF")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedMTBF { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time Between Unscheduled Removal. This Attribute is applicable only for Service 
      // Items Example: 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedMTBUR")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedMTBUR { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time To Repair. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedMTTR")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedMTTR { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Maximum Lifetime value. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("lifeLimit")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? LifeLimit { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object repairable value. This Attribute is applicable only for Service Items Example: 
      // Yes/No
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("repairable")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Repairable { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object replaceable value. This Attribute is applicable only for Service Items Example: 
      // Yes/No
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("replaceable")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Replaceable { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object replacementType value. This Attribute is applicable only for Service Items 
      // Example: LineAndShop/ShopOnly/NotDefined
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("replacementType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ReplacementType { get; set; }

      [JsonPropertyName("dsmfg:MfgItemEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMfgItemEnterpriseAttributes MfgItemEnterpriseAttributes { get; set; }
   }
}