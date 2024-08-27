// ------------------------------------------------------------------------------------------------------------------------------------
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
// ------------------------------------------------------------------------------------------------------------------------------------

namespace ws3dx.dsmfg
{
   public static class MFGResourceNames
   {
      #region masks
      public const string DSMFG_MFGITEM_MASK_DEFAULT = "dsmfg:MfgItemMask.Default";
      public const string DSMFG_MFGITEM_MASK_DETAILS = "dsmfg:MfgItemMask.Details";

      public const string DSMFG_MFGINST_MASK_DEFAULT = "dsmfg:MfgItemInstanceMask.Default";
      public const string DSMFG_MFGINST_MASK_DETAILS = "dsmfg:MfgItemInstanceMask.Details";

      public const string DSMFG_MFGPROCESS_MASK_DEFAULT = "dsprcs:MfgProcessMask.Default";
      public const string DSMFG_MFGPROCESS_MASK_DETAILS = "dsprcs:MfgProcessMask.Details";
      public const string DSMFG_MFGPROC_MASK_STRUCTURE = "dsprcs:MfgProcessMask.Structure.ModelView.Index";

      public const string DSMFG_MFGPROC_INST_DEFAULT = "dsprcs:MfgProcessInstanceMask.Default";
      public const string DSMFG_MFGPROC_INST_DETAILS = "dsprcs:MfgProcessInstanceMask.Details";

      public const string DSMFG_MFGOPERATION_MASK_DEFAULT = "dsprcs:MfgOperationMask.Default";
      public const string DSMFG_MFGOPERATION_MASK_DETAILS = "dsprcs:MfgOperationMask.Details";

      public const string DSMFG_SCOPEENGITEM_MASK_DEFAULT = "dsmfg:ScopeEngItemMask.Default";
      public const string DSMFG_PARTIALSCOPEENGITEM_MASK_DEFAULT = "dsmfg:PartialScopeEngItemMask.Default";
      public const string DSMFG_IMPLEMENTLINKS_MASK_DEFAULT = "dsmfg:ImplementedEngOccurrenceMask.Default";
      public const string DSMFG_ITEMSPECLINK_MASK_DEFAULT = "dsprcs:ItemSpecificationMask.Default";
      public const string DSMFG_TIMECONSTRAINT_MASK_DEFAULT = "dsprcs:TimeConstraintMask.Default";
      #endregion

      public const string TYPE_ATT = "type";
      public const string ID_ATT = "id";
      public const string OWNER_ATT = "owner";
      public const string ORGANIZATION_ATT = "organization";
      public const string COLLABSPACE_ATT = "collabspace";
      public const string TITLE_ATT = "title";
      public const string MODIFIED_ATT = "modified";
      public const string CREATED_ATT = "created";
      public const string CESTAMP_ATT = "cestamp";

      public const string DSPRCS_MFGOP_ENTERPRISE_ATTRIBUTES = "dsmfg:MfgOperationEnterpriseAttributes";

      public const string DSMFG_MFGENTERPRISEATTRIBUTES = "dsmfg:MfgItemEnterpriseAttributes";
      public const string DSMFG_MARKING_ENTERPRISE_ATTRIBUTES = "dsmfg:MarkingEnterpriseAttributes";
      public const string DSMFG_ANNOTATION_ENTERPRISE_ATTRIBUTES = "dsmfg:AnnotationEnterpriseAttributes";
      public const string DSMFG_TRANSFORM_ENTERPRISE_ATTRIBUTES = "dsmfg:TransformEnterpriseAttributes";
      public const string DSMFG_MACHINE_ENTERPRISE_ATTRIBUTES = "dsmfg:MachineEnterpriseAttributes";
      public const string DSMFG_BEVELING_ENTERPRISE_ATTRIBUTES = "dsmfg:BevelingEnterpriseAttributes";
      public const string DSMFG_CUTTING_ENTERPRISE_ATTRIBUTES = "dsmfg:CuttingEnterpriseAttributes";
      public const string DSMFG_GRINDING_ENTERPRISE_ATTRIBUTES = "dsmfg:GrindingEnterpriseAttributes";
      public const string DSMFG_NODRILL_ENTERPRISE_ATTRIBUTES = "dsmfg:NoDrillEnterpriseAttributes";
      public const string DSMFG_DRILL_ENTERPRISE_ATTRIBUTES = "dsmfg:DrillEnterpriseAttributes";
      public const string DSMFG_PREDRILL_ENTERPRISE_ATTRIBUTES = "dsmfg:PreDrillEnterpriseAttributes";
      public const string DSMFG_FASTEN_ENTERPRISE_ATTRIBUTES = "dsmfg:FastenEnterpriseAttributes";
      public const string DSMFG_UNFASTEN_ENTERPRISE_ATTRIBUTES = "dsmfg:UnfastenEnterpriseAttributes";
      public const string DSMFG_SPLITPROCESS_ENTERPRISE_ATTRIBUTES = "dsmfg:SplitProcessEnterpriseAttributes";

