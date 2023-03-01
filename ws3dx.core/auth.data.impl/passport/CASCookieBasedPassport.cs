//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2020 Dassault Systèmes - CPE EMED
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

using System.Net;
using System.Net.Http;

namespace ws3dx.authentication.data.impl.passport
{
   public class CASCookieBasedPassport : Passport
   {
      private HttpClient m_client = null;
      private HttpClientHandler m_clientHandler = new HttpClientHandler();

      private const string CAS_TICKET_NAME = "CASTGC";

      protected CASCookieBasedPassport(string passportUrl) : base(passportUrl)
      {
         m_clientHandler.CookieContainer = new CookieContainer();
         m_clientHandler.AllowAutoRedirect = true;

         // Initialize RestClient and Cookie Manager
         m_client = new HttpClient(m_clientHandler) { BaseAddress = PassportHost };

         return;
      }

      protected HttpClient Client { get { return m_client; } }

      public CookieContainer CookieContainer
      {
         get
         {
            return m_clientHandler.CookieContainer;
         }
      }
      public bool IsCookieAuthenticated
      {
         get
         {   //Check CASTGC cookie exists
            //on premise
            CookieCollection cookies = this.CookieContainer.GetCookies(this.PassportUri);

            foreach (Cookie cookie in cookies)
            {
               if (cookie.Name == CAS_TICKET_NAME)
               {
                  return true;
               }
            }

            //Cloud
            cookies = this.CookieContainer.GetCookies(Client.BaseAddress);

            foreach (Cookie cookie in cookies)
            {
               if (cookie.Name == CAS_TICKET_NAME)
               {
                  return true;
               }
            }

            return false;
         }
      }
   }
}
