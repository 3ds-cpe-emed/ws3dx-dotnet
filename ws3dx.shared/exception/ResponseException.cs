// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2022 Dassault Systèmes - CPE EMED
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
using System.Net.Http;
using System.Threading.Tasks;

using ws3dx.utils;

namespace ws3dx.exception
{
   public class ResponseException : Exception
   {
      public ResponseException() : base()
      {
      }

      public ResponseException(string _message) : base(_message)
      {
      }

      public ResponseException(string _message, Exception _innerException) : base(_message, _innerException)
      {
      }

      public ResponseException(HttpResponseMessage _response)
      {
         Response = _response;
      }

      public HttpResponseMessage Response { get; }

      public async Task<string> GetErrorMessage()
      {
         HttpResponseMessage response = this.Response;

         if (response == null) return string.Empty;

         string reasonPhrase = response.ReasonPhrase;

         if (!reasonPhrase.IsNullOrEmpty())
         {
            return reasonPhrase;
         }
         else
         {
            return await response.Content.ReadAsStringAsync();
         }
      }
   }
}
