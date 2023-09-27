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
using ws3dx.dsmfg.data.extension;
using ws3dx.serialization.attribute;
using ws3dx.shared.data;

namespace ws3dx.dsmfg.data
{
   [MaskSchema("dsmfg:MfgItemMask.Details")]
   public interface IMfgItemDetailMask : IMfgItemMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates Yes(2) or No(1) value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Outsourced { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates Yes(2) or No(1) value Example: 2
      //
      // </summary>
      //----------------------------------------------------------------
      public string PlanningRequired { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: checks whether lot number is required Example: false
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsLotNumberRequired { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: checks whether serial number is required Example: false
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsSerialNumberRequired { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedCost value Example: 10
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedCostCurrency value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string EstimatedCostCurrency { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedLeadTimeDescription value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string EstimatedLeadTimeDescription { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedWeight value Example: 10
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedWeight { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object manufacturedItemClassification value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string ManufacturedItemClassification { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object materialCategory value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string MaterialCategory { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object spareManufacturedItem value Example: false
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? SpareManufacturedItem { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object targetReleaseDate value Example: Dec 11, 2017 12:53 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string TargetReleaseDate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object depthOfFeature value Example: 10
      //
      // </summary>
      //----------------------------------------------------------------
      public double? DepthOfFeature { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object diameterOfFeature value Example: 10
      //
      // </summary>
      //----------------------------------------------------------------
      public double? DiameterOfFeature { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object mfgFastenerStrategy value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string MfgFastenerStrategy { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object magnitude value, supported values Area,Length, Mass, Volume. Applicable only 
      // for continous Manufacturing Item Types. Example: MASS
      //
      // </summary>
      //----------------------------------------------------------------
      public string Magnitude { get; set; }

      public IEnterpriseItemNumber EnterpriseReference { get; set; }
      
      //<summary>
      //
      // Description: Object essentiality value. This Attribute is applicable only for Service Items Example: 
      // essentiality value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string Essentiality { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time Between Failure. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public double? EstimatedMTBF { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time Between Unscheduled Removal. This Attribute is applicable only for Service 
      // Items Example: 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public double? EstimatedMTBUR { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean Time To Repair. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public double? EstimatedMTTR { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Maximum Lifetime value. This Attribute is applicable only for Service Items Example: 
      // 10.5
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public double? LifeLimit { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object repairable value. This Attribute is applicable only for Service Items Example: 
      // Yes/No
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string Repairable { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object replaceable value. This Attribute is applicable only for Service Items Example: 
      // Yes/No
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string Replaceable { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object replacementType value. This Attribute is applicable only for Service Items 
      // Example: LineAndShop/ShopOnly/NotDefined
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string ReplacementType { get; set; }

      public IMagnitudeValueInput RefQuantity { get; set; }

      public IMfgItemEnterpriseAttributes MfgItemEnterpriseAttributes { get; set; }

      public ICreateAssemblyEnterpriseAttributes CreateAssemblyEnterpriseAttributes { get; set; }

      public ICreateKitEnterpriseAttributes CreateKitEnterpriseAttributes { get; set; }

      public ICreateMaterialEnterpriseAttributes CreateMaterialEnterpriseAttributes { get; set; }

      public IProvideEnterpriseAttributes ProvideEnterpriseAttributes { get; set; }

      public IElementaryEndItemEnterpriseAttributes ElementaryEndItemEnterpriseAttributes { get; set; }

      public IInstallationEnterpriseAttributes InstallationEnterpriseAttributes { get; set; }

      public IProcessContinuousCreateMaterialEnterpriseAttributes ProcessContinuousCreateMaterialEnterpriseAttributes { get; set; }

      public IProcessContinuousProvideEnterpriseAttributes ProcessContinuousProvideEnterpriseAttributes { get; set; }

      public IMarkingEnterpriseAttributes MarkingEnterpriseAttributes { get; set; }

      public IAnnotationEnterpriseAttributes AnnotationEnterpriseAttributes { get; set; }

      public ITransformEnterpriseAttributes TransformEnterpriseAttributes { get; set; }

      public IMachineEnterpriseAttributes MachineEnterpriseAttributes { get; set; }

      public IBevelingEnterpriseAttributes BevelingEnterpriseAttributes { get; set; }

      public ICuttingEnterpriseAttributes CuttingEnterpriseAttributes { get; set; }

      public IGrindingEnterpriseAttributes GrindingEnterpriseAttributes { get; set; }

      public INoDrillEnterpriseAttributes NoDrillEnterpriseAttributes { get; set; }

      public IDrillEnterpriseAttributes DrillEnterpriseAttributes { get; set; }

      public IPreDrillEnterpriseAttributes PreDrillEnterpriseAttributes { get; set; }

      public IFastenEnterpriseAttributes FastenEnterpriseAttributes { get; set; }

      public IUnfastenEnterpriseAttributes UnfastenEnterpriseAttributes { get; set; }

      public ISplitProcessEnterpriseAttributes SplitProcessEnterpriseAttributes { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      public IServiceItemEnterpriseAttributes ServiceItemEnterpriseAttributes { get; set; }

      public IServiceAssemblyEnterpriseAttributes ServiceAssemblyEnterpriseAttributes { get; set; }

      public IServicePartEnterpriseAttributes ServicePartEnterpriseAttributes { get; set; }

      public IServiceKitEnterpriseAttributes ServiceKitEnterpriseAttributes { get; set; }

      public IContinuousServiceItemEnterpriseAttributes ContinuousServiceItemEnterpriseAttributes { get; set; }

      public IContinuousServicePartEnterpriseAttributes ContinuousServicePartEnterpriseAttributes { get; set; }
   }
}