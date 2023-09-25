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
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ws3dx.core.serialization.registry;

using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization
{
   /// <summary>
   /// Main Deserializer class
   /// </summary>
   /// <typeparam name="T">Represents the inner type</typeparam>
   public abstract class CoreSchemaDeserializer<T>
   {
      private const string TYPE_PROPERTY_NAME = "type";

      #region type cache - for performance reasons
      private static readonly IDictionary<Type, IDictionary<string, PropertyInfo>> m_propsMapByType = new Dictionary<Type, IDictionary<string, PropertyInfo>>();
      private static readonly IDictionary<Type, bool> m_isGenericDictionaryByType = new Dictionary<Type, bool>();
      private static readonly IDictionary<Type, IDictionary<string, MethodInfo>> m_propConversionMethodsByType = new Dictionary<Type, IDictionary<string, MethodInfo>>();
      #endregion

      public abstract dynamic DeserializeElement(JsonElement _jsonElem, Type _deserialElemType);

      /// <summary>
      /// Deserialization main entry point
      /// </summary>
      /// <param name="jsonContent"></param>
      /// <returns></returns>
      public object Deserialize(string jsonContent)
      {
         return _Deserialize(jsonContent, typeof(T));
      }

      public IList<T> DeserializeCollection(string jsonContent, string _wrappingCollectionProperty, bool _ignoreIfPropertyNotFound = false)
      {
         using JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);

         JsonElement root = jsonDocument.RootElement;

         JsonElement memberRoot;

         // Fast forward to the items json property of the wrapping collection

         if (!root.TryGetProperty(_wrappingCollectionProperty, out memberRoot))
         {
            if (_ignoreIfPropertyNotFound) { return new List<T>();}

            throw new ArgumentException($"Cannot find '{_wrappingCollectionProperty}' property in json root wrapping collection.");
         }

         if (memberRoot.ValueKind != JsonValueKind.Array)
         {
            throw new ArgumentException($"Expecting '{_wrappingCollectionProperty}' property to be of array schema type.");
         }

         return (IList<T>)DeserializeElement(memberRoot, typeof(List<T>));
      }

      // ....
      public object _Deserialize(string jsonContent, Type _wrapperType)
      {
         using (JsonDocument jsonDocument = JsonDocument.Parse(jsonContent))
         {
            JsonElement root = jsonDocument.RootElement;

            return DeserializeElement(root, _wrapperType);
         }
      }

      private static Type GetDefaultClassImp(Type _type)
      {
         if (_type == null) throw new ArgumentNullException();

         Type typeClassImp = _type;

         if (_type.IsInterface)
         {
            typeClassImp = GlobalSchemaAttributeRegistry.GetDefaultImplementationClass(_type);
         }

         //e.g. _type = IList<IEngineeringMask>  typeClassImp = List<T>
         if (_type.IsGenericType && !_type.ContainsGenericParameters && typeClassImp.IsGenericType && typeClassImp.ContainsGenericParameters)
         {
            Type typeGenericArgument = _type.GetGenericArguments()[0];
            return typeClassImp.MakeGenericType(typeGenericArgument);
         }

         return typeClassImp;
      }

      /// <summary>
      /// Deserialization main entry point
      /// </summary>
      /// <typeparam name="S">Type of the wrapping collection (e.g. NlsLabeledItemSet) that is discarded in favour of an IEnumerator</typeparam>
      /// <param name="jsonContent"></param>
      /// <returns></returns>
      protected virtual dynamic DeserializeItem(JsonElement jsonElement, Type _type)
      {
         Type concreteType = _type;

         if (_type.IsGenericType || _type.IsInterface)
         {
            concreteType = GetDefaultClassImp(_type);
         }
         #region ---- TODO : REview if there is any logic that actually triggers this region
         //If it is primitive value and the primite values match ok - otherwise convert (or delegate conversion)
         if (SerializationUtils.IsPrimitiveValue(jsonElement.ValueKind))
         {
            return DeserializePrimitiveValue(jsonElement, concreteType);
         }
         else
         {
            #endregion
            switch (jsonElement.ValueKind)
            {
               case JsonValueKind.Object:
                  return DeserializeObjectFromClassImp(jsonElement, concreteType);
               case JsonValueKind.Array:
                  return DeserializeArray(jsonElement, concreteType);
            }
         }
         return null;
      }

      protected static bool TypeIsSupportedGenericDictionaryClass(Type _type, bool _useCache = true)
      {
         if (_useCache)
         {
            if (m_isGenericDictionaryByType.ContainsKey(_type))
            {
               return m_isGenericDictionaryByType[_type];
            }
         }

         bool __isGenericDictionaryClass = _TypeIsSupportedGenericDictionaryClass(_type);

         if (_useCache)
         {
            m_isGenericDictionaryByType[_type] = __isGenericDictionaryClass;
         }

         return __isGenericDictionaryClass;
      }

      // Check if type implements IDictionary<string,object>
      protected static bool _TypeIsSupportedGenericDictionaryClass(Type _type)
      {
         foreach (Type interfaceType in _type.GetInterfaces())
         {
            if (interfaceType.IsGenericType && (interfaceType.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
            {
               Type[] genArgs = interfaceType.GetGenericArguments();

               if ((genArgs.Length == 2) && genArgs[0].Equals(typeof(string)) && genArgs[1].Equals(typeof(object)))
               {
                  return true;
               }
            }
         }

         return false;
      }

      #region ----

      /// <summary>
      /// Deserializes a json object as a Dictionary<string,object> type
      /// </summary>
      /// <param name="_jsonObject"></param>
      /// <returns></returns>
      private static IDictionary<string, object> DeserializeAsObjectDictionary(Type _dictionaryType, JsonElement _jsonObject)
      {
         if (_jsonObject.ValueKind != JsonValueKind.Object) throw new ArgumentException("_jsonObject argument must be an object");

         IDictionary<string, object> __dictionary = (IDictionary<string, object>)Activator.CreateInstance(_dictionaryType);

         JsonElement.ObjectEnumerator jen = _jsonObject.EnumerateObject();

         while (jen.MoveNext())
         {
            JsonProperty jProp = jen.Current;

            string propName = jProp.Name;

            JsonElement propValue = jProp.Value;

            if (SerializationUtils.IsPrimitiveValue(propValue.ValueKind))
            {
               __dictionary[propName] = GetPrimitiveValue(propValue);
            }
            else
            {
               switch (jProp.Value.ValueKind)
               {
                  case JsonValueKind.Object:
                     __dictionary[propName] = DeserializeAsObjectDictionary(typeof(Dictionary<string, object>), propValue);
                     break;

                  case JsonValueKind.Array:
                     // If Deserializing as a dictionary we can assume the default type for holding an array
                     // A list of objects is the most flexible type
                     __dictionary[propName] = DeserializeAsList(propValue);
                     break;
               }
            }
         }

         return __dictionary;
      }

      /// <summary>
      /// Deserializes a json array as a List<object>
      /// </summary>
      /// <param name="_jsonArray"></param>
      /// <returns></returns>
      private static IList<object> DeserializeAsList(JsonElement _jsonArray)
      {
         if (_jsonArray.ValueKind != JsonValueKind.Array) throw new ArgumentException("_jsonArray must be an array");

         IList<object> __list = new List<object>();

         JsonElement.ArrayEnumerator jen = _jsonArray.EnumerateArray();

         while (jen.MoveNext())
         {
            JsonElement jObj = jen.Current;

            if (SerializationUtils.IsPrimitiveValue(jObj.ValueKind))
            {
               __list.Add(GetPrimitiveValue(jObj));
            }
            else
            {
               __list.Add(DeserializeAsObjectDictionary(typeof(Dictionary<string, object>), jObj));
            }
         }
         return __list;
      }

      protected dynamic DeserializeArray(JsonElement _jsonArray, Type _arrayImpType)
      {
         if (_jsonArray.ValueKind != JsonValueKind.Array) throw new ArgumentOutOfRangeException("expecting a json array");

         Type listType;
         Type listArgType;

         if (!TryGetEnumerableImpTypes(_arrayImpType, out listType, out listArgType)) return null;

         JsonElement.ArrayEnumerator aen = _jsonArray.EnumerateArray();

         IList __list = (IList)Activator.CreateInstance(listType);

         while (aen.MoveNext())
         {
            JsonElement curArrayElem = aen.Current;

            __list.Add(InvokeDeserializeItemForType(listArgType, curArrayElem));
         }

         return __list;
      }

      protected dynamic DeserializeObjectFromClassImp(JsonElement _jsonObject, Type _classImpType)
      {
         if (_jsonObject.ValueKind != JsonValueKind.Object) throw new ArgumentOutOfRangeException("expecting a json object");

         //At this point expecting class type. A json object <=> class instance
         //if (!_elemType.IsClass) throw new ArgumentOutOfRangeException("expecting a json object");

         Type classImpType = _classImpType;

         bool curTypeImplementsGenericDictionary = TypeIsSupportedGenericDictionaryClass(classImpType);

         dynamic __item = Activator.CreateInstance(classImpType);

         // Methods to CONVERT property values for deserialization, overriding direct attribute assignment.
         IDictionary<string, MethodInfo> jsonOverrideMethods = GetOverrideDeserializationMethods(classImpType);

         JsonElement.ObjectEnumerator jen = _jsonObject.EnumerateObject();

         while (jen.MoveNext())
         {
            JsonProperty jProp = jen.Current;

            string jPropName = jProp.Name;

            if (jsonOverrideMethods.ContainsKey(jPropName))
            {
               MethodInfo deserializeMethod = jsonOverrideMethods[jPropName];

               deserializeMethod.Invoke(__item, new object[] { jProp.Value });

               continue;
            }

            if (!TypeHasMatchingProperty(classImpType, jPropName))
            {
               if (curTypeImplementsGenericDictionary)
               {
                  SetDictionaryEntry((IDictionary<string, object>)__item, jProp, _classImpType);
               }
               else
               {
                  continue;
               }
            }

            PropertyInfo propInfo = GetPropertyInfo(classImpType, jPropName);

            //If it is primitive value and the primite values match ok - otherwise convert (or delegate conversion)
            if (SerializationUtils.IsPrimitiveValue(jProp.Value.ValueKind))
            {
               SetPrimitiveValue(__item, propInfo, jProp.Value);
            }
            else
            {
               Type propType = propInfo.PropertyType;

               JsonElement jsonElement = jProp.Value;

               switch (jProp.Value.ValueKind)
               {
                  case JsonValueKind.Object:

                     ProxyCollectionItemsAttribute proxyCollectionProperty = propInfo.GetCustomAttribute<ProxyCollectionItemsAttribute>();

                     if (proxyCollectionProperty != null)
                     {
                        JsonElement memberRoot;

                        if (!jsonElement.TryGetProperty(proxyCollectionProperty.JsonPropertyName, out memberRoot))
                        {
                           throw new ArgumentException($"Cannot find '{proxyCollectionProperty.JsonPropertyName}' property in proxy collection property '{propInfo.Name}' in type '{_classImpType.Name}'");
                        }

                        if (memberRoot.ValueKind != JsonValueKind.Array)
                        {
                           throw new ArgumentException($"Expecting '{proxyCollectionProperty.JsonPropertyName}' property to be of array schema type.");
                        }

                        propInfo.SetValue(__item, InvokeDeserializeItemForType(propType, memberRoot));
                     }
                     else
                     {
                        //Check if property type is of known IDictionary<string, object> in which case handle it
                        if (TypeIsSupportedGenericDictionaryClass(propType))
                        {
                           if (propType.IsInterface)
                           {
                              Type propClassImpType = GetDefaultClassImp(propType); //GlobalSchemaAttributeRegistry.GetDefaultImplementationClass(propType);
                              if (propClassImpType != null)
                              {
                                 propInfo.SetValue(__item, DeserializeAsObjectDictionary(propClassImpType, jProp.Value));
                              }
                              else
                              {
                                 throw new Exception($"No deserialization implementation class was found for the {propType.Name} interface.");
                              }
                           }
                           else
                           {
                              propInfo.SetValue(__item, DeserializeAsObjectDictionary(propType, jProp.Value));
                           }
                        }
                        else
                        {
                           if (propType.IsInterface)
                           {
                              //Get the default implementor class
                              //Type classDeserializerImp = GlobalSchemaAttributeRegistry.GetDefaultImplementationClass(propType);
                              Type classDeserializerImp = GetDefaultClassImp(propType);
                              if (classDeserializerImp != null)
                              {
                                 propInfo.SetValue(__item, InvokeDeserializeItemForType(classDeserializerImp, jProp.Value));
                              }
                              else
                              {
                                 throw new Exception($"No deserialization implementation class was found for the {propType.Name} interface.");
                              }
                           }
                           else
                           {
                              propInfo.SetValue(__item, InvokeDeserializeItemForType(propType, jProp.Value));
                           }
                        }
                     }

                     break;

                  case JsonValueKind.Array:
                     propInfo.SetValue(__item, DeserializeArray(jProp.Value, propType));
                     break;
               }
            }
         }

         return __item;
      }

      private static object InvokeDeserializeItemForType(Type _itemType, JsonElement _jsonElement)
      {
         object deserializerInst = MaskDeserializationHandler.GetCachedInstanceForType(_itemType);

         MethodInfo method = deserializerInst.GetType().GetMethod(nameof(DeserializeItem), BindingFlags.NonPublic | BindingFlags.Instance);

         return method.Invoke(deserializerInst, new object[] { _jsonElement, _itemType });
      }

      #endregion

      #region ----

      //...
      protected static bool IsEnumerableType(Type _type)
      {
         return _type.GetInterface(nameof(IEnumerable)) != null;
      }

      protected static bool TryGetEnumerableImpTypes(Type _propType, out Type __listType, out Type __listArgType)
      {
         __listType = _propType;
         __listArgType = typeof(object);

         if (!_propType.IsGenericType)
            return false;

         Type[] genericTypeArgs = _propType.GenericTypeArguments;

         if (genericTypeArgs?.Length == 1)
         {
            __listArgType = genericTypeArgs[0];
         }

         if (_propType.IsInterface)
         {
            __listType = typeof(List<>).MakeGenericType(__listArgType);
         }

         return true;
      }

      // Study an alternative to attributes for this purpose? e.g. events or an interface method?
      protected static IDictionary<string, MethodInfo> GetOverrideDeserializationMethods(Type _type, bool _useCache = true)
      {
         if (_useCache)
         {
            if (m_propConversionMethodsByType.ContainsKey(_type))
            {
               return m_propConversionMethodsByType[_type];
            }
         }

         Dictionary<string, MethodInfo> __jsonMappableMethods = new Dictionary<string, MethodInfo>();

         // Do Type Properties
         MethodInfo[] methods = _type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

         foreach (MethodInfo method in methods)
         {
            //Check if the property has a JSONPropertyName attribute assigned and used it instead.
            DeserializePropertyAttribute jsonPropertyNameAttribute = method.GetCustomAttribute<DeserializePropertyAttribute>();

            if (jsonPropertyNameAttribute == null) continue;

            string jPropNameParsed = jsonPropertyNameAttribute.PropertyName;

            __jsonMappableMethods.Add(jPropNameParsed, method);

            //TODO: Validate the expected method signature
            //...
         }

         if (_useCache)
         {
            m_propConversionMethodsByType[_type] = __jsonMappableMethods;
         }

         return __jsonMappableMethods;
      }
      #endregion

      #region Type properties cached methods

      /// <summary>
      /// Returns the type property value if it exists.
      /// </summary>
      /// <param name="_jsonObject"></param>
      /// <param name="__type"></param>
      /// <returns></returns>
      protected static bool TryGetTypePropertyValue(JsonElement _jsonObject, out string __type)
      {
         if (_jsonObject.ValueKind != JsonValueKind.Object) throw new ArgumentException($"_jsonObject argument should be a json object not a {_jsonObject.ValueKind}");

         __type = null;

         if (!IsKindOfItemType(_jsonObject)) return false;

         __type = GetItemType(_jsonObject);

         return true;
      }

      /// <summary>
      /// Checks if the json object has a type property.
      /// Items are by definition json objects that have a specific type.
      /// </summary>
      /// <param name="jsonElement"></param>
      /// <returns></returns>
      protected static bool IsKindOfItemType(JsonElement jsonElement)
      {
         JsonElement jsonValue;
         if (jsonElement.TryGetProperty(TYPE_PROPERTY_NAME, out jsonValue))
         {
            return jsonValue.ValueKind == JsonValueKind.String;
         }
         return false;
      }

      /// <summary>
      /// Get the value of the type property name (validation that it exists should be done with the IsItem method)
      /// </summary>
      /// <param name="jsonElement"></param>
      /// <returns></returns>
      protected static string GetItemType(JsonElement jsonElement)
      {
         return jsonElement.GetProperty(TYPE_PROPERTY_NAME).GetString();
      }

      /// <summary>
      /// Checks if the type has a property with a given name.
      /// </summary>
      /// <param name="_type"></param>
      /// <param name="_propertyName"></param>
      /// <returns></returns>
      protected static bool TypeHasMatchingProperty(Type _type, string _propertyName)
      {
         // Do Type Properties
         IDictionary<string, PropertyInfo> jsonMappableProperties = GetTypePropsDictionary(_type);
         return jsonMappableProperties.ContainsKey(_propertyName);
      }

      protected static PropertyInfo GetPropertyInfo(Type _itemType, string _propertyName)
      {
         // Do Type Properties
         IDictionary<string, PropertyInfo> jsonMappableProperties = GetTypePropsDictionary(_itemType);

         if (jsonMappableProperties == null) return null;

         if (!jsonMappableProperties.ContainsKey(_propertyName)) return null;

         return jsonMappableProperties[_propertyName];
      }

      /// <summary>
      /// Gets Type Properties from Reflection. Uses cached values for the second time onwards for performance reasons.
      /// </summary>
      /// <param name="_type"></param>
      /// <param name="_useCache"></param>
      /// <returns></returns>
      protected static IDictionary<string, PropertyInfo> GetTypePropsDictionary(Type _type, bool _useCache = true)
      {
         if (_useCache)
         {
            if (m_propsMapByType.ContainsKey(_type))
            {
               return m_propsMapByType[_type];
            }
         }

         Dictionary<string, PropertyInfo> __jsonMappableProperties = new Dictionary<string, PropertyInfo>();

         // Do Type Properties
         PropertyInfo[] properties = _type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

         foreach (PropertyInfo property in properties)
         {
            string jPropNameParsed = property.Name;

            //Check if the property has a JSONPropertyName attribute assigned and used it instead.
            JsonPropertyNameAttribute jsonPropertyNameAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();

            if (jsonPropertyNameAttribute != null)
               jPropNameParsed = jsonPropertyNameAttribute.Name;

            if (!__jsonMappableProperties.ContainsKey(jPropNameParsed))
            {
               __jsonMappableProperties.Add(jPropNameParsed, property);
            }
            else
            {
               if (property.DeclaringType == _type)
               {
                  __jsonMappableProperties[jPropNameParsed] = property;
               }
            }
         }

         if (_useCache)
         {
            m_propsMapByType[_type] = __jsonMappableProperties;
         }

         return __jsonMappableProperties;
      }

      #endregion

      #region  ---

      protected void SetDictionaryEntry(IDictionary<string, object> _dictionary, JsonProperty _jProperty, Type _itemType)
      {
         _dictionary.Add(_jProperty.Name, DeserializeElement(_jProperty.Value, _itemType));
      }

      private static object GetPrimitiveValue(JsonElement _value)
      {
         object __value = null;

         switch (_value.ValueKind)
         {
            case JsonValueKind.Undefined:
               break;

            case JsonValueKind.Null:
               break;

            case JsonValueKind.String:
               __value = _value.GetString();
               break;

            case JsonValueKind.Number:
               __value = _value.GetDecimal();
               break;

            case JsonValueKind.True:
               __value = true;
               break;

            case JsonValueKind.False:
               __value = false;
               break;
         }

         return __value;
      }

      private static void SetPrimitiveValue(object _item, PropertyInfo _property, JsonElement _value)
      {
         Type propType = _property.PropertyType;

         switch (_value.ValueKind)
         {
            //TODO: SET
            case JsonValueKind.Undefined:
               break;

            case JsonValueKind.Null:

               if (SerializationUtils.CanBeNull(propType))
               {
                  _property.SetValue(_item, null);
               }
               break;

            case JsonValueKind.String:

               string valueString = _value.GetString();

               if (propType.Equals(typeof(string)))
               {
                  _property.SetValue(_item, valueString);
               }
               else
               {
                  //Try convert the string to number if that is the case
                  _property.SetValue(_item, SerializationUtils.ConvertStringToPrimitive(propType, valueString));
               }

               break;

            case JsonValueKind.Number:
               SetNumber(_item, _property, _value);
               break;

            case JsonValueKind.True:
               SetBoolean(_item, _property, true);
               break;

            case JsonValueKind.False:
               SetBoolean(_item, _property, false);
               break;
         }
      }

      public static object GetDefault(Type type)
      {
         if (type.IsValueType)
         {
            return Activator.CreateInstance(type);
         }
         return null;
      }

      private dynamic DeserializePrimitiveValue(JsonElement _elem, Type _type)
      {
         dynamic __ret = GetDefault(_type);

         switch (_elem.ValueKind)
         {
            case JsonValueKind.Undefined:
               break;

            case JsonValueKind.Null:
               if (SerializationUtils.CanBeNull(_type))
               {
                  __ret = null;
               }
               break;

            case JsonValueKind.String:
               __ret = _elem.GetString();
               break;

            case JsonValueKind.Number:
               __ret = GetNumberValue(_elem, _type);
               break;

            case JsonValueKind.True:
               __ret = _elem.GetBoolean();
               break;

            case JsonValueKind.False:
               __ret = _elem.GetBoolean();
               break;
         }

         return __ret;
      }

      private static void SetBoolean(object _item, PropertyInfo _property, bool _value)
      {
         Type propType = _property.PropertyType;

         if (propType == typeof(bool) || (Nullable.GetUnderlyingType(propType) == typeof(bool)))
         {
            _property.SetValue(_item, _value);
         }
         else
         {
            if (propType == typeof(string))
            {
               if (_value)
               {
                  _property.SetValue(_item, bool.TrueString);
               }
               else
               {
                  _property.SetValue(_item, bool.FalseString);
               }
            }
         }
      }

      private static dynamic GetNumberValue(JsonElement _value, Type _propertyType)
      {
         Type parsedPropertyType = _propertyType;

         if (_propertyType.IsGenericType && _propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
         {
            parsedPropertyType = _propertyType.GetGenericArguments()[0];
         }

         if (_value.ValueKind != JsonValueKind.Number) throw new ArgumentOutOfRangeException(nameof(_value));

         if (parsedPropertyType == typeof(double))
         {
            return _value.GetDouble();
         }
         if (parsedPropertyType == typeof(float))
         {
            return _value.GetSingle();
         }
         if (parsedPropertyType == typeof(decimal))
         {
            return _value.GetDecimal();
         }
         if (parsedPropertyType == typeof(long))
         {
            return _value.GetInt64();
         }
         if (parsedPropertyType == typeof(int))
         {
            return _value.GetInt32();
         }
         if (parsedPropertyType == typeof(short))
         {
            return _value.GetInt16();
         }

         throw new ArgumentOutOfRangeException(nameof(parsedPropertyType));
      }

      private static void SetNumber(object _item, PropertyInfo _property, JsonElement _value)
      {
         _property.SetValue(_item, GetNumberValue(_value, _property.PropertyType));
      }
      #endregion
   }
}
