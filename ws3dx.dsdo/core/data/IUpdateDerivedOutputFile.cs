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

namespace ws3dx.dsdo.data
{
   public interface IUpdateDerivedOutputFile
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: UjU5AAABwMACLcJmZh0Fe7bzCrHPMclJAbI26g6pJMiin8
      //
      // </summary>
      //----------------------------------------------------------------
      public string Receipt { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: STEP_b87da43e_5360_5e992f39_c87c_Default.stp
      //
      // </summary>
      //----------------------------------------------------------------
      public string Filename { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: STEP
      //
      // </summary>
      //----------------------------------------------------------------
      public string Format { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: e7d4437ce8ac6574495f2b9c95b89105
      //
      // </summary>
      //----------------------------------------------------------------
      public string Checksum { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: corelationID_DO
      //
      // </summary>
      //----------------------------------------------------------------
      public string CorelationID { get; set; }
   }
}