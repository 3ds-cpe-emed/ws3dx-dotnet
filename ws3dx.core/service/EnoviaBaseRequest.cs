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
using System.Text;
using System.Web;
using ws3dx.constants;
using ws3dx.utils;
using HttpRequestHeaders = ws3dx.constants.HttpRequestHeaders;

namespace ws3dx.core.service
{
   public class EnoviaBaseRequest : HttpRequestMessage
   {
      private string m_path = string.Empty;
      private string m_query = string.Empty;

      public EnoviaBaseRequest(HttpMethod _httpMethod, string _resource, string _tenant = null, string _securitycontext = null, string _csrftoken = null) : base(_httpMethod, new UriRelative(_resource))
      {
         m_path = _resource;

         SecurityContext = _securitycontext;
         CSRFToken = _csrftoken;
         Tenant = _tenant;

         if (SecurityContext != null)
         {
            Headers.Add(HttpRequestHeaders.SECURITY_CONTEXT, _securitycontext);
         }

         if (CSRFToken != null)
         {
            Headers.Add(HttpRequestHeaders.ENO_CSRF_TOKEN, _csrftoken);
         }

         if (Tenant != null)
         {
            AddQueryParameter(HttpRequestParams.TENANT, _tenant);
         }
      }

      public string SecurityContext { get; private set; }
      public string Tenant { get; private set; }
      public string CSRFToken { get; private set; }

      public void AddHeaders(IDictionary<string, string> _headers = null)
      {
         foreach (string headerKey in _headers.Keys)
         {
            Headers.Add(headerKey, _headers[headerKey]);
         }
      }

      public void AddQueryParameters(IDictionary<string, string> _queryParameters)
      {
         if (_queryParameters == null) return;

         IEnumerator<KeyValuePair<string, string>> queryParamEnumerator = _queryParameters.GetEnumerator();

         while (queryParamEnumerator.MoveNext())
         {
            KeyValuePair<string, string> queryParamPair = queryParamEnumerator.Current;

            AddQueryParameter(queryParamPair.Key, queryParamPair.Value);
         }
      }

      public void AddQueryParameter(string _name, string _value)
      {
         string urlEncodedValue = HttpUtility.UrlEncode(_value);

         if (m_query.IsNullOrEmpty())
         {
            m_query = string.Format("{0}={1}", _name, urlEncodedValue);
         }
         else
         {
            m_query += string.Format("&{0}={1}", _name, urlEncodedValue);
         }

         this.RequestUri = new UriRelative(string.Format("{0}?{1}", m_path, m_query));
      }

      public void AddJsonPayload(string _body)
      {
         this.Content = new StringContent(_body, Encoding.UTF8, MimeTypes.APPLICATION_JSON);
      }
   }
}
