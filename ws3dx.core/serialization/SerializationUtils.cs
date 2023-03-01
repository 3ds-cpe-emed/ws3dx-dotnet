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

namespace ws3dx.core.serialization
{
   public static class SerializationUtils
   {
      public static bool IsPrimitiveValue(JsonValueKind jsonValueKind)
      {
         if ((jsonValueKind == JsonValueKind.Array) || (jsonValueKind == JsonValueKind.Object)) return false;
         return true;
      }
      public static bool IsPrimitiveTypeValue(Type _type, bool checkNullable = false)
      {
         if (checkNullable)
         {
            if (IsNullable(_type))
            {
               return Nullable.GetUnderlyingType(_type).IsPrimitive;
            }
         }

         return _type.IsPrimitive;
      }

      public static object ConvertStringToPrimitive(Type _type, string _valString, bool _checkNullable = true)
      {
         if (!IsPrimitiveTypeValue(_type, true)) return null;

         Type _primitiveType = _type;

         //Get Underlying Primitive Type
         if (_checkNullable)
         {
            if (IsNullable(_type))
            {
               _primitiveType = Nullable.GetUnderlyingType(_type);
            }
         }

         return ConvertToPrimitiveType(_primitiveType, _valString);
      }

      public static bool TryGetPrimitiveType(Type _type, out Type __primitiveType)
      {
         __primitiveType = _type;

         if (_type.IsPrimitive) return true;

         Type underlyingType = Nullable.GetUnderlyingType(_type);

         if ((underlyingType != null) && (underlyingType.IsPrimitive))
         {
            __primitiveType = underlyingType;
            return true;
         }

         return false;
      }

      public static bool IsNullable(Type _type)
      {
         return (Nullable.GetUnderlyingType(_type) != null);
      }
      public static bool CanBeNull(Type _type)
      {
         return (!_type.IsValueType || IsNullable(_type));
      }

      #region Copying values from Json into DotNet instances

      /// <summary>
      /// The primitive types are: Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single
      /// https://docs.microsoft.com/en-us/dotnet/api/system.type.isprimitive?view=netcore-3.1
      /// </summary>
      /// <param name="_writer"></param>
      /// <param name="_value"></param>
      public static void WritePrimitiveTypeValue(Utf8JsonWriter _writer, object _value)
      {
         Type valueType = _value.GetType();

         Type primitiveValueType;

         if (TryGetPrimitiveType(valueType, out primitiveValueType))
         {
            valueType = primitiveValueType;
         }

         switch (Type.GetTypeCode(valueType))
         {
            case TypeCode.Boolean:
               _writer.WriteBooleanValue((bool)_value);
               break;

            case TypeCode.Byte:
               _writer.WriteNumberValue((byte)_value);
               break;

            case TypeCode.SByte:
               _writer.WriteNumberValue((sbyte)_value);
               break;

            case TypeCode.Int16:
               _writer.WriteNumberValue((short)_value);
               break;

            case TypeCode.UInt16:
               _writer.WriteNumberValue((ushort)_value);
               break;

            case TypeCode.Int32:
               _writer.WriteNumberValue((int)_value);
               break;

            case TypeCode.UInt32:
               _writer.WriteNumberValue((uint)_value);
               break;

            case TypeCode.Int64:
               _writer.WriteNumberValue((long)_value);
               break;

            case TypeCode.UInt64:
               _writer.WriteNumberValue((ulong)_value);
               break;

            case TypeCode.Char:
               _writer.WriteStringValue((string)_value);
               break;

            case TypeCode.Double:
               _writer.WriteNumberValue((double)_value);
               break;

            case TypeCode.Single:
               _writer.WriteNumberValue((float)_value);
               break;

            default:
               _writer.WriteNullValue();
               break;
         }
      }

