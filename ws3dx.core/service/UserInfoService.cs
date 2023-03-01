// ------------------------------------------------------------------------------------------------------------------------------------
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
// ------------------------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

using ws3dx.authentication.data;
using ws3dx.core.data.impl;
using ws3dx.core.exception;

namespace ws3dx.core.service
{
   public class UserInfoService : EnoviaBaseService
   {
      public const string RESOURCE_EP = "/resources/modeler/pno/person";

      public UserInfoService(string _enoviaService, IPassportAuthentication _auth, string _tenant = null) : base(_enoviaService, _auth)
      {
         Tenant = _tenant;
         Current = true;

         IncludeCollaborativeSpaces = false;
         IncludePreferredCredentials = false;
      }

      public bool Current
      {
         get; set;
      }
      public bool IncludeCollaborativeSpaces
      {
         get; set;
      }

      public bool IncludePreferredCredentials
      {
         get; set;
      }

      public async Task<UserInfo> GetCurrentUserInfoAsync()
      {
         Dictionary<string, string> queryParameters = new Dictionary<string, string>();

         queryParameters.Add("current", "true");

         if (IncludeCollaborativeSpaces)
         {
            queryParameters.Add("select", "collabspaces");
         }
         if (IncludePreferredCredentials)
         {
            queryParameters.Add("select", "preferredcredentials");
         }

         HttpResponseMessage requestResponse = await this.GetAsync(RESOURCE_EP, queryParameters);

         if (requestResponse.StatusCode != System.Net.HttpStatusCode.OK)
         {
            //handle according to established exception policy
            throw new UserInfoException(requestResponse);
         }

         return await requestResponse.Content.ReadFromJsonAsync<UserInfo>();
      }

      public async Task<UserInfo> GetUserInfoByIdAsync(string _userId)
      {
         string userIdEncodedUTF8 = HttpUtility.UrlEncode(_userId);

         HttpResponseMessage requestResponse = await GetAsync(string.Format("{0}/{1}", RESOURCE_EP, userIdEncodedUTF8));

         if (requestResponse.StatusCode != System.Net.HttpStatusCode.OK)
         {
            //handle according to established exception policy
            throw new UserInfoException(requestResponse);
         }

         return await requestResponse.Content.ReadFromJsonAsync<UserInfo>();
      }
   }
}
