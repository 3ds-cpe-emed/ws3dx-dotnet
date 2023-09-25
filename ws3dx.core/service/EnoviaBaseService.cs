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

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using ws3dx.authentication.data;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.serialization;
using ws3dx.serialization.attribute;

namespace ws3dx.core.service
{
   public abstract class EnoviaBaseService
   {
      //Rest connection
      protected HttpClient m_client = null;
      private readonly HttpClientHandler m_clientHandler = new HttpClientHandler();

      private readonly IPassportAuthentication m_authentication = null;

      private readonly Uri m_enoviaHost = null;
      private readonly string m_enoviaService = null;

      protected const string MASK_PARAM_NAME = "$mask";
      protected const string FIELDS_PARAM_NAME = "$fields";
      protected const string INCLUDE_PARAM_NAME = "$include";

      protected virtual string GetMaskParamName() { return MASK_PARAM_NAME; }
      protected virtual string GetFieldsParamName() { return FIELDS_PARAM_NAME; }
      protected virtual string GetIncludeParamName() { return INCLUDE_PARAM_NAME; }

      protected bool HasMask { get { return !string.IsNullOrEmpty(GetMaskParamName()); } }

      //ENO_CSRF_TOKEN
      private CsrfTokenCache m_tokenCache = null;

      private const int CSRF_CACHE_INTERVAL = 55; //TODO Configuration. Currently hardcoded, use the CSRF TOKEN for 55 minutes.

      // -- PnO Resources --
      private const string CSRF_TOKEN = "/resources/v1/application/CSRF";

      public string SecurityContext { get; set; }

      //For cloud
      public string Tenant { get; set; }

      protected EnoviaBaseService(string enoviaService, IPassportAuthentication _passport)
      {
         m_authentication = _passport;

         Uri enoviaUri = new Uri(enoviaService);

         m_enoviaService = enoviaUri.LocalPath;

         string enoviaHost = string.Format("{0}://{1}", enoviaUri.Scheme, enoviaUri.Host);

         if (!enoviaUri.IsDefaultPort)
         {
            enoviaHost += $":{enoviaUri.Port}";
         }

         m_enoviaHost = new Uri(enoviaHost);

         // Initialize RestClient and Cookie Manager if Cookie Authentication
         m_client = new HttpClient(m_clientHandler) { BaseAddress = m_enoviaHost };

         if (Authentication.IsCookieAuthentication())
         {
            //..........
            m_clientHandler.CookieContainer = Authentication.GetCookieContainer();
         }
         else
         {
            m_clientHandler.CookieContainer = new CookieContainer();
         }
      }

      protected HttpClientHandler BaseClientHandler
      {
         get { return m_clientHandler; }
      }

      public string EnoviaServiceURL { get { return string.Format("{0}{1}", m_enoviaHost.ToString(), m_enoviaService); } }

      public IPassportAuthentication Authentication { get { return m_authentication; } }

      public bool IncludeTenant
      {
         get
         {
            return Tenant != null;
         }
      }

      protected string GetEndpointURL(string _endpoint)
      {
         if (m_enoviaService.EndsWith("/") && _endpoint.StartsWith("/"))
         {
            _endpoint = _endpoint.Substring(1, _endpoint.Length - 1);
         }

         return string.Format("{0}{1}", m_enoviaService, _endpoint);
      }

      #region CSRF Token Cache Management
      public async Task<string> GetCSRFToken(bool _useCache = true)
      {
         if (!_useCache || !IsTokenCacheValid())
         {
            //Refresh token cache
            m_tokenCache = await GetNewTokenCache();
         }

         return m_tokenCache.csrf.value;
      }

      private bool IsTokenCacheValid()
      {
         return _IsTokenCacheValid(m_tokenCache);
      }
      private bool _IsTokenCacheValid(CsrfTokenCache _cache)
      {
         if (_cache == null) return false;

         if (_cache.csrf == null) return false;

         System.TimeSpan timeInterval = (DateTime.Now - _cache.received);

         return timeInterval.TotalMinutes <= CSRF_CACHE_INTERVAL;
      }

