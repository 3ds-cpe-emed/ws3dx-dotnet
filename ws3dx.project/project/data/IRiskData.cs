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
   public interface IRiskData
   {
      public string Title { get; set; }

      public string Name { get; set; }

      public string Revision { get; set; }

      public string Description { get; set; }

      public string State { get; set; }

      public string Originated { get; set; }

      public string Modified { get; set; }

      public string Originator { get; set; }

      public string Owner { get; set; }

      public string EstimatedStartDate { get; set; }

      public string EstimatedFinishDate { get; set; }

      public string ActualStartDate { get; set; }

      public string ActualFinishDate { get; set; }

      public string RiskType { get; set; }

      public string RiskVisibility { get; set; }

      public string RiskImpact { get; set; }

      public string RiskProbability { get; set; }

      public string RiskFactor { get; set; }

      public string RiskResolution { get; set; }

      public string RiskAbatement { get; set; }

      public string MeasureOfSuccess { get; set; }

      public string RiskCategory { get; set; }

      public string ModifyAccess { get; set; }

      public string DeleteAccess { get; set; }

      public string PromoteAccess { get; set; }

      public string DemoteAccess { get; set; }

      public string FromConnectAccess { get; set; }

      public string ToConnectAccess { get; set; }
   }
}