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
    public class MfgProcessPatch : IMfgProcessPatch
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

        [JsonPropertyName("sequencingMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SequencingMode { get; set; }

        [JsonPropertyName("capacity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Capacity { get; set; }

        [JsonPropertyName("cycleTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? CycleTime { get; set; }

        [JsonPropertyName("flowModeIN")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FlowModeIN { get; set; }

        [JsonPropertyName("flowModeOUT")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FlowModeOUT { get; set; }

        [JsonPropertyName("meanTimeBetweenFailure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MeanTimeBetweenFailure { get; set; }

        [JsonPropertyName("meanTimeToRepair")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MeanTimeToRepair { get; set; }

        [JsonPropertyName("operationMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OperationMode { get; set; }

        [JsonPropertyName("queuingModeIN")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? QueuingModeIN { get; set; }

        [JsonPropertyName("queuingModeOUT")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? QueuingModeOUT { get; set; }

        [JsonPropertyName("totalProductionTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalProductionTime { get; set; }

        [JsonPropertyName("estimatedDistance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? EstimatedDistance { get; set; }

        [JsonPropertyName("transferMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TransferMode { get; set; }

        [JsonPropertyName("arrivalMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ArrivalMode { get; set; }

        [JsonPropertyName("initialDelay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? InitialDelay { get; set; }

        [JsonPropertyName("cestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cestamp { get; set; }

        [JsonPropertyName("dsprcs:MfgProcessEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IMfgProcessEnterpriseAttributes MfgProcessEnterpriseAttributes { get; set; }

        [JsonPropertyName("customerAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICustomerAttributes CustomerAttributes { get; set; }
    }
}