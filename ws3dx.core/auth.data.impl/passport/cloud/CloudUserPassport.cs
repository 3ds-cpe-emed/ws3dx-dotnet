//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2023 Dassault Systèmes - CPE EMED
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
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.authentication.exception;
using ws3dx.core.auth.data.utils;
using ws3dx.core.data.impl;

namespace ws3dx.core.auth.data.impl.passport
{
   public class CloudUserPassport
   {
      private class CompassServiceRedirection : IPassportServiceRedirection
      {
         public string GetServiceURL()
         {
            return $"{Global3DEXPERIENCEConstant.PUBLIC_CLOUD_COMPASS_URL}/resources/AppsMngt/api/pull/self";
         }
      }

      private readonly UserPassport m_wrappedUserPassport = new UserPassport(Global3DEXPERIENCEConstant.PUBLIC_CLOUD_IAM_URL);

      private PlatformServiceCollection m_platformServiceCollection;
      private UserAccess m_userAccess;
      private UserInfo m_userInfo;
      private readonly string m_platformId;

      public CloudUserPassport(string _platformId)
      {
         m_platformId = _platformId;
      }

      public IPassportAuthentication GetPassportAuthentication() { return m_wrappedUserPassport; }

      public async Task<UserAccess> Login(string _username, string _password, bool _rememberMe = false)
      {
         m_userAccess = await m_wrappedUserPassport.CASLoginWithRedirection<UserAccess>(_username, _password, _rememberMe, new CompassServiceRedirection());
         return m_userAccess;
      }

      private async Task<UserAccess> GetPlatformAccessInformation(IPassportAuthentication passportAuthentication)
      {
         UserAccess __userAccess = null;

         string url = $"{Global3DEXPERIENCEConstant.PUBLIC_CLOUD_COMPASS_URL}/resources/AppsMngt/api/pull/self";

         // Initialize RestClient and Cookie Manager if Cookie Authentication
         using (HttpClientHandler httpClientHandler = new HttpClientHandler() { CookieContainer = passportAuthentication.GetCookieContainer() })
         using (HttpClient client = new HttpClient(httpClientHandler))
         {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
               if (!response.IsSuccessStatusCode)
               {
                  //handle according to established exception policy
                  throw new AuthenticationException(response);
               }

               __userAccess = await response.Content.ReadFromJsonAsync<UserAccess>();
            }
         }

         return __userAccess;
      }

      private async Task<PlatformServiceCollection> GetPlatformServices(IPassportAuthentication passportAuthentication, string _platformId)
      {
         PlatformServiceCollection __platformServiceCollection = null;

         string platformIdValueHash = CryptoUtils.Hash(Global3DEXPERIENCEConstant.X3DCOMPASS_HEADER_APPENDIX + _platformId);

         platformIdValueHash = platformIdValueHash.ToLowerInvariant();

         // Initialize RestClient and Cookie Manager if Cookie Authentication
         using (HttpClientHandler httpClientHandler = new HttpClientHandler() { CookieContainer = passportAuthentication.GetCookieContainer() })
         using (HttpClient client = new HttpClient(httpClientHandler))
         {
            string url = $"{Global3DEXPERIENCEConstant.PUBLIC_CLOUD_COMPASS_URL}/resources/AppsMngt/api/v1/public/services/platform?platform={_platformId}";

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            {
               request.Headers.Add(Global3DEXPERIENCEConstant.X3DCOMPASS_HEADER_NAME, platformIdValueHash);

               using (HttpResponseMessage response = await client.SendAsync(request))
               {
                  if (!response.IsSuccessStatusCode)
                  {
                     //handle according to established exception policy
                     throw new Exception($"Error retrieving tenant {_platformId} services");
                  }

                  __platformServiceCollection = await response.Content.ReadFromJsonAsync<PlatformServiceCollection>();
               }
            }
         }

         return __platformServiceCollection;
      }

      private async Task<UserInfo> GetUserInfo(IPassportAuthentication passportAuthentication, string _platformId)
      {
         UserInfo __userInfo = null;

         string platform3DSpaceServiceUrl = await GetPlatformServiceUrl(_platformId, "3DSpace");

         string url = $"{platform3DSpaceServiceUrl}/resources/modeler/pno/person?current=true&tenant={_platformId}&select=firstname&select=lastname&select=email&select=address&select=phone&select=isactive&select=company&select=collabspaces&select=preferredcredentials";

         // Initialize RestClient and Cookie Manager if Cookie Authentication
         using (HttpClientHandler httpClientHandler = new HttpClientHandler() { CookieContainer = passportAuthentication.GetCookieContainer() })
         using (HttpClient client = new HttpClient(httpClientHandler))
         {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
               if (!response.IsSuccessStatusCode)
               {
                  //handle according to established exception policy
                  throw new Exception("Error retrieving user information from 3DSpace service.");
               }

               __userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
            }
         }

         return __userInfo;
      }

      private async Task<string> GetPlatformServiceUrl(string _platformId, string _serviceName, bool _useCache = true)
      {
         if (!m_wrappedUserPassport.IsCookieAuthenticated) throw new AuthenticationException("Not authenticated.");

         if (_useCache && (m_userAccess == null)) throw new AuthenticationException("Cannot get cached user access.");

         //TODO: Regenerate UserAccess Information
         if ((!_useCache) || (m_userAccess == null))
         {
            m_userAccess = await GetPlatformAccessInformation(m_wrappedUserPassport);
         }

         PlatformAccess selectedPlatformAccess = null;

         foreach (PlatformAccess platformAccess in m_userAccess.Platforms)
         {
            if (platformAccess.Id == null) continue;

            if (platformAccess.Id.Equals(_platformId, StringComparison.InvariantCultureIgnoreCase))
            {
               selectedPlatformAccess = platformAccess;
               break;
            }
         }

         if (selectedPlatformAccess == null) throw new AuthenticationException($"User has no access to the requested {_platformId} platform.");

         if ((!_useCache) || (m_platformServiceCollection == null))
         {
            m_platformServiceCollection = await GetPlatformServices(m_wrappedUserPassport, _platformId);
         }

         IEnumerable<PlatformService> platformServices = null;

         foreach (PlatformServicesDescriptor platformServicesDescriptor in m_platformServiceCollection.Platforms)
         {
            if (platformServicesDescriptor.Id == _platformId)
            {
               platformServices = platformServicesDescriptor.Services;
               break;
            }
         }

         if (platformServices == null)
         {
            throw new Exception($"No platform services descriptor available for the {_platformId} platform.");
         }

         string __serviceUrl = null;

         foreach (PlatformService platformService in platformServices)
         {
            if (platformService.Id == null) continue;

            if (platformService.Name.Equals(_serviceName, StringComparison.InvariantCultureIgnoreCase))
            {
               __serviceUrl = platformService.Url;
               break;
            }
         }

         return __serviceUrl;
      }

      public async Task<UserInfo> GetUserTenantInfo()
      {
         const bool _useCache = true;

         if (!m_wrappedUserPassport.IsCookieAuthenticated) throw new AuthenticationException("Not authenticated.");

         if ((m_userInfo == null) || (!_useCache))
         {
            m_userInfo = await GetUserInfo(GetPassportAuthentication(), m_platformId);
         }

         return m_userInfo;
      }

      public async Task<string> Get3DSpaceUrl()
      {
         return await GetPlatformServiceUrl(m_platformId, "3DSpace", true);
      }
   }
}
