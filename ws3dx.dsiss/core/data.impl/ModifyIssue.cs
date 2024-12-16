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
using System.Text.Json.Serialization;
using ws3dx.data;

namespace ws3dx.dsiss.data.impl
{
    public class ModifyIssue : IModifyIssue
    {
        [JsonPropertyName("cestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cestamp { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        [JsonPropertyName("Priority")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Priority { get; set; }

        [JsonPropertyName("Estimated Start Date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EstimatedStartDate { get; set; }

        [JsonPropertyName("Actual Start Date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ActualStartDate { get; set; }

        [JsonPropertyName("Estimated End Date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EstimatedEndDate { get; set; }

        [JsonPropertyName("Actual End Date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ActualEndDate { get; set; }

        [JsonPropertyName("Escalation Required")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string EscalationRequired { get; set; }

        [JsonPropertyName("Resolution Recommendation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ResolutionRecommendation { get; set; }

        [JsonPropertyName("dslc:IssueEnterpriseAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IExtendedAttributes IssueEnterpriseAttributes { get; set; }

        [JsonPropertyName("remove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IModifyIssueRemove> Remove { get; set; }

        [JsonPropertyName("add")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IModifyIssueAdd> Add { get; set; }

        [JsonPropertyName("replace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IModifyIssueReplace> Replace { get; set; }
    }
}