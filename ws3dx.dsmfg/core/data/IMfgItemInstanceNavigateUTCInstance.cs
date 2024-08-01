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
using ws3dx.dsmfg.data.impl;
using ws3dx.serialization.attribute;
namespace ws3dx.dsmfg.data
{
    [ConcreteInterfaceImpConverter(typeof(MfgItemInstanceNavigateUTCInstance))]
    public interface IMfgItemInstanceNavigateUTCInstance
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Entity physical id of the dsmfg:MfgItemInstance' Example: MfgItemInstanceID1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Identifier { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// source Example: https://server_name.dsone.3ds.com:443/3DSpace
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Source { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// relativePath Example: /resources/v1/modeler/dsmfg/dsmfg:MfgItem/MfgItemParentID/dsmfg:MfgItemInstance/MfgItemInstanceID1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string RelativePath { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Basic type value Example: DELFmiFunctionIdentifiedInstance
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

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
        /// Instance name Example: My name
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Name { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Instance description vlaue Example: My description
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Description { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Reference Entity ID Example: 2D70169432D84866A200F907881AC9B1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Reference { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Parent Entity ID Example: 2D70169432D84866A200F907881AC9B1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Parent { get; set; }

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
        /// Basic modified value in UTC Example: 2022-01-31T09:48:10Z
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Modified { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object created value in UTC Example: 2022-01-31T09:48:10Z
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Created { get; set; }

    }
}