      private async Task<CsrfTokenCache> GetNewTokenCache()
      {
         HttpResponseMessage tokenResponse = await GetAsync(CSRF_TOKEN);

         if (tokenResponse.StatusCode != HttpStatusCode.OK)
            throw new Exception(String.Format("Error getting 3DSpace CSRF token ({0}) ", tokenResponse.StatusCode));

         CsrfTokenResponse csrfTokenResponse = await tokenResponse.Content.ReadFromJsonAsync<CsrfTokenResponse>();

         CsrfTokenCache tokenCache = new CsrfTokenCache();
         tokenCache.received = DateTime.Now;
         tokenCache.csrf = csrfTokenResponse.csrf;

         return tokenCache;
      }

      #endregion

      public async Task<HttpResponseMessage> GetAsync(string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, bool _requiresCsrfToken = false, bool _useCsrfCache = true)
      {
         return await ExecuteAsyncMethod(HttpMethod.Get, _endpoint, _queryParameters, _headers, null, true, _requiresCsrfToken, _useCsrfCache);
      }

      public async Task<HttpResponseMessage> PostAsync(string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, string _body = null, bool _bodyIsJson = true, bool _requiresCsrfToken = true, bool _useCsrfCache = true)
      {
         return await ExecuteAsyncMethod(HttpMethod.Post, _endpoint, _queryParameters, _headers, _body, _bodyIsJson, _requiresCsrfToken, _useCsrfCache);
      }

      public async Task<HttpResponseMessage> PatchAsync(string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, string _body = null, bool _bodyIsJson = true, bool _requiresCsrfToken = true, bool _useCsrfCache = true)
      {
         return await ExecuteAsyncMethod(new HttpMethod("PATCH"), _endpoint, _queryParameters, _headers, _body, _bodyIsJson, _requiresCsrfToken, _useCsrfCache);
      }

      public async Task<HttpResponseMessage> DeleteAsync(string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, bool _requiresCsrfToken = true, bool _useCsrfCache = true)
      {
         return await ExecuteAsyncMethod(HttpMethod.Delete, _endpoint, _queryParameters, _headers, null, false, _requiresCsrfToken, _useCsrfCache);
      }

      public async Task<HttpResponseMessage> PutAsync(string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, string _body = null, bool _bodyIsJson = true, bool _requiresCsrfToken = true, bool _useCsrfCache = true)
      {
         return await ExecuteAsyncMethod(HttpMethod.Put, _endpoint, _queryParameters, _headers, _body, _bodyIsJson, _requiresCsrfToken, _useCsrfCache);
      }

      private async Task<HttpResponseMessage> ExecuteAsyncMethod(HttpMethod _method, string _endpoint, IDictionary<string, string> _queryParameters = null, IDictionary<string, string> _headers = null, string _body = null, bool _bodyIsJson = true, bool _requiresCsrfToken = true, bool _useCsrfCache = true)
      {
         EnoviaJsonRequest __request = await CreateJsonRequest(_method, _endpoint, IncludeTenant, _requiresCsrfToken, _useCsrfCache);

         if (_queryParameters != null)
         {
            foreach (string keyName in _queryParameters.Keys)
            {
               __request.AddQueryParameter(keyName, _queryParameters[keyName]);
            }
         }

         if (_headers != null)
            __request.AddHeaders(_headers);

         if (_body != null)
         {
            __request.AddJsonPayload(_body);
         }

         return await m_client.SendAsync(__request);
      }

      private async Task<EnoviaJsonRequest> CreateJsonRequest(HttpMethod _httpMethod, string _endpoint, bool _includeTenant = false, bool _requiresCsrfToken = false, bool _useCsrfCache = true)
      {
         string csrfToken = null;

         if (_requiresCsrfToken)
         {
            csrfToken = await GetCSRFToken(_useCsrfCache);
         }

         EnoviaJsonRequest request = new EnoviaJsonRequest(_httpMethod, GetEndpointURL(_endpoint), Tenant, SecurityContext, csrfToken);

         if (!Authentication.IsCookieAuthentication())
         {
            Authentication.AuthenticateRequest(request);
         }

         return request;
      }

      #region Deserialization 

