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
   public class TaskData : ITaskData
   {
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName("originated")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originated { get; set; }

      [JsonPropertyName("modifyAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ModifyAccess { get; set; }

      [JsonPropertyName("deleteAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DeleteAccess { get; set; }

      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      [JsonPropertyName("project")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Project { get; set; }

      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName("hasProject")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string HasProject { get; set; }

      [JsonPropertyName("taskRequirement")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TaskRequirement { get; set; }

      [JsonPropertyName("notes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Notes { get; set; }

      [JsonPropertyName("needsReview")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string NeedsReview { get; set; }

      [JsonPropertyName("percentComplete")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PercentComplete { get; set; }

      [JsonPropertyName("estimatedStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedStartDate { get; set; }

      [JsonPropertyName("dueDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DueDate { get; set; }

      [JsonPropertyName("estimatedDurationInputValue")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDurationInputValue { get; set; }

      [JsonPropertyName("estimatedDurationInputUnit")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDurationInputUnit { get; set; }

      [JsonPropertyName("estimatedDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedDuration { get; set; }

      [JsonPropertyName("actualStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualStartDate { get; set; }

      [JsonPropertyName("actualFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualFinishDate { get; set; }

      [JsonPropertyName("actualDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualDuration { get; set; }

      [JsonPropertyName("forecastStartDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastStartDate { get; set; }

      [JsonPropertyName("forecastFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastFinishDate { get; set; }

      [JsonPropertyName("forecastDuration")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ForecastDuration { get; set; }

      [JsonPropertyName("constraintType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ConstraintType { get; set; }

      [JsonPropertyName("constraintDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ConstraintDate { get; set; }

      [JsonPropertyName("scheduleFrom")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScheduleFrom { get; set; }

      [JsonPropertyName("scheduleBasedOn")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScheduleBasedOn { get; set; }

      [JsonPropertyName("projectVisibility")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ProjectVisibility { get; set; }

      [JsonPropertyName("routeTaskInstructions")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskInstructions { get; set; }

      [JsonPropertyName("routeTaskAction")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskAction { get; set; }

      [JsonPropertyName("routeTaskDueDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskDueDate { get; set; }

      [JsonPropertyName("routeTaskActualFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskActualFinishDate { get; set; }

      [JsonPropertyName("routeTaskDelegationAllowed")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskDelegationAllowed { get; set; }

      [JsonPropertyName("routeTaskAssigneeSetDueDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskAssigneeSetDueDate { get; set; }

      [JsonPropertyName("routeTaskApprovalAction")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskApprovalAction { get; set; }

      [JsonPropertyName("routeTaskApprovalComments")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskApprovalComments { get; set; }

      [JsonPropertyName("routeTaskReviewerComments")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RouteTaskReviewerComments { get; set; }

      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      [JsonPropertyName("PALId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PALId { get; set; }

      [JsonPropertyName("objectId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ObjectId { get; set; }

      [JsonPropertyName("freeFloat")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FreeFloat { get; set; }

      [JsonPropertyName("totalFloat")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TotalFloat { get; set; }

      [JsonPropertyName("isOverallCritical")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string IsOverallCritical { get; set; }

      [JsonPropertyName("nlsType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string NlsType { get; set; }

      [JsonPropertyName("pattern")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Pattern { get; set; }

      [JsonPropertyName("color")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Color { get; set; }

      [JsonPropertyName("isSummaryTask")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string IsSummaryTask { get; set; }

      [JsonPropertyName("effortId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EffortId { get; set; }

      [JsonPropertyName("sourceId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SourceId { get; set; }

      [JsonPropertyName("taskProjectId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TaskProjectId { get; set; }

      [JsonPropertyName("criticalTask")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CriticalTask { get; set; }

      [JsonPropertyName("status")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Status { get; set; }

      [JsonPropertyName("Deviation")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Deviation { get; set; }

      [JsonPropertyName("predictiveActualFinishDate")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PredictiveActualFinishDate { get; set; }
   }
}