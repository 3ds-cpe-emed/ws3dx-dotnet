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
using ws3dx.dsprcs.data;

namespace ws3dx.dsprcs.service
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

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the variant effectivities. If unsetVariant service is executed under Work Under 
        /// (Change Action) then it may lead to a new evolution of existing relationship.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProces/{PID}/dsprcs:MfgProcessInstance/{ID}/dscfg:Filterable/unset/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcesId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="instanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryVariantEffectivity> UnsetMfgProcessInstanceVariantEffectivity(string mfgProcesId, string instanceId, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProces/{mfgProcesId}/dsprcs:MfgProcessInstance/{instanceId}/dscfg:Filterable/unset/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity>(resourceURI, headerParams: headerParams);
        }

        ///---------------------------------------------------------------------------------------------
        /// <summary>
        /// Service to unset the variant effectivities. If unsetVariant service is executed under Work Under 
        /// (Change Action) then it may lead to a new evolution of existing relationship.
        /// </summary>
        ///---------------------------------------------------------------------------------------------
        /// <remarks>
        /// (POST) dsprcs:MfgProces/{PID}/dsprcs:MfgOperationInstance/{ID}/dscfg:Filterable/unset/variant
        /// </remarks>
        ///---------------------------------------------------------------------------------------------
        /// <param name="mfgProcesId">
        /// dsprcs:MfgProcess object ID
        /// </param>
        /// <param name="mfgOperationInstanceId">
        /// dsprcs:MfgProcessInstance object ID
        /// </param>
        /// <param name="changeAuthoringContext">
        /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
        /// </param>
        ///---------------------------------------------------------------------------------------------
        public async Task<IUnitaryVariantEffectivity> UnsetMfgOperationInstanceVariantEffectivity(string mfgProcesId, string mfgOperationInstanceId, string changeAuthoringContext = null)
        {
            string resourceURI = $"{GetBaseResource()}dsprcs:MfgProces/{mfgProcesId}/dsprcs:MfgOperationInstance/{mfgOperationInstanceId}/dscfg:Filterable/unset/variant";

            IDictionary<string, string> headerParams = new Dictionary<string, string>();
            if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

            return await PostIndividual<IUnitaryVariantEffectivity>(resourceURI, headerParams: headerParams);
        }
    }
}