      protected T Deserialize<T>(string _responseContent)
      {
         dynamic __output;

         System.Diagnostics.Debug.WriteLine($"Deserialize<{typeof(T).Name}>");
         System.Diagnostics.Debug.WriteLine(_responseContent);

         try
         {
            __output = MaskDeserializationHandler.Deserialize<T>(_responseContent);
         }
         catch (Exception _ex)
         {
            System.Diagnostics.Debug.WriteLine(_ex.Message);
            throw;
         }

         return __output;
      }

      protected IList<T> DeserializeCollection<T>(string _json, string _wrapperCollectionJsonPropertyName, bool _ignoreIfPropertyNotFound = false)
      {
         IList<T> __output = null;

         System.Diagnostics.Debug.WriteLine($"DeserializeCollection<{typeof(T).Name}>");
         System.Diagnostics.Debug.WriteLine(_json);
         System.Diagnostics.Debug.WriteLine($"_wrapperCollectionJsonPropertyName={_wrapperCollectionJsonPropertyName}");

         try
         {
            __output = MaskDeserializationHandler.DeserializeCollection<T>(_json, _wrapperCollectionJsonPropertyName, _ignoreIfPropertyNotFound);
         }
         catch (Exception _ex)
         {
            System.Diagnostics.Debug.WriteLine(_ex.Message);
            throw;
         }

         return __output;
      }

      #endregion

      #region GET
      private async Task<string> Get<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         //mask
         Dictionary<string, string> requestQueryParams = new Dictionary<string, string>();

         if (HasMask)
         {
            requestQueryParams.Add(GetMaskParamName(), MaskNameUtils.GetMaskNameFromType(typeof(T)));
         }

         if (queryParams != null)
         {
            foreach (string queryParamName in queryParams.Keys)
            {
               requestQueryParams.Add(queryParamName, queryParams[queryParamName]);
            }
         }

         //Send the Request
         HttpResponseMessage response = await GetAsync(_requestUri, requestQueryParams, _headers: headerParams);

         //Handle the Response
         if (response.StatusCode != System.Net.HttpStatusCode.OK)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         return await response.Content.ReadAsStringAsync();
      }

      protected async Task<T> GetIndividual<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         string responseContent = await Get<T>(_requestUri, queryParams, headerParams);

