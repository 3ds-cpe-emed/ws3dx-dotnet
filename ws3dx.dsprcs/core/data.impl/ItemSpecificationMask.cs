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
using ws3dx.dsmfg.data;
using ws3dx.dsprcs.data;
using ws3dx.shared.data;

namespace ws3dx.dsprcs.core.data.impl
{
   public class ItemSpecificationMask : IItemSpecificationMask
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
      // Description: Occurrence path for the related process operation instance.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("operationOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<ISpecifiedOccurrence> OperationOccurrence { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Occurrence path for the related manufacturing item instance that the operation is 
      // acting upon.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("itemOcc")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<ISpecifiedOccurrence> ItemOccurrence { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Reference to the scope manufacturing item.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("itemRef")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier ItemReference { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The manufacturing item instance that act as the context for the scope item.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("scopeContext")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public ITypedUriIdentifier ScopeContext { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object usage value Example: Add
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("usage")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Usage { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object overlap value Example: false
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("overlap")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? Overlap { get; set; }

      [JsonPropertyName("sendAheadQuantity")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public dsprcs.data.IMagnitudeValue SendAheadQuantity { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Object cestamp value Example: 2D70169432D84866A200F907881AC9B1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cestamp")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }
   }
}