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

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ws3dx.utils
{
   public class DownloadFileManager
   {
      /// <summary>
      /// Validates download parameters (download filename and download path) setting temp filename and locations if null and retrieving the full path (location / filename)
      /// </summary>
      /// <param name="_downloadPath"></param>
      /// <param name="_downloadFilename"></param>
      /// <returns></returns>
      /// <exception cref="Exception"></exception>
      private static string GetDownloadFilePath(string _downloadPath, string _downloadFilename)
      {
         string downloadLocation = _downloadPath;
         string downloadFilename = _downloadFilename;

         if (downloadLocation == null)
         {
            downloadLocation = Path.GetTempPath();
         }

         if (!downloadLocation.EndsWith(Path.DirectorySeparatorChar.ToString()))
         {
            downloadLocation += Path.DirectorySeparatorChar.ToString();
         }

         if (downloadFilename == null)
         {
            downloadFilename = Path.GetTempFileName();
         }

         //validation
         foreach (char invalidChar in Path.GetInvalidFileNameChars())
         {
            if (_downloadFilename.Contains(invalidChar))
            {
               throw new Exception($"download filename cannot contain '{invalidChar}'");
            }
         }

         foreach (char invalidChar in Path.GetInvalidPathChars())
         {
            if (downloadLocation.Contains(invalidChar))
            {
               throw new Exception($"download path cannot contain '{invalidChar}'");
            }
         }

         return string.Format("{0}{1}", downloadLocation, downloadFilename);

      }

      /// <summary>
      /// 
      /// GET method for Download with __fcs_jobTicket already included as a query parameter of the download URL 
      /// e.g. 3DEXPERIENCE Document Web Services requires this method to download files
      /// 
      /// </summary>
      /// <param name="_downloadUrl"></param>
      /// <param name="_downloadFilename"></param>
      /// <param name="_downloadFolder"></param>
      public static async Task<string> Download(string _downloadUrl, string _downloadFilename = null, string _downloadFolder = null)
      {

         string downloadFile = GetDownloadFilePath(_downloadFolder, _downloadFilename);

         using (var fileWriter = File.OpenWrite(downloadFile))
         {
            //Check using a static httpclient or IHttpClientFactory (include timeout)
            using (HttpClient downloadClient = new HttpClient(new HttpClientHandler()))
            {
               using (HttpResponseMessage res = await downloadClient.GetAsync(_downloadUrl))
               using (Stream streamToReadFrom = await res.Content.ReadAsStreamAsync())
               {
                  streamToReadFrom.CopyTo(fileWriter);
               }
            }
         }

         return downloadFile;
      }

      /// <summary>
      /// 
      /// POST method for Download with __fcs_jobTicket escaped and encoded as "application/x-www-form-urlencoded" 
      /// e.g. 3DEXPERIENCE Derived Output web services requires this method
      /// 
      /// </summary>
      /// <param name="_downloadTicketUrl"></param>
      /// <param name="_downloadTicket"></param>
      /// <param name="_downloadFilename"></param>
      /// <param name="_downloadFolder"></param>
      /// <returns></returns>
      public static async Task<string> DownloadWithTicket(string _downloadTicketUrl, string _downloadTicket, string _downloadFilename = null, string _downloadFolder = null)
      {
         string downloadFile = GetDownloadFilePath(_downloadFolder, _downloadFilename);

         using (var fileWriter = File.OpenWrite(downloadFile))
         {
            //Check using a static httpclient or IHttpClientFactory (include timeout)
            using (HttpClient downloadClient = new HttpClient(new HttpClientHandler()))
            {
               HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _downloadTicketUrl);

               string escapedDownloadTicket = Uri.EscapeDataString(_downloadTicket);
               string payload = $"__fcs__jobTicket={escapedDownloadTicket}";

               requestMessage.Content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");

               using (HttpResponseMessage res = await downloadClient.SendAsync(requestMessage))
               using (Stream streamToReadFrom = await res.Content.ReadAsStreamAsync())
               {
                  streamToReadFrom.CopyTo(fileWriter);
               }
            }
         }

         return downloadFile;
      }
   }
}
