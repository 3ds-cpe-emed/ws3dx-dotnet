//------------------------------------------------------------------------------------------------------------------------------------
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

using ws3dx.authentication.data;
using ws3dx.dsdo.core.data.impl;
using ws3dx.dsdo.core.service;
using ws3dx.dsdo.data;
using ws3dx.dsxcad.core.service;
using ws3dx.dsxcad.data;
using ws3dx.shared.data;
using ws3dx.shared.data.impl;
using ws3dx.utils;
using ws3dx.utils.search;

namespace ws3dx.tests
{
   public class DerivedOutputDownload_UnitTests : PassportAuthenticationTestSetup
   {
      // Download the Derived Output PDF file associated with a Catia V5 Drawing
      [TestCase("drw-R1132100982379-00007989", "A.1")]
      public async Task DownloadCatiaV5DWGDerivedOutputFile(string dwgName, string dwgRevision)
      {
         // First step authenticate using CAS
         IPassportAuthentication passport = await Authenticate();

         // Second step get Drawing (option 1 - from direct search)
         DrawingService drawingService = XCADDrawingServiceFactory.Create(passport, GetServiceUrl(), GetTenant(), GetDefaultSecurityContext());

         SearchByNameRevision searchDWGByNameRevision = new SearchByNameRevision(dwgName, dwgRevision);

         IList<IXCADDrawingBasicMask> drawingSearchResult = await drawingService.Search<IXCADDrawingBasicMask>(searchDWGByNameRevision);

         DerivedOutputService derivedOutputService = DerivedOutputServiceFactory.Create(passport, GetServiceUrl(), GetTenant(), GetDefaultSecurityContext());

         // Third step get Drawing Derived Output information

         foreach (IXCADDrawingBasicMask drawing in drawingSearchResult)
         {
            ITypedUriId typedUriId = new TypedUriId
            {
               Type = "dsxcad:Drawing",
               Source = GetServiceUrl(),
               Id = drawing.Id,
               RelativePath = $"/resources/v1/modeler/dsxcad/dsxcad:Drawing/{drawing.Id}"
            };

            ILocateDerivedOutputs locateDerivedOutputs = new LocateDerivedOutputs
            {
               ReferencedObject = new List<ITypedUriId>
               {
                  typedUriId
               }
            };

            IEnumerable<IDerivedOutputDetailMask> locateResult = await derivedOutputService.Locate<IDerivedOutputDetailMask>(locateDerivedOutputs);

            foreach (IDerivedOutputDetailMask locateData in locateResult)
            {
               if ((locateData == null) || (locateData.DerivedOutputs == null)) continue;

               if (locateData.DerivedOutputs.DerivedOutputFiles == null) continue;

               if (locateData.DerivedOutputs.ReferencedObject == null) continue;

               string derivedOutputId = locateData.DerivedOutputs.Id;

               // Fourth step if Drawing is PDF download it
               foreach (IDerivedOutputFileDetail fileDetail in locateData.DerivedOutputs.DerivedOutputFiles)
               {
                  if (fileDetail.Format.Equals("PDF", StringComparison.InvariantCultureIgnoreCase))
                  {
                     // Get Download Ticket and Download file
                     IDownloadFileTicketResponse downloadTicketResponse = await derivedOutputService.GetDownloadTicket(derivedOutputId, fileDetail.Id, null);

                     if (downloadTicketResponse.Success == true)
                     {
                        IDownloadFileTicketData downloadDOFileTicketData = downloadTicketResponse.Data;

                        if (downloadDOFileTicketData != null)
                        {
                           IDownloadFileTicket downloadDOFileTicket  = downloadDOFileTicketData.Data;

                           string ticketUrl = downloadDOFileTicket.TicketURL;
                           string ticket = downloadDOFileTicket.Ticket;

                           string filename = downloadDOFileTicket.Filename;

                           await DownloadFileManager.DownloadWithTicket(ticketUrl, ticket, filename);
                        }

                     }
                  }
               }
            }
         }

         //IEngItemDefaultMask ret = await derivedOutputService.Get<IEngItemDefaultMask>(engItemId);

        // Assert.IsNotNull(ret);
      }
   }
}