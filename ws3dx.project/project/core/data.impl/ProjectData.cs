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
   public class ProjectData : IProjectData
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

      [JsonPropertyName("estimatedStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedStartDate { get; set; }

      [JsonPropertyName("estimatedFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedFinishDate { get; set; }

      [JsonPropertyName("dueDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DueDate { get; set; }

      [JsonPropertyName("actualStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualStartDate { get; set; }

      [JsonPropertyName("actualFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualFinishDate { get; set; }

      [JsonPropertyName("nlsType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string NlsType { get; set; }

      [JsonPropertyName("color")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Color { get; set; }

      [JsonPropertyName("pattern")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Pattern { get; set; }

      [JsonPropertyName("ganttConfig")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string GanttConfig { get; set; }

      [JsonPropertyName("kindofBaseline")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string KindofBaseline { get; set; }

      [JsonPropertyName("kindofExperiment")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string KindofExperiment { get; set; }

      [JsonPropertyName("kindofTemplate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string KindofTemplate { get; set; }

      [JsonPropertyName("kindofConcept")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string KindofConcept { get; set; }

      [JsonPropertyName("routeId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteId { get; set; }

      [JsonPropertyName("columns")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Columns { get; set; }

      [JsonPropertyName("percentComplete")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PercentComplete { get; set; }

      [JsonPropertyName("percentCompleteBasedOn")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PercentCompleteBasedOn { get; set; }

      [JsonPropertyName("lagCalendar")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string LagCalendar { get; set; }

      [JsonPropertyName("estimatedDurationInputValue")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDurationInputValue { get; set; }

      [JsonPropertyName("estimatedDurationInputUnit")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDurationInputUnit { get; set; }

      [JsonPropertyName("estimatedDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDuration { get; set; }

      [JsonPropertyName("actualDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualDuration { get; set; }

      [JsonPropertyName("forecastDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastDuration { get; set; }

      [JsonPropertyName("forecastStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastStartDate { get; set; }

      [JsonPropertyName("forecastFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastFinishDate { get; set; }

      [JsonPropertyName("constraintType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ConstraintType { get; set; }

      [JsonPropertyName("constraintDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ConstraintDate { get; set; }

      [JsonPropertyName("defaultConstraintType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DefaultConstraintType { get; set; }

      [JsonPropertyName("scheduleFrom")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScheduleFrom { get; set; }

      [JsonPropertyName("scheduleBasedOn")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScheduleBasedOn { get; set; }

      [JsonPropertyName("projectVisibility")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ProjectVisibility { get; set; }

      [JsonPropertyName("currency")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Currency { get; set; }

      [JsonPropertyName("notes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Notes { get; set; }

      [JsonPropertyName("status")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Status { get; set; }

      [JsonPropertyName("PALId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PALId { get; set; }

      [JsonPropertyName("objectId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ObjectId { get; set; }
   }
}