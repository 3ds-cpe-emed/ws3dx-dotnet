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
using ws3dx.dsprcs.data;

namespace ws3dx.dsprcs.core.data.impl
{
   public class TimeConstraint : ITimeConstraint
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
      // Description: DB type of the object Example: dsprcs:TimeConstraint
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Basic modified value Example: Dec 15, 2017 11:17 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("modified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object created value Example: Dec 11, 2017 12:53 PM
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("created")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indicates FinishToStart(1), StartToStart(2) or FinishToFinish(3) value. Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("dependencyType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DependencyType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Boolean value whether time constraint is product flow Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isProductFlow")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsProductFlow { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Delay mode enum value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("delayMode")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string DelayMode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Boolean value whether time constraint is optional Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isOptional")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsOptional { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Resource constraint enum value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("resourceConstraint")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ResourceConstraint { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Delay real value Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("delay")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? Delay { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Return code value Example: RCFail203
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("returnCode")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ReturnCode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Maximum retries value Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("maximumRetries")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int? MaximumRetries { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Occurrence of constraining operation instance details Example: 
      // ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("fromOperationOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> FromOperationOccurrence { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Occurrence of constrained operation instance details Example: 
      // ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("toOperationOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> ToOperationOccurrence { get; set; }
   }
}