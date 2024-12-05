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
using ws3dx.dsprcs.data;
using ws3dx.serialization.attribute;

namespace ws3dx.dsprcs.data.impl
{
	public class TimeConstraintAttributes :  ITimeConstraintAttributes
	{
		[JsonPropertyName("resourcesQuantity")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public double? ResourcesQuantity { get; set; }

		[JsonPropertyName("dependencyType")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string DependencyType { get; set; }

		[JsonPropertyName("isProductFlow")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? IsProductFlow { get; set; }

		[JsonPropertyName("delayMode")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string DelayMode { get; set; }

		[JsonPropertyName("isOptional")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? IsOptional { get; set; }

		[JsonPropertyName("resourceConstraint")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ResourceConstraint { get; set; }

		[JsonPropertyName("delay")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public double? Delay { get; set; }

		[JsonPropertyName("flowType")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string FlowType { get; set; }

		[JsonPropertyName("returnCode")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ReturnCode { get; set; }

		[JsonPropertyName("maximumRetries")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public int? MaximumRetries { get; set; }

		[JsonPropertyName("transferQuantity")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public double? TransferQuantity { get; set; }

		[JsonPropertyName("priority")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public int? Priority { get; set; }

		[JsonPropertyName("overlapQuantityMode")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string OverlapQuantityMode { get; set; }

		[JsonPropertyName("overlapQuantity")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth OverlapQuantity { get; set; }

	}
}