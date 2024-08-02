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

namespace ws3dx.dsxcad.data
{
   public interface IXCADFamilyRepDerivedItemReference
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: source Example: $3DSpace
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: 3DBOMType Example: dsxcad:Part
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

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
      // Description: relativePath Example: /resources/v1/modeler/dsxcad/dsxcad:Part/0A57A84A1A..
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Active status of the Item Example: true/false
      //
      // </summary>
      //----------------------------------------------------------------
      public string Active { get; set; }
   }
}