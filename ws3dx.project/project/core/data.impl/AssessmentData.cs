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
   public class AssessmentData : IAssessmentData
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

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

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

      [JsonPropertyName("assessmentDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string AssessmentDate { get; set; }

      [JsonPropertyName("assessment")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Assessment { get; set; }

      [JsonPropertyName("scope")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Scope { get; set; }

      [JsonPropertyName("schedule")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Schedule { get; set; }

      [JsonPropertyName("cost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cost { get; set; }

      [JsonPropertyName("quality")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Quality { get; set; }

      [JsonPropertyName("resource")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Resource { get; set; }

      [JsonPropertyName("communication")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Communication { get; set; }

      [JsonPropertyName("risk")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Risk { get; set; }

      [JsonPropertyName("procurement")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Procurement { get; set; }

      [JsonPropertyName("stakeholders")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Stakeholders { get; set; }

      [JsonPropertyName("assessmentCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string AssessmentCmnts { get; set; }

      [JsonPropertyName("scopeCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScopeCmnts { get; set; }

      [JsonPropertyName("scheduleCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScheduleCmnts { get; set; }

      [JsonPropertyName("costCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CostCmnts { get; set; }

      [JsonPropertyName("qualityCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string QualityCmnts { get; set; }

      [JsonPropertyName("resourceCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ResourceCmnts { get; set; }

      [JsonPropertyName("communicationCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CommunicationCmnts { get; set; }

      [JsonPropertyName("riskCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RiskCmnts { get; set; }

      [JsonPropertyName("procurementCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ProcurementCmnts { get; set; }

      [JsonPropertyName("stakeholdersCmnts")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string StakeholdersCmnts { get; set; }

   }
}