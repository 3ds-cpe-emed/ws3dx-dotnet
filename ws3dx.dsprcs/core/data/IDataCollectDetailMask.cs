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
using ws3dx.serialization.attribute;

namespace ws3dx.dsprcs.data
{
   [MaskSchema("dsprcs:DataCollectMask.Details")]
   public interface IDataCollectDetailMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference name Example: My name
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference object title value Example: My title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference description value Example: My description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

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
      // Description: Basic type value Example: My Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

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
      // Description: Object revision value Example: A.1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Revision { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object current state value Example: In Work
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object owner value Example: John Doe
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object organization value Example: MyCompany
      //
      // </summary>
      //----------------------------------------------------------------
      public string Organization { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object collabspace value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string Collabspace { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object text value Example: Any text
      //
      // </summary>
      //----------------------------------------------------------------
      public string Text { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object label value Example: Any label
      //
      // </summary>
      //----------------------------------------------------------------
      public string Label { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indicates Real(1),Integer(2),Text(3),Boolean(4),Timestamp(5) value. Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? DcType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object sampleSize value Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? SampleSize { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object hasMaxValuated value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? HasMaxValuated { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object hasMinValuated value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? HasMinValuated { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object magnitude value Example: Any magnitude
      //
      // </summary>
      //----------------------------------------------------------------
      public string Magnitude { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object max value Example: 100
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MaxValue { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object min value Example: 100
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MinValue { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object possibleValues value Example: [100, 10, 120]
      //
      // </summary>
      //----------------------------------------------------------------
      public string PossibleValues { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object minIncluded value Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? MinIncluded { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object maxIncluded value
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? MaxIncluded { get; set; }

      public IWorkInstructionEnterpriseAttributes WorkInstructionEnterpriseAttributes { get; set; }

      public IDataCollectEnterpriseAttributes DataCollectEnterpriseAttributes { get; set; }
   }
}