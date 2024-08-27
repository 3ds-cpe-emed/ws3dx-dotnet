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
   public class ItemSpecification : IItemSpecification
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: ID of the connection object Example: EE562168015FFCF14F940A513C63AA77
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: DB Type Example: MfgProductionPlanning
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Indication of whether this is item act as scope or not. If false, then means this is 
      // implement link. Example: true
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("isScope")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsScope { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Occurrence path for the related process operation instance. Example: 
      // ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("operationOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> OperationOccurrence { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Occurrence path for the related manufacturing item instance that the operation is 
      // acting upon. Example: ["9FF50FB000005EAC607D42FF0001E9F2","EE562168015FFCF14F940A513C63AA77"]
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("itemOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<string> ItemOccurrence { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Reference to the scope manufacturing item. Example: 9FF50FB000005EAC607D42FF0001E9F2
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("itemRef")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ItemReference { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The manufacturing item instance that act as the context for the scope item. Example: 
      // 9FF50FB000005EAC607D42FF0001E9F2
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("scopeContext")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ScopeContext { get; set; }
   }
}