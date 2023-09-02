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

namespace ws3dx.dsrsc.data
{
   public interface IUpdateOrganizationalResource
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My title
      //
      // </summary>
      //----------------------------------------------------------------
      public string Title { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: My description
      //
      // </summary>
      //----------------------------------------------------------------
      public string Description { get; set; }

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
      // Description: Calculated cycle time of the resource Example: 0
      //
      // </summary>
      //----------------------------------------------------------------
      public double? CalculatedCycleTime { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Category of the resource Example: String
      //
      // </summary>
      //----------------------------------------------------------------
      public string Category { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Manufacturer of the resource Example: String
      //
      // </summary>
      //----------------------------------------------------------------
      public string Manufacturer { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Description: Sub type of the resource Example: String
      //
      // </summary>
      //----------------------------------------------------------------
      public string SubType { get; set; }

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