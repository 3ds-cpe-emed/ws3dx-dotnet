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
using ws3dx.project.risk.data;

namespace ws3dx.project.risk.core.data.impl
{
   public class RiskData : IRiskData
   {
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      [JsonPropertyName("identifier")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Identifier { get; set; }

      [JsonPropertyName("source")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Source { get; set; }

      [JsonPropertyName("relativePath")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RelativePath { get; set; }

      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

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

      [JsonPropertyName("originated")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originated { get; set; }

      [JsonPropertyName("originator")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originator { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

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

      [JsonPropertyName("classType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ClassType { get; set; }

      [JsonPropertyName("mitigationType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MitigationType { get; set; }

      [JsonPropertyName("impact")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Impact { get; set; }

      [JsonPropertyName("probability")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Probability { get; set; }

      [JsonPropertyName("rpnValue")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RpnValue { get; set; }

      [JsonPropertyName("effectiveDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EffectiveDate { get; set; }

      [JsonPropertyName("abatement")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Abatement { get; set; }

      [JsonPropertyName("measureOfSuccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string MeasureOfSuccess { get; set; }

      [JsonPropertyName("contextId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContextId { get; set; }

      [JsonPropertyName("ownerInfo")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRisksOwnerInfo> OwnerInfo { get; set; }

      [JsonPropertyName("classes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRiskClass> Classes { get; set; }

      [JsonPropertyName("rpn")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRisksRpn> Rpn { get; set; }

      [JsonPropertyName("context")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRisksContext> Context { get; set; }

      [JsonPropertyName("assignees")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRiskAssignee> Assignees { get; set; }

      [JsonPropertyName("affectedItems")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRiskAffectedItem> AffectedItems { get; set; }

      [JsonPropertyName("resolvedBy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRisksResolvedBy> ResolvedBy { get; set; }

      [JsonPropertyName("references")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IRiskReference> References { get; set; }
   }
}