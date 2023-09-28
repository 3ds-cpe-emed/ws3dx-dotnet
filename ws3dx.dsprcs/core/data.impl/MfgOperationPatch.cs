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
using ws3dx.dsprcs.data;
using ws3dx.dsprcs.data.extension;

namespace ws3dx.dsprcs.core.data.impl
{
   public class MfgOperationPatch : IMfgOperationPatch
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

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
      // Description: Object sequencingMode value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("sequencingMode")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SequencingMode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object estimatedTime_AddedValueRatio value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedTime_AddedValueRatio")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedTimeAddedValueRatio { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object measuredTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("measuredTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? MeasuredTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object trackTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("trackTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? TrackTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object timeMode value indicates 
      // EstimatedTime(1);AnalyzedTime(2);SimulatedTime(3);WorkInstruction(4);UserDefinedTime(5);MeasuredTime(6);TrackTime(7) 
      // Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("timeMode")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? TimeMode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object executionTemplate value Example: Kitting
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("executionTemplate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ExecutionTemplate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object isTimeProportionalToQty value Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isTimeProportionalToQty")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsTimeProportionalToQty { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object interruptible value Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("interruptible")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? Interruptible { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object manageVariant value Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manageVariant")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? ManageVariant { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object rollup value Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("rollup")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? Rollup { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object materialScrap value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("materialScrap")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? MaterialScrap { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object preparationTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("preparationTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? PreparationTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object preProcessingTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("preProcessingTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? PreProcessingTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object postProcessingTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("postProcessingTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? PostProcessingTime { get; set; }

      [JsonPropertyName("quantityToBeProducedPerTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMagnitudeValueAuth QuantityToBeProducedPerTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object timePerFastening value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("timePerFastening")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? TimePerFastening { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object fasteningRate value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("fasteningRate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? FasteningRate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates RETURN_BACK(1), KEEP_RESERVED (2), AVAILABLE_FOR_OTHERS(3) Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("inputResources")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? InputResources { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object occurrenceTime value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("occurrenceTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? OccurrenceTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates TOTAL_TIME(1), BUSY_TIME(2), NUMBER_OF_PRODUCTS(3) Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("occurrenceTimeMode")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? OccurrenceTimeMode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates CONTINUE(1), RESTART(2), SCRAP_INPUT_PRODUCTS(3) Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("restart")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? Restart { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates IMMEDIATE(1) , WHEN_OPERATIONS_END(2) Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("stopingOnGoingOp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? StopingOnGoingOp { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object recorderLevel value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("recorderLevel")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? RecorderLevel { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object lot value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("lot")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? Lot { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object proportion value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("proportion")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Proportion { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Object cestamp value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      [JsonPropertyName("dsprcs:MfgOperationEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IMfgOperationEnterpriseAttributes MfgOperationEnterpriseAttributes { get; set; }

      [JsonPropertyName("customerAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ICustomerAttributes CustomerAttributes { get; set; }
   }
}