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
using ws3dx.project.task.data;

namespace ws3dx.project.task.core.data.impl
{
   public class PredecessorsRelelements : IPredecessorsRelelements
   {
      [JsonPropertyName("lagTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string LagTime { get; set; }

      [JsonPropertyName("dependencyType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DependencyType { get; set; }

      [JsonPropertyName("lagTimeInputUnit")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string LagTimeInputUnit { get; set; }

      [JsonPropertyName("lagTimeInputValue")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string LagTimeInputValue { get; set; }

      [JsonPropertyName("From")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string From { get; set; }

      [JsonPropertyName("predTaskSeqNumber")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PredTaskSeqNumber { get; set; }

      [JsonPropertyName("To")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string To { get; set; }

      [JsonPropertyName("predProjectName")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PredProjectName { get; set; }

      [JsonPropertyName("predProjectId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PredProjectId { get; set; }
   }
}