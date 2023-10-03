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
   public class RequirementService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsreq/";

      public RequirementService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dsreq:Requirement/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(INewRequirementMask) };
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
      // (GET) /dsreq:Requirement/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an dsreq:Requirement Summary: Gets a Change Control of an 
      // dsreq:Requirement
      // <param name="reqId">
      // Description: dsreq:Requirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IChangeControlStatusMask>> GetChangeControl(string reqId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Requirement/{reqId}/dslc:changeControl";

         return await GetCollectionFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:Requirement/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate Change Control. Once object is change controlled, a change is required to 
      // perform any modification on the object. Summary: Activate Change Control
      // <param name="reqId">
      // Description: dsreq:Requirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string reqId, IEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:RequirementSpecification/{reqId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IEmpty>(resourceURI, request);
      }

      // SR-00971020
      //	IR-1028857

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dsreq:Requirement/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Requirement with an attributes list. Summary: Gets a Requirement
      // <param name="reqId">
      // Description: dsreq:Requirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<INewRequirementMask> Get(string reqId)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Requirement/{reqId}";

         return await GetIndividualFromResponseMemberProperty<INewRequirementMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dsreq:Requirement
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Requirements using payload items. A maximum of 10 items is allowed. Summary: 
      // Create Requirements
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<INewRequirementMask>> Create(ICreateRequirement request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Requirement";

         return await PostCollectionFromResponseMemberProperty<INewRequirementMask, ICreateRequirement>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dsreq:Requirement/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Requirement with an attributes list. attributes Summary: Modifies the 
      // Requirement attributes
      // <param name="reqId">
      // Description: dsreq:Requirement object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<INewRequirementMask> Update(string reqId, IModifyRequirement request)
      {
         string resourceURI = $"{GetBaseResource()}dsreq:Requirement/{reqId}";

         return await PatchIndividualFromResponseMemberProperty<INewRequirementMask, IModifyRequirement>(resourceURI, request);
      }
   }
}