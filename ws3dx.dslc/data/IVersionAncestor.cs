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

namespace ws3dx.dslc.data
{
   public interface IVersionAncestor
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The operation used to create the version. May be Revision,Branch,RevisionFrom or 
      // MinorRevision Example: Revision
      //
      // </summary>
      //----------------------------------------------------------------
      public string EdgeType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The identifier of the ancestor Example: F718B05686760000926EEB5BE7400900
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The identifier of the new object. Example: F718B05686760000926EEB5BE7400900
      //
      // </summary>
      //----------------------------------------------------------------
      public string Identifier { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The source of the new object. Example: https://ve4al702dsy.dsone.3ds.com:443/3DSpace
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The type of the new object. Example: VPMReference
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: The relative path of the new object. Example: /resources/v1/modeler/dseng/dseng:EngItem/F718B05686760000926EEB5BE7400900
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }
   }
}