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
using ws3dx.data;
using ws3dx.shared.data.extension;

namespace ws3dx.dsrm.data
{
   public interface IUpdateRawMaterial
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Raw Material Description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Title of the RM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Dimension Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string DimensionType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Timestamp id
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      public ICustomerAttributes CustomerAttributes { get; set; }

      public IChangeControl ChangeControl { get; set; }

      public IExtendedAttributes EnterpriseAttributes { get; set; }

      public IEnterpriseReference EnterpriseReference { get; set; }
   }
}