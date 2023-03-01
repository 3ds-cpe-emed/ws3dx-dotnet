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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.project.risk.data;

namespace ws3dx.project.risk.core.service
{
   // SDK Service
   public class RiskService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler//";

      public RiskService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/risks/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { };
      }

      protected override string GetSearchSkipParamName()
      {
         return "$skip";
      }

      protected override string GetSearchTopParamName()
      {
         return "$top";
      }

      protected override string GetSearchCriteriaParamName()
      {
         return "searchStr";
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /risks
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get user Risks.
      // <param name="owned">
      // Description: Retrieve Risks owned by me (Default: true)
      // </param>
      // <param name="assigned">
      // Description: Retrieve Risks assigned to me (Default: true)
      // </param>
      // <param name="completed">
      // Description: Retrieve Risks that have been Completed within this range (none, all, number of days; 
      // Default: none)
      // </param>
      // <param name="state">
      // Description: Filter Risks by one or more comma separated states: Create, Assign, Active, Review, 
      // Complete (Default: all but Complete)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseRisk> GetRisks(string owned, string assigned, int completed, string state)
      {
         string resourceURI = $"{GetBaseResource()}/risks";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("owned", owned);
         queryParams.Add("assigned", assigned);
         queryParams.Add("completed", completed.ToString());
         queryParams.Add("state", state);

         return await GetUnique<IResponseRisk>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /risks/{riskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get Risk item details.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseRisk> GetRisk(string riskId)
      {
         string resourceURI = $"{GetBaseResource()}/risks/{riskId}";

         return await GetUnique<IResponseRisk>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /risks
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Create Risks.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseRisk> CreateRisk(IRisk risks)
      {
         string resourceURI = $"{GetBaseResource()}/risks";

         return await PostRequest<IResponseRisk, IRisk>(resourceURI, risks);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /risks/{riskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Modify a Risk item.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseRisk> UpdateRisk(string riskId, IRisk risks)
      {
         string resourceURI = $"{GetBaseResource()}/risks/{riskId}";

         return await PutIndividual<IResponseRisk, IRisk>(resourceURI, risks);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /risks/{riskId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete a Risk item.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseRisk> DeleteRisk(string riskId)
      {
         string resourceURI = $"{GetBaseResource()}/risks/{riskId}";

         return await DeleteIndividual<IResponseRisk>(resourceURI);
      }
   }
}