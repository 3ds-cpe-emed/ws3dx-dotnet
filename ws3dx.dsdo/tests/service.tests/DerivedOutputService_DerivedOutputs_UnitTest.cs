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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dsdo.core.data.impl;
using ws3dx.dsdo.core.service;
using ws3dx.dsdo.data;
using ws3dx.shared.data;
using ws3dx.dsxcad.core.data.impl;
using System.Linq;

namespace NUnitTestProject
{
   public class DerivedOutputService_DerivedOutputs_UnitTests : DerivedOutputServiceTestsSetup
   {
      public CheckinTicketService InitiateCheckinTicketService(IPassportAuthentication _passport)
      {
         CheckinTicketService __checkinTicketService = new CheckinTicketService(GetServiceUrl(), _passport);
         __checkinTicketService.Tenant = GetTenant();
         __checkinTicketService.SecurityContext = GetDefaultSecurityContext();
         return __checkinTicketService;
      }


      [TestCase("")]
      public async Task Get_IDerivedOutputDetailMask(string doId)
      {
         DerivedOutputService derivedOutputService = ServiceFactoryCreate(await Authenticate());

         IDerivedOutputDetailMask ret = await derivedOutputService.Get<IDerivedOutputDetailMask>(doId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IDerivedOutputCompleteMask(string doId)
      {
         DerivedOutputService derivedOutputService = ServiceFactoryCreate(await Authenticate());

         IDerivedOutputCompleteMask ret = await derivedOutputService.Get<IDerivedOutputCompleteMask>(doId);

         Assert.IsNotNull(ret);
      }


      public async Task<string> UploadFile(IPassportAuthentication _passport, ITypedUriId _id, string _fileLocalPath)
      {
         CheckinTicketService checkinTicketService = InitiateCheckinTicketService(_passport);

         // Step 1 -  upload file
         // request Check in ticket

         IGetCheckInTicketRequest checkinTicketRequest = new GetCheckInTicketRequest();
         checkinTicketRequest.FileCount = "1";
         checkinTicketRequest.ReferencedObject = _id;

         IGetCheckInTicketResponse checkinTicketResponse = await checkinTicketService.Get(checkinTicketRequest);

         Assert.AreEqual(checkinTicketResponse.StatusCode, "200");
         Assert.AreEqual(checkinTicketResponse.Success, "true");

         string ticket = checkinTicketResponse.Data.DataElements.Ticket;
         string ticketUrl = checkinTicketResponse.Data.DataElements.TicketURL;
         string ticketParamName = "__fcs__jobTicket";

         // -----
         //----
         // Building the request using Multipart Form Data
         // Create the file content part by copying the file contents
         var fileContent = new StreamContent(File.OpenRead(_fileLocalPath));
         fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
         {
            Name = "\"file\"",
            FileName = "\"" + Path.GetFileName(_fileLocalPath) + "\""
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
         System.Uri ticketUrlUri = new System.Uri(ticketUrl);

         string baseAddress = $"{ticketUrlUri.Scheme}://{ticketUrlUri.Host}/";

         if (!ticketUrlUri.IsDefaultPort)
         {
            baseAddress += $":{ticketUrlUri.Port}";
         }

         HttpClient client = new HttpClient(new HttpClientHandler()) { BaseAddress = new System.Uri(baseAddress) };

         HttpResponseMessage result = await client.PostAsync(ticketUrlUri.AbsolutePath, requestContent);

         if (result.StatusCode != HttpStatusCode.OK)
         {
            throw new Exception(result.Content.ToString());
         }

         string receipt = await result.Content.ReadAsStringAsync();

         receipt = receipt.Trim('\n'); ;

         return receipt;
      }

      // ID 2661E4727D710000627CC3D6000106F1
      // NAME prd-R1132100982379-00465895

      [TestCase("221CD96C0A1B000064C928600012881F", "E:\\downloads\\3DMaster_V2R0_221202.pdf")]
      public async Task Create_IDerivedOutputDetailMask(string _id, string _doLocalFilePath)
      {
         IPassportAuthentication passport = await Authenticate();

         DerivedOutputService derivedOutputService = ServiceFactoryCreate(passport);

         ITypedUriId id = new XCADPartUriId(_id);

         string receipt = await UploadFile(passport, id, _doLocalFilePath);

         string checksum = "";

         using (var md5 = MD5.Create())
         {
            using (var stream = File.OpenRead(_doLocalFilePath))
            {
               byte[] hash = md5.ComputeHash(stream);

               checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
         }

         ICreateDerivedOutputFile doFile = new CreateDerivedOutputFile
         {
            Checksum = checksum,
            Filename = "3DMaster_V2R0_221202.pdf",
            Format = "PDF",
            Receipt = receipt
         };

         ICreateDerivedOutput request = new CreateDerivedOutput
         {
            ReferencedObject = id,
            DerivedOutputFiles = new List<ICreateDerivedOutputFile> { doFile }
         };

         try
         {
            IDerivedOutputDetailMask ret = await derivedOutputService.Create<IDerivedOutputDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }


      [TestCase()]
      public async Task Create_IDerivedOutputCompleteMask()
      {
         DerivedOutputService derivedOutputService = ServiceFactoryCreate(await Authenticate());

         ICreateDerivedOutput request = new CreateDerivedOutput();

         try
         {
            IDerivedOutputCompleteMask ret = await derivedOutputService.Create<IDerivedOutputCompleteMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate_IDerivedOutputDetailMask()
      {
         DerivedOutputService derivedOutputService = ServiceFactoryCreate(await Authenticate());

         ILocateDerivedOutputs request = new LocateDerivedOutputs();

         try
         {
            IEnumerable<IDerivedOutputDetailMask> ret = await derivedOutputService.Locate<IDerivedOutputDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate_IDerivedOutputCompleteMask()
      {
         DerivedOutputService derivedOutputService = ServiceFactoryCreate(await Authenticate());

         ILocateDerivedOutputs request = new LocateDerivedOutputs();

         try
         {
            IEnumerable<IDerivedOutputCompleteMask> ret = await derivedOutputService.Locate<IDerivedOutputCompleteMask>(request);

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