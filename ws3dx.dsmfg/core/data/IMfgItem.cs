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
using ws3dx.dsmfg.data.extension;
using ws3dx.dsmfg.data.impl;
using ws3dx.serialization.attribute;
using ws3dx.shared.data;
using ws3dx.shared.data.extension;
namespace ws3dx.dsmfg.data
{
    [ConcreteInterfaceImpConverter(typeof(MfgItem))]
    public interface IMfgItem
    {
        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Example: My title
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Title { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Example: My description
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Description { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Reference name Example: My name
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Name { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Example: CreateAssembly
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Type { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Indicates Yes(2) or No(1) value Example: 1
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Outsourced { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Indicates Yes(2) or No(1) value Example: 2
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string PlanningRequired { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// checks whether lot number is required Example: false
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? IsLotNumberRequired { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// checks whether serial number is required Example: true
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? IsSerialNumberRequired { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object estimatedTime value Example: 10
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? EstimatedTime { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object estimatedCost value Example: 10
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? EstimatedCost { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object estimatedCostCurrency value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string EstimatedCostCurrency { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object estimatedLeadTimeDescription value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string EstimatedLeadTimeDescription { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object estimatedWeight value Example: 10
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? EstimatedWeight { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object manufacturedItemClassification value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string ManufacturedItemClassification { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object materialCategory value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string MaterialCategory { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object spareManufacturedItem value Example: false
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public bool? SpareManufacturedItem { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object targetReleaseDate value Example: 2021/09/27@12:00:00:GMT
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string TargetReleaseDate { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object depthOfFeature value Example: 10
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? DepthOfFeature { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object diameterOfFeature value Example: 10
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public double? DiameterOfFeature { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object mfgFastenerStrategy value Example: Default
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string MfgFastenerStrategy { get; set; }

        ///----------------------------------------------------------------
        /// <summary>
        ///
        /// Object magnitude value, supported values Area,Length, Mass, Volume. Applicable only for continous
        /// Manufacturing Item Types. Example: MASS
        ///
        /// </summary>
        ///----------------------------------------------------------------
        public string Magnitude { get; set; }

        public IEnterpriseItemNumber EnterpriseReference { get; set; }

        public IMfgItemEnterpriseAttributes MfgEnterpriseAttributes { get; set; }

        public ICustomerAttributes CustomerAttributes { get; set; }

    }
}