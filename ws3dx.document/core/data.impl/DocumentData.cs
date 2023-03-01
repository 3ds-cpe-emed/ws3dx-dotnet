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
using ws3dx.document.data;

namespace ws3dx.document.core.data.impl
{
   public class DocumentData : IDocumentData
   {
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      [JsonPropertyName("stateNLS")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string StateNLS { get; set; }

      [JsonPropertyName("typeNLS")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TypeNLS { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("isLatestRevision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string IsLatestRevision { get; set; }

      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      [JsonPropertyName("collabspace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }

      [JsonPropertyName("collabSpaceTitle")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CollabSpaceTitle { get; set; }

      [JsonPropertyName("originated")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originated { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("comments")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Comments { get; set; }

      [JsonPropertyName("hasDownloadAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string HasDownloadAccess { get; set; }

      [JsonPropertyName("hasReviseAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string HasReviseAccess { get; set; }

      [JsonPropertyName("hasModifyAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string HasModifyAccess { get; set; }

      [JsonPropertyName("hasDeleteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string HasDeleteAccess { get; set; }

      [JsonPropertyName("reservedby")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Reservedby { get; set; }

      [JsonPropertyName("parentId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ParentId { get; set; }

      [JsonPropertyName("parentRelName")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ParentRelName { get; set; }

      [JsonPropertyName("parentDirection")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ParentDirection { get; set; }

      [JsonPropertyName("fileExtension")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> FileExtension { get; set; }

      [JsonPropertyName("imageId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ImageId { get; set; }

      [JsonPropertyName("receipt")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Receipt { get; set; }

      [JsonPropertyName("secondaryTitle")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SecondaryTitle { get; set; }

      [JsonPropertyName("extensions")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> Extensions { get; set; }
   }
}