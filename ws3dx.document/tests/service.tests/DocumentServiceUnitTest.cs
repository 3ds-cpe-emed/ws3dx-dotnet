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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.document.core.data.impl;
using ws3dx.document.core.service;
using ws3dx.document.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class DocumentServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";

      string m_username = string.Empty;
      string m_password = string.Empty;
      string m_passportUrl = string.Empty;
      string m_serviceUrl = string.Empty;
      string m_tenant = string.Empty;

      ws3dx.core.data.impl.UserInfo m_userInfo = null;

      public async Task<IPassportAuthentication> Authenticate()
      {
         UserPassport passport = new UserPassport(m_passportUrl);

         UserInfoRedirection userInfoRedirection = new UserInfoRedirection(m_serviceUrl, m_tenant)
         {
            Current = true,
            IncludeCollaborativeSpaces = true,
            IncludePreferredCredentials = true
         };

         m_userInfo = await passport.CASLoginWithRedirection<ws3dx.core.data.impl.UserInfo>(m_username, m_password, false, userInfoRedirection);

         Assert.IsNotNull(m_userInfo);

         StringAssert.AreEqualIgnoringCase(m_userInfo.name, m_username);

         Assert.IsTrue(passport.IsCookieAuthenticated);

         return passport;
      }

      [SetUp]
      public void Setup()
      {
         m_username = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_USERNAME, EnvironmentVariableTarget.User); // e.g. AAA27
         m_password = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSWORD, EnvironmentVariableTarget.User); // e.g. your password
         m_passportUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSPORT, EnvironmentVariableTarget.User); // e.g. https://eu1-ds-iam.3dexperience.3ds.com:443/3DPassport

         m_serviceUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_ENOVIA, EnvironmentVariableTarget.User); // e.g. https://r1132100982379-eu1-space.3dexperience.3ds.com:443/enovia
         m_tenant = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_TENANT, EnvironmentVariableTarget.User); // e.g. R1132100982379
      }

      public string GetDefaultSecurityContext()
      {
         return m_userInfo.preferredcredentials.ToString();
      }

      public DocumentService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         return new DocumentService(_serviceUrl, _passport)
         {
            Tenant = _tenant,
            SecurityContext = GetDefaultSecurityContext()
         };
      }

      [TestCase("", "", "")]
      public async Task GetItemDocuments(string parentId, string parentRelName, string parentDirection)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDocumentDataResponse> ret = await documentService.GetItemDocuments(parentId, parentRelName, parentDirection);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetFileVersions(string docId, string fileId)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDocumentFile> ret = await documentService.GetFileVersions(docId, fileId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetFiles(string docId)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDocumentFile> ret = await documentService.GetFiles(docId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get(string docId)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IDocumentDataResponse> ret = await documentService.Get(docId);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27 New Document from web services")]
      public async Task Create(string _titleId)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDocument document = new Document();
         document.Data = new DocumentData();
         document.Data.Title = _titleId;

         IDocuments documents = new Documents();
         documents.Data = new List<IDocument>();
         documents.Data.Add(document);

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
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

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

      [TestCase("")]
      public async Task GetMany(string ids)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
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

      [TestCase("document", 0, 50)]
      public async Task Search_Paged(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDocumentDataResponse> ret = await documentService.Search(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("document")]
      public async Task Search_Full(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         DocumentService documentService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IDocumentDataResponse> ret = await documentService.Search(searchByFreeText);

         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IDocumentsResponse docFound in ret)
         {
            IEnumerable<IDocumentDataResponse> docs = await documentService.Get(docFound.Data[0].Id);

            foreach (IDocumentDataResponse doc in docs)
            {
               Assert.AreEqual(docFound.Data[0].Id, doc.Id);
            }

            i++;

            if (i > 20) return;
         }
      }
   }
}