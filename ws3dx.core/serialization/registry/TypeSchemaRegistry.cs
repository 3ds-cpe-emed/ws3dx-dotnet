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

using System;
using System.Collections.Generic;
using System.Reflection;

using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization.registry
{
   public class TypeSchemaRegistry
   {
      readonly IDictionary<Type, IDictionary<string, IDictionary<object, IList<Type>>>> m_typePropertyIndex = new Dictionary<Type, IDictionary<string, IDictionary<object, IList<Type>>>>();

      readonly IDictionary<Type, object> m_baseTypeSchemaDeserializers = new Dictionary<Type, object>();

      //readonly IDictionary<Type, List<Type>> m_implClasses = new Dictionary<Type, List<Type>>();

      public void Parse(IList<Assembly> _assemblies, ref IDictionary<Guid, IList<Type>> _itfImplClassDict)
      {

         List<Type> typeSchemaItfList = new List<Type>();

         foreach (Assembly assembly in _assemblies)
         {
            foreach (Type type in assembly.GetTypes())
            {
               IEnumerable<TypeSchemaAttribute> deserializerAttsEnumerable = type.GetCustomAttributes<TypeSchemaAttribute>();
               if (deserializerAttsEnumerable == null) continue;

               IEnumerator<TypeSchemaAttribute> deserializerAttsEnum = deserializerAttsEnumerable.GetEnumerator();
               if (deserializerAttsEnum == null) continue;

               while (deserializerAttsEnum.MoveNext())
               {
                  TypeSchemaAttribute typeSchemaAttribute = deserializerAttsEnum.Current;

                  object propertyValue = typeSchemaAttribute.PropertyTypeValue;
                  string propertyName = typeSchemaAttribute.PropertyTypeName;
                  Type baseSchemaInterfaceType = typeSchemaAttribute.BaseMaskSchemaInterface;

                  if (!m_typePropertyIndex.ContainsKey(baseSchemaInterfaceType))
                  {
                     m_typePropertyIndex.Add(baseSchemaInterfaceType, new Dictionary<string, IDictionary<object, IList<Type>>>());
                  }

                  IDictionary<string, IDictionary<object, IList<Type>>> propNameValueTypeDictionary = m_typePropertyIndex[baseSchemaInterfaceType];

                  if (!propNameValueTypeDictionary.ContainsKey(propertyName))
                  {
                     propNameValueTypeDictionary.Add(propertyName, new Dictionary<object, IList<Type>>());
                  }

                  IDictionary<object, IList<Type>> propValueTypeDictionary = propNameValueTypeDictionary[propertyName];

                  if (!propValueTypeDictionary.ContainsKey(propertyValue))
                  {
                     propValueTypeDictionary.Add(propertyValue, new List<Type>());
                  }

                  propValueTypeDictionary[propertyValue].Add(type);

                  // implementation classes
                  if (!typeSchemaItfList.Contains(type))
                  {
                     typeSchemaItfList.Add(type);
                  }

                  // register a TypeSchemaDeserializer for this base type (if not already registered)
                  if (!m_baseTypeSchemaDeserializers.ContainsKey(baseSchemaInterfaceType))
                  {
                     Type serializerType = typeof(TypeSchemaDeserializer<>).MakeGenericType(baseSchemaInterfaceType);
                     m_baseTypeSchemaDeserializers.Add(baseSchemaInterfaceType, Activator.CreateInstance(serializerType));
                  }
               }
            }
         }

         //For each interface will look for implementation classes on each assembly

         foreach (Type typeSchemaInterface in typeSchemaItfList)
         {
            if (!_itfImplClassDict.ContainsKey(typeSchemaInterface.GUID))
            {
               _itfImplClassDict.Add(typeSchemaInterface.GUID, new List<Type>());
            }

            foreach (Assembly assembly in _assemblies)
            {
              IList<Type> implClassList =
                     RegistryUtils.GetInterfaceImplementationClasses(assembly, typeSchemaInterface);

               foreach (Type implClass in implClassList)
               {
                  _itfImplClassDict[typeSchemaInterface.GUID].Add(implClass);
               }
            }
         }
      }

      public bool HasBaseType(Type _baseType) { return m_typePropertyIndex.ContainsKey(_baseType); }

      public ICollection<string> GetRegisteredPropertyNamesForBaseType(Type _baseType) { return m_typePropertyIndex[_baseType].Keys; }

      public bool HasPropertyName(Type _baseType, string _propertyName)
      {
         return m_typePropertyIndex[_baseType].ContainsKey(_propertyName);
      }

      public bool HasPropertyValue(Type _baseType, string _propertyName, object _propertyValue)
      {
         return m_typePropertyIndex[_baseType][_propertyName].ContainsKey(_propertyValue);
      }

      public Type GetTypeForPropertyValue(Type _baseType, string _propertyName, object _propertyValue)
      {
         if (!HasBaseType(_baseType)) return null;
         if (!HasPropertyName(_baseType, _propertyName)) return null;
         if (!HasPropertyValue(_baseType, _propertyName,_propertyValue)) return null;

         return m_typePropertyIndex[_baseType][_propertyName][_propertyValue][0];
      }

      public object GetDeserializerInstanceForType(Type _type)
      {
         return m_baseTypeSchemaDeserializers.ContainsKey(_type) ? m_baseTypeSchemaDeserializers[_type] : null ;
      }
   }
}
