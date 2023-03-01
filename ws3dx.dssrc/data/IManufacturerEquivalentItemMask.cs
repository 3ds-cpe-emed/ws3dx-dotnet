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

namespace ws3dx.dssrc.data
{
   [MaskSchema("dssrc:ManufacturerEquivalentItems.Basic")]
   public interface IManufacturerEquivalentItemMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: MEI part number
      //
      // </summary>
      //----------------------------------------------------------------
      public string ManufacturerPartNumber { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: part source...
      //
      // </summary>
      //----------------------------------------------------------------
      public string PartSource { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: part source url...
      //
      // </summary>
      //----------------------------------------------------------------
      public string PartSourceURL { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Supplier Company
      //
      // </summary>
      //----------------------------------------------------------------
      public string Manufacturer { get; set; }

      public IEngItemUriIdentifier EngItem { get; set; }

      public ITypedUriIdentifier ManufacturerCompany { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: /resources/v1/modeler/dssrc/dssrc:ManufacturerEquivalentItems/582E8256AB4A00005F1993EA000AE52B
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: https://3DEXPERIENCE_3DSpace
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

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