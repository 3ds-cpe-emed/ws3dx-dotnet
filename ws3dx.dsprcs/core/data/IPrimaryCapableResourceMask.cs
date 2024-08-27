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
using ws3dx.serialization.attribute;
using ws3dx.shared.data;

namespace ws3dx.dsprcs.data
{
   [MaskSchema("dsprcs:PrimaryCapableResourceMask.Default")]
   public interface IPrimaryCapableResourceMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Modified { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Created { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Resource quantity real value Example: 10.5
      //
      // </summary>
      //----------------------------------------------------------------
      public double? ResourcesQuantity { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Boolean value whether is preferred Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsPreferred { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Boolean value whether is manually scheduled Example: false
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? ManuallyScheduled { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Priority integer value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? Priority { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Tool changeover time real value Example: 20.5
      //
      // </summary>
      //----------------------------------------------------------------
      public double? ToolChangeoverTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Boolean value whether is reserved from first step Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsReservedFromFirstStep { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Capable resource group index integer value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? CapableRscGroupIndex { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Estimated time real value Example: 20.5
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EstimatedTime { get; set; }

      public ITypedUriIdentifier Resource { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }
   }
}