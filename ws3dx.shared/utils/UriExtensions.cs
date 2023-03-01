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

//Adapted to relative URI from https://stackoverflow.com/questions/14517798/append-values-to-query-string

using System;
using System.Web;

namespace ws3dx.utils
{
   public class UriRelative
   {
      private Uri m_uri;

      public UriRelative(string _string)
      {
         m_uri = new Uri(_string, UriKind.Relative);
      }

      private static void AddQueryParameterToUriBuilder(UriBuilder _uriBuilder, string _paramName, string _paramValue)
      {
         var query = HttpUtility.ParseQueryString(_uriBuilder.Query);
         query[_paramName] = _paramValue;
         _uriBuilder.Query = query.ToString();
      }

      public void AddQueryParameter(string paramName, string paramValue)
      {
         const string DUMMYBASEADDRESS = "https://google.com";

         UriBuilder uriBuilder = new UriBuilder(m_uri.ToAbsolute(DUMMYBASEADDRESS));

         AddQueryParameterToUriBuilder(uriBuilder, paramName, paramValue);

         m_uri = new Uri(uriBuilder.Uri.PathAndQuery, UriKind.Relative);
      }

      public static implicit operator Uri(UriRelative uriRel) => uriRel.m_uri;
   }

   public static class UriExtensions
   {
      public static string ToRelative(this Uri uri)
      {
         // TODO: Null-checks

         return uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString;
      }

      public static string ToAbsolute(this Uri uri, string baseUrl)
      {
         // TODO: Null-checks

         var baseUri = new Uri(baseUrl);

         return uri.ToAbsolute(baseUri);
      }

      public static string ToAbsolute(this Uri uri, Uri baseUri)
      {
         // TODO: Null-checks

         var relative = uri.ToRelative();

         if (Uri.TryCreate(baseUri, relative, out var absolute))
         {
            return absolute.ToString();
         }

         return uri.IsAbsoluteUri ? uri.ToString() : null;
      }
   }
}
