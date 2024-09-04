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
    [ConcreteInterfaceImpConverter(typeof(PreAssignedWorkcenter))]
    public interface IPreAssignedWorkcenter
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// ID of the connection object Example: EE562168015FFCF14F940A513C63AA77
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Id { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// DB Type Example: AllocatedResourceLink
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Reference to the preassigned work center. Example: 9FF50FB00000775C607A98F600013E5E
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Resource { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Occurrence path for the related process operation. Example: ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> OperationOccurrence { get; set; }
    }
}