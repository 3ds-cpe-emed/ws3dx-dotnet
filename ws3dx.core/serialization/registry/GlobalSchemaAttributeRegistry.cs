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
      private static MaskSchemaRegistry               m_glbSchemaMaskRegistry       = null;
      private static ResponseCollectionSchemaRegistry m_glbCollectionSchemaRegistry = null;
      private static IDictionary<Type, IList<Type>>   m_glbInterfaceImplClasses     = null;

      private static bool IsInitialized { get; set; } = false;

      private static void Initialize()
      {
         IList<Assembly> assemblies = GetAllRelevantAssemblies();

         m_glbSchemaMaskRegistry = new MaskSchemaRegistry();
         m_glbSchemaMaskRegistry.Parse(assemblies);

         m_glbCollectionSchemaRegistry = new ResponseCollectionSchemaRegistry();
         m_glbCollectionSchemaRegistry.Parse(assemblies);

         m_glbInterfaceImplClasses = Parse(assemblies);

         IsInitialized = true;
      }

      private static IDictionary<Type, IList<Type>> Parse(IList<Assembly> _assemblies)
      {
         IList<Type> interfaceTypeList = new List<Type>();
         IList<Type> classTypeList = new List<Type>();
         IDictionary<Type, IList<Type>> __contextClassImpTypeListByInterfaceType = new Dictionary<Type, IList<Type>>();

         #region adding well known collection generic type definitions
         // IList -> List
         __contextClassImpTypeListByInterfaceType.Add(typeof(IList<>),       new List<Type>() { typeof(List<>) });
         // IDictionary -> Dictionary
         __contextClassImpTypeListByInterfaceType.Add(typeof(IDictionary<,>), new List<Type>() { typeof(Dictionary<,>) });
         #endregion

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
            foreach (Type classInterfaceType in classType.GetInterfaces())
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

      private static IList<Assembly> GetAllRelevantAssemblies()
      {
         Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
         //TODO: In the future we want to optimize this and filter the assemblies with just "our" assemblies
         return new List<Assembly>(assemblies);
      }

      public static Type GetDefaultImplementationClass(Type _interfaceMaskDef)
      {
         if (!IsInitialized)
         {
            Initialize();
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

         Type interfaceDef = _interfaceMaskDef;

         if ((_interfaceMaskDef.IsGenericType) && (!_interfaceMaskDef.IsGenericTypeDefinition)) {
            interfaceDef = _interfaceMaskDef.GetGenericTypeDefinition();
         }

         if (m_glbInterfaceImplClasses.TryGetValue(interfaceDef, out IList<Type> interfaceImplClassList) && interfaceImplClassList?.Count > 0)
         {
            return interfaceImplClassList[0];
         }

         return null;
      }

      public static bool IsResponseCollectionSchema(Type _testType)
      {
         if (!IsInitialized) { Initialize();}
         return m_glbCollectionSchemaRegistry.IsResponseCollectionSchema(_testType);
      }

      public static ResponseCollectionSchemaHelper GetResponseCollectionSchema(Type _type)
      {
         if (!IsInitialized) { Initialize();}
         return m_glbCollectionSchemaRegistry.GetResponseCollection(_type);
      }
   }
}