      public const string DSMFG_OUTSOURCED = "outsourced";
      public const string DSMFG_PLANNING_REQUIRED = "planningRequired";
      public const string DSMFG_IS_LOT_NUMBER_REQUIRED = "isLotNumberRequired";
      public const string DSMFG_IS_SERIAL_NUMBER_REQUIRED = "isSerialNumberRequired";
      public const string DSMFG_ESTIMATED_TIME = "estimatedTime";

      public const string DSMFG_ESTIMATED_COST = "estimatedCost";
      public const string DSMFG_ESTIMATED_COST_CURRENCY = "estimatedCostCurrency";
      public const string DSMFG_ESTIMATED_LEAD_TIME_DESC = "estimatedLeadTimeDescription";
      public const string DSMFG_ESTIMATED_WEIGHT = "estimatedWeight";
      public const string DSMFG_MFGITEM_CLASSIFICATION = "manufacturedItemClassification";
      public const string DSMFG_MAT_CATEGORY = "materialCategory";
      public const string DSMFG_SPARE_MFGITEM = "spareManufacturedItem";
      public const string DSMFG_TARGET_RELEASE_DATE = "targetReleaseDate";
      public const string DSMFG_DEPTH = "depthOfFeature";
      public const string DSMFG_DIAMETER = "diameterOfFeature";

      public const string MANUFACTURED_MATERIAL_ENTERPRISE_ATTS = "dsmfg:CreateMaterialEnterpriseAttributes";
      public const string MANUFACTURING_ASSEMBLY_ENTERPRISE_ATTS = "dsmfg:CreateAssemblyEnterpriseAttributes";
      public const string PROVIDED_PART_ENTERPRISE_ATTS = "dsmfg:ProvideEnterpriseAttributes";
      public const string MANUFACTURED_PART_ENTERPRISE_ATTS = "dsmfg:ElementaryEndItemEnterpriseAttributes";
      public const string MANUFACTURING_INSTALLATION_ENTERPRISE_ATTS = "dsmfg:InstallationEnterpriseAttributes";
      public const string MANUFACTURING_KIT_ENTERPRISE_ATTS = "dsmfg:CreateKitEnterpriseAttributes";
      public const string PROC_CONT_MANUF_MAT_ENTERPRISE_ATTS = "dsmfg:ProcessContinuousCreateMaterialEnterpriseAttributes";
      public const string PROC_CONT_PROVIDED_PART_ENTERPRISE_ATTS = "dsmfg:ProcessContinuousProvideEnterpriseAttributes";

      public const string MANUFACTURED_MATERIAL_TYPE = "CreateMaterial";
      public const string MANUFACTURING_ASSEMBLY_TYPE = "CreateAssembly";
      public const string PROVIDED_PART_TYPE = "Provide";
      public const string MANUFACTURED_PART_TYPE = "ElementaryEndItem";
      public const string MANUFACTURING_INSTALLATION_TYPE = "Installation";
      public const string MANUFACTURING_KIT_TYPE = "CreateKit";
      public const string PROC_CONT_MANUF_MAT_TYPE = "ProcessContinuousCreateMaterial";
      public const string PROC_CONT_PROVIDED_PART_TYPE = "ProcessContinuousProvide";

