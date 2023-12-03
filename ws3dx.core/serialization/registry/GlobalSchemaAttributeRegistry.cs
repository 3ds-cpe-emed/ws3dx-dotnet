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
      private static IDictionary<Guid, IList<Type>> m_glbInterfaceImplClasses = new Dictionary<Guid, IList<Type>>();

      public static TypeSchemaRegistry TypeSchemaRegistry { get ; private set; }
      public static MaskSchemaRegistry MaskSchemaRegistry { get; private set; }

      public static bool IsInitialized { get; private set; } = false;

      public static void Initialize()
      {
         IList<Assembly> assemblies = GetAllRelevantAssemblies();

         MaskSchemaRegistry = new MaskSchemaRegistry();
         MaskSchemaRegistry.Parse(assemblies, ref m_glbInterfaceImplClasses);

         TypeSchemaRegistry = new TypeSchemaRegistry();
         TypeSchemaRegistry.Parse(assemblies, ref m_glbInterfaceImplClasses);

         Parse(assemblies, ref m_glbInterfaceImplClasses);

         IsInitialized = true;
      }

      private static void  Parse(IList<Assembly> _assemblies, ref IDictionary<Guid, IList<Type>> _itfImplClassDict)
      {
         IDictionary<Guid, Type> interfaceTypeList = new Dictionary<Guid, Type>();
         IList<Type> classTypeList = new List<Type>();
         //IDictionary<Guid, IList<Type>> __contextClassImpTypeListByInterfaceType = new Dictionary<Guid, IList<Type>>();

         #region adding well known collection generic type definitions
         // IList -> List
         _itfImplClassDict.Add(typeof(IList<>).GUID, new List<Type>() { typeof(List<>) });
         // IDictionary -> Dictionary
         _itfImplClassDict.Add(typeof(IDictionary<,>).GUID, new List<Type>() { typeof(Dictionary<,>) });
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

                  if (!_itfImplClassDict.ContainsKey(classInterfaceTypeGuid))
                  {
                     _itfImplClassDict.Add(classInterfaceTypeGuid, new List<Type>());
                  }
                  _itfImplClassDict[classInterfaceTypeGuid].Add(classType);
               }
            }
         }
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
         if (!_interfaceMaskDef.IsInterface) throw new Exception("GetDefaultImplementationClass expects a type interface");

         if (!IsInitialized) {
            Initialize();
         }

         Type interfaceDef = _interfaceMaskDef;

         if ((_interfaceMaskDef.IsGenericType) && (!_interfaceMaskDef.IsGenericTypeDefinition))
         {
            interfaceDef = _interfaceMaskDef.GetGenericTypeDefinition();
         }

         if (m_glbInterfaceImplClasses.TryGetValue(interfaceDef.GUID, out IList<Type> implClassList))
         {
            return implClassList.Count > 0 ?  implClassList[0] : null;
         }

         return null;
      }
   }
}
