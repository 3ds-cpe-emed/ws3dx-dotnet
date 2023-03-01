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

namespace ws3dx.dsmfg.data
{
   public interface IGetMfgItemsFromEngItem
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: source Example: https://server_name.dsone.3ds.com:443/3DSpace
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: type Example: CreateAssembly
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Corresponding Eng Item ID Example: 07188256124D00005FBF9A2D000A8671
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id dsmfg:MfgItem ID Example: 07188256124D00005FBF9A2D000A8671
      //
      // </summary>
      //----------------------------------------------------------------
      public string Identifier { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: relativePath Example: /resources/v1/modeler/dsmfg/dsmfg:MfgItem/07188256124D00005FBF9A2D000A8671
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: relationType value
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelationType { get; set; }
   }
}