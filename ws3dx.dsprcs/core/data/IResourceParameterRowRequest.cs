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
	[ConcreteInterfaceImpConverter(typeof(ResourceParameterRowRequest))]
	public interface IResourceParameterRowRequest
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
        /// Object text value Example: Any text
		///
		/// </summary>
		///----------------------------------------------------------------
		public string Text { get; set; }
		
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
        /// object displayUnit value. Example: KILOGRAM
		///
		/// </summary>
		///----------------------------------------------------------------
		public string DisplayUnit { get; set; }
		
		public IMagnitudeValueAuth MaxValue { get; set; }
		
		public IMagnitudeValueAuth MinValue { get; set; }
		
		public IMagnitudeValueAuth NominalValue { get; set; }
		
		public IMagnitudeValueAuth ControlMinValue { get; set; }
		
		public IMagnitudeValueAuth ControlMaxValue { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object controlMinLimit value Example: Excluded
		///
		/// </summary>
		///----------------------------------------------------------------
		public string ControlMinLimit { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object controlMaxLimit value Example: Included
		///
		/// </summary>
		///----------------------------------------------------------------
		public string ControlMaxLimit { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object minLimit value Example: Included
		///
		/// </summary>
		///----------------------------------------------------------------
		public string MinLimit { get; set; }
		
		///----------------------------------------------------------------
		/// <summary>
		///		
        /// Object maxLimit value Example: Excluded
		///
		/// </summary>
		///----------------------------------------------------------------
		public string MaxLimit { get; set; }
		
	}
}