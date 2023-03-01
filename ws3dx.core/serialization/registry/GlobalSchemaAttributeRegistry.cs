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

namespace ws3dx.core.serialization.registry
{
   static class GlobalSchemaAttributeRegistry
   {
      private static MaskSchemaRegistry m_glbSchemaMaskRegistry = null;
      private static InterfaceDeserializerAttributeRegistry m_glbDefDeserializerRegistry = null;

      // TODO: Evaluate if this should be under another registry or else in the Mask Schema registry ...
      //private static IDictionary<Type, IList<Type>>  m_glbInterfaceToImplClassMap  = null;

      private static bool m_isInitialized = false;

      private static IDictionary<Type, IList<Type>> m_glbInterfaceImplClasses = null;

      private static void Initialize()
      {
         IList<Assembly> assemblies = GetAllRelevantAssemblies();

         m_glbSchemaMaskRegistry = new MaskSchemaRegistry();
         m_glbDefDeserializerRegistry = new InterfaceDeserializerAttributeRegistry();

         m_glbSchemaMaskRegistry.Parse(assemblies);

         m_glbDefDeserializerRegistry.Parse(assemblies);

         m_glbInterfaceImplClasses = Parse(assemblies);

         IsInitialized = true;
      }

      private static IDictionary<Type, IList<Type>> Parse(IList<Assembly> _assemblies)
      {
         IList<Type> interfaceTypeList = new List<Type>();
         IList<Type> classTypeList = new List<Type>();
         IDictionary<Type, IList<Type>> __contextClassImpTypeListByInterfaceType = new Dictionary<Type, IList<Type>>();

         foreach (Assembly assembly in _assemblies)
         {
            if (assembly.IsDynamic) continue;

            Type[] exportedTypeArray = assembly.GetExportedTypes();

            foreach (Type exportedType in exportedTypeArray)
            {
               if ((exportedType.IsGenericType) || (exportedType.IsGenericTypeDefinition)) continue;

               if (exportedType.IsClass)
               {
                  classTypeList.Add(exportedType);
               }
               else
               {
                  if (exportedType.IsInterface)
                  {
                     interfaceTypeList.Add(exportedType);
                  }
               }
            }
         }

         foreach (Type classType in classTypeList)
         {
            Type[] classInterfaceTypeArray = classType.GetInterfaces();

            foreach (Type classInterfaceType in classInterfaceTypeArray)
            {
               if (interfaceTypeList.Contains(classInterfaceType))
               {
                  if (!__contextClassImpTypeListByInterfaceType.ContainsKey(classInterfaceType))
                  {
                     __contextClassImpTypeListByInterfaceType.Add(classInterfaceType, new List<Type>());
                  }

                  __contextClassImpTypeListByInterfaceType[classInterfaceType].Add(classType);
               }
            }
         }

         return __contextClassImpTypeListByInterfaceType;
      }

      private static bool IsInitialized { get => m_isInitialized; set => m_isInitialized = value; }

      private static IList<Assembly> GetAllRelevantAssemblies()
      {
         Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
         //TODO: In the future we might want to filter the assemblies with just "our" assemblies
         return new List<Assembly>(assemblies);
      }

      public static Type GetDefaultImplementationClass(Type _interfaceMaskDef)
      {
         if (!IsInitialized)
         {
            Initialize();
         }

         IList<Type> classImpList = m_glbDefDeserializerRegistry.GetDefaultImplementationClass(_interfaceMaskDef);
         if ((classImpList != null) && (classImpList.Count > 0))
         {
            return classImpList[0];
         }

         IList<MaskSchemaInterfaceInfo> maskSchemaInterfaceInfos = m_glbSchemaMaskRegistry.GetCachedDefaultImplementationClass(_interfaceMaskDef);
         if ((maskSchemaInterfaceInfos != null) && (maskSchemaInterfaceInfos.Count > 0))
         {
            IList<Type> maskClassImpList = maskSchemaInterfaceInfos[0].MaskImplClassList;
            if ((maskClassImpList == null) || (maskClassImpList.Count == 0))
            {
               //This should never happen. A mask interface should always be deployed with
               //an implementation class.
               return null;
            }

            //TODO: Log if more than one MaskInterfaceInfo is received for the same type (this shouldn't happen either)
            return maskClassImpList[0];
         }

         IList<Type> interfaceImplClassList = null;
         if (m_glbInterfaceImplClasses.TryGetValue(_interfaceMaskDef, out interfaceImplClassList))
         {
            if ((interfaceImplClassList != null) && (interfaceImplClassList.Count > 0))
            {
               return interfaceImplClassList[0];
            }
         }

         return null;
      }

      public static bool InterfaceFilterByName(Type typeObj, Object criteriaObj)
      {
         if (typeObj.ToString() == criteriaObj.ToString())
            return true;
         else
            return false;
      }

      public static Type GetDefaultClassDeserializerImpForInterface(Type _interfaceType)
      {
         if (!IsInitialized)
         {
            Initialize();
         }

         Type interfaceType = _interfaceType;

         if (_interfaceType.IsGenericType)
         {
            interfaceType = _interfaceType.GetGenericTypeDefinition();
         }

         IList<Type> classImpList = m_glbDefDeserializerRegistry.GetDefaultImplementationClass(interfaceType);

         if ((classImpList == null) || (classImpList.Count == 0)) return null;

         Type classImp = classImpList[0];

         //"Resolve" generic implementation class with interface arguments
         if (_interfaceType.IsGenericType)
         {
            Type[] genericArgTypes = _interfaceType.GetGenericArguments();

            if (classImp.IsGenericType)
            {
               return classImp.MakeGenericType(genericArgTypes);
            }
         }

         return classImp;
      }
   }
}
