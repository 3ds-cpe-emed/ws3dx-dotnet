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

namespace ws3dx.project.project.data
{
   public interface IProjectData
   {
      public string Title { get; set; }

      public string Name { get; set; }

      public string Revision { get; set; }

      public string Description { get; set; }

      public string State { get; set; }

      public string Originated { get; set; }

      public string Modified { get; set; }

      public string Policy { get; set; }

      public string ModifyAccess { get; set; }

      public string DeleteAccess { get; set; }

      public string Project { get; set; }

      public string EstimatedStartDate { get; set; }

      public string EstimatedFinishDate { get; set; }

      public string DueDate { get; set; }

      public string ActualStartDate { get; set; }

      public string ActualFinishDate { get; set; }

      public string NlsType { get; set; }

      public string Color { get; set; }

      public string Pattern { get; set; }

      public string GanttConfig { get; set; }

      public string KindofBaseline { get; set; }

      public string KindofExperiment { get; set; }

      public string KindofTemplate { get; set; }

      public string KindofConcept { get; set; }

      public string RouteId { get; set; }

      public string Columns { get; set; }

      public string PercentComplete { get; set; }

      public string PercentCompleteBasedOn { get; set; }

      public string LagCalendar { get; set; }

      public string EstimatedDurationInputValue { get; set; }

      public string EstimatedDurationInputUnit { get; set; }

      public string EstimatedDuration { get; set; }

      public string ActualDuration { get; set; }

      public string ForecastDuration { get; set; }

      public string ForecastStartDate { get; set; }

      public string ForecastFinishDate { get; set; }

      public string ConstraintType { get; set; }

      public string ConstraintDate { get; set; }

      public string DefaultConstraintType { get; set; }

      public string ScheduleFrom { get; set; }

      public string ScheduleBasedOn { get; set; }

      public string ProjectVisibility { get; set; }

      public string Currency { get; set; }

      public string Notes { get; set; }

      public string Status { get; set; }

      public string PALId { get; set; }

      public string ObjectId { get; set; }
   }
}