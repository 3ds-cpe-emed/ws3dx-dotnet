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
using ws3dx.dsprcs.data.extension;

namespace ws3dx.dsprcs.data.impl
{
    public class MfgOperationDetailMask : IMfgOperationDetailMask
    {
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; }

        [JsonPropertyName("modified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Modified { get; set; }

        [JsonPropertyName("created")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Created { get; set; }

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

        [JsonPropertyName("estimatedTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedTime { get; set; }

        [JsonPropertyName("estimatedTime_AddedValueRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedTimeAddedValueRatio { get; set; }

        [JsonPropertyName("measuredTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MeasuredTime { get; set; }

        [JsonPropertyName("trackTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TrackTime { get; set; }

        [JsonPropertyName("timeMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TimeMode { get; set; }

        [JsonPropertyName("executionTemplate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExecutionTemplate { get; set; }

        [JsonPropertyName("sequencingMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SequencingMode { get; set; }

        [JsonPropertyName("versionComment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VersionComment { get; set; }

        [JsonPropertyName("isTimeProportionalToQty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsTimeProportionalToQty { get; set; }

        [JsonPropertyName("interruptible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Interruptible { get; set; }

        [JsonPropertyName("manageVariant")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ManageVariant { get; set; }

        [JsonPropertyName("rollup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Rollup { get; set; }

        [JsonPropertyName("materialScrap")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MaterialScrap { get; set; }

        [JsonPropertyName("preparationTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PreparationTime { get; set; }

        [JsonPropertyName("preProcessingTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PreProcessingTime { get; set; }

        [JsonPropertyName("postProcessingTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PostProcessingTime { get; set; }

        [JsonPropertyName("quantityToBeProducedPerTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMagnitudeValue QuantityToBeProducedPerTime { get; set; }

        [JsonPropertyName("timePerFastening")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TimePerFastening { get; set; }

        [JsonPropertyName("fasteningRate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FasteningRate { get; set; }

        [JsonPropertyName("inputResources")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? InputResources { get; set; }

        [JsonPropertyName("occurrenceTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? OccurrenceTime { get; set; }

        [JsonPropertyName("occurrenceTimeMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OccurrenceTimeMode { get; set; }

        [JsonPropertyName("restart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Restart { get; set; }

        [JsonPropertyName("stopingOnGoingOp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? StopingOnGoingOp { get; set; }

        [JsonPropertyName("recorderLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RecorderLevel { get; set; }

        [JsonPropertyName("lot")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Lot { get; set; }

        [JsonPropertyName("proportion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Proportion { get; set; }

        [JsonPropertyName("cestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cestamp { get; set; }

        [JsonPropertyName("dsprcs:MfgOperationEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMfgOperationEnterpriseAttributes MfgOperationEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiGeneralOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IGeneralOperationReferenceEnterpriseAttributes GeneralOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiLoadingOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ILoadingOperationReferenceEnterpriseAttributes LoadingOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiUnLoadingOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IUnLoadingOperationReferenceEnterpriseAttributes UnLoadingOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiRemoveMaterialOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IRemoveMaterialOperationReferenceEnterpriseAttributes RemoveMaterialOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiTransferOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITransferOperationReferenceEnterpriseAttributes TransferOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiPunctualOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IPunctualOperationReferenceEnterpriseAttributes PunctualOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiCurveOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICurveOperationReferenceEnterpriseAttributes CurveOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiInterruptOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IInterruptOperationReferenceEnterpriseAttributes InterruptOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiBufferOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IBufferOperationReferenceEnterpriseAttributes BufferOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiSinkOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ISinkOperationReferenceEnterpriseAttributes SinkOperationReferenceEnterpriseAttributes { get; set; }

        [JsonPropertyName("dsprcs:DELLmiSourceOperationReferenceEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ISourceOperationReferenceEnterpriseAttributes SourceOperationReferenceEnterpriseAttributes { get; set; }
    }
}