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
using System.Text.Json.Serialization;
using ws3dx.dsrsc.data;

namespace ws3dx.dsrsc.core.data.impl
{
   public class ResourceLocated : IResourceLocated
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Full path to the source, including the server hostname. Example: 
      // https://server_name.dsone.3ds.com/3DSpace
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("source")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Source { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Type of the object. Example: VPMReference
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Physical ID of the object. Example: Object Physical ID
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Relative path from the source to get the details of the object, including the ID of 
      // the object. Example: /resources/v1/modeler/dsrsc/dsrsc:Resource/ResourcePhysicalID
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("relativePath")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RelativePath { get; set; }

      [JsonPropertyName("instance")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IResourceInstanceLocated Instance { get; set; }

      [JsonPropertyName("primaryCapableResource")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IPrimaryCapableResourceRef PrimaryCapableResource { get; set; }
   }
}