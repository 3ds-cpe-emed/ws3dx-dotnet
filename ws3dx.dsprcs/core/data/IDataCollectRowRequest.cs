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
using ws3dx.dsprcs.data;
using ws3dx.serialization.attribute;
using ws3dx.dsprcs.data.impl;
namespace ws3dx.dsprcs.data
{
	[ConcreteInterfaceImpConverter(typeof(DataCollectRowRequest))]
	public interface IDataCollectRowRequest
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
        /// Object text value Example: Any text
		///
		/// </summary>
		///----------------------------------------------------------------
		public string Text { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object label value Example: Any label
		///
		/// </summary>
		///----------------------------------------------------------------
		public string Label { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object mode value Example: Collected or Computed
		///
		/// </summary>
		///----------------------------------------------------------------
		public string Mode { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object numberOfMeasurements value Example: 10
		///
		/// </summary>
		///----------------------------------------------------------------
		public int? NumberOfMeasurements { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object possibleValues value Example: [100, 10, 120]
		///
		/// </summary>
		///----------------------------------------------------------------
		public string PossibleValues { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object magnitude value Example: Any magnitude
		///
		/// </summary>
		///----------------------------------------------------------------
		public string Magnitude { get; set; }
		
		public IMagnitudeValueAuth MaxValue { get; set; }
		
		public IMagnitudeValueAuth MinValue { get; set; }
		
		public IMagnitudeValueAuth NominalValue { get; set; }
		
		public IMagnitudeValueAuth ControlMinValue { get; set; }
		
		public IMagnitudeValueAuth ControlMaxValue { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object minIncluded value Example: true
		///
		/// </summary>
		///----------------------------------------------------------------
		public bool? MinIncluded { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object maxIncluded value Example: true
		///
		/// </summary>
		///----------------------------------------------------------------
		public bool? MaxIncluded { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object controlMinIncluded value Example: true
		///
		/// </summary>
		///----------------------------------------------------------------
		public bool? ControlMinIncluded { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object controlMaxIncluded value Example: true
		///
		/// </summary>
		///----------------------------------------------------------------
		public bool? ControlMaxIncluded { get; set; }
		
	}
}