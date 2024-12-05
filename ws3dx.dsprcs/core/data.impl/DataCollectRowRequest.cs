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
	public class DataCollectRowRequest :  IDataCollectRowRequest
	{
		[JsonPropertyName("title")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Title { get; set; }

		[JsonPropertyName("description")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Description { get; set; }

		[JsonPropertyName("name")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Name { get; set; }

		[JsonPropertyName("text")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Text { get; set; }

		[JsonPropertyName("label")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Label { get; set; }

		[JsonPropertyName("mode")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Mode { get; set; }

		[JsonPropertyName("numberOfMeasurements")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public int? NumberOfMeasurements { get; set; }

		[JsonPropertyName("possibleValues")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string PossibleValues { get; set; }

		[JsonPropertyName("magnitude")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Magnitude { get; set; }

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

		[JsonPropertyName("minIncluded")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? MinIncluded { get; set; }

		[JsonPropertyName("maxIncluded")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? MaxIncluded { get; set; }

		[JsonPropertyName("controlMinIncluded")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? ControlMinIncluded { get; set; }

		[JsonPropertyName("controlMaxIncluded")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? ControlMaxIncluded { get; set; }

	}
}