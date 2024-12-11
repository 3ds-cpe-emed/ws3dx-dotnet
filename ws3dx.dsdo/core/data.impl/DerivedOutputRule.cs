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

namespace ws3dx.dsdo.data.impl
{
    public class DerivedOutputRule : IDerivedOutputRule
    {
        [JsonPropertyName("converter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Converter { get; set; }

        [JsonPropertyName("targetToDisplay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TargetToDisplay { get; set; }

        [JsonPropertyName("inputStreamId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InputStreamId { get; set; }

        [JsonPropertyName("source")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Source { get; set; }

        [JsonPropertyName("target")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Target { get; set; }

        [JsonPropertyName("sourceToDisplay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SourceToDisplay { get; set; }

        [JsonPropertyName("sourceType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SourceType { get; set; }

        [JsonPropertyName("ruleType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RuleType { get; set; }

        [JsonPropertyName("outputStreamId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OutputStreamId { get; set; }

        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string State { get; set; }

        [JsonPropertyName("ruleId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RuleId { get; set; }

        [JsonPropertyName("category")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Category { get; set; }

        [JsonPropertyName("activation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Activation { get; set; }
    }
}