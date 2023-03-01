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

namespace ws3dx.authentication.data.impl.passport
{
   public class Passport
   {
      private Uri m_passportHost = null;
      private string m_passportService = null;
      private Uri m_passportUri = null;

      protected Passport(string passportUrl)
      {
         if (!passportUrl.EndsWith(@"/"))
         {
            passportUrl += @"/";
         }

         m_passportUri = new Uri(passportUrl);

         m_passportService = m_passportUri.LocalPath;

         string passportHost = string.Format("{0}://{1}", m_passportUri.Scheme, m_passportUri.Host); ;

         if (!m_passportUri.IsDefaultPort)
         {
            passportHost += $":{m_passportUri.Port}";
         }

         m_passportHost = new Uri(passportHost);

         return;
      }

      protected Uri PassportHost { get { return m_passportHost; } }

      protected Uri PassportUri { get { return m_passportUri; } }

      protected string GetEndpointURL(string _endpoint)
      {
         if (m_passportService.EndsWith(@"/") && _endpoint.StartsWith(@"/"))
         {
            _endpoint = _endpoint.Substring(1, _endpoint.Length - 1);
         }

         return string.Format("{0}{1}", m_passportService, _endpoint);
      }
   }
}
