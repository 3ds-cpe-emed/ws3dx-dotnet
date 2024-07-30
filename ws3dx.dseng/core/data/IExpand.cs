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
using ws3dx.dseng.data.impl;
using ws3dx.serialization.attribute;

namespace ws3dx.dseng.data
{
    [ConcreteInterfaceImpConverter(typeof(Expand))]
    public interface IExpand
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// -1 for all level, and 1,2,3,.. for specific level Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? ExpandDepth { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// true/false Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? WithPath { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Default value: ["VPMReference"], Autorised value: "VPMReference", "VPMRepReference" or any public 
        /// subtypes of VPMReference and VPMRepReference (Drawing for example) Example: ["VPMReference","VPMRepReference"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> TypeFilterBo { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Default value: ["VPMInstance"], Autorised value: "VPMInstance", "VPMRepInstance" or any public 
        /// subtypes of VPMInstance and VPMRepInstance Example: ["VPMInstance","VPMRepInstance"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> TypeFilterRel { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// inputType is not proper. Please check the Filter Specification here: Web Services and Events | 
        /// 3DSpace | Advanced Filtering | The Public Filter Specification Example: {...}
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Filter { get; set; }
    }
}