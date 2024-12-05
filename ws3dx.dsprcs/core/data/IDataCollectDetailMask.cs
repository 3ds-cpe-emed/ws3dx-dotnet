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
    [ConcreteInterfaceImpConverter(typeof(DataCollectDetailMask))]
    [MaskSchema("dsprcs:DataCollectMask.Details")]
    public interface IDataCollectDetailMask
    {
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
        /// Entity physical id Example: EE562168015FFCF14F940A513C63AA77
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Id { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Basic type value Example: My Type
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Basic modified value Example: Dec 15, 2017 11:17 PM
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Modified { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object created value Example: Dec 11, 2017 12:53 PM
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Created { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object revision value Example: A.1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Revision { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object current state value Example: In Work
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
        /// Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
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
        /// Object label value Example: Any label
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Label { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Indicates Real(1),Integer(2),Text(3),Boolean(4),Timestamp(5) value. Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? DcType { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object sampleSize value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? SampleSize { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object hasMaxValuated value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? HasMaxValuated { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object hasMinValuated value Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? HasMinValuated { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object magnitude value Example: Any magnitude
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Magnitude { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object max value Example: 100
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? MaxValue { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Object min value Example: 100
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? MinValue { get; set; }

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

        public IWorkInstructionEnterpriseAttributes WorkInstructionEnterpriseAttributes { get; set; }

        public IDataCollectEnterpriseAttributes DataCollectEnterpriseAttributes { get; set; }
    }
}