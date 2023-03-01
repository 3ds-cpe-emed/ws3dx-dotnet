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

namespace ws3dx.dsrsc.data
{
   public interface IResourceLocated
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Full path to the source, including the server hostname. Example: 
      // https://server_name.dsone.3ds.com/3DSpace
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Type of the object. Example: VPMReference
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Physical ID of the object. Example: Object Physical ID
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Relative path from the source to get the details of the object, including the ID of 
      // the object. Example: /resources/v1/modeler/dsrsc/dsrsc:Resource/ResourcePhysicalID
      //
      // </summary>
      //----------------------------------------------------------------
      public string RelativePath { get; set; }

      public IResourceInstanceLocated Instance { get; set; }

      public IPrimaryCapableResourceRef PrimaryCapableResource { get; set; }
   }
}