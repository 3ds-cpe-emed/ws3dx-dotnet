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
using System.Collections.Generic;
using System.Text.Json;

using JsonElement = System.Text.Json.JsonElement;

namespace ws3dx.core.serialization
{
   //Implementation inspired from : https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter?pivots=dotnet-core-3-1
   public class JsonGenericCollectionDeserializer : MaskSchemaDeserializer<JsonElement>
   {
      private static JsonGenericCollectionDeserializer m_instance = null;

      public static JsonGenericCollectionDeserializer Instance
      {
         get
         {
            m_instance ??= new JsonGenericCollectionDeserializer();
            return m_instance;
         }
      }

      public override IList<JsonElement> DeserializeCollection(string jsonContent, string _wrappingCollectionProperty, bool _ignoreIfPropertyNotFound = false)
      {
         JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);

        JsonElement root = jsonDocument.RootElement;

         // Fast forward to the items json property of the wrapping collection

         if (!root.TryGetProperty(_wrappingCollectionProperty, out JsonElement memberRoot))
         {
            if (_ignoreIfPropertyNotFound) { return new List<JsonElement>(); }

            throw new ArgumentException($"Cannot find '{_wrappingCollectionProperty}' property in json root wrapping collection.");
         }

         if (memberRoot.ValueKind != JsonValueKind.Array)
         {
            throw new ArgumentException($"Expecting '{_wrappingCollectionProperty}' property to be of array schema type.");
         }

         List<JsonElement> __jsonelementlist = new List<JsonElement>();

         using JsonElement.ArrayEnumerator jsonarrayenumerator = memberRoot.EnumerateArray();

         jsonarrayenumerator.Reset();

         while (jsonarrayenumerator.MoveNext())
         {
            __jsonelementlist.Add(jsonarrayenumerator.Current);
         }

         return __jsonelementlist;
      }
   }
}
