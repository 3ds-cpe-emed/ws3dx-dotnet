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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.dsprcs.data;

namespace ws3dx.dsprcs.core.service
{
   // SDK Service
   public class MfgProcesService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsprcs/";

      public MfgProcesService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProces/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/unset/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the variant effectivities. If unsetVariant service is executed under 
      // Work Under (Change Action) then it may lead to a new evolution of existing relationship. Summary: 
      // Service to unset the variant effectivities
      // <param name="mfgProcesId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="instanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> UnsetInstanceVariantEffectivity(string mfgProcesId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProces/{mfgProcesId}/dsprcs:MfgProcessInstance/{instanceId}/dscfg:Filterable/unset/variant";

         return await PostRequest<IUnitaryVariantEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsprcs:MfgProces/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the variant effectivities. If unsetVariant service is executed under 
      // Work Under (Change Action) then it may lead to a new evolution of existing relationship. Summary: 
      // Service to unset the variant effectivities
      // <param name="mfgProcesId">
      // Description: dsprcs:MfgProcess object ID
      // </param>
      // <param name="mfgOperationInstanceId">
      // Description: dsprcs:MfgProcessInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IUnitaryVariantEffectivity> UnsetMfgOperationInstanceVariantEffectivity(string mfgProcesId, string mfgOperationInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dsprcs:MfgProces/{mfgProcesId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/variant";

         return await PostRequest<IUnitaryVariantEffectivity>(resourceURI);
      }


   }
}