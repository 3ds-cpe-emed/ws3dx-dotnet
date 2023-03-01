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
using System.Text.Json.Serialization;
using ws3dx.dslc.data;

namespace ws3dx.dslc.core.data.impl
{
   public class ObjRefBranchInput : IObjRefBranchInput
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: To revise : do not use or set to Revise (default).
      // To branch : set to Branch. Example: Branch
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("edgeType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EdgeType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: To revise : do not use or set to any value (not taken into account).
      //  To branch : do not use or set to desired value (taken into account). Example: br_
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("affix")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Affix { get; set; }

      [JsonPropertyName("data")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IObjRefBranch> Data { get; set; }
   }
}