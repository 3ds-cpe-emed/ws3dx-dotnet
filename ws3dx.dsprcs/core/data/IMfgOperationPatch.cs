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
using ws3dx.dsprcs.data.impl;
using ws3dx.serialization.attribute;
namespace ws3dx.dsprcs.data
{
    [ConcreteInterfaceImpConverter(typeof(MfgOperationPatch))]
    public interface IMfgOperationPatch
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Example: My title
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Title { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Example: My description
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Description { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Reference name Example: My name
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Name { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object sequencingMode value
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string SequencingMode { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object estimatedTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? EstimatedTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object estimatedTime_AddedValueRatio value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? EstimatedTimeAddedValueRatio { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object measuredTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? MeasuredTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object trackTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? TrackTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object timeMode value indicates EstimatedTime(1);AnalyzedTime(2);SimulatedTime(3);WorkInstruction(4);UserDefinedTime(5);MeasuredTime(6);TrackTime(7) 
        /// Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? TimeMode { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object executionTemplate value Example: Kitting
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ExecutionTemplate { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object isTimeProportionalToQty value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? IsTimeProportionalToQty { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object interruptible value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? Interruptible { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object manageVariant value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? ManageVariant { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object rollup value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? Rollup { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object materialScrap value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? MaterialScrap { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object preparationTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? PreparationTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object preProcessingTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? PreProcessingTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object postProcessingTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? PostProcessingTime { get; set; }

        public IMagnitudeValueAuth QuantityToBeProducedPerTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object timePerFastening value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? TimePerFastening { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object fasteningRate value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? FasteningRate { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Indicates RETURN_BACK(1), KEEP_RESERVED (2), AVAILABLE_FOR_OTHERS(3) Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? InputResources { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object occurrenceTime value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? OccurrenceTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Indicates TOTAL_TIME(1), BUSY_TIME(2), NUMBER_OF_PRODUCTS(3) Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? OccurrenceTimeMode { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Indicates CONTINUE(1), RESTART(2), SCRAP_INPUT_PRODUCTS(3) Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? Restart { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Indicates IMMEDIATE(1) , WHEN_OPERATIONS_END(2) Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? StopingOnGoingOp { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object recorderLevel value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? RecorderLevel { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object lot value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? Lot { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object proportion value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? Proportion { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Example: Object cestamp value
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Cestamp { get; set; }

        public IMfgOperationEnterpriseAttributes MfgOperationEnterpriseAttributes { get; set; }

        public ICustomerAttributes CustomerAttributes { get; set; }
    }
}