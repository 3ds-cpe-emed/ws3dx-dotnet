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
using ws3dx.document.data;
using ws3dx.utils.search;

namespace ws3dx.document.core.service
{
   // SDK Service
   public class DocumentService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler//";

      public DocumentService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/documents/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IDocumentDataResponse) };
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

      protected override string GetMaskParamName()
      {
         return null;
      }

      public async Task<IList<IDocumentDataResponse>> Search(SearchQuery _searchString)
      {
         return await SearchCollection<IDocumentDataResponse>("data", _searchString);
      }

      public async Task<IList<IDocumentDataResponse>> Search(SearchQuery _searchString, long _skip = 0, long _top = 100)
      {
         return await SearchCollection<IDocumentDataResponse>("data", _searchString, _skip, _top);
      }

      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /documents/parentId/{parentId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the documents related to a given parent object.
      // <param name="parentRelName">
      // Description: The name of the relationship (e.g. Reference Document, PLMDocConnection).
      // </param>
      // <param name="parentDirection">
      // Description: The direction of the relationship (from|to, default is from)
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IDocumentDataResponse>> GetItemDocuments(string parentId, string parentRelName, string parentDirection)
      {
         string resourceURI = $"{GetBaseResource()}/documents/parentId/{parentId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("parentRelName", parentRelName);
         queryParams.Add("parentDirection", parentDirection);

         return await GetCollectionFromResponseDataProperty<IDocumentDataResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /documents/{docId}/files/{fileId}/versions
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the file versions.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IDocumentFile>> GetFileVersions(string docId, string fileId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}/versions";

         return await GetCollectionFromResponseDataProperty<IDocumentFile>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /documents/{docId}/files
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Retrieve the files meta-data for a given document.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IDocumentFile>> GetFiles(string docId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files";

         return await GetCollectionFromResponseDataProperty<IDocumentFile>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /documents/{docId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the information for a given document object.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IDocumentDataResponse> Get(string docId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}";

         return await GetIndividualFromResponseDataProperty<IDocumentDataResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /documents
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Create new document and related file data.
      // <param name="parentRelName">
      // Description: The parent relationship to link the document; dependent on parentId(i.e. Reference 
      // Document, SpecificationDocument). It is required if managing parents objects with this request.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IDocumentDataResponse>> Create(IDocuments documents, string parentRelName = null)
      {
         string resourceURI = $"{GetBaseResource()}/documents";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         if (parentRelName != null) {
         queryParams.Add("parentRelName", parentRelName);
         }

         return await PostCollectionFromResponseDataProperty<IDocumentDataResponse, IDocuments>(resourceURI, documents, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /documents/{docId}/files
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Create new document object files.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IDocumentFile>> AddFiles(string docId, IFiles files)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files";

         return await PostCollectionFromResponseDataProperty<IDocumentFile, IFiles>(resourceURI, files);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /documents/ids
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the documents for a given set of document IDs.
      // <param name="ids">
      // Comma-separated list of IDs to retrieve.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IDocumentDataResponse>> GetMany(string ids)
      {
         string resourceURI = $"{GetBaseResource()}/documents/ids";

         return await PostCollectionFromResponseDataProperty<IDocumentDataResponse, string>(resourceURI, ids);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/reserve
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Reserve the given document.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDocumentsResponse> Reserve(string docId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/reserve";

         return await PutIndividual<IDocumentsResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/{fileId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update a given document object file.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileResponse> UpdateFile(string docId, string fileId, IFiles files)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}";

         return await PutIndividual<IFileResponse, IFiles>(resourceURI, files);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update a given set of documents and their related data.
      // <param name="parentRelName">
      // Description: The parent relationship to link the document; dependent on parentId(i.e. Reference 
      // Document, SpecificationDocument). It is required if managing parents objects with this request.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDocumentsResponse> UpdateMany(IDocuments documents, string parentRelName = null)
      {
         string resourceURI = $"{GetBaseResource()}/documents";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         if (parentRelName!=null) {
         queryParams.Add("parentRelName", parentRelName);
         }

         return await PutIndividual<IDocumentsResponse, IDocuments>(resourceURI, documents, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/CheckinTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get an checkin ticket to upload files to FCS in order to add or modify a 
      // file for a given document.
      // <param name="store">
      // Description: name of destination file store
      // </param>
      // <param name="policy">
      // Description: name of document policy
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ICheckInTicketResponse> GetCheckInTicket(string docId, string store, string policy)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/CheckinTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("store", store);
         queryParams.Add("policy", policy);

         return await PutIndividual<ICheckInTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/{fileId}/CheckoutTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Lock and get the checkout ticket for a given file within a document.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ICheckOutTicketResponse> GetFileCheckOutTicket(string docId, string fileId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}/CheckoutTicket";

         return await PutIndividual<ICheckOutTicketResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/{fileId}/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the download ticket to download a specific file associated to a document.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDownloadTicketResponse> GetFileDownloadTicket(string docId, string fileId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}/DownloadTicket";

         return await PutIndividual<IDownloadTicketResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update the information for a given document object.
      // <param name="parentRelName">
      // Description: The parent relationship to link the document; dependent on parentId(i.e. Reference 
      // Document, SpecificationDocument). It is required if managing parents objects with this request.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDocumentsResponse> Update(string docId, IDocuments documents, string parentRelName = null)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         if (parentRelName != null) {
         queryParams.Add("parentRelName", parentRelName);
         }

         return await PutIndividual<IDocumentsResponse, IDocuments>(resourceURI, documents, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/{fileId}/versions/{versionId}/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the download ticket to download a specific file version associated to 
      // a document/file.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDownloadTicketResponse> GetFileVersionDownloadTicket(string docId, string fileId, string versionId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}/versions/{versionId}/DownloadTicket";

         return await PutIndividual<IDownloadTicketResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/files/CheckinTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get a checkin ticket to upload files to FCS; required for checking in a file 
      // to a new document that is not created yet.
      // <param name="store">
      // Description: name of destination file store
      // </param>
      // <param name="policy">
      // Description: name of document policy
      // </param>
      // <param name="fileCount">
      // Description: number of files being checked in
      // </param>
      // <param name="ticketCount">
      // Description: number of tickets to generate
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ICheckInTicketResponse> GetPreCreateCheckInTicket(string store, string policy, string fileCount, string ticketCount)
      {
         string resourceURI = $"{GetBaseResource()}/documents/files/CheckinTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("store", store);
         queryParams.Add("policy", policy);
         queryParams.Add("fileCount", fileCount);
         queryParams.Add("ticketCount", ticketCount);

         return await PutIndividual<ICheckInTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/CheckoutTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Lock and get the checkout ticket for a document; a zip is returned when 
      // multiple files exist.
      // <param name="zipFiles">
      // Description: should be true to zip the files
      // </param>
      // <param name="zipName">
      // Description: name of the zip file
      // </param>
      // <param name="fileStream">
      // Description: true or false option to return a url. This is an FCS option to allow to stream as 
      // long as the request is for one file. Default is false.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ICheckOutTicketResponse> GetCheckOutTicket(string docId, string zipFiles, string zipName, string fileStream)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/CheckoutTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("zipFiles", zipFiles);
         queryParams.Add("zipName", zipName);
         queryParams.Add("fileStream", fileStream);

         return await PutIndividual<ICheckOutTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the download ticket to download all the files associated to a document.
      // <param name="zipFiles">
      // Description: should be true to zip the files
      // </param>
      // <param name="zipName">
      // Description: name of the zip file
      // </param>
      // <param name="fileStream">
      // Description: true or false option to return a url. This is an FCS option to allow to stream as 
      // long as the request is for one file. Default is false.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDownloadTicketResponse> GetDownloadTicket(string docId, string zipFiles, string zipName, string fileStream)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/DownloadTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("zipFiles", zipFiles);
         queryParams.Add("zipName", zipName);
         queryParams.Add("fileStream", fileStream);

         return await PutIndividual<IDownloadTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/files
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update the document object files.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IFileResponse> UpdateFiles(string docId, IFiles files)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files";

         return await PutIndividual<IFileResponse, IFiles>(resourceURI, files);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get the FCS download ticket for the given documents.
      // <param name="zipFiles">
      // Description: should be true to zip the files
      // </param>
      // <param name="zipName">
      // Description: name of the zip file
      // </param>
      // <param name="fileStream">
      // Description: true or false option to return a url. This is an FCS option to allow to stream as 
      // long as the request is for one file. Default is false.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDownloadTicketResponse> GetDownloadTicketForMany(string zipFiles, string zipName, string fileStream)
      {
         string resourceURI = $"{GetBaseResource()}/documents/DownloadTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("zipFiles", zipFiles);
         queryParams.Add("zipName", zipName);
         queryParams.Add("fileStream", fileStream);

         return await PutIndividual<IDownloadTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/CheckoutTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Lock and get the checkout tickets for the given documents
      // <param name="zipFiles">
      // Description: should be true to zip the files
      // </param>
      // <param name="zipName">
      // Description: name of the zip file
      // </param>
      // <param name="fileStream">
      // Description: true or false option to return a url. This is an FCS option to allow to stream as 
      // long as the request is for one file. Default is false.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ICheckOutTicketResponse> GetCheckOutTicketForMany(string zipFiles, string zipName, string fileStream)
      {
         string resourceURI = $"{GetBaseResource()}/documents/CheckoutTicket";

         IDictionary<string, string> queryParams = new Dictionary<string, string>();
         queryParams.Add("zipFiles", zipFiles);
         queryParams.Add("zipName", zipName);
         queryParams.Add("fileStream", fileStream);

         return await PutIndividual<ICheckOutTicketResponse>(resourceURI, queryParams: queryParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /documents/{docId}/unreserve
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Unreserve the given document.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDocumentsResponse> Unreserve(string docId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/unreserve";

         return await PutIndividual<IDocumentsResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /documents/{docId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete a given document object.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEmptyResponse> Delete(string docId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}";

         return await DeleteIndividual<IEmptyResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /documents/{docId}/files/{fileId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete a given document object file.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEmptyResponse> RemoveFile(string docId, string fileId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}";

         return await DeleteIndividual<IEmptyResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /documents/{docId}/files/{fileId}/versions/{versionId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete the given file versions.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEmptyResponse> RemoveFileVersion(string docId, string fileId, string versionId)
      {
         string resourceURI = $"{GetBaseResource()}/documents/{docId}/files/{fileId}/versions/{versionId}";

         return await DeleteIndividual<IEmptyResponse>(resourceURI);
      }
   }
}