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
using ws3dx.document.data;

namespace ws3dx.document.core.data.impl
{
   public class FileData : IFileData
   {
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName("comments")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Comments { get; set; }

      [JsonPropertyName("locker")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Locker { get; set; }

      [JsonPropertyName("fileType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FileType { get; set; }

      [JsonPropertyName("dimension")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Dimension { get; set; }

      [JsonPropertyName("length")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Length { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("originated")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originated { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("receipt")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Receipt { get; set; }

      [JsonPropertyName("keepLocked")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string KeepLocked { get; set; }

      [JsonPropertyName("format")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Format { get; set; }

      [JsonPropertyName("store")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Store { get; set; }

      [JsonPropertyName("fileSize")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FileSize { get; set; }

      [JsonPropertyName("fileChecksum")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FileChecksum { get; set; }
   }
}