         return MaskDeserializationHandler.Deserialize<T>(responseContent);
      }

      protected async Task<T> GetIndividualFromResponseDataProperty<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         return await GetIndividualFromResponseArrayProperty<T>(_requestUri, "data", queryParams, headerParams);
      }

      protected async Task<T> GetIndividualFromResponseMemberProperty<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         return await GetIndividualFromResponseArrayProperty<T>(_requestUri, "member", queryParams, headerParams);
      }

      protected async Task<T> GetIndividualFromResponseArrayProperty<T>(string _requestUri, string _wrappingCollectionArrayPropertyName, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         IList<T> returnSet = await GetCollectionFromResponseArrayProperty<T>(_requestUri, _wrappingCollectionArrayPropertyName, queryParams, headerParams);

         if ((returnSet == null) || (returnSet.Count == 0)) return default;

         return returnSet[0];
      }

      protected async Task<IList<T>> GetCollectionFromResponseMemberProperty<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         return await GetCollectionFromResponseArrayProperty<T>(_requestUri, "member", queryParams, headerParams);
      }

      protected async Task<IList<T>> GetCollectionFromResponseResultsProperty<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         return await GetCollectionFromResponseArrayProperty<T>(_requestUri, "results", queryParams, headerParams);
      }

      protected async Task<IList<T>> GetCollectionFromResponseDataProperty<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         return await GetCollectionFromResponseArrayProperty<T>(_requestUri, "data", queryParams, headerParams);
      }

      protected async Task<IList<T>> GetCollectionFromResponseArrayProperty<T>(string _requestUri, string _wrappingCollectionArrayPropertyName, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         string responseContent = await Get<T>(_requestUri, queryParams, headerParams);

         return DeserializeCollection<T>(responseContent, _wrappingCollectionArrayPropertyName);
      }
      #endregion

      #region POST

      protected async Task<T> PostIndividualNoMask<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await PostNoMask(_requestUri, _payload, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<IList<T>> PostCollectionNoMaskFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostCollectionNoMaskFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }

      protected async Task<IList<T>> PostCollectionNoMaskFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await PostNoMask(_requestUri, _payload, queryParams, headerParams);

         return DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);
      }

      private async Task<string> PostNoMask(string _requestUri, object _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         //mask
         Dictionary<string, string> requestQueryParams = new Dictionary<string, string>();

         if (queryParams != null)
         {
            foreach (string queryParamName in queryParams.Keys)
            {
               requestQueryParams.Add(queryParamName, queryParams[queryParamName]);
            }
         }

         string serializedPayload = SerializationHandler.Serialize(_payload, SerializationContext.CREATE);

         //Send the Request
         HttpResponseMessage response = await PostAsync(_requestUri, _body: serializedPayload, _queryParameters: requestQueryParams, _headers: headerParams);

         //Handle the Response
         if (response.StatusCode != System.Net.HttpStatusCode.OK)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         return await response.Content.ReadAsStringAsync();
      }

      private async Task<string> Post<T>(string _requestUri, object _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         //mask
         Dictionary<string, string> requestQueryParams = new Dictionary<string, string>();

         if (HasMask)
         {
            requestQueryParams.Add(GetMaskParamName(), MaskNameUtils.GetMaskNameFromType(typeof(T)));
         }

         if (queryParams != null)
         {
            foreach (string queryParamName in queryParams.Keys)
            {
               requestQueryParams.Add(queryParamName, queryParams[queryParamName]);
            }
         }

         string serializedPayload = SerializationHandler.Serialize(_payload, SerializationContext.CREATE);

         //Send the Request
         HttpResponseMessage response = await PostAsync(_requestUri, _body: serializedPayload, _queryParameters: requestQueryParams, _headers: headerParams);

         //Handle the Response
         if (!response.IsSuccessStatusCode)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         return await response.Content.ReadAsStringAsync();
      }

      protected async Task<T> PostIndividual<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         string responseContent = await Post<T>(_requestUri, null, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<T> PostIndividual<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Post<T>(_requestUri, _payload, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<T> PostIndividualFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostIndividualFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }

      protected async Task<T> PostIndividualFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostIndividualFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }

      protected async Task<T> PostIndividualFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Post<T>(_requestUri, _payload, queryParams, headerParams);

         IList<T> returnSet = DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);

         if ((returnSet == null) || (returnSet.Count == 0)) return default;

         return returnSet[0];
      }

      protected async Task<T> PostGroup<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Post<T>(_requestUri, _payload, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<IList<T>> PostCollectionFromResponseResourcesProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostCollectionFromResponseCollectionProperty<T, P>(_requestUri, "resources", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PostCollectionFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostCollectionFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PostCollectionFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostCollectionFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PostCollectionFromResponseResultsProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PostCollectionFromResponseCollectionProperty<T, P>(_requestUri, "results", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PostCollectionFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Post<T>(_requestUri, _payload, queryParams, headerParams);

         return DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);
      }

      protected async Task<(IList<T>, IList<string>)> PostBulkCollection<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Post<T>(_requestUri, _payload, queryParams, headerParams);

         IList<T>  memberList = DeserializeCollection<T>(responseContent, "member");

         IList<string> nonMemberList = DeserializeCollection<string>(responseContent, "nonmembers", true);

         return (memberList, nonMemberList);
      }
      #endregion

      #region PATCH
      private async Task<string> Patch(string _requestUri, object _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         string serializedPayload = SerializationHandler.Serialize(_payload, SerializationContext.PATCH);

         //Send the Request
         HttpResponseMessage response = await PatchAsync(_requestUri, _body: serializedPayload, _queryParameters: queryParams, _headers: headerParams);

         //Handle the Response
         if (response.StatusCode != System.Net.HttpStatusCode.OK)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         return await response.Content.ReadAsStringAsync();
      }

      protected async Task<T> PatchIndividual<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         string responseContent = await Patch(_requestUri, null, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<T> PatchIndividual<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Patch(_requestUri, _payload, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<T> PatchIndividualFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchIndividualFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }

      protected async Task<T> PatchIndividualFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchIndividualFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }
      protected async Task<T> PatchIndividualFromResponseResultsProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchIndividualFromResponseCollectionProperty<T, P>(_requestUri, "results", _payload, queryParams, headerParams);
      }

      protected async Task<T> PatchIndividualFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Patch(_requestUri, _payload, queryParams, headerParams);

         IList<T> returnSet = DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);

         if ((returnSet == null) || (returnSet.Count == 0)) return default;

         return returnSet[0];
      }

      protected async Task<IList<T>> PatchCollectionFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchCollectionFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PatchCollectionFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchCollectionFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PatchCollectionFromResponseResultsProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PatchCollectionFromResponseCollectionProperty<T, P>(_requestUri, "results", _payload, queryParams, headerParams);
      }
      protected async Task<IList<T>> PatchCollectionFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Patch(_requestUri, _payload, queryParams, headerParams);

         return DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);
      }
      #endregion

      #region PUT
      protected async Task<string> Put(string _requestUri, object _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         string serializedPayload = SerializationHandler.Serialize(_payload, SerializationContext.PATCH);

         //Send the Request
         HttpResponseMessage response = await PutAsync(_requestUri, _body: serializedPayload, _queryParameters: queryParams, _headers: headerParams);

         //Handle the Response
         if (response.StatusCode != System.Net.HttpStatusCode.OK)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         return await response.Content.ReadAsStringAsync();
      }

      protected async Task<T> PutIndividual<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         string responseContent = await Put(_requestUri, null, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }

      protected async Task<T> PutIndividual<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Put(_requestUri, _payload, queryParams, headerParams);

         return Deserialize<T>(responseContent);
      }
      protected async Task<T> PutIndividualFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutIndividualFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }

      protected async Task<T> PutIndividualFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutIndividualFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }

      protected async Task<T> PutIndividualFromResponseResultsProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutIndividualFromResponseCollectionProperty<T, P>(_requestUri, "results", _payload, queryParams, headerParams);
      }

      protected async Task<T> PutIndividualFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Put(_requestUri, _payload, queryParams, headerParams);

         IList<T> returnSet = DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);

         if ((returnSet == null) || (returnSet.Count == 0)) return default;

         return returnSet[0];
      }

      protected async Task<IList<T>> PutCollectionFromResponseDataProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutCollectionFromResponseCollectionProperty<T, P>(_requestUri, "data", _payload, queryParams, headerParams);
      }

      protected async Task<IList<T>> PutCollectionFromResponseResultsProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutCollectionFromResponseCollectionProperty<T, P>(_requestUri, "results", _payload, queryParams, headerParams);
      }

      protected async Task<IList<T>> PutCollectionFromResponseMemberProperty<T, P>(string _requestUri, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         return await PutCollectionFromResponseCollectionProperty<T, P>(_requestUri, "member", _payload, queryParams, headerParams);
      }

      protected async Task<IList<T>> PutCollectionFromResponseCollectionProperty<T, P>(string _requestUri, string _responseCollectionPropertyName, P _payload = null, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null) where P : class
      {
         string responseContent = await Put(_requestUri, _payload, queryParams, headerParams);

         return DeserializeCollection<T>(responseContent, _responseCollectionPropertyName);
      }
      #endregion

      #region DELETE
      protected async Task<T> DeleteIndividual<T>(string _requestUri, IDictionary<string, string> queryParams = null, IDictionary<string, string> headerParams = null)
      {
         if (_requestUri == null) throw new ArgumentNullException("_requestUri is missing");

         //Send the Request
         //Delete should not have a body / payload (see https://www.rfc-editor.org/rfc/rfc9110.html#name-delete)
         HttpResponseMessage response = await DeleteAsync(_requestUri, _queryParameters: queryParams, _headers: headerParams);

         //Handle the Response
         if (response.StatusCode != System.Net.HttpStatusCode.OK)
         {
            // handle according to established exception policy
            throw (new HttpResponseException(response));
         }

         string responseContent = await response.Content.ReadAsStringAsync();

         return Deserialize<T>(responseContent);
      }
      #endregion
   }
}
