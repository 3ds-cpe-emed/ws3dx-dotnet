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
using ws3dx.project.project.data;

namespace ws3dx.project.project.core.data.impl
{
   public class ScopeData : IScopeData
   {
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("synopsis")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Synopsis { get; set; }

      [JsonPropertyName("firstname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Firstname { get; set; }

      [JsonPropertyName("lastname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Lastname { get; set; }

      [JsonPropertyName("fullname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Fullname { get; set; }

      [JsonPropertyName("objectId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ObjectId { get; set; }

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("stateNLS")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string StateNLS { get; set; }

      [JsonPropertyName("typeNLS")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TypeNLS { get; set; }

      [JsonPropertyName("collabSpace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CollabSpace { get; set; }

      [JsonPropertyName("collabSpaceTitle")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CollabSpaceTitle { get; set; }

      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      [JsonPropertyName("organizationTitle")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string OrganizationTitle { get; set; }

      [JsonPropertyName("ownerFullname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string OwnerFullname { get; set; }

      [JsonPropertyName("hasfiles")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> Hasfiles { get; set; }

      [JsonPropertyName("fileExtension")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> FileExtension { get; set; }

   }
}