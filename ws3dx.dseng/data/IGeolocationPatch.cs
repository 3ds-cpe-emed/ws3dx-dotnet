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
   public interface IGeolocationPatch
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 12.45
      //
      // </summary>
      //----------------------------------------------------------------
      public double? Azimuth { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? Activate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 12345.56
      //
      // </summary>
      //----------------------------------------------------------------
      public double? Axis1 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 56789.2
      //
      // </summary>
      //----------------------------------------------------------------
      public double? Axis2 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 125.0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? Axis3 { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Timestamp id
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }
   }
}