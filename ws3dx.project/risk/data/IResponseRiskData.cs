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

namespace ws3dx.project.risk.data
{
   public interface IResponseRiskData
   {
      public string Id { get; set; }

      public string Type { get; set; }

      public string Identifier { get; set; }

      public string Source { get; set; }

      public string RelativePath { get; set; }

      public string Cestamp { get; set; }

      public string Title { get; set; }

      public string Name { get; set; }

      public string Revision { get; set; }

      public string Description { get; set; }

      public string Originated { get; set; }

      public string Originator { get; set; }

      public string Modified { get; set; }

      public string Owner { get; set; }

      public string Policy { get; set; }

      public string State { get; set; }

      public string EstimatedStartDate { get; set; }

      public string EstimatedFinishDate { get; set; }

      public string ActualStartDate { get; set; }

      public string ActualFinishDate { get; set; }

      public string ClassType { get; set; }

      public string MitigationType { get; set; }

      public string Impact { get; set; }

      public string Probability { get; set; }

      public string RpnValue { get; set; }

      public string EffectiveDate { get; set; }

      public string Abatement { get; set; }

      public string MeasureOfSuccess { get; set; }

      public string ContextId { get; set; }

      public IList<IRisksOwnerInfo> OwnerInfo { get; set; }

      public IList<IRiskClass> Classes { get; set; }

      public IList<IRisksRpn> Rpn { get; set; }

      public IList<IRisksContext> Context { get; set; }

      public IList<IRiskAssignee> Assignees { get; set; }

      public IList<IRiskAffectedItem> AffectedItems { get; set; }

      public IList<IRisksResolvedBy> ResolvedBy { get; set; }

      public IList<IRiskReference> References { get; set; }
   }
}