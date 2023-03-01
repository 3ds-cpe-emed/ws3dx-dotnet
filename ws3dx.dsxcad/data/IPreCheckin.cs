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
   public interface IPreCheckin
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Number of files to upload to FCS Example: 2
      //
      // </summary>
      //----------------------------------------------------------------
      public string FileNumber { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Number of ticket needed Example: 1
      //
      // </summary>
      //----------------------------------------------------------------
      public string TicketNumber { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Type of the object associated to the file Example: dsxcad:Part
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

   }
}