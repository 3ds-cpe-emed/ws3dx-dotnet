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
using ws3dx.dsreq.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace ws3dx.dsreq.core.service
{
   // SDK Service
   public class RequirementSpecificationService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsreq/";

      public RequirementSpecificationService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }
      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsreq:RequirementSpecification/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(INewRequirementSpecificationMask) };
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
         return "$searchStr";
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery)
      {
         return await SearchCollection<T>("member", searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await SearchCollection<T>("member", searchQuery, _skip, _top);
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsreq:RequirementSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Requirement Specification with an attributes list. Summary: Gets a Requirement 
      // Specification
      // <param name="reqSpecId">
      // Description: dsreq:RequirementSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<INewRequirementSpecificationMask> Get(string reqSpecId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification/{reqSpecId}";

         return await GetIndividualFromResponseMemberProperty<INewRequirementSpecificationMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsreq:RequirementSpecification/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an dsreq:RequirementSpecification Summary: Gets a Change 
      // Control of an dsreq:RequirementSpecification
      // <param name="ID">
      // Description: dsreq:RequirementSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string reqSpecId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification/{reqSpecId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:RequirementSpecification/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate Change Control. Once object is change controlled, a change is required to 
      // perform any modification on the object. Summary: Activate Change Control
      // <param name="ID">
      // Description: dsreq:RequirementSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string reqSpecId, IEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification/{reqSpecId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:RequirementSpecification
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Requirement Specifications using payload items. A maximum of 10 items is 
      // allowed. Summary: Create Requirement Specifications
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<INewRequirementSpecificationMask>> Create(ICreateRequirementSpecification request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification";

         return await PostCollectionFromResponseMemberProperty<INewRequirementSpecificationMask, ICreateRequirementSpecification>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsreq:RequirementSpecification/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Requirement Specification with an attributes list. attributes Summary: 
      // Modifies the Requirement Specification attributes
      // <param name="reqSpecId">
      // Description: dsreq:RequirementSpecification object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<INewRequirementSpecificationMask> Update(string reqSpecId, IModifyRequirementSpecification request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification/{reqSpecId}";

         return await PatchIndividualFromResponseMemberProperty<INewRequirementSpecificationMask, IModifyRequirementSpecification>(resourceURI, request);
      }
   }
}