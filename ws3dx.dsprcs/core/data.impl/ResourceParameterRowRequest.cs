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
	public class ResourceParameterRowRequest :  IResourceParameterRowRequest
	{
		[JsonPropertyName("title")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Title { get; set; }

		[JsonPropertyName("description")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Description { get; set; }

		[JsonPropertyName("text")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Text { get; set; }

		[JsonPropertyName("possibleValues")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string PossibleValues { get; set; }

		[JsonPropertyName("displayUnit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string DisplayUnit { get; set; }

		[JsonPropertyName("maxValue")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth MaxValue { get; set; }

		[JsonPropertyName("minValue")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth MinValue { get; set; }

		[JsonPropertyName("nominalValue")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth NominalValue { get; set; }

		[JsonPropertyName("controlMinValue")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth ControlMinValue { get; set; }

		[JsonPropertyName("controlMaxValue")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IMagnitudeValueAuth ControlMaxValue { get; set; }

		[JsonPropertyName("controlMinLimit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ControlMinLimit { get; set; }

		[JsonPropertyName("controlMaxLimit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ControlMaxLimit { get; set; }

		[JsonPropertyName("minLimit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string MinLimit { get; set; }

		[JsonPropertyName("maxLimit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string MaxLimit { get; set; }

	}
}