      public const string FASTEN_TYPE = "Fasten";
      public const string MARKING_TYPE = "Marking";
      public const string PRE_DRILL_TYPE = "PreDrill";
      public const string DRILL_TYPE = "Drill";
      public const string ANNOTATION_TYPE = "Annotation";
      public const string BEVELING_TYPE = "Beveling";
      public const string CUTTING_TYPE = "Cutting";
      public const string GRINDING_TYPE = "Grinding";
      public const string NODRILL_TYPE = "NoDrill";
      public const string MACHINE_TYPE = "Machine";
      public const string TRANSFORM_TYPE = "Transform";
      public const string UNFASTEN_TYPE = "Unfasten";

      public const string MFGITEM_INSTANCE_TYPE = "DELFmiFunctionIdentifiedInstance";

      // Verify: Currently it seems that, even if can create them, we cannot read ServiceAssembly and ServiceKit through the Manufacturing Item APIs
      // 404 error (URI not Found) - Classes have been updated with an NotImplementedException
      public const string SERVICE_ASSEMBLY_ENTERPRISE_ATTS = "dsmfg:ServiceAssemblyEnterpriseAttributes";
      public const string SERVICE_KIT_ENTERPRISE_ATTS = "dsmfg:ServiceKitEnterpriseAttributes";
      public const string SERVICE_KIT_TYPE = "DELServiceKitReference";
      public const string SERVICE_ASSEMBLY_TYPE = "DELServiceAssemblyReference";

      public const string REFERENCE_ATT = "reference";
      public const string REFOBJECT_ATT = "referencedObject";
      public const string DSPRCS_OP_TIMECONSTRAINTS = "dsprcs:TimeConstraint";
      public const string DSPRCS_OP_TC_DELAY = "delay";
      public const string DSPRCS_OP_TC_DELAYMODE = "delayMode";
      public const string DSPRCS_OP_TC_RESOURCE_CONSTRAINT = "resourceConstraint";
      public const string DSPRCS_OP_TC_ISOPTIONAL = "isOptional";
      public const string DSPRCS_OP_TC_DEPENDENCYTYPE = "dependencyType";
      public const string DSPRCS_OP_TC_ISPRODUCTFLOW = "isProductFlow";
      public const string DSPRCS_OP_TC_TOOPOCC = "toOperationOcc";
      public const string DSPRCS_OP_TC_FROMOPOCC = "fromOperationOcc";
      public const string DSPRCS_OP_TC_FLOWTYPE = "flowType";

      // ProcessContinuousCreateMaterial
      // ProcessContinuousProvide
      // "status": 400,
      // "message": "Create Failed com.dassault_systemes.platform.model.CommonWebException"

      //public static readonly string[] TRANSFORM       = { "Transform", "dsmfg:MarkEnterpriseAttributes" };
      //public static readonly string[] MARK            = { "Marking", "dsmfg:MarkEnterpriseAttributes" };
      //public static readonly string[] MACHINING       = { "Machine", "dsmfg:MachiningEnterpriseAttributes" };
      //public static readonly string[] ANNOTATION      = { "Annotation", "dsmfg:AnnotationEnterpriseAttributes" };
      //public static readonly string[] NO_DRILL        = { "NoDrill", "dsmfg:NoDrillEnterpriseAttributes" };
      //public static readonly string[] CUT             = { "Cutting", "dsmfg:CutEnterpriseAttributes" };
      //public static readonly string[] PRE_DRILL       = { "PreDrill", "dsmfg:PreDrillEnterpriseAttributes" };
      //public static readonly string[] REMOVE_MATERIAL = { "RemoveMaterial", "dsmfg:RemoveMaterialEnterpriseAttributes" };
      //public static readonly string[] GRIND           = { "Grinding", "dsmfg:GrindEnterpriseAttributes" };
      //public static readonly string[] BEVEL           = { "Beveling", "dsmfg:BevelEnterpriseAttributes" };
      //public static readonly string[] DRILL           = { "Drill", "dsmfg:DrillEnterpriseAttributes" };

      //DSPRCS_SYSTEM

      public const string DSMFG_MFGPROC_SEQUENCING_MODE = "sequencingMode";
      public const string DSPRCS_PR_SEQUENCING_MODE = "sequencingMode";
      public const string DSPRCS_PR_OPERATION_INSTANCE = "dsprcs:MfgOperationInstance";
      public const string DSPRCS_PR_OPERATION = "dsprcs:MfgOperation";
      public const string DSPRCS_PR_PATH = "path";
      public const string DSPRCS_PR_ITEM_SPECIFICATION = "dsprcs:ItemSpecification";
      public const string DSPRCS_PR_TIME_CONSTRAINTS = "dsprcs:TimeConstraint";

