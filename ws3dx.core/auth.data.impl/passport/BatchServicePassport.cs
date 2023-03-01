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

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ws3dx.authentication.exception;
using ws3dx.utils;

namespace ws3dx.authentication.data.impl.passport
{
   public class BatchServicePassport : CASCookieBasedPassport, IPassportAuthentication
   {
      private const string GET_TRANSIENT_TICKET_WS = "/api/v2/batch/ticket";
      private const string LOGIN_TRANSIENT_TICKET_WS = "/api/login/cas/transient";

      private const string TRANSIENT_TOKEN = "CAS_TRANSIENT";
      private const string DS_SERVICE_NAME = "DS-Service-Name";
      private const string DS_SERVICE_SECRET = "DS-Service-Secret";
      private const string IDENTIFIER = "identifier";
      private const string TGT = "tgt";

      private const string CAS_TICKET_NAME = "CASTGC";

      private const string AUTHENTICATED = "authenticated";

      private string m_userId = string.Empty;
      private string m_serviceName = string.Empty;
      private string m_serviceSecret = string.Empty;

      private BatchServicePassportAuthentication m_authenticationIdentity = null;

      public BatchServicePassport(string passportUrl) : base(passportUrl)
      {
      }

      private async Task<BatchServiceTransientToken> GetTransientToken(string serviceName, string serviceSecret, string userId)
      {
         //Step 1 - Request transient token
         UriRelative transientTickettUri = new UriRelative(GetEndpointURL(GET_TRANSIENT_TICKET_WS));
         transientTickettUri.AddQueryParameter(IDENTIFIER, userId);

         GetHttpJsonMessage getTransientTokenRequest = new GetHttpJsonMessage(transientTickettUri);
         getTransientTokenRequest.Headers.Add(DS_SERVICE_NAME, serviceName);
         getTransientTokenRequest.Headers.Add(DS_SERVICE_SECRET, serviceSecret);

         HttpResponseMessage getTransientTokenResponse = await Client.SendAsync(getTransientTokenRequest);

         if (!getTransientTokenResponse.IsSuccessStatusCode)
         {
            //handle according to established exception policy
            throw new GetLoginTicketException(getTransientTokenResponse);
         }

         //Handle ticket login response
         BatchServiceTransientToken transientToken = await getTransientTokenResponse.Content.ReadFromJsonAsync<BatchServiceTransientToken>();

         if (transientToken.token_type != TRANSIENT_TOKEN)
         {
            //handle according to established exception policy
            throw new GetLoginTicketException(getTransientTokenResponse);
         };

         return transientToken;
      }

      public BatchServicePassportAuthentication AuthenticationIdentity { get { return m_authenticationIdentity; } }

      public async Task<bool> CASLogin(string serviceName, string serviceSecret, string userId)
      {
         //Step 1 - Request on behalf transient token
         BatchServiceTransientToken transientToken =
             await GetTransientToken(serviceName, serviceSecret, userId);

         // Step 2 - build the login request
         UriRelative loginUrl = new UriRelative(GetEndpointURL(LOGIN_TRANSIENT_TICKET_WS));
         loginUrl.AddQueryParameter(TGT, transientToken.access_token);

         GetHttpJsonMessage loginRequest = new GetHttpJsonMessage(loginUrl);

         HttpResponseMessage loginRequestResponse = await Client.SendAsync(loginRequest);

         if (!loginRequestResponse.IsSuccessStatusCode)
         {
            //handle according to established exception policy
            throw new AuthenticationException(loginRequestResponse);
         }

         m_authenticationIdentity = await loginRequestResponse.Content.ReadFromJsonAsync<BatchServicePassportAuthentication>();

         if ((m_authenticationIdentity != null) && (m_authenticationIdentity.message.Equals(AUTHENTICATED, StringComparison.InvariantCultureIgnoreCase)))
         {
            return IsCookieAuthenticated;
         }

         return false;
      }

      public bool AuthenticateRequest(HttpRequestMessage request, bool refreshAutomatically = true)
      {
         throw new NotImplementedException();
      }

      public CookieContainer GetCookieContainer()
      {
         return CookieContainer;
      }

      public string GetIdentity()
      {
         throw new NotImplementedException();
      }

      public bool IsCookieAuthentication()
      {
         return true;
      }

      public bool IsValid()
      {
         return this.IsCookieAuthenticated;
      }
   }
}
