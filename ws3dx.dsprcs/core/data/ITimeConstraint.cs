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
    [ConcreteInterfaceImpConverter(typeof(TimeConstraint))]
    public interface ITimeConstraint
    {
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
        /// DB type of the object Example: dsprcs:TimeConstraint
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
        /// Indicates FinishToStart(1), StartToStart(2) or FinishToFinish(3) value. Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string DependencyType { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Boolean value whether time constraint is product flow Example: false
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? IsProductFlow { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Delay mode enum value
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string DelayMode { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Boolean value whether time constraint is optional Example: false
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? IsOptional { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Resource constraint enum value
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ResourceConstraint { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Delay real value Example: 0
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? Delay { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Return code value Example: RCFail203
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ReturnCode { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Maximum retries value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public int? MaximumRetries { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Occurrence of constraining operation instance details Example: 
        /// ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> FromOperationOccurrence { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///		
        /// Occurrence of constrained operation instance details Example: 
        /// ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public IList<string> ToOperationOccurrence { get; set; }
    }
}