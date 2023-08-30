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
using ws3dx.dsreq.data;
using ws3dx.dsreq.data.extension;

namespace ws3dx.dsreq.core.data.impl
{
   public class ModifyRequirement : IModifyRequirement
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: High/Medium/Low
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("priority")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Priority { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: High/Medium/Low
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("difficulty")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Difficulty { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Constraint/Functional/Non-Functional/None
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("requirementClassification")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RequirementClassification { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Content Data
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("contentData")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContentData { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Very High/High/Medium/Low/Least Important
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("userRequirementImportance")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string UserRequirementImportance { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Propagate Access
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("propagateAccess")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PropagateAccess { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Sponsoring Customer
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("sponsoringCustomer")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SponsoringCustomer { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Estimated Cost
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Requirement Category
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("requirementCategory")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RequirementCategory { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Content Type
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("contentType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ContentType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: id
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Name
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Originator
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("originator")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Originator { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: User_trigram
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: A
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("revision")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 01phdf093857590343
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("physicalId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string PhysicalId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: CA id
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("changeActionID")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ChangeActionID { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Notes
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("notes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Notes { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Designated User
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("designatedUser")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DesignatedUser { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: e service production
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("vault")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Vault { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: e service production
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: TRUE/FALSE
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("propagate_Access")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Propagate_Access { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Object Synopsis
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("synopsis")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Synopsis { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: TRUE/FALSE
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("accessType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string AccessType { get; set; }

      [JsonPropertyName("customerAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IRequirementCustomerAttributes CustomerAttributes { get; set; }
   }
}