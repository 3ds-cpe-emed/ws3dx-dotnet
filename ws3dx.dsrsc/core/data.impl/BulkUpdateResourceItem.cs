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
using ws3dx.data;
using ws3dx.dsrsc.data;

namespace ws3dx.dsrsc.core.data.impl
{
   public class BulkUpdateResourceItem : IBulkUpdateResourceItem
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My title
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("title")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My description
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("description")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Reference name Example: My name
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("name")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Calculated cycle time of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("calculatedCycleTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? CalculatedCycleTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Category of the resource Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("category")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Category { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Manufacturer of the resource Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("manufacturer")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Manufacturer { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Sub type of the resource Example: String
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("subType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string SubType { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Consumable cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("consumableCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? ConsumableCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Cycle time of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("cycleTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? CycleTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Energy cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("energyCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? EnergyCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean time before failure of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("meanTimeBeforeFailure")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? MeanTimeBeforeFailure { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Mean time to repair of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("meanTimeToRepair")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? MeanTimeToRepair { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Maintenance cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("maintenanceCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? MaintenanceCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Purchase cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("purchaseCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? PurchaseCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Repair cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("repairCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? RepairCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Set up time of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("setUpTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? SetUpTime { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Set up time reduced of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("setUpTimeReduced")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? SetUpTimeReduced { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: target cost of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("targetCost")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? TargetCost { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Targeted cycle time of the resource Example: 0
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("targetedCycleTime")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public double? TargetedCycleTime { get; set; }

      [JsonPropertyName("dseno:EnterpriseAttributes")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IExtendedAttributes EnterpriseAttributes { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: My Id translated value
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Example: VPMReference
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("type")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: value the interface extension Example: Worker
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("resourceType")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string ResourceType { get; set; }
   }
}