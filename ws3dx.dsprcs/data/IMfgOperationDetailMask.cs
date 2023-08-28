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
using ws3dx.dsprcs.data.extension;
using ws3dx.serialization.attribute;

namespace ws3dx.dsprcs.data
{
   [MaskSchema("dsprcs:MfgOperationMask.Details")]
   public interface IMfgOperationDetailMask
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
      // Description: Object estimatedTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object estimatedTime_AddedValueRatio value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedTimeAddedValueRatio { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object measuredTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MeasuredTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object trackTime value Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? TrackTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object timeMode value indicates 
      // EstimatedTime(1);AnalyzedTime(2);SimulatedTime(3);WorkInstruction(4);UserDefinedTime(5);MeasuredTime(6);TrackTime(7) 
      // Example: 3
      //
      // </summary>
      //----------------------------------------------------------------
      public string TimeMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object executionTemplate value Example: Kitting
      //
      // </summary>
      //----------------------------------------------------------------
      public string ExecutionTemplate { get; set; }

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
      // Description: Object versionComment value Example: My Revision Comment
      //
      // </summary>
      //----------------------------------------------------------------
      public string VersionComment { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object isTimeProportionalToQty value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsTimeProportionalToQty { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object interruptible value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? Interruptible { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object manageVariant value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? ManageVariant { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object rollup value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? Rollup { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object materialScrap value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MaterialScrap { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object preparationTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? PreparationTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object preProcessingTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? PreProcessingTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object postProcessingTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? PostProcessingTime { get; set; }

      public IMagnitudeValue QuantityToBeProducedPerTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object timePerFastening value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? TimePerFastening { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object fasteningRate value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? FasteningRate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates RETURN_BACK(1), KEEP_RESERVED (2), AVAILABLE_FOR_OTHERS(3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? InputResources { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object occurrenceTime value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? OccurrenceTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates TOTAL_TIME(1), BUSY_TIME(2), NUMBER_OF_PRODUCTS(3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? OccurrenceTimeMode { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates CONTINUE(1), RESTART(2), SCRAP_INPUT_PRODUCTS(3) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? Restart { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates IMMEDIATE(1) , WHEN_OPERATIONS_END(2) Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? StopingOnGoingOp { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object recorderLevel value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? RecorderLevel { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object lot value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? Lot { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object proportion value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public double? Proportion { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      public IMfgOperationEnterpriseAttributes MfgOperationEnterpriseAttributes { get; set; }

      public IGeneralOperationReferenceEnterpriseAttributes GeneralOperationReferenceEnterpriseAttributes { get; set; }

      public ILoadingOperationReferenceEnterpriseAttributes LoadingOperationReferenceEnterpriseAttributes { get; set; }

      public IUnLoadingOperationReferenceEnterpriseAttributes UnLoadingOperationReferenceEnterpriseAttributes { get; set; }

      public IRemoveMaterialOperationReferenceEnterpriseAttributes RemoveMaterialOperationReferenceEnterpriseAttributes { get; set; }

      public ITransferOperationReferenceEnterpriseAttributes TransferOperationReferenceEnterpriseAttributes { get; set; }

      public IPunctualOperationReferenceEnterpriseAttributes PunctualOperationReferenceEnterpriseAttributes { get; set; }

      public ICurveOperationReferenceEnterpriseAttributes CurveOperationReferenceEnterpriseAttributes { get; set; }

      public IInterruptOperationReferenceEnterpriseAttributes InterruptOperationReferenceEnterpriseAttributes { get; set; }

      public IBufferOperationReferenceEnterpriseAttributes BufferOperationReferenceEnterpriseAttributes { get; set; }

      public ISinkOperationReferenceEnterpriseAttributes SinkOperationReferenceEnterpriseAttributes { get; set; }

      public ISourceOperationReferenceEnterpriseAttributes SourceOperationReferenceEnterpriseAttributes { get; set; }
   }
}