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
using System.Collections.Generic;
using ws3dx.dsprcs.data.impl;
using ws3dx.serialization.attribute;
namespace ws3dx.dsprcs.data
{
    [ConcreteInterfaceImpConverter(typeof(ResourceParameterRowMask))]
    [MaskSchema("dsprcs:ResourceParameterRowMask.Default")]
    public interface IResourceParameterRowMask
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Reference object title value Example: My title
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Title { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Reference description value Example: My description
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Description { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Entity physical id Example: Object Physical ID
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Id { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Basic type value Example: DELResourcePrmPlanGET or DELResourcePrmPlanSET
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Basic modified value Example: 2023-12-08 06:08:33 UTC
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Modified { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object created value Example: 2023-12-08 06:08:33 UTC
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Created { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object current state value Example: DEFAULT
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string State { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object owner value Example: John Doe
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Owner { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object organization value Example: MyCompany
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Organization { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object collabspace value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Collabspace { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object cestamp value Example: Object cestamp value
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Cestamp { get; set; }

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
        /// Basic type value Example: Interger/Text/Real/Boolean…
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ParamType { get; set; }

        public IMagnitudeValuewithDisplayUnit ParamValue { get; set; }

        public IMagnitudeValuewithDisplayUnit MinValue { get; set; }

        public IMagnitudeValuewithDisplayUnit MaxValue { get; set; }

        public IMagnitudeValuewithDisplayUnit ControlMinValue { get; set; }

        public IMagnitudeValuewithDisplayUnit ControlMaxValue { get; set; }

        public IMagnitudeValuewithDisplayUnit NominalValue { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object minLimit value Example: Unset/Include/Excluded
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string MinLimit { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object minLimit value Example: Unset/Include/Excluded
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string MaxLimit { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object minLimit value Example: Unset/Include/Excluded
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ControlMinLimit { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object minLimit value Example: Unset/Include/Excluded
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ControlMaxLimit { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object possibleValues value Example: ["P1","P2"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> PossibleValues { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object symbolicResourceParamID value Example: UUID1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string SymbolicResourceParamID { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object symbolicCapableResourceD value Example: UUID2
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string SymbolicCapableResourceD { get; set; }
    }
}