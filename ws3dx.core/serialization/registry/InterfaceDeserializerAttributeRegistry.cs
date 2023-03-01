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
using System.Reflection;

using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization.registry
{
   class InterfaceDeserializerAttributeRegistry
   {
      IDictionary<Type, IList<Type>> m_classImplementationByInterfaceTypeIndex = new Dictionary<Type, IList<Type>>();

      public InterfaceDeserializerAttributeRegistry()
      {
         //Prepopulate with some well-known interfaces 

         //IList -> List
         m_classImplementationByInterfaceTypeIndex.Add(typeof(IList<>), new List<Type>() { typeof(List<>) });

         //IDictionary -> Dictionary
         m_classImplementationByInterfaceTypeIndex.Add(typeof(IDictionary<,>), new List<Type>() { typeof(Dictionary<,>) });
      }

      public void Parse(IList<Assembly> _assemblies)
      {
         foreach (Assembly assembly in _assemblies)
         {
            IDictionary<Type, IList<Type>> impClassesByInterfaceIndex = GetDeserializationImpClassesByInterfaceType(assembly);

            foreach (Type interfaceType in impClassesByInterfaceIndex.Keys)
            {
               if (!m_classImplementationByInterfaceTypeIndex.ContainsKey(interfaceType))
               {
                  m_classImplementationByInterfaceTypeIndex.Add(interfaceType, new List<Type>());
               }

               ((List<Type>)m_classImplementationByInterfaceTypeIndex[interfaceType]).AddRange(impClassesByInterfaceIndex[interfaceType]);
            }
         }
      }

      private IDictionary<Type, IList<Type>> GetDeserializationImpClassesByInterfaceType(Assembly _assembly)
      {
         return RegistryUtils.GetListOfTypesByIndexType<InterfaceDeserializerAttribute>(_assembly, nameof(InterfaceDeserializerAttribute.Interface));
      }

      public IList<Type> GetDefaultImplementationClass(Type _interfaceMaskDef)
      {
         if (!_interfaceMaskDef.IsInterface) { throw new ArgumentException("Expecting an interface as a type"); };

         if (!m_classImplementationByInterfaceTypeIndex.ContainsKey(_interfaceMaskDef))
         {
            return null;
         }
         return m_classImplementationByInterfaceTypeIndex[_interfaceMaskDef];
      }
   }
}
