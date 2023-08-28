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
   public class MfgProcessLocateUTCMask : IMfgProcessLocateUTCMask
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: source Example: https://server_name.dsone.3ds.com:443/3DSpace
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("source")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Source { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: type Example: DELLmiWorkPlanSystemReference
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Entity physical id of dsprcs:MfgProcess Example: MfgProcessRefID1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("identifier")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Identifier { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: relativePath Example: /resources/v1/modeler/dsprcs/dsprcs:MfgProcess/MfgProcessRefID1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("relativePath")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string RelativePath { get; set; }

      [JsonPropertyName("dsprcs:MfgProcessInstance")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IMfgProcessInstancesUTC> MfgProcessInstance { get; set; }

      [JsonPropertyName("dsrsc:ScopeLink")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IScopeLink> ScopeLink { get; set; }

      [JsonPropertyName("dsprcs:PrimaryCapableResource")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IPrimaryCapableResourceUTC> PrimaryCapableResource { get; set; }

      [JsonPropertyName("dsprcs:ItemSpecification")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IItemSpecificationsUTC> ItemSpecification { get; set; }
   }
}