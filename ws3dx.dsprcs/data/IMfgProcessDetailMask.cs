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
using ws3dx.dsprcs.data.extension;
using ws3dx.serialization.attribute;

namespace ws3dx.dsprcs.data
{
   [MaskSchema("dsprcs:MfgProcessMask.Details")]
   public interface IMfgProcessDetailMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference name Example: My name
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference object title value Example: My title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference description value Example: My description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic type value Example: My Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Modified { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Created { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object revision value Example: A.1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Revision { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object current state value Example: In Work
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object owner value Example: John Doe
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object organization value Example: MyCompany
      //
      // </summary>
      //----------------------------------------------------------------
      public string Organization { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object collabspace value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string Collabspace { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object sequencingMode value Example: Advanced
      //
      // </summary>
      //----------------------------------------------------------------
      public string SequencingMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object capacity value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? Capacity { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cycleTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? CycleTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates FirstAllowed (1), Priority (2), Proportion (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? FlowModeIN { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates FirstAllowed (1), Priority (2), Proportion (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? FlowModeOUT { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object meanTimeBetweenFailure value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MeanTimeBetweenFailure { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object meanTimeToRepair value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MeanTimeToRepair { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates PUSH (1), SCHEDULE (2), PULL (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? OperationMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates LIFO (1), FIFO (2), PRIORITY (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? QueuingModeIN { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates LIFO (1), FIFO (2), PRIORITY (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? QueuingModeOUT { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object totalProductionTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? TotalProductionTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedDistance value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedDistance { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates Continuous (1), Batch (2) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? TransferMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates Sequential (1), Any (2), AllTogether (3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? ArrivalMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object initialDelay value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? InitialDelay { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      public IMfgProcessEnterpriseAttributes MfgProcessEnterpriseAttributes { get; set; }

      public IWorkPlanEnterpriseAttributes WorkPlanEnterpriseAttributes { get; set; }

      public IQtyControlProcessReferenceEnterpriseAttributes QtyControlProcessReferenceEnterpriseAttributes { get; set; }

      public IGeneralSystemReferenceEnterpriseAttributes GeneralSystemReferenceEnterpriseAttributes { get; set; }

      public ITransformationSystemReferenceEnterpriseAttributes TransformationSystemReferenceEnterpriseAttributes { get; set; }

      public ITransferSystemReferenceEnterpriseAttributes TransferSystemReferenceEnterpriseAttributes { get; set; }

      public IStorageSystemReferenceEnterpriseAttributes StorageSystemReferenceEnterpriseAttributes { get; set; }

      public IBufferSystemEnterpriseAttributes BufferSystemEnterpriseAttributes { get; set; }

      public ISinkSystemEnterpriseAttributes SinkSystemEnterpriseAttributes { get; set; }

      public ISourceSystemEnterpriseAttributes SourceSystemEnterpriseAttributes { get; set; }

      public IServiceHeaderWorkPlanEnterpriseAttributes ServiceHeaderWorkPlanEnterpriseAttributes { get; set; }

      public IServiceWorkPlanEnterpriseAttributes ServiceWorkPlanEnterpriseAttributes { get; set; }
   }
}