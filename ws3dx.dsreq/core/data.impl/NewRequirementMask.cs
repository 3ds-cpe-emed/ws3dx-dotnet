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
using ws3dx.dsreq.data;

namespace ws3dx.dsreq.core.data.impl
{
   public class NewRequirementMask : INewRequirementMask
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: object name Example: My name
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object Title value Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object description value Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic type value Example: My Type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object revision value Example: A.1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object current state value Example: In Work
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object owner value Example: John Doe
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object organization value Example: MyCompany
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object collabspace value Example: Default
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("collabspace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: High
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Priority")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Priority { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Synopsis")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Synopsis { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ContentType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContentType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ContentData")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContentData { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ContentText")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContentText { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("UserRequirementImportance")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string UserRequirementImportance { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("AccessType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string AccessType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("RequirementCategory")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RequirementCategory { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("RequirementClassification")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RequirementClassification { get; set; }
   }
}