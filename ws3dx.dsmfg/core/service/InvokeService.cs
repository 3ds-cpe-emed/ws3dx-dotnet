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
using ws3dx.dsmfg.data;
using ws3dx.shared.data;

namespace ws3dx.dsmfg.core.service
{
   // SDK Service
   public class InvokeService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsmfg/";

      public InvokeService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:getRealizedChanges
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Retrieve Manufacturing Item realized changes with its realized activity in the change. 
      // Summary: Retrieve Manufacturing Item realized changes with its realized activity in the change.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IRealizedChangeDetailMask>> GetRealizedChanges(IRealizedChangeRequest request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:getRealizedChanges";

         return await PostCollectionFromResponseMemberProperty<IRealizedChangeDetailMask, IRealizedChangeRequest>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:detachMfgItemInstances
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach Manufacturing item instances from an Manufacturing Item version. 
      //  And number of dsmfg:MfgItemInstances to be deleted/detached is limited to 10. per request Summary: 
      // Detach Manufacturing item instances from an Manufacturing Item version.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachInstances(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:detachMfgItemInstances";

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:getMfgItemInstanceFromImplementedEngOccurrence
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get all the Manufacturing Item Instances from the given specified Engineering Item 
      // occurrence having implement links Summary: Get all the Manufacturing Item Instances from the 
      // given specified Engineering Item occurrence having implement links
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMfgItemInstanceNavigateUTCMask>> GetInstanceFromImplementedEngOccurrence(IItemOccurrence[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:getMfgItemInstanceFromImplementedEngOccurrence";

         return await PostCollectionFromResponseMemberProperty<IMfgItemInstanceNavigateUTCMask, IItemOccurrence[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:getMfgItemsFromEngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get scoped and resulting manufacturing item references from Engineering Item Summary: 
      // Get scoped, partial scoped and resulting manufacturing item references from Engineering Item
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMfgItemNavigateUTCMask>> GetMfgItemsFromEngItem(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:getMfgItemsFromEngItem";

         return await PostCollectionFromResponseMemberProperty<IMfgItemNavigateUTCMask, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:reconnect
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Bulk reconnect of scope and resulting products for the corresponding specified Mfg 
      // Item. 
      //  Number of objects to be reconnected is limited to 10 per request.
      //  Reconnect Scope is supported only for 'Provide' Mfg Item types. Summary: Bulk reconnect of scope 
      // and resulting products for the corresponding specified Mfg Item.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Reconnect(IMfgItemReconnectRequestPayload request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:reconnect";

         return await PostIndividual<IGenericResponse, IMfgItemReconnectRequestPayload>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsmfg:reconnect
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Bulk reconnect of scope and resulting products for the corresponding specified Mfg 
      // Item. 
      //  Number of objects to be reconnected is limited to 10 per request.
      //  Reconnect Scope is supported only for 'Provide' Mfg Item types. Summary: Bulk reconnect of scope 
      // and resulting products for the corresponding specified Mfg Item.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Reconnect(IMfgItemReconnectRequestPayloadResultingEngItem request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsmfg:reconnect";

         return await PostIndividual<IGenericResponse, IMfgItemReconnectRequestPayloadResultingEngItem>(resourceURI, request);
      }
   }
}