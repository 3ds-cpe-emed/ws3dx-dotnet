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
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ws3dx.client;
using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization
{
   public abstract class SerializationHandler
   {
      static JsonWriterOptions m_options = new JsonWriterOptions
      {
         //Indented = true
      };

      #region cache - for performance reasons
      static IDictionary<Type, IDictionary<string, PropertyInfo>> m_propsMapByType = new Dictionary<Type, IDictionary<string, PropertyInfo>>();

      static IDictionary<Type, IDictionary<string, MethodInfo>> m_propConversionMethodsByType = new Dictionary<Type, IDictionary<string, MethodInfo>>();

      static IDictionary<PropertyInfo, IDictionary<SerializationContext, string>> m_serializationPropNameByPropInfo = new Dictionary<PropertyInfo, IDictionary<SerializationContext, string>>();

      #endregion

      private static void SerializeObject(Utf8JsonWriter _writer, object _object, SerializationContext _serializationContext)
      {
         if (_object == null) throw new ArgumentNullException("_object cannot be null");

         #region Start Json Object
         _writer.WriteStartObject();

         try
         {
            Type objectType = _object.GetType();

            IDictionary<string, MethodInfo> overrideMethods = GetOverrideSerializationMethods(objectType);

            PropertyInfo[] propInfoArray = null;

            //TODO: Review this... Simplify - refactor
            if (_serializationContext == SerializationContext.PATCH)
            {
               IList<PropertyInfo> propInfoList = new List<PropertyInfo>();

               if (objectType.GetInterface(nameof(ITrackPropertyChanging)) != null)
               {
                  //Get Modified Properties only
                  IEnumerator<IPropertyUpdate> propertyChanges = ((ITrackPropertyChanging)_object).GetChanges();

                  while (propertyChanges.MoveNext())
                  {
                     IPropertyUpdate propUpd = propertyChanges.Current;

                     PropertyInfo propInfo = objectType.GetProperty(propUpd.PropertyName);

                     propInfoList.Add(propInfo);
                  }
               }

               // Add SerializationContext.Patch properties here as well ... (e.g. CESTAMP) review if there is a better way
               PropertyInfo[] propInfoArray2 = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

               foreach (PropertyInfo propInfo in propInfoArray2)
               {
                  if (propInfoList.Contains(propInfo)) continue;

                  if (HasSerializationContextAttribute(propInfo, _serializationContext))
                  {
                     propInfoList.Add(propInfo);
                  }
               }

               propInfoArray = new PropertyInfo[propInfoList.Count];

               propInfoList.CopyTo(propInfoArray, 0);
            }
            else
            {
               propInfoArray = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }

            foreach (PropertyInfo propInfo in propInfoArray)
            {
               string propertyName = GetJsonPropertyName(propInfo, _serializationContext);

               Type propertyType = propInfo.PropertyType;

               object val = null;

               if (overrideMethods.ContainsKey(propertyName))
               {
                  MethodInfo overrideMethodInfo = overrideMethods[propertyName];

                  val = overrideMethodInfo.Invoke(_object, null);

                  //TODO: Is there a better way of doing this?
                  if (val != null)
                  {
                     propertyType = val.GetType();
                  }
               }
               else
               {
                  val = propInfo.GetValue(_object);
               }

               //TODO: Cache this for the type
               JsonIgnoreAttribute jsonIgnoreAttribute = propInfo.GetCustomAttribute<JsonIgnoreAttribute>();

               if ((val == null) && (jsonIgnoreAttribute != null) && (jsonIgnoreAttribute.Condition == JsonIgnoreCondition.WhenWritingNull))
               {
                  continue;
               }

               _writer.WritePropertyName(propertyName);
               //SET VALUE
               WriteValue(_writer, propertyType, val, _serializationContext);
            }
         }
         finally
         {
            _writer.WriteEndObject();
         }
         #endregion
      }

      //TODO: CHECK if we can remove _valType and use _val.GetType inside the function instead ...
      private static void WriteValue(Utf8JsonWriter _writer, Type _valType, object _val, SerializationContext _serializationContext)
      {
         // https://docs.microsoft.com/en-us/dotnet/api/system.type.isclass?view=netcore-3.1
         // Gets a value indicating whether the Type is a class or a delegate;
         // that is, not a value type or interface.
         if ((_valType.IsClass) || (_valType.IsInterface))
         {
            if (_valType == typeof(string))
            {
               _writer.WriteStringValue((string)_val);
            }
            else
            {
               //Serialize Array <=> IEnumerable
               if (SerializationUtils.IsEnumeratorType(_valType))
               {
                  //TODO: Check at this point val cannot be null
                  #region array property
                  SerializeArray(_writer, (IEnumerable)_val, _serializationContext);
                  #endregion
               }
               else
               {
                  #region json object property
                  SerializeObject(_writer, _val, _serializationContext);
                  #endregion
               }
            }
         }
         else
         {
            //Nullable is not interpreted as a class nor as an interface
            //Case in which the value
            if (SerializationUtils.IsNullable(_valType) || (_valType.IsPrimitive))
            {
               //This check is the val is of a Nullable type and retrieves the underlying type
               // https://docs.microsoft.com/en-us/dotnet/api/system.type.isprimitive?view=netcore-3.1
               // The primitive types are Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64,
               // IntPtr, UIntPtr, Char, Double, and Single
               SerializationUtils.WritePrimitiveTypeValue(_writer, _val);
            }
         }
      }

      private static void SerializeArray(Utf8JsonWriter _writer, IEnumerable _enum, SerializationContext _serializationContext)
      {
         _writer.WriteStartArray();

         try
         {
            foreach (var listElement in _enum)
            {
               if (listElement != null)
               {
                  WriteValue(_writer, listElement.GetType(), listElement, _serializationContext);
               }
               else
               {
                  _writer.WriteNullValue();
               }
            }
         }
         finally
         {
            _writer.WriteEndArray();
         }
      }

      public static string Serialize(object _object, SerializationContext _serializationCtx)
      {
         using MemoryStream memStream = new MemoryStream();
         using Utf8JsonWriter writer = new Utf8JsonWriter(memStream, m_options);

         if (_object == null)
         {
            SerializationUtils.SerializeEmptyObject(writer);
         }
         else
         {
            Type objectType = _object.GetType();

            if (SerializationUtils.IsEnumeratorType(objectType))
            {
               SerializeArray(writer, (IEnumerable)_object, _serializationCtx);
            }
            else
            {
               SerializeObject(writer, _object, _serializationCtx);
            }
         }

         writer.Flush();

         return Encoding.UTF8.GetString(memStream.ToArray());
      }

      //TODO: Do not recreate this everytime. Cache this.

      //This code seems to be duplicated in the MaskSchemaDeserializer::GetOverrideDeserializationMethods - refactor
      private static IDictionary<string, MethodInfo> GetOverrideSerializationMethods(Type _type, bool _useCache = true)
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
            SerializePropertyAttribute jsonPropertyNameAttribute = method.GetCustomAttribute<SerializePropertyAttribute>();

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

      private static string GetJsonPropertyName(PropertyInfo _propInfo, SerializationContext _ctx, bool _useCache = true)
      {
         #region cache check

         if (_useCache)
         {
            if (m_serializationPropNameByPropInfo.ContainsKey(_propInfo))
            {
               IDictionary<SerializationContext, string> serializationPropNames = m_serializationPropNameByPropInfo[_propInfo];

               if (serializationPropNames.ContainsKey(_ctx))
               {
                  return serializationPropNames[_ctx];
               }
            }
         }
         #endregion

         IEnumerable<JsonPropertyNameAttribute> jsonPropNameAttsEnumerable = _propInfo.GetCustomAttributes<JsonPropertyNameAttribute>();
         if (jsonPropNameAttsEnumerable == null)
            return _propInfo.Name;

         IEnumerator<JsonPropertyNameAttribute> jsonPropNameAttsEnumerator = jsonPropNameAttsEnumerable.GetEnumerator();
         if (jsonPropNameAttsEnumerator == null)
            return _propInfo.Name;

         if (!jsonPropNameAttsEnumerator.MoveNext())
            return _propInfo.Name;

         JsonPropertyNameAttribute jsonPropNameAtt = jsonPropNameAttsEnumerator.Current;

         string __ctxAttributeName = jsonPropNameAtt.Name;

         string ctxAttributeName;
         if (TryGetSerializationContextAttribute(_propInfo, _ctx, out ctxAttributeName))
         {
            __ctxAttributeName = ctxAttributeName;
         }

         #region cache update

         if (_useCache)
         {
            if (!m_serializationPropNameByPropInfo.ContainsKey(_propInfo))
            {
               m_serializationPropNameByPropInfo.Add(_propInfo, new Dictionary<SerializationContext, string>());
            }

            IDictionary<SerializationContext, string> serializationPropNames = m_serializationPropNameByPropInfo[_propInfo];

            if (serializationPropNames.ContainsKey(_ctx))
            {
               serializationPropNames[_ctx] = __ctxAttributeName;
            }
            else
            {
               serializationPropNames.Add(_ctx, __ctxAttributeName);
            }
         }
         #endregion

         return __ctxAttributeName;
      }

      private static bool HasSerializationContextAttribute(PropertyInfo _propInfo, SerializationContext _serializationContext)
      {
         string ctxAttribute = null;
         return TryGetSerializationContextAttribute(_propInfo, _serializationContext, out ctxAttribute);
      }

      private static bool TryGetSerializationContextAttribute(PropertyInfo _propInfo, SerializationContext _serializationContext, out string __val)
      {
         __val = null;

         IEnumerable<ContextSerializationAttribute> ctxSerialAttsEnumerable = _propInfo.GetCustomAttributes<ContextSerializationAttribute>();
         if (ctxSerialAttsEnumerable == null) return false;

         IEnumerator<ContextSerializationAttribute> ctxSerialAttsEnumerator = ctxSerialAttsEnumerable.GetEnumerator();
         if (ctxSerialAttsEnumerator == null) return false;

         while (ctxSerialAttsEnumerator.MoveNext())
         {
            ContextSerializationAttribute ctxSerialAtt = ctxSerialAttsEnumerator.Current;

            if (ctxSerialAtt.SerializationContext == _serializationContext)
            {
               __val = ctxSerialAtt.PropertyName;
               return true;
            }
         }

         return false;
      }
   }
}
