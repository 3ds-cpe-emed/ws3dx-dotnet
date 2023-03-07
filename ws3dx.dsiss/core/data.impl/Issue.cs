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
using ws3dx.data;
using ws3dx.dsiss.data;

namespace ws3dx.dsiss.core.data.impl
{
   public class Issue : IIssue
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: F718B05686760000926EEB5BE7400900
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Issue
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("policy")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Policy { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Issue
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Description of Issue
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: title of Issue
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: ISS-0000001
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: current state of the Issue Example: Create
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("state")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Identifier of the owner of the Issue
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("owner")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: MyCompany
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("organization")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 3DS Collab Space
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("collabSpace")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CollabSpace { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Low
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Priority")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Priority { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Fri Jul 21 02:00:00 CEST 2017
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Estimated Start Date")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedStartDate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 2017-07-21T17:32:28Z
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Actual Start Date")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualStartDate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Sat Jul 22 02:00:00 CEST 2017
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Estimated End Date")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EstimatedEndDate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: 2017-07-22T17:32:28Z
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Actual End Date")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ActualEndDate { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("withApproval")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string WithApproval { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: No
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Escalation Required")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string EscalationRequired { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: Recommendation details for resolution
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("Resolution Recommendation")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ResolutionRecommendation { get; set; }

      [JsonPropertyName("dslc:IssueEnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IExtendedAttributes IssueEnterpriseAttributes { get; set; }
   }
}