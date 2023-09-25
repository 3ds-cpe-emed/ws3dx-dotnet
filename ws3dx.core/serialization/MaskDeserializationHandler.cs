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

namespace ws3dx.core.serialization
{
   /// <summary>
   /// Entry point for deserialization. Holds cached instances of deserializers by type.
   /// </summary>
   public static class MaskDeserializationHandler
   {
      /// <summary>
      /// static map of deserializers by type
      /// </summary>
      private static readonly Dictionary<Type, object> m_deserializerByTypeMap = new Dictionary<Type, object>();

      /// <summary>
      /// Returns an cached instance of a deserializer based on its type. It creates it if it doesn't exist.
      /// </summary>
      /// <param name="_type"></param>
      /// <returns></returns>
      internal static object GetCachedInstanceForType(Type _type)
      {
         if (!m_deserializerByTypeMap.ContainsKey(_type))
         {
            Type serializerType = typeof(MaskSchemaDeserializer<>).MakeGenericType(_type);

            m_deserializerByTypeMap.Add(_type, Activator.CreateInstance(serializerType));
         }

         return m_deserializerByTypeMap[_type];
      }

      public static dynamic DeserializeCollection<T>(string _json, string _wrapperCollectionJsonPropertyName, bool _ignoreIfPropertyNotFound = false)
      {
         MaskSchemaDeserializer<T> schemaDeserializer = (MaskSchemaDeserializer<T>)GetCachedInstanceForType(typeof(T));

         return schemaDeserializer.DeserializeCollection(_json, _wrapperCollectionJsonPropertyName, _ignoreIfPropertyNotFound);
      }

      public static dynamic Deserialize<T>(string _json)
      {
         MaskSchemaDeserializer<T> schemaDeserializer = (MaskSchemaDeserializer<T>)GetCachedInstanceForType(typeof(T));

         return schemaDeserializer.Deserialize(_json);
      }
   }
}