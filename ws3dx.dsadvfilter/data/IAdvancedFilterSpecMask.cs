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

namespace ws3dx.dsadvfilter.data
{
   [MaskSchema("dsadvfilter:AdvFilterMask.FilterSpec")]
   public interface IAdvancedFilterSpecMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object Title value Example: My title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object description value Example: My description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Filtered Product Example: classReturnType is not proper. Please check the computed 
      // program return type
      //
      // </summary>
      //----------------------------------------------------------------
      public string ReferencedObject { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Filter specification Example: classReturnType is not proper. Please check the computed 
      // program return type
      //
      // </summary>
      //----------------------------------------------------------------
      public string Filter { get; set; }

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