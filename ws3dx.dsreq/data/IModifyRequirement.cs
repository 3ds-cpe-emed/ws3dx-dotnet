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
using ws3dx.dsreq.data.extension;

namespace ws3dx.dsreq.data
{
   public interface IModifyRequirement
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: High/Medium/Low
      //
      // </summary>
      //----------------------------------------------------------------
      public string Priority { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: High/Medium/Low
      //
      // </summary>
      //----------------------------------------------------------------
      public string Difficulty { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Constraint/Functional/Non-Functional/None
      //
      // </summary>
      //----------------------------------------------------------------
      public string RequirementClassification { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Content Data
      //
      // </summary>
      //----------------------------------------------------------------
      public string ContentData { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Very High/High/Medium/Low/Least Important
      //
      // </summary>
      //----------------------------------------------------------------
      public string UserRequirementImportance { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Propagate Access
      //
      // </summary>
      //----------------------------------------------------------------
      public string PropagateAccess { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Sponsoring Customer
      //
      // </summary>
      //----------------------------------------------------------------
      public string SponsoringCustomer { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Estimated Cost
      //
      // </summary>
      //----------------------------------------------------------------
      public string EstimatedCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Requirement Category
      //
      // </summary>
      //----------------------------------------------------------------
      public string RequirementCategory { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Content Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string ContentType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: id
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Name
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Originator
      //
      // </summary>
      //----------------------------------------------------------------
      public string Originator { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: User_trigram
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: A
      //
      // </summary>
      //----------------------------------------------------------------
      public string Revision { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 01phdf093857590343
      //
      // </summary>
      //----------------------------------------------------------------
      public string PhysicalId { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: CA id
      //
      // </summary>
      //----------------------------------------------------------------
      public string ChangeActionID { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Notes
      //
      // </summary>
      //----------------------------------------------------------------
      public string Notes { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Designated User
      //
      // </summary>
      //----------------------------------------------------------------
      public string DesignatedUser { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: e service production
      //
      // </summary>
      //----------------------------------------------------------------
      public string Vault { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: e service production
      //
      // </summary>
      //----------------------------------------------------------------
      public string Policy { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: TRUE/FALSE
      //
      // </summary>
      //----------------------------------------------------------------
      public string Propagate_Access { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My Object Synopsis
      //
      // </summary>
      //----------------------------------------------------------------
      public string Synopsis { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: TRUE/FALSE
      //
      // </summary>
      //----------------------------------------------------------------
      public string AccessType { get; set; }

      public IRequirementCustomerAttributes CustomerAttributes { get; set; }
   }
}