      public const string DSPRCS_OP_ESTIMATED_TIME = "estimatedTime";
      public const string DSPRCS_OP_ESTIMATEDTIME_ADDEDVALUERATIO = "estimatedTime_AddedValueRatio";
      public const string DSPRCS_OP_MEASUREDTIME = "measuredTime";
      public const string DSPRCS_OP_TRACKTIME = "trackTime";
      public const string DSPRCS_OP_TIMEMODE = "timeMode";
      public const string DSPRCS_OP_EXECUTIONTEMPLATE = "executionTemplate";
      public const string DSPRCS_OP_SEQUENCING_MODE = "sequencingMode";
      public const string DSPRCS_OP_VERSIONCOMMENT = "versionComment";
      public const string DSPRCS_OP_ISTIMEPROPORTIONALTOQTY = "isTimeProportionalToQty";
      public const string DSPRCS_OP_INTERRUPTIBLE = "interruptible";
      public const string DSPRCS_OP_MANAGEVARIANT = "manageVariant";
      public const string DSPRCS_OP_ROLLUP = "rollup";

      public const string DSPRCS_OP_INST_PARENT = "parent";
      public const string DSPRCS_OP_INST_REFERENCE = "reference";
      public const string DSPRCS_OP_INST_TREEORDER = "treeOrder";

      public const string HEADER_OP_TYPE = "DELLmiHeaderOperationReference";
      public const string CURVE_OP_TYPE = "DELLmiCurveOperationReference";
      public const string PUNCTUAL_OP_TYPE = "DELLmiPunctualOperationReference";
      public const string TRANSFER_OP_TYPE = "DELLmiTransferOperationReference";
      public const string REMOVE_MAT_OP_TYPE = "DELLmiRemoveMaterialOperationReference";
      public const string GENERAL_OP_TYPE = "DELLmiGeneralOperationReference";
      public const string UNLOADING_OP_TYPE = "DELLmiUnloadingOperationReference";
      public const string LOADING_OP_TYPE = "DELLmiLoadingOperationReference";

      public const string WORKPLAN_TYPE = "DELLmiWorkPlanSystemReference";
      public const string BUFFER_SYSTEM_TYPE = "BufferSystem";
      public const string SINK_SYSTEM_TYPE = "SinkSystem";
      public const string TRANSFER_SYSTEM_TYPE = "DELLmiTransferSystemReference";
      public const string SOURCE_SYSTEM_TYPE = "SourceSystem";
      public const string TRANSFORMATION_SYSTEM_TYPE = "DELLmiTransformationSystemReference";
      public const string GENERAL_SYSTEM_TYPE = "DELLmiGeneralSystemReference";

      public const string DSMFG_MFGPROC_ENTERPRISEATTRIBUTES = "dsprcs:MfgProcessEnterpriseAttributes";
      public const string WORKPLAN_ENTERPRISE_ATTRIBUTES = "dsprcs:WorkPlanEnterpriseAttributes";

      public const string BUFFER_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:BufferSystemEnterpriseAttributes";
      public const string TRANSFER_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:TransferSystemEnterpriseAttributes";
      public const string SINK_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:SinkSystemEnterpriseAttributes";
      public const string SOURCE_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:SourceSystemEnterpriseAttributes";
      public const string TRANSFORMATION_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:TransformationSystemEnterpriseAttributes";
      public const string GENERAL_SYSTEM_ENTERPRISE_ATTRIBUTES = "dsprcs:GeneralSystemEnterpriseAttributes";

      // Verify: Currently it seems that, even if can create them, we cannot read LogisticStation and LogisticTransfer through the Manufacturing Process APIs
      // 404 error (URI not Found) - Classes have been updated with an NotImplementedException
      public const string LOGISTIC_TRANSFER_TYPE = "DELSCPLogisticsTransferSiteRef";
      public const string LOGISTIC_TRANSFER_ENTERPRISE_ATTRIBUTES = "";
      public const string LOGISTIC_STATION_TYPE = "DELSCPLogisticsSiteRef";
      public const string LOGISTIC_STATION_ENTERPRISE_ATTRIBUTES = "";
   }
}