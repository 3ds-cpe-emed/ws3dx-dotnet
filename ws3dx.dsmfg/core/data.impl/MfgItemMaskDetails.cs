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
   public class MfgItemMaskDetails : IMfgItemMaskDetails
   {
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      [JsonPropertyName("collabspace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }

      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

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
      // Description: checks whether serial number is required Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isSerialNumberRequired")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool IsSerialNumberRequired { get; set; }

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
      public double DepthOfFeature { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object diameterOfFeature value Example: 10
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("depthOfFeature")]
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

      [JsonPropertyName("dsmfg:MfgItemEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMfgItemEnterpriseAttributes MfgItemEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateAssemblyEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateAssemblyEnterpriseAttributes CreateAssemblyEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateKitEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateKitEnterpriseAttributes CreateKitEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CreateMaterialEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICreateMaterialEnterpriseAttributes CreateMaterialEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProvideEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IProvideEnterpriseAttributes ProvideEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ElementaryEndItemEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IElementaryEndItemEnterpriseAttributes ElementaryEndItemEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:InstallationEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IInstallationEnterpriseAttributes InstallationEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProcessContinuousCreateMaterialEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IProcessContinuousCreateMaterialEnterpriseAttributes ProcessContinuousCreateMaterialEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:ProcessContinuousProvideEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IProcessContinuousProvideEnterpriseAttributes ProcessContinuousProvideEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:MarkingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMarkingEnterpriseAttributes MarkingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:AnnotationEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IAnnotationEnterpriseAttributes AnnotationEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:TransformEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITransformEnterpriseAttributes TransformEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:MachineEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMachineEnterpriseAttributes MachineEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:BevelingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IBevelingEnterpriseAttributes BevelingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:CuttingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICuttingEnterpriseAttributes CuttingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:GrindingEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IGrindingEnterpriseAttributes GrindingEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:NoDrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public INoDrillEnterpriseAttributes NoDrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:DrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IDrillEnterpriseAttributes DrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:PreDrillEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IPreDrillEnterpriseAttributes PreDrillEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:FastenEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IFastenEnterpriseAttributes FastenEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:UnfastenEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IUnfastenEnterpriseAttributes UnfastenEnterpriseAttributes { get; set; }

      [JsonPropertyName("dsmfg:SplitProcessEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ISplitProcessEnterpriseAttributes SplitProcessEnterpriseAttributes { get; set; }
   }
}