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
using System.Linq;
using System.Reflection;

namespace ws3dx.core.serialization.registry
{
   static internal class RegistryUtils
   {
      private const string INVALID_ARG_EXCEPTION_NOT_INTERFACE = "Expecting an interface type as argument by contract";
      private const string INVALID_ARG_EXCEPTION_NOT_GENERIC_INTERFACE = "Generic interface types not supported";

      static internal IList<Type> GetInterfaceImplementationClasses(Assembly _assembly, Type _interfaceType)
      {
         if (!_interfaceType.IsInterface) throw new ArgumentException(INVALID_ARG_EXCEPTION_NOT_INTERFACE);
         if (_interfaceType.IsGenericType) throw new ArgumentException(INVALID_ARG_EXCEPTION_NOT_GENERIC_INTERFACE);

         IList<Type> __output = new List<Type>();

         Type[] assemblyTypes = _assembly.GetTypes();

         foreach (Type candidateImplClassType in assemblyTypes)
         {
            if (!candidateImplClassType.IsClass) continue;

            Type[] candidateImplClassTypeInterfaceTypeArray = candidateImplClassType.GetInterfaces();

            //https://stackoverflow.com/questions/7563269/find-only-non-inherited-interfaces
            var exceptInheritedInterfaces = candidateImplClassTypeInterfaceTypeArray.Except(
              candidateImplClassTypeInterfaceTypeArray.SelectMany(t => t.GetInterfaces())
            );

            foreach (Type candidateImplClassTypeInterfaceType in exceptInheritedInterfaces)
            {
               if (candidateImplClassTypeInterfaceType == _interfaceType)
               {
                  __output.Add(candidateImplClassType);
                  break;
               }
            }
         }

         return __output;
      }

      static internal IDictionary<string, IList<Type>> GetTypesByMaskName<T>(Assembly _assembly, string _attributeName) where T : System.Attribute
      {
         Dictionary<string, IList<Type>> __output = new Dictionary<string, IList<Type>>();

         Type[] assemblyTypes = _assembly.GetTypes();

         foreach (Type type in assemblyTypes)
         {
            IEnumerable<T> deserializerAttsEnumerable = type.GetCustomAttributes<T>();
            if (deserializerAttsEnumerable == null) continue;

            IEnumerator<T> deserializerAttsEnum = deserializerAttsEnumerable.GetEnumerator();
            if (deserializerAttsEnum == null) continue;

            while (deserializerAttsEnum.MoveNext())
            {
               T schemaMaskAttribute = deserializerAttsEnum.Current;

               PropertyInfo propInfo = typeof(T).GetProperty(_attributeName);

               string key = (string)propInfo.GetValue(schemaMaskAttribute);

               if (!__output.ContainsKey(key))
               {
                  __output.Add(key, new List<Type>());
               }
               __output[key].Add(type);
            }
         }

         return __output;
      }

      static internal IDictionary<Type, IList<Type>> GetListOfTypesByIndexType<T>(Assembly _assembly, string _attributeName) where T : System.Attribute
      {
         Dictionary<Type, IList<Type>> __output = new Dictionary<Type, IList<Type>>();

         Type[] assemblyTypes = _assembly.GetTypes();

         foreach (Type type in assemblyTypes)
         {
            IEnumerable<T> deserializerAttsEnumerable = type.GetCustomAttributes<T>();
            if (deserializerAttsEnumerable == null) continue;

            IEnumerator<T> deserializerAttsEnum = deserializerAttsEnumerable.GetEnumerator();
            if (deserializerAttsEnum == null) continue;

            while (deserializerAttsEnum.MoveNext())
            {
               T curAttribute = deserializerAttsEnum.Current;

               PropertyInfo propInfo = typeof(T).GetProperty(_attributeName);

               Type key = (Type)propInfo.GetValue(curAttribute);

               if (!__output.ContainsKey(key))
               {
                  __output.Add(key, new List<Type>());
               }
               __output[key].Add(type);
            }
         }

         return __output;
      }
   }
}

