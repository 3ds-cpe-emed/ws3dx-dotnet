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
using ws3dx.shared.data;

namespace ws3dx.dsprcs.core.data.impl
{
   public class PrimaryCapableResourceUTC : IPrimaryCapableResourceUTC
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Entity physical id Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic modified value in utc Example: 2022-01-31T09:48:10Z
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object created value in utc Example: 2022-01-31T09:48:10Z
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Resource quantity real value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("resourcesQuantity")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? ResourcesQuantity { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Boolean value whether is preferred Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isPreferred")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsPreferred { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Boolean value whether is manually scheduled Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manuallyScheduled")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? ManuallyScheduled { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Priority integer value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("priority")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? Priority { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Tool changeover time real value Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("toolChangeoverTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? ToolChangeoverTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Boolean value whether is reserved from first step Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isReservedFromFirstStep")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsReservedFromFirstStep { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Capable resource group index integer value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("capableRscGroupIndex")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? CapableRscGroupIndex { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Estimated time real value Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("estimatedTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EstimatedTime { get; set; }

      [JsonPropertyName("resource")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier Resource { get; set; }
   }
}