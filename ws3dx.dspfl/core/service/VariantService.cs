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
using ws3dx.data.collection.impl;
using ws3dx.dspfl.data;

namespace ws3dx.dspfl.core.service
{
   // SDK Service
   public class VariantService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dspfl/";

      public VariantService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:Variant/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Variant. Summary: Get a Variant
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IVariantMask> GetVariant(string variantId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}";

         return await GetIndividual<IVariantMask, NlsLabeledItemSet<IVariantMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:Variant/{ID}/dspfl:VariantValue
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Variant Values of given Variant. Summary: Get all Variant Values
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IValueMask>> GetValues(string variantId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}/dspfl:VariantValue";

         return await GetGroup<IValueMask, NlsLabeledItemSet<IValueMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:Variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Variants. Summary: Get all Variants
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IVariantMask>> GetAllVariants()
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant";

         return await GetGroup<IVariantMask, NlsLabeledItemSet<IVariantMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:Variant/{PID}/dspfl:VariantValue/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Variant Value Summary: Get a Variant Value
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:VariantValue object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IValueMask>> GetValue(string variantId, string ID)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}/dspfl:VariantValue/{ID}";

         return await GetGroup<IValueMask, NlsLabeledItemSet<IValueMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:Variant/{ID}/dspfl:VariantValue
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Variant Values. Summary: Create Variant Values
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IValueMask>> CreateValue(string variantId, ICreateVariantValue request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}/dspfl:VariantValue";

         return await PostGroup<IValueMask, NlsLabeledItemSet<IValueMask>, ICreateVariantValue>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:Variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Variants. Summary: Create Variants
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IVariantMask>> Create(ICreateVariant request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant";

         return await PostGroup<IVariantMask, IEnumerable<IVariantMask>, ICreateVariant>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:Variant/{PID}/dspfl:VariantValue/{ID}/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Variant Value sequenceNumber Summary: Modify Variant Value sequenceNumber
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:VariantValue object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IValueMask>> UpdateValue(string variantId, string ID, IOrdered request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}/dspfl:VariantValue/{ID}/modify";

         return await PostGroup<IValueMask, NlsLabeledItemSet<IValueMask>, IOrdered>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:Variant/{PID}/dspfl:VariantValue/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Variant Value attributes. Summary: Modify Variant Value attributes.
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:VariantValue object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IValueMask> UpdateValue(string variantId, string ID, IUpdateVariantValue request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}/dspfl:VariantValue/{ID}";

         return await PatchIndividual<IValueMask, NlsLabeledItemSet<IValueMask>, IUpdateVariantValue>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:Variant/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Variant attributes Summary: Modify Variant attributes
      // <param name="variantId">
      // Description: dspfl:Variant object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IVariantMask> UpdateVariant(string variantId, IUpdateVariant request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:Variant/{variantId}";

         return await PatchIndividual<IVariantMask, NlsLabeledItemSet<IVariantMask>, IUpdateVariant>(resourceURI, request);
      }
   }
}