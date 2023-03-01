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
using System.Net.Http.Headers;
using System.Text;

namespace ws3dx.authentication.data.impl.passport
{
   public class AgentPassport : IPassportAuthentication
   {
      private string m_agentId = string.Empty;
      private string m_agentSecret = string.Empty;

      private string m_authenticationValue = string.Empty;

      public AgentPassport(string _agentId, string _agentSecret)
      {
         m_agentId = _agentId;
         m_agentSecret = _agentSecret;

         string authRaw = string.Format("{0}:{1}", m_agentId, m_agentSecret);

         byte[] authBytes = Encoding.UTF8.GetBytes(authRaw);
         m_authenticationValue = System.Convert.ToBase64String(authBytes);
      }

      public bool AuthenticateRequest(HttpRequestMessage request, bool refreshAutomatically = true)
      {
         //There is no refresh mechanism for this authentication
         request.Headers.Authorization = new AuthenticationHeaderValue("Basic", m_authenticationValue);
         return true;
      }

      public CookieContainer GetCookieContainer()
      {
         throw new NotImplementedException();
      }

      public string GetIdentity()
      {
         throw new NotImplementedException();
      }

      public bool IsCookieAuthentication()
      {
         return false;
      }

      public bool IsValid()
      {
         //TODO: Review this
         return true;
      }
   }
}