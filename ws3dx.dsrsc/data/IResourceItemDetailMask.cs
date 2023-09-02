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
using ws3dx.data;
using ws3dx.serialization.attribute;

namespace ws3dx.dsrsc.data
{
   [MaskSchema("dsmvrsc:ResourceMask.Details")]
   public interface IResourceItemDetailMask
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference name Example: My name
      //
      // </summary>
      //----------------------------------------------------------------
      public string Name { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference object title value Example: My title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Reference description value Example: My description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Entity physical id Example: Object Physical ID
      //
      // </summary>
      //----------------------------------------------------------------
      public string Id { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic type value Example: My Type
      //
      // </summary>
      //----------------------------------------------------------------
      public string Type { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Basic modified value Example: 12/31/2018 11:17:00 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Modified { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object created value Example: 12/31/2017 12:53:00 PM
      //
      // </summary>
      //----------------------------------------------------------------
      public string Created { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object revision value Example: A.1
      //
      // </summary>
      //----------------------------------------------------------------
      public string Revision { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object current state value Example: IN_WORK
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object owner value Example: John Doe
      //
      // </summary>
      //----------------------------------------------------------------
      public string Owner { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object organization value Example: MyCompany
      //
      // </summary>
      //----------------------------------------------------------------
      public string Organization { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Object collabspace value Example: Default
      //
      // </summary>
      //----------------------------------------------------------------
      public string Collabspace { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Boolean of whether the resource is an asset or not Example: true
      //
      // </summary>
      //----------------------------------------------------------------
      public bool? IsAsset { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Type of the resource Example: NCMachine
      //
      // </summary>
      //----------------------------------------------------------------
      public string ResourceType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Category of the resource Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string Category { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Manufacturer of the resource Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string Manufacturer { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Sub type of the resource Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string SubType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Calculated cycle time of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? CalculatedCycleTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Consumable cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? ConsumableCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Cycle time of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? CycleTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Energy cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? EnergyCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Mean time before failure of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MeanTimeBeforeFailure { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Mean time to repair of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MeanTimeToRepair { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Maintenance cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? MaintenanceCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Purchase cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? PurchaseCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Repair cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? RepairCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Set up time of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? SetUpTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Set up time reduced of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? SetUpTimeReduced { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: target cost of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? TargetCost { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Targeted cycle time of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? TargetedCycleTime { get; set; }

      public IExtendedAttributes EnterpriseAttributes { get; set; }
   }
}