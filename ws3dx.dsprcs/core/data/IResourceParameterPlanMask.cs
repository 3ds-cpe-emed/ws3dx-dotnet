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
using ws3dx.dsprcs.data.impl;
using ws3dx.serialization.attribute;
namespace ws3dx.dsprcs.data
{
    [ConcreteInterfaceImpConverter(typeof(ResourceParameterPlanMask))]
    [MaskSchema("dsprcs:ResourceParameterPlanMask.Default")]
    public interface IResourceParameterPlanMask
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
        /// Entity physical id Example: Object Physical ID
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Id { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Basic type value Example: DELResourceParameterPlanReference
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Basic modified value Example: 2024-07-01T09:48:10.000Z
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Modified { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object created value Example: 2024-07-01T09:48:10.000Z
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
        /// Object current state value Example: IN_WORK
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
    }
}