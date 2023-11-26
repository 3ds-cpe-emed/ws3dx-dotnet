// ------------------------------------------------------------------------------------------------------------------------------------
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

using System.Text.Json;
using System;
using ws3dx.core.serialization.registry;
using System.Collections.Generic;

namespace ws3dx.core.serialization
{
   public class TypeSchemaDeserializer<T> : CoreSchemaDeserializer<T>
   {
      public override dynamic DeserializeElement(JsonElement _jsonElem, Type _deserializedElemType)
      {
        Type deserializationElementType  = GetDeserializationType(_jsonElem, _deserializedElemType);

         return DeserializeItem(_jsonElem, deserializationElementType);
      }

      protected Type GetDeserializationType(JsonElement _jsonElem, Type _baseType)
      {
         if (!GlobalSchemaAttributeRegistry.TypeSchemaRegistry.HasBaseType(_baseType)) return _baseType;

         ICollection<string> propertyNames = GlobalSchemaAttributeRegistry.TypeSchemaRegistry.GetRegisteredPropertyNamesForBaseType(_baseType);

         foreach (string propertyName in propertyNames)
         {
            if (IsKindOfItemProperty(_jsonElem, propertyName))
            {
               JsonElement jsonPropertyElement = _jsonElem.GetProperty(propertyName);

               object propertyValue = null;
               switch (jsonPropertyElement.ValueKind)
               {
                 case JsonValueKind.String:
                     propertyValue = jsonPropertyElement.GetString();
                     break;

                 case JsonValueKind.Number:

                     propertyValue=jsonPropertyElement.GetDecimal();
                     break;

                  case JsonValueKind.True:
                  case JsonValueKind.False:
                     propertyValue = jsonPropertyElement.GetBoolean();
                     break;
               }

               if (propertyValue == null)
                  return _baseType;

               if (!GlobalSchemaAttributeRegistry.TypeSchemaRegistry.HasPropertyValue(_baseType, propertyName, propertyValue)) 
                  return _baseType;

               return GlobalSchemaAttributeRegistry.TypeSchemaRegistry.GetTypeForPropertyValue(_baseType, propertyName, propertyValue);
            }
         }

         return _baseType;

      }

      /// <summary>
      /// Checks if the json object has a type property.
      /// Items are by definition json objects that have a specific type.
      /// </summary>
      /// <param name="jsonElement"></param>
      /// <returns></returns>
      protected static bool IsKindOfItemProperty(JsonElement jsonElement, string _propertyName)
      {
         if (jsonElement.TryGetProperty(_propertyName, out _))
         {
            return true;
         }
         return false;
      }
   }
}
