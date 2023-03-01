﻿// ------------------------------------------------------------------------------------------------------------------------------------
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
   class MaskSchemaRegistry
   {
      const string ATTRIBUTE_MASK_SCHEMA_NAME = "MaskName";

      IDictionary<string, IList<MaskSchemaInterfaceInfo>> m_masksSchemaInterfaceInfoByMaskName = new Dictionary<string, IList<MaskSchemaInterfaceInfo>>();
      IDictionary<Type, IList<MaskSchemaInterfaceInfo>> m_masksSchemaInterfaceInfoByType = new Dictionary<Type, IList<MaskSchemaInterfaceInfo>>();

      public void Parse(IList<Assembly> _assemblies)
      {
         foreach (Assembly assembly in _assemblies)
         {
            //Get interfaces mapped with FieldsSchema Attribute index them with Fields name
            IDictionary<string, IList<Type>> maskTypesByMaskName = RegistryUtils.GetTypesByMaskName<MaskSchemaAttribute>(assembly, ATTRIBUTE_MASK_SCHEMA_NAME);

            foreach (string maskTypesByMaskNameKey in maskTypesByMaskName.Keys)
            {
               if (!m_masksSchemaInterfaceInfoByMaskName.ContainsKey(maskTypesByMaskNameKey))
               {
                  m_masksSchemaInterfaceInfoByMaskName.Add(maskTypesByMaskNameKey, new List<MaskSchemaInterfaceInfo>());
               }

               foreach (Type maskType in maskTypesByMaskName[maskTypesByMaskNameKey])
               {
                  m_masksSchemaInterfaceInfoByMaskName[maskTypesByMaskNameKey].Add(new MaskSchemaInterfaceInfo(maskTypesByMaskNameKey, maskType));
               }
            }
         }

         //For each interface will look for implementation classes on each assembly

         foreach (string maskKey in m_masksSchemaInterfaceInfoByMaskName.Keys)
         {
            IList<MaskSchemaInterfaceInfo> maskSchemaInterfaceInfoList = m_masksSchemaInterfaceInfoByMaskName[maskKey];

            foreach (MaskSchemaInterfaceInfo maskSchemaInterfaceInfo in maskSchemaInterfaceInfoList)
            {
               IList<Type> maskSchemaImplClasses = new List<Type>();

               foreach (Assembly assembly in _assemblies)
               {
                  ((List<Type>)maskSchemaImplClasses).AddRange(
                        RegistryUtils.GetInterfaceImplementationClasses(assembly, maskSchemaInterfaceInfo.MaskInterface));
               }

               maskSchemaInterfaceInfo.MaskImplClassList = maskSchemaImplClasses;
            }
         }

         //Index by Type for faster retrieval of implementation class
         foreach (string maskKey in m_masksSchemaInterfaceInfoByMaskName.Keys)
         {
            IList<MaskSchemaInterfaceInfo> maskSchemaInterfaceInfoList = m_masksSchemaInterfaceInfoByMaskName[maskKey];

            foreach (MaskSchemaInterfaceInfo maskSchemaInterfaceInfo in maskSchemaInterfaceInfoList)
            {
               if (!m_masksSchemaInterfaceInfoByType.ContainsKey(maskSchemaInterfaceInfo.MaskInterface))
               {
                  m_masksSchemaInterfaceInfoByType.Add(maskSchemaInterfaceInfo.MaskInterface, new List<MaskSchemaInterfaceInfo>());
               }

               m_masksSchemaInterfaceInfoByType[maskSchemaInterfaceInfo.MaskInterface].Add(maskSchemaInterfaceInfo);
            }
         }
      }

      public IList<MaskSchemaInterfaceInfo> GetMaskSchemaInterfaceInfo(string _masksSchemaName)
      {
         if (!m_masksSchemaInterfaceInfoByMaskName.ContainsKey(_masksSchemaName)) return null;

         return m_masksSchemaInterfaceInfoByMaskName[_masksSchemaName];
      }

      public IList<MaskSchemaInterfaceInfo> GetCachedDefaultImplementationClass(Type _interface)
      {
         if (!m_masksSchemaInterfaceInfoByType.ContainsKey(_interface)) return null;
         return m_masksSchemaInterfaceInfoByType[_interface];
      }
   }
}
