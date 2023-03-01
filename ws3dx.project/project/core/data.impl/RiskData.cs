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
   public class RiskData : IRiskData
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

      [JsonPropertyName("originator")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originator { get; set; }

      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      [JsonPropertyName("estimatedStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedStartDate { get; set; }

      [JsonPropertyName("estimatedFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedFinishDate { get; set; }

      [JsonPropertyName("actualStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualStartDate { get; set; }

      [JsonPropertyName("actualFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualFinishDate { get; set; }

      [JsonPropertyName("riskType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskType { get; set; }

      [JsonPropertyName("riskVisibility")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskVisibility { get; set; }

      [JsonPropertyName("riskImpact")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskImpact { get; set; }

      [JsonPropertyName("riskProbability")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskProbability { get; set; }

      [JsonPropertyName("riskFactor")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskFactor { get; set; }

      [JsonPropertyName("riskResolution")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskResolution { get; set; }

      [JsonPropertyName("riskAbatement")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskAbatement { get; set; }

      [JsonPropertyName("measureOfSuccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MeasureOfSuccess { get; set; }

      [JsonPropertyName("riskCategory")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskCategory { get; set; }

      [JsonPropertyName("modifyAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ModifyAccess { get; set; }

      [JsonPropertyName("deleteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DeleteAccess { get; set; }

      [JsonPropertyName("promoteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PromoteAccess { get; set; }

      [JsonPropertyName("demoteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DemoteAccess { get; set; }

      [JsonPropertyName("fromConnectAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FromConnectAccess { get; set; }

      [JsonPropertyName("toConnectAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ToConnectAccess { get; set; }

   }
}