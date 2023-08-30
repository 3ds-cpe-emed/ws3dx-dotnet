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

namespace ws3dx.dslib.data
{
   public interface IClassAttributeDefinition
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: DB name of the class attribute Example: Product Color
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: type of the class attribute (string/boolean/integer/real/timestamp) Example: string
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: default value of the class attribute Example: Green
      //
      // </summary>
      //----------------------------------------------------------------
      public string Default { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: description of the class attribute Example: attribute to store the color of the product
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: dimension(magnitude) of the class attribute Example: DSDim_LENGTH
      //
      // </summary>
      //----------------------------------------------------------------
      public string Dimension { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: property to decide whether the class attribute allows multiple values or not Example: 
      // true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? Multivalued { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The authorized values(range values) of the class attribute Example: 
      // ["Green","Blue","Red","Yellow","Black"]
      //
      // </summary>
      //----------------------------------------------------------------
      public IList<string> AuthorizedValues { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: minimum(inclusive) range value of the class attribute (for integer/real types only) 
      // Example: 10
      //
      // </summary>
      //----------------------------------------------------------------
      public string Minimum { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: maximum(inclusive) range value of the class attribute (for integer/real types only) 
      // Example: 100
      //
      // </summary>
      //----------------------------------------------------------------
      public string Maximum { get; set; }
   }
}