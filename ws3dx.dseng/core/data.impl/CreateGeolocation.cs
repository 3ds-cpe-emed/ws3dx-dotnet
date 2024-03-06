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
using ws3dx.dseng.data;

namespace ws3dx.dseng.core.data.impl
{
   public class CreateGeolocation : ICreateGeolocation
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Coordinates reference system ID Example: epsg::2000
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("crsId")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string CrsId { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Coordinate of first axis (in metre) Example: 12345.56
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("axis1")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Axis1 { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Coordinate of second axis (in metre) Example: 56789.2
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("axis2")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Axis2 { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Coordinate of third axis (in metre) Example: 125.0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("axis3")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Axis3 { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Azimuth (in radian) Example: 12.45
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("azimuth")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Azimuth { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Define if geolocation on item is active or not Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("active")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? Active { get; set; }
   }
}