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
using ws3dx.dsiss.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace ws3dx.dsiss.core.service
{
   // SDK Service
   public class IssueService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsiss";

      public IssueService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/issue/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(ITypedUriIdentifier) };
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

      protected override string GetMaskParamName()
      {
         return null;
      }

      public async Task<IList<ITypedUriIdentifier>> Search(SearchQuery _searchQuery)
      {
         return await SearchCollection<ITypedUriIdentifier>("issue", _searchQuery);
      }

      public async Task<IList<ITypedUriIdentifier>> Search(SearchQuery searchQuery, long _skip, long _top)
      {
         return await SearchCollection<ITypedUriIdentifier>("issue", searchQuery, _skip, _top);
      }

      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /issue/{id}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Retrieves a Issue with the required facets. Core part is always retrieved Summary: 
      // Retrieve a Issue.
      // <param name="issueId">
      // Description: The physicalid of the Issue you want to retrieve
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IIssueDetail> Get(string issueId)
      {
         string resourceURI = $"{GetBaseResource()}/issue/{issueId}";

         return await GetIndividual<IIssueDetail>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /issue/{id}/reject
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Reject a Issue Summary: Reject a Issue
      // <param name="issueId">
      // Description: The physicalid of the Issue you want to reject
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IIssue> Reject(string issueId, IIssueComment request)
      {
         string resourceURI = $"{GetBaseResource()}/issue/{issueId}/reject";

         return await PostIndividual<IIssue, IIssueComment>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /issue
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates a new Issue or subtype of Issue with elements passed in input. Elements passed 
      // in input can only be part of the core part Summary: Creates a new Issue.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IIssue> Create(ICreateIssue request)
      {
         string resourceURI = $"{GetBaseResource()}/issue";

         return await PostIndividual<IIssue, ICreateIssue>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /issue/{id}/approve
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Approve a Issue Summary: Approve a Issue
      // <param name="issueId">
      // Description: The physicalid of the Issue you want to approve
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IIssue> Approve(string issueId, IIssueComment request)
      {
         string resourceURI = $"{GetBaseResource()}/issue/{issueId}/approve";

         return await PostIndividual<IIssue, IIssueComment>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /issue/{id}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify an existing Issue. Only the elements passed in input are modified. Output will 
      // be composed of the core part as well as the modified fields. Summary: Modify an existing Issue.
      // <param name="issueId">
      // Description: The physicalid of the Issue you want to modify
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IIssueDetail> Update(string issueId, IModifyIssue request)
      {
         string resourceURI = $"{GetBaseResource()}/issue/{issueId}";

         return await PatchIndividual<IIssueDetail, IModifyIssue>(resourceURI, request);
      }
   }
}