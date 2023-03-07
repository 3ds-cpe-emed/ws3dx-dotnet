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
   public interface IAssessmentData
   {
      public string Title { get; set; }

      public string Name { get; set; }

      public string Revision { get; set; }

      public string Policy { get; set; }

      public string State { get; set; }

      public string Originated { get; set; }

      public string Originator { get; set; }

      public string Modified { get; set; }

      public string Owner { get; set; }

      public string AssessmentDate { get; set; }

      public string Assessment { get; set; }

      public string Scope { get; set; }

      public string Schedule { get; set; }

      public string Cost { get; set; }

      public string Quality { get; set; }

      public string Resource { get; set; }

      public string Communication { get; set; }

      public string Risk { get; set; }

      public string Procurement { get; set; }

      public string Stakeholders { get; set; }

      public string AssessmentCmnts { get; set; }

      public string ScopeCmnts { get; set; }

      public string ScheduleCmnts { get; set; }

      public string CostCmnts { get; set; }

      public string QualityCmnts { get; set; }

      public string ResourceCmnts { get; set; }

      public string CommunicationCmnts { get; set; }

      public string RiskCmnts { get; set; }

      public string ProcurementCmnts { get; set; }

      public string StakeholdersCmnts { get; set; }
   }
}