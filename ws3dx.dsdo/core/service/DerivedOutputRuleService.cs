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
using ws3dx.dsdo.data;

namespace ws3dx.dsdo.core.service
{
   // SDK Service
   public class DerivedOutputRuleService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsdo/";

      public DerivedOutputRuleService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsdo:DerivedOutputRules
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get all Derived Output rules based on category and rule type Summary: Get all Derived 
      // Output rules based on category and rule type
      // <param name="category">
      // Description: Defining from which category, we have to fetch the rules. For example, SOLIDWORKS, 
      // CATIA, etc.
      // </param>
      // <param name="ruleType">
      // Description: All the rules specifying this rule type will be fetched
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IDerivedOutputRuleDetailMask>> GetAll(string category, string ruleType)
      {
         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputRules";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("category", category);
         queryParams.Add("ruleType", ruleType);

         return await GetCollectionFromResponseMemberProperty<IDerivedOutputRuleDetailMask>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsdo:DerivedOutputRules/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets details of Derived Output Rule based on specified rule ID Summary: Gets details 
      // of Derived Output Rule based on specified rule ID
      // <param name="ID">
      // Description: Applicable rule ID for which user wants to get details. This rule should be present 
      // in the DB.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IDerivedOutputRuleDetailMask> Get(string ID)
      {
         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputRules/{ID}";

         return await GetIndividualFromResponseMemberProperty<IDerivedOutputRuleDetailMask>(resourceURI);
      }
   }
}