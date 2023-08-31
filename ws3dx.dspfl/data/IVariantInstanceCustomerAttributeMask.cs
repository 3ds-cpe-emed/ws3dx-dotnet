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
using ws3dx.serialization.attribute;

namespace ws3dx.dspfl.data
{
   [MaskSchema("dsmvpfl:VariantInstanceCustomerAttributeMask")]
   public interface IVariantInstanceCustomerAttributeMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id Example: AA562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object path Example: 
      // resources/v1/modeler/dspfl/dspfl:ModelVersion/MM562168015FFCF14F940A513C63AA77/dspfl:VariantInstance/AA562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: 3DSpace URL Example: 3DSpaceURL
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id Example: AA562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Identifier { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: constraint Example: Must/May
      //
      // </summary>
      //----------------------------------------------------------------
      public string Constraint { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? SequenceNumber { get; set; }

      public IList<IVariantInstanceCustomerAttributeVariant> Variant { get; set; }

      public IList<IVariantInstanceCustomerAttributeValue> Value { get; set; }
   }
}