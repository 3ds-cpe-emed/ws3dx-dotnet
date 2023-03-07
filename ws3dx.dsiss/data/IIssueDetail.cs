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
using ws3dx.data;
using ws3dx.shared.data;
using ws3dx.shared.data.extension;

namespace ws3dx.dsiss.data
{
   public interface IIssueDetail
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: EE562168015FFCF14F940A513C63AA77
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: F718B05686760000926EEB5BE7400900
      //
      // </summary>
      //----------------------------------------------------------------
      public string Cestamp { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Issue
      //
      // </summary>
      //----------------------------------------------------------------
      public string Policy { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Issue
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Description of Issue
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: title of Issue
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: ISS-0000001
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: current state of the Issue Example: Create
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Identifier of the owner of the Issue
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: MyCompany
      //
      // </summary>
      //----------------------------------------------------------------
      public string Organization { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 3DS Collab Space
      //
      // </summary>
      //----------------------------------------------------------------
      public string CollabSpace { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Low
      //
      // </summary>
      //----------------------------------------------------------------
      public string Priority { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Fri Jul 21 02:00:00 CEST 2017
      //
      // </summary>
      //----------------------------------------------------------------
      public string EstimatedStartDate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 2017-07-21T17:32:28Z
      //
      // </summary>
      //----------------------------------------------------------------
      public string ActualStartDate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Sat Jul 22 02:00:00 CEST 2017
      //
      // </summary>
      //----------------------------------------------------------------
      public string EstimatedEndDate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 2017-07-22T17:32:28Z
      //
      // </summary>
      //----------------------------------------------------------------
      public string ActualEndDate { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public string WithApproval { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: No
      //
      // </summary>
      //----------------------------------------------------------------
      public string EscalationRequired { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Recommendation details for resolution
      //
      // </summary>
      //----------------------------------------------------------------
      public string ResolutionRecommendation { get; set; }

      public IExtendedAttributes IssueEnterpriseAttributes { get; set; }

      public IIssueMembers Members { get; set; }

      public IList<IAffectedItem> AffectedItems { get; set; }

      public IList<ITypedUriIdentifier> ResolvedBy { get; set; }

      public IList<IResolution> Resolution { get; set; }

      public IList<ITypedUriIdentifier> Contexts { get; set; }

      public ICustomerAttributes CustomerAttributes { get; set; }
   }
}