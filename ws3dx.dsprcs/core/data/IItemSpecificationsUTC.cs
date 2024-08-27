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

namespace ws3dx.dsprcs.data
{
   public interface IItemSpecificationsUTC
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: ID of the connection object Example: EE562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Indication of whether this is item act as scope or not. If false, then means this is 
      // implement link. Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsScope { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference to the scope manufacturing item.
      //
      // </summary>
      //----------------------------------------------------------------
      public ITypedUriIdentifier ItemReference { get; set; }
   }
}