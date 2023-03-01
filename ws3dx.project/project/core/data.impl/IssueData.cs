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
using ws3dx.project.project.data;

namespace ws3dx.project.project.core.data.impl
{
   public class IssueData : IIssueData
   {
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      [JsonPropertyName("originated")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originated { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("estimatedStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedStartDate { get; set; }

      [JsonPropertyName("estimatedFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedFinishDate { get; set; }

      [JsonPropertyName("problemType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ProblemType { get; set; }

      [JsonPropertyName("priority")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Priority { get; set; }

      [JsonPropertyName("priorityInternal")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PriorityInternal { get; set; }

      [JsonPropertyName("actionTaken")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActionTaken { get; set; }

      [JsonPropertyName("resolution")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Resolution { get; set; }

      [JsonPropertyName("steps")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Steps { get; set; }

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("modifyAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ModifyAccess { get; set; }

      [JsonPropertyName("deleteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DeleteAccess { get; set; }

      [JsonPropertyName("project")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Project { get; set; }

   }
}