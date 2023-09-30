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

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.document.core.data.impl;
using ws3dx.document.core.service;
using ws3dx.document.data;
using ws3dx.utils.search;
using System.Linq;

namespace NUnitTestProject
{
   public class DocumentService_Document_UnitTests : DocumentServiceTestsSetup
   {

      [TestCase("", "", "")]
      public async Task GetItemDocuments(string parentId, string parentRelName, string parentDirection)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDocumentDataResponse> ret = await documentService.GetItemDocuments(parentId, parentRelName, parentDirection);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetFileVersions(string docId, string fileId)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDocumentFile> ret = await documentService.GetFileVersions(docId, fileId);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IDocumentsResponse(string search, int skip, int top)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDocumentDataResponse> ret = await documentService.Search(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IDocumentsResponse(string search)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDocumentDataResponse> ret = await documentService.Search(searchByFreeText);

         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IDocumentsResponse docFound in ret)
         {
            IDocumentDataResponse doc = await documentService.Get(docFound.Data[0].Id);

            Assert.AreEqual(docFound.Data[0].Id, doc.Id);
          
            i++;

            if (i > 20) return;
         }
      }

      [TestCase("")]
      public async Task GetFiles(string docId)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         IEnumerable<IDocumentFile> ret = await documentService.GetFiles(docId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get(string docId)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         IDocumentDataResponse ret = await documentService.Get(docId);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27 New Document from web services")]
      public async Task Create(string _titleId)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         IDocument document = new Document();
         document.Data = new DocumentData();
         document.Data.Title = _titleId;

         IDocuments documents = new Documents();
         documents.Data = new List<IDocument>
         {
            document
         };

         try
         {
            IEnumerable<IDocumentDataResponse> ret = await documentService.Create(documents);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("44C2728F84480000642550550001D78E", "WN_CTX_FD01_2", "E:\\Downloads\\WN_CTX_FD01_2.png")]
      public async Task AddFiles(string docId, string title, string fileLocalPath)
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         // Add file to existing document in 2 steps
         // step 1 - upload file         
         // step 2 - add file

         try
         {
            // Step 1 -  upload file
            // request Check in ticket
            ICheckInTicketResponse checkinTicketResponse = await documentService.GetCheckInTicket(docId, null, null);

            Assert.AreEqual(checkinTicketResponse.StatusCode, 200);
            string ticketParamName = checkinTicketResponse.Data[0].Data.TicketParamName;
            string ticket = checkinTicketResponse.Data[0].Data.Ticket;
            string ticketUrl = checkinTicketResponse.Data[0].Data.TicketURL;

            // -----
            //----
            // Building the request using Multipart Form Data
            // Create the file content part by copying the file contents
            var fileContent = new StreamContent(File.OpenRead(fileLocalPath));
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
               Name = "\"file_0\"",
               FileName = "\"" + Path.GetFileName(fileLocalPath) + "\""
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Create the ticket content
            StringContent ticketContent = new StringContent(ticket);
            ticketContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
               Name = $"\"{ticketParamName}\""
            };

            // -----
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(ticketContent);
            requestContent.Add(fileContent);

            //Note: This was VERY hard to find however the 3DEXPERIENCE does not accept double quotes in the boundary
            //definition... Need to remove them.
            NameValueHeaderValue boundary = requestContent.Headers.ContentType.Parameters.First(o => o.Name == "boundary");
            boundary.Value = boundary.Value.Replace("\"", String.Empty);

            // ------

            // Prepare request resource path / address --------
            Uri ticketUrlUri = new Uri(ticketUrl);

            string baseAddress = $"{ticketUrlUri.Scheme}://{ticketUrlUri.Host}/";

            if (!ticketUrlUri.IsDefaultPort)
            {
               baseAddress += $":{ticketUrlUri.Port}";
            }

            HttpClient client = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(baseAddress) };

            HttpResponseMessage result = await client.PostAsync(ticketUrlUri.AbsolutePath, requestContent);

            if (result.StatusCode != HttpStatusCode.OK)
            {
               throw new Exception(result.Content.ToString());
            }

            string receipt = await result.Content.ReadAsStringAsync();

            receipt = receipt.Trim('\n'); ;

            // Step 2 - add file ---
            // -------
            IDocumentFile docFile = new DocumentFile();
            docFile.Data = new FileData();
            docFile.Data.Title = title;
            docFile.Data.Receipt = receipt;
            docFile.UpdateAction = "CONNECT";

            IFiles files = new Files();
            files.Data = new List<IDocumentFile>();
            files.Data.Add(docFile);

            IEnumerable<IDocumentFile> ret = await documentService.AddFiles(docId, files);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task GetMany()
      {
         DocumentService documentService = ServiceFactoryCreate(await Authenticate());

         string ids = "";

         try
         {
            IEnumerable<IDocumentDataResponse> ret = await documentService.GetMany(ids);

            Assert.IsNotNull(ret);

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}