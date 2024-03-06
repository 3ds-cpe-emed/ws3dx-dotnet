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

namespace ws3dx.dseng.data
{
   public interface IPosition
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A11 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A12 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A13 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A21 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A22 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A23 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A31 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A32 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: rotation matrix coefficient Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public int? A33 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: translation vector X in mm Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? U1 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: translation vector Y in mm Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? U2 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: translation vector Z in mm Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public int? U3 { get; set; }
   }
}