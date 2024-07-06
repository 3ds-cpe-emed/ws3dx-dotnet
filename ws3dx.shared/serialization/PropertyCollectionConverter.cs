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
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ws3dx.serialization
{
   public interface IPropertyCollectionConverter
   {
      Type GenericTypeForCollection { get; set; }
      Type CollectionWrapperType { get; set; }
   }

   public class PropertyCollectionConverter<T> : JsonConverter<T>, IPropertyCollectionConverter
   {
      public Type GenericTypeForCollection { get; set; }
      public Type CollectionWrapperType { get; set; }

      public override bool CanConvert(Type typeToConvert)
      {
         if (!typeToConvert.IsAssignableTo(typeof(IEnumerable))) return false;

         Type genericType = typeToConvert.GenericTypeArguments[0];

         return genericType == GenericTypeForCollection;
      }

      public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
         Type collectionWrapperType = CollectionWrapperType.MakeGenericType(GenericTypeForCollection);

         dynamic deserializedItemCollection = JsonSerializer.Deserialize(ref reader, collectionWrapperType, options);

         return (T)(deserializedItemCollection.Items);
      }

      public override void Write(Utf8JsonWriter _writer, T _type, JsonSerializerOptions _options)
      {
         JsonSerializer.Serialize(_writer, _type, _options);
      }
   }
}
