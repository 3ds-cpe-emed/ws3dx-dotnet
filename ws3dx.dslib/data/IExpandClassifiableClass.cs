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
   public interface IExpandClassifiableClass
   {
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
      // Description: object name Example: My name
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

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
      // Description: Basic type value Example: My Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic modified value Example: 8/28/2020 12:14:54 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Modified { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object created value Example: 8/18/2020 12:18:24 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Created { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object revision value Example: 154F8256744D000002A6AF5E1AE90900
      //
      // </summary>
      //----------------------------------------------------------------
      public string Revision { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object current state value Example: Active
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object owner value Example: John WICK
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object organization value Example: MyCompany
      //
      // </summary>
      //----------------------------------------------------------------
      public string Organization { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object collabspace value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string Collabspace { get; set; }

      public IList<IExpandClassifiableClass> Children { get; set; }
   }
}