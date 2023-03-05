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
using System.Reflection;
using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization.registry
{
   class ResponseCollectionSchemaRegistry
   {
      private readonly IDictionary<Type, ResponseCollectionSchemaHelper> m_responseCollectionSchemaByType = new Dictionary<Type, ResponseCollectionSchemaHelper>();

      public void Parse(IList<Assembly> _assemblies)
      {
         foreach (Assembly assembly in _assemblies)
         {
            foreach (ResponseCollectionSchemaHelper responseCollectionSchema in FindResponseCollectionSchemas(assembly))
            {
               Type collectionType = responseCollectionSchema.CollectionType;

               //This is actually an error as logically there should be only one ResponseCollectionSchemaHelper per type
               if (m_responseCollectionSchemaByType.ContainsKey(collectionType)) continue;

               m_responseCollectionSchemaByType.Add(collectionType, responseCollectionSchema);
            }
         }
      }

      public bool IsResponseCollectionSchema(Type _type)
      {
         return m_responseCollectionSchemaByType.ContainsKey(_type);
      }

      public ResponseCollectionSchemaHelper GetResponseCollection(Type _type)
      {
         if (!m_responseCollectionSchemaByType.ContainsKey(_type)) return null;

         return m_responseCollectionSchemaByType[_type];
      }

      private IList<ResponseCollectionSchemaHelper> FindResponseCollectionSchemas(Assembly _assembly)
      {
         IList<ResponseCollectionSchemaHelper> __output = new List<ResponseCollectionSchemaHelper>();

         foreach (Type type in _assembly.GetTypes())
         {
            foreach (PropertyInfo propInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
               ResponseCollectionItemsAttribute attributeData = propInfo.GetCustomAttribute<ResponseCollectionItemsAttribute>(true);

               if (attributeData == null) continue;

               string jsonPropertyName = attributeData.JsonPropertyName;

               ResponseCollectionSchemaHelper collectionSchemaHelper = new ResponseCollectionSchemaHelper()
               {
                  CollectionType = type,
                  CollectionItemsJsonPropertyName = jsonPropertyName,
                  CollectionItemsType = propInfo.PropertyType
               };

               __output.Add(collectionSchemaHelper);
            }
         }
         return __output;
      }
   }
}
