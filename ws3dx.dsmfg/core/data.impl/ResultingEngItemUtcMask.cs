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
using ws3dx.shared.data;

namespace ws3dx.dsmfg.data.impl
{
    public class ResultingEngItemUtcMask : IResultingEngItemUtcMask
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        [JsonPropertyName("usage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Usage { get; set; }

        [JsonPropertyName("computed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Computed { get; set; }

        [JsonPropertyName("resultingEngItem")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ITypedUriIdentifier ResultingEngItem { get; set; }

        [JsonPropertyName("modified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Modified { get; set; }

        [JsonPropertyName("created")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Created { get; set; }

        [JsonPropertyName("Cestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cestamp { get; set; }

        [JsonPropertyName("owner")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Owner { get; set; }

        [JsonPropertyName("organization")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Organization { get; set; }

        [JsonPropertyName("collabspace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Collabspace { get; set; }

        [JsonPropertyName("ProductConfiguration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ITypedUriIdentifier ProductConfiguration { get; set; }

    }
}