      public static void SetItemValue(ref Utf8JsonReader _reader, object _item, PropertyInfo _property)
      {
         Type propertyType = _property.PropertyType;

         if (_reader.TokenType == JsonTokenType.PropertyName)
            _reader.Read();

         switch (_reader.TokenType)
         {
            case JsonTokenType.None:
               break;

            case JsonTokenType.Null:
               break;

            case JsonTokenType.StartArray:
               //to be tested
               _property.SetValue(_item, JsonSerializer.Deserialize(ref _reader, _property.PropertyType));
               break;

            case JsonTokenType.String:

               string readerString = _reader.GetString();

               if (propertyType == typeof(string))
               {
                  _property.SetValue(_item, readerString);
               }
               else
               {
                  if (propertyType.IsPrimitive)
                  {
                     _property.SetValue(_item, ConvertToPrimitiveType(propertyType, readerString));
                  }
                  else
                  {
                     Type underlyingNullableType = Nullable.GetUnderlyingType(propertyType);

                     if (underlyingNullableType != null)
                     {
                        if (underlyingNullableType.IsPrimitive)
                        {
                           _property.SetValue(_item, ConvertToPrimitiveType(underlyingNullableType, readerString));
                        }
                     }
                  }
               }

               break;

            case JsonTokenType.Number:
               if (_property.PropertyType == typeof(double))
               {
                  _property.SetValue(_item, _reader.GetDouble());
               }
               else
               {
                  if (_property.PropertyType == typeof(float))
                  {
                     _property.SetValue(_item, _reader.GetSingle());
                  }
                  else
                  {
                     if (_property.PropertyType == typeof(decimal))
                     {
                        _property.SetValue(_item, _reader.GetDecimal());
                     }
                     else
                     {
                        if (_property.PropertyType == typeof(long))
                        {
                           _property.SetValue(_item, _reader.GetInt64());
                        }
                        else
                        {
                           if (_property.PropertyType == typeof(int))
                           {
                              _property.SetValue(_item, _reader.GetInt32());
                           }
                           else
                           {
                              if (_property.PropertyType == typeof(short))
                              {
                                 _property.SetValue(_item, _reader.GetInt16());
                              }
                           }
                        }
                     }
                  }
               }
               break;
            case JsonTokenType.True:

               if (propertyType == typeof(bool) || (Nullable.GetUnderlyingType(propertyType) == typeof(bool)))
               {
                  _property.SetValue(_item, true);
               }
               else
               {
                  if (propertyType == typeof(string))
                  {
                     _property.SetValue(_item, bool.TrueString);
                  }
               }

               break;

            case JsonTokenType.False:

               if (propertyType == typeof(bool) || (Nullable.GetUnderlyingType(propertyType) == typeof(bool)))
               {
                  _property.SetValue(_item, false);
               }
               else
               {
                  if (propertyType == typeof(string))
                  {
                     _property.SetValue(_item, bool.FalseString);
                  }
               }

               break;
            case JsonTokenType.StartObject:
               //to be tested
               _property.SetValue(_item, JsonSerializer.Deserialize(ref _reader, _property.PropertyType));
               break;
         }
      }

      internal static void SerializeEmptyObject(Utf8JsonWriter _writer)
      {
         if (_writer == null) throw new ArgumentNullException(nameof(_writer));

         _writer.WriteStartObject();
         _writer.WriteEndObject();
      }

      internal static bool IsEnumeratorType(Type _type)
      {
         if (_type.Equals(typeof(IEnumerable))) return true;

         if (_type.GetInterface(nameof(IEnumerable)) != null) return true;

         if (_type.IsGenericType && (_type.GetGenericTypeDefinition() == typeof(IEnumerable<>))) return true;

         return false;
      }

      private static object ConvertToPrimitiveType(Type convertType, string stringToConvert)
      {
         if (convertType == typeof(double))
         {
            double outVal;
            if (double.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(float))
         {
            float outVal;
            if (float.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(decimal))
         {
            decimal outVal;
            if (decimal.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(int))
         {
            int outVal;

            if (int.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(uint))
         {
            uint outVal;

            if (uint.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(long))
         {
            long outVal;

            if (long.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(ulong))
         {
            ulong outVal;

            if (ulong.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(short))
         {
            short outVal;

            if (short.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(ushort))
         {
            ushort outVal;

            if (ushort.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(bool))
         {
            bool outVal;

            if (bool.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(byte))
         {
            byte outVal;

            if (byte.TryParse(stringToConvert, out outVal)) return outVal;
         }
         if (convertType == typeof(sbyte))
         {
            sbyte outVal;

            if (sbyte.TryParse(stringToConvert, out outVal)) return outVal;
         }

         if (convertType == typeof(char))
         {
            char outVal;

            if (char.TryParse(stringToConvert, out outVal)) return outVal;
         }

         return null;
      }

      #endregion
   }
}
