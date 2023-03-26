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
   internal static class GlobalSchemaAttributeRegistry
   {
      private static MaskSchemaRegistry m_glbSchemaMaskRegistry = null;
      private static IDictionary<Guid, IList<Type>> m_glbInterfaceImplClasses = null;

      private static bool IsInitialized { get; set; } = false;

      private static void Initialize()
      {
         IList<Assembly> assemblies = GetAllRelevantAssemblies();

         m_glbSchemaMaskRegistry = new MaskSchemaRegistry();
         m_glbSchemaMaskRegistry.Parse(assemblies);

         m_glbInterfaceImplClasses = Parse(assemblies);

         IsInitialized = true;
      }

      private static IDictionary<Guid, IList<Type>> Parse(IList<Assembly> _assemblies)
      {
         IDictionary<Guid, Type> interfaceTypeList = new Dictionary<Guid, Type>();
         IList<Type> classTypeList = new List<Type>();
         IDictionary<Guid, IList<Type>> __contextClassImpTypeListByInterfaceType = new Dictionary<Guid, IList<Type>>();

         #region adding well known collection generic type definitions
         // IList -> List
         __contextClassImpTypeListByInterfaceType.Add(typeof(IList<>).GUID, new List<Type>() { typeof(List<>) });
         // IDictionary -> Dictionary
         __contextClassImpTypeListByInterfaceType.Add(typeof(IDictionary<,>).GUID, new List<Type>() { typeof(Dictionary<,>) });
         #endregion

         foreach (Assembly assembly in _assemblies)
         {
            if (assembly.IsDynamic) continue;

            foreach (Type exportedType in assembly.GetExportedTypes())
            {
               if (exportedType.IsClass)
               {
                  classTypeList.Add(exportedType);
               }
               else
               {
                  if (exportedType.IsInterface)
                  {
                     interfaceTypeList.Add(exportedType.GUID, exportedType);
                  }
               }
            }
         }

         foreach (Type classType in classTypeList)
         {
            foreach (Type classInterfaceType in classType.GetInterfaces())
            {
               if (interfaceTypeList.ContainsKey(classInterfaceType.GUID))
               {
                  Guid classInterfaceTypeGuid = classInterfaceType.GUID;

                  if (!__contextClassImpTypeListByInterfaceType.ContainsKey(classInterfaceTypeGuid))
                  {
                     __contextClassImpTypeListByInterfaceType.Add(classInterfaceTypeGuid, new List<Type>());
                  }
                  __contextClassImpTypeListByInterfaceType[classInterfaceTypeGuid].Add(classType);
               }
            }
         }

         return __contextClassImpTypeListByInterfaceType;
      }

      private static IList<Assembly> GetAllRelevantAssemblies()
      {
         string thisAssemblyLocation = typeof(GlobalSchemaAttributeRegistry).Assembly.Location;
         string thisAssemblyPath = System.IO.Path.GetDirectoryName(thisAssemblyLocation);

         Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

         IList<Assembly> allCurDomainAssemblies = new List<Assembly>(assemblies);

         IList<Assembly> __relevantAssemblies = new List<Assembly>();

         foreach (Assembly assembly in allCurDomainAssemblies)
         {
            if (assembly.IsDynamic) continue;

            string testAssemblyLocation = assembly.Location;
            string testAssemblyPath = System.IO.Path.GetDirectoryName(testAssemblyLocation);

            if (thisAssemblyPath.Equals(testAssemblyPath, StringComparison.InvariantCultureIgnoreCase))
            {
               string assemblyName = assembly.GetName().Name;
               if (assemblyName.StartsWith("ws3dx", StringComparison.InvariantCultureIgnoreCase))
               {
                  __relevantAssemblies.Add(assembly);
               }
            }
         }

         return __relevantAssemblies;
      }

      public static Type GetDefaultImplementationClass(Type _interfaceMaskDef)
      {
         if (!IsInitialized)
         {
            Initialize();
         }

         IList<MaskSchemaInterfaceInfo> maskSchemaInterfaceInfos = m_glbSchemaMaskRegistry.GetCachedDefaultImplementationClass(_interfaceMaskDef);
         if (maskSchemaInterfaceInfos?.Count > 0)
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

         Type interfaceDef = _interfaceMaskDef;

         if ((_interfaceMaskDef.IsGenericType) && (!_interfaceMaskDef.IsGenericTypeDefinition))
         {
            interfaceDef = _interfaceMaskDef.GetGenericTypeDefinition();
         }

         if (m_glbInterfaceImplClasses.TryGetValue(interfaceDef.GUID, out IList<Type> interfaceImplClassList) && interfaceImplClassList?.Count > 0)
         {
            return interfaceImplClassList[0];
         }

         return null;
      }
   }
}
