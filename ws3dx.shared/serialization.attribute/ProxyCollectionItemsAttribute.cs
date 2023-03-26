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

namespace ws3dx.serialization.attribute
{
   /// <summary>
   /// Jumps over (bypasses) an intermediate (proxy) class that is just used in json
   /// as a "dummy collector" (e.g. { totalItems=2 , member = [ {...}, {...} ] } )
   /// and going directly to its array
   /// </summary>
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
   public class ProxyCollectionItemsAttribute : Attribute
   {
      public string JsonPropertyName { get; }

      public ProxyCollectionItemsAttribute(string jsonPropertyName)
      {
         JsonPropertyName = jsonPropertyName;
      }
   }
}
