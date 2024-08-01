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
using ws3dx.dsmfg.data.extension;
using ws3dx.shared.data;
using ws3dx.shared.data.extension;

namespace ws3dx.dsmfg.data.impl
{
    public class MfgItem : IMfgItem
    {
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; }

        [JsonPropertyName("outsourced")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Outsourced { get; set; }

        [JsonPropertyName("planningRequired")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PlanningRequired { get; set; }

        [JsonPropertyName("isLotNumberRequired")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsLotNumberRequired { get; set; }

        [JsonPropertyName("isSerialNumberRequired")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsSerialNumberRequired { get; set; }

        [JsonPropertyName("estimatedTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedTime { get; set; }

        [JsonPropertyName("estimatedCost")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedCost { get; set; }

        [JsonPropertyName("estimatedCostCurrency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EstimatedCostCurrency { get; set; }

        [JsonPropertyName("estimatedLeadTimeDescription")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EstimatedLeadTimeDescription { get; set; }

        [JsonPropertyName("estimatedWeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedWeight { get; set; }

        [JsonPropertyName("manufacturedItemClassification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ManufacturedItemClassification { get; set; }

        [JsonPropertyName("materialCategory")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MaterialCategory { get; set; }

        [JsonPropertyName("spareManufacturedItem")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SpareManufacturedItem { get; set; }

        [JsonPropertyName("targetReleaseDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TargetReleaseDate { get; set; }

        [JsonPropertyName("depthOfFeature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? DepthOfFeature { get; set; }

        [JsonPropertyName("diameterOfFeature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? DiameterOfFeature { get; set; }

        [JsonPropertyName("mfgFastenerStrategy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MfgFastenerStrategy { get; set; }

        [JsonPropertyName("magnitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Magnitude { get; set; }

        [JsonPropertyName("dsmfg:EnterpriseReference")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnterpriseItemNumber EnterpriseReference { get; set; }

        [JsonPropertyName("dsmfg:MfgEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMfgItemEnterpriseAttributes MfgEnterpriseAttributes { get; set; }

        [JsonPropertyName("customerAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICustomerAttributes CustomerAttributes { get; set; }

    }
}