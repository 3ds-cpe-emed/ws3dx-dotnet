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

namespace ws3dx.authentication.data
{
   public interface IPassportAuthentication
   {
      //Attaches authentication data to the IRestRequest
      bool AuthenticateRequest(HttpRequestMessage request, bool refreshAutomatically = true);

      //If is Cookie authentication use the GetCookie Container method otherwise Authenticate each single request using the AuthenticateRequest
      bool IsCookieAuthentication();

      //Returns the Cookie Container associated to the Passport
      CookieContainer GetCookieContainer();

      //Returns identity associated to the passport authentication
      string GetIdentity();

      // Return true if the identity associated to this passport is currently validated
      // and false otherwise (e.g. in the case it has expired and requires a refresh or the user has never correctly authenticated)
      bool IsValid();
   }
}
