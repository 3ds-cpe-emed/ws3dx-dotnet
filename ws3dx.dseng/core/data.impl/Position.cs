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

namespace ws3dx.dseng.data.impl
{
    public class Position : IPosition
    {
        [JsonPropertyName("a11")]
      public double A11 { get; set; }

        [JsonPropertyName("a12")]
      public double A12 { get; set; }

        [JsonPropertyName("a13")]
      public double A13 { get; set; }

        [JsonPropertyName("a21")]
      public double A21 { get; set; }

        [JsonPropertyName("a22")]
      public double A22 { get; set; }

        [JsonPropertyName("a23")]
      public double A23 { get; set; }

        [JsonPropertyName("a31")]
      public double A31 { get; set; }

        [JsonPropertyName("a32")]
      public double A32 { get; set; }

        [JsonPropertyName("a33")]
      public double A33 { get; set; }

        [JsonPropertyName("u1")]
      public double U1 { get; set; }

        [JsonPropertyName("u2")]
      public double U2 { get; set; }

        [JsonPropertyName("u3")]
      public double U3 { get; set; }
    }
}