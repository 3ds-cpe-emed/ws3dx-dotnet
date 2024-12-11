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
using ws3dx.shared.data;

namespace ws3dx.dsdo.data
{
   public interface ICreateDerivedOutputJobsResponse
   {
      public ITypedUriId ReferencedObject { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: DOJob_C0828256DBC8320062D66F0000072D99_A.1_2027540094524400
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: C0828256DBC8320062D66F2C001CE380
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 4e9b3458f2e57787a144c1763544eeb88850e5affbdfdb9ce90d4bf154d1d85b
      //
      // </summary>
      //----------------------------------------------------------------
      public string RuleId { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: prd_oMhNiOU+++++3++-uz+9g_prd_oMhNiOU+++++3++-uz+9g_A.1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: STEP
      //
      // </summary>
      //----------------------------------------------------------------
      public string Target { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Created
      //
      // </summary>
      //----------------------------------------------------------------
      public string Status { get; set; }
   }
}