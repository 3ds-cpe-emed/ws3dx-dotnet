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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.dssrc.data;

namespace ws3dx.dssrc.core.service
{
   // SDK Service
   public class ManufacturerEquivalentItemService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dssrc/";

      public ManufacturerEquivalentItemService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dssrc:ManufacturerEquivalentItems/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Manufacturer Equivalent Item Summary: Gets a Manufacturer Equivalent Item
      // <param name="meiId">
      // Description: dssrc:ManufacturerEquivalentItems object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IManufacturerEquivalentItemMask>> Get(string meiId)
      {
         string resourceURI = $"{GetBaseResource()}/dssrc:ManufacturerEquivalentItems/{meiId}";


         return await GetMultiple<IManufacturerEquivalentItemMask>(resourceURI);
      }





      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dssrc:ManufacturerEquivalentItems
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Add Manufacturer Equivalent Item extension to Physical Product/s. Summary: Add new 
      // Manufacturer Equivalent Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IManufacturerEquivalentItemMask>> Create(INewManufacturerEquivalentItem[] request)
      {
         string resourceURI = $"{GetBaseResource()}/dssrc:ManufacturerEquivalentItems";


         return await PostRequestMultiple<IManufacturerEquivalentItemMask, INewManufacturerEquivalentItem[]>(resourceURI, request);

      }




      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dssrc:ManufacturerEquivalentItems/Locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Locate and Get Manufacturing Equivalent Item details with the specified engineering 
      // occurrences. Summary: Locate Manufacturer Equivalent Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IManufacturerEquivalentItemMask>> Locate(ILocateManufacturerEquivalentItems request)
      {
         string resourceURI = $"{GetBaseResource()}/dssrc:ManufacturerEquivalentItems/Locate";


         return await PostRequestMultiple<IManufacturerEquivalentItemMask, ILocateManufacturerEquivalentItems>(resourceURI, request);

      }




      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dssrc:ManufacturerEquivalentItems/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Manufacturer Equivalent Item attributes Summary: Modifies the Manufacturer 
      // Equivalent Item attributes
      // <param name="meiId">
      // Description: dssrc:ManufacturerEquivalentItems object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IManufacturerEquivalentItemMask>> Update(string meiId, IUpdateManufacturerEquivalentItem request)
      {
         string resourceURI = $"{GetBaseResource()}/dssrc:ManufacturerEquivalentItems/{meiId}";


         return await PatchGroup<IManufacturerEquivalentItemMask, IUpdateManufacturerEquivalentItem>(resourceURI, request);

      }



   }
}