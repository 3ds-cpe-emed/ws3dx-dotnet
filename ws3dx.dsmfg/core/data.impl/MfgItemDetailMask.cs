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
   public class MfgItemDetailMask : IMfgItemDetailMask
   {
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
      // Description: Reference object title value Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Reference description value Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic type value Example: My Type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object revision value Example: A.1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object current state value Example: In Work
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object owner value Example: John Doe
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object organization value Example: MyCompany
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object collabspace value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("collabspace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }

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

      [JsonPropertyName("dsmfg:MfgItemEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMfgItemEnterpriseAttributes MfgItemEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateAssemblyEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes CreateAssemblyEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateKitEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes CreateKitEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateMaterialEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes CreateMaterialEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProvideEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes ProvideEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ElementaryEndItemEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes ElementaryEndItemEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:InstallationEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes InstallationEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProcessContinuousCreateMaterialEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes ProcessContinuousCreateMaterialEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProcessContinuousProvideEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes ProcessContinuousProvideEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:MarkingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes MarkingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:AnnotationEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes AnnotationEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:TransformEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes TransformEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:MachineEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes MachineEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:BevelingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes BevelingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CuttingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes CuttingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:GrindingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes GrindingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:NoDrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes NoDrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:DrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes DrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:PreDrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes PreDrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:FastenEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes FastenEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:UnfastenEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes UnfastenEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:SplitProcessEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes SplitProcessEnterpriseAttributes { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }
   }
}