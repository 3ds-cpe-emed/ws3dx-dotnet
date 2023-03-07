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
using ws3dx.serialization.attribute;
using ws3dx.shared.data;

namespace ws3dx.dsbks.data
{
   [MaskSchema("dsbks:BksMask.Bookmarks")]
   public interface IBookmarkSubBookmarksMask
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
      // Description: Get the list of bookmarks linked to the bookmark from the index (the object existence 
      // might be outdated). $top and $skip can be used as query parameters for pagination.
      //
      // </summary>
      //----------------------------------------------------------------
      public IList<ITypedUriIdentifier> Bookmarks { get; set; }
   }
}