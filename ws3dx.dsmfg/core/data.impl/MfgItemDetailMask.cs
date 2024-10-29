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
using PolyJson;
using System.Text.Json.Serialization;
using ws3dx.dsmfg.data.extension;
using ws3dx.dsmfg.data.impl.model;
using ws3dx.shared.data;

namespace ws3dx.dsmfg.data.impl
{
    [PolyJsonConverter("type")]
    [PolyJsonConverter.SubType(typeof(ManufacturingAssembly), "CreateAssembly")]
    [PolyJsonConverter.SubType(typeof(ContinuousManufacturedMaterial), "ContinuousCreateMaterial")]
    [PolyJsonConverter.SubType(typeof(ContinuousProvidedMaterial), "ContinuousProvide")]
    [PolyJsonConverter.SubType(typeof(ManufacturedMaterial), "CreateMaterial")]
    [PolyJsonConverter.SubType(typeof(ManufacturingPart), "ElementaryEndItem")]
    [PolyJsonConverter.SubType(typeof(ManufacturingKit), "CreateKit")]
    [PolyJsonConverter.SubType(typeof(ProvidedPart), "Provide")]
    [PolyJsonConverter.SubType(typeof(Installation), "Installation")]
    [PolyJsonConverter.SubType(typeof(Annotation), "Annotation")]
    [PolyJsonConverter.SubType(typeof(Beveling), "Beveling")]
    [PolyJsonConverter.SubType(typeof(Fasten), "Fasten")]
    [PolyJsonConverter.SubType(typeof(Marking), "Marking")]
    [PolyJsonConverter.SubType(typeof(PreDrill), "PreDrill")]
    [PolyJsonConverter.SubType(typeof(Drill), "Drill")]
    [PolyJsonConverter.SubType(typeof(Cutting), "Cutting")]
    [PolyJsonConverter.SubType(typeof(Grinding), "Grinding")]
    [PolyJsonConverter.SubType(typeof(NoDrill), "NoDrill")]
    [PolyJsonConverter.SubType(typeof(Machine), "Machine")]
    [PolyJsonConverter.SubType(typeof(Transform), "Transform")]
    [PolyJsonConverter.SubType(typeof(Unfasten), "Unfasten")]
    [PolyJsonConverter.SubType(typeof(ContinuousManufacturedMaterial), "ProcessContinuousMaterial")]
    [PolyJsonConverter.SubType(typeof(ContinuousProvidedMaterial), "ProcessContinuousProvide")]
    
    public class MfgItemDetailMask : MfgItemMask, IMfgItemDetailMask
    {
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

        [JsonPropertyName("refQuantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMagnitudeValueInput RefQuantity { get; set; }

        [JsonPropertyName("essentiality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Essentiality { get; set; }

        [JsonPropertyName("estimatedMTBF")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedMTBF { get; set; }

        [JsonPropertyName("estimatedMTBUR")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedMTBUR { get; set; }

        [JsonPropertyName("estimatedMTTR")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedMTTR { get; set; }

        [JsonPropertyName("lifeLimit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? LifeLimit { get; set; }

        [JsonPropertyName("repairable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Repairable { get; set; }

        [JsonPropertyName("replaceable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Replaceable { get; set; }

        [JsonPropertyName("replacementType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ReplacementType { get; set; }

        [JsonPropertyName("dsmfg:MfgItemEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMfgItemEnterpriseAttributes MfgItemEnterpriseAttributes { get; set; }

    }
}