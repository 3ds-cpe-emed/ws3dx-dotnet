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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.dslc.data;

namespace ws3dx.dslc.core.service
{
   // SDK Service
   public class VersionService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dslc/";

      public VersionService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) version/getGraph
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get the version graphs for a list of objects. The request will be rejected if the 
      // total number of objects exceeds 50. Summary: Get the version graphs of objects
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IVersionGraph>> GetGraph(IObjRefInput request)
      {
         string resourceURI = $"{GetBaseResource()}version/getGraph";

         return await PostGroup<IVersionGraph, IVersionGraphOutput, IObjRefInput>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) version/create
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create new versions for a list of objects. 
      //  1. Versions to create are revisions : 'edgeType' keyword is missing or set to 'Revision' (default 
      // value). 'affix' keyword is optional (not used if added). 
      //  2. Versions to create are branches : 'edgeType' keyword is set to 'Branch'. 'affix' keyword is 
      // optional (used if added). 
      //  The request will be rejected if the total number of objects (after completion excluding relationship) 
      // exceeds 100. Summary: Version objects
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IDuplicate>> Create(IObjRefBranchInput request)
      {
         string resourceURI = $"{GetBaseResource()}version/create";

         return await PostGroup<IDuplicate, IDuplicateOutput, IObjRefBranchInput>(resourceURI, request);
      }
   }
}