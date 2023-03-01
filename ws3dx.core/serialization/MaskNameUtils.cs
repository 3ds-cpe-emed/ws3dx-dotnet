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

using ws3dx.serialization.attribute;

namespace ws3dx.core.serialization
{
   public static class MaskNameUtils
   {
      public static bool TryGetMaskNameFromType(Type type, out string __maskName)
      {
         __maskName = null;

         MaskSchemaAttribute[] attributes;
         if (type.IsInterface)
         {
            //Inherit parameter does not work correctly for interfaces - overriding with custom
            //MaskSchemaAttribute[] attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), true);
            //attributes = GetMaskSchemaAttributesInHierarchy(type);
            attributes = GetMaskSchemaAttribute(type);
         }
         else
         {
            attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), true);
         }

         if ((attributes == null) || (attributes.Length == 0))
         {
            return false;
         }

         //if (attributes.Length > 1)
         //{
         //throw new Exception($"Multiple Mask Schema Definition attributes associated to type {type.Name}");
         //}

         __maskName = attributes[0].MaskName;

         return true;
      }
      public static string GetMaskNameFromType(Type type)
      {
         MaskSchemaAttribute[] attributes;
         if (type.IsInterface)
         {
            //Inherit parameter does not work correctly for interfaces - overriding with custom
            //MaskSchemaAttribute[] attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), true);
            //attributes = GetMaskSchemaAttributesInHierarchy(type);
            attributes = GetMaskSchemaAttribute(type);
         }
         else
         {
            attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), true);
         }

         if ((attributes == null) || (attributes.Length == 0))
         {
            throw new Exception($"No Mask Schema Definition attribute associated to type {type.Name}");
         }

         if (attributes.Length > 1)
         {
            throw new Exception($"Multiple Mask Schema Definition attributes associated to type {type.Name}");
         }

         return attributes[0].MaskName;
      }

      private static MaskSchemaAttribute[] GetMaskSchemaAttributesInHierarchy(Type type)
      {
         List<MaskSchemaAttribute> list = new List<MaskSchemaAttribute>();

         MaskSchemaAttribute[] attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), false);

         if (attributes.Length > 0)
         {
            list.AddRange(attributes);
         }

         Type[] interfaceTree = type.GetInterfaces();

         foreach (Type interfaceAncestor in interfaceTree)
         {
            attributes = (MaskSchemaAttribute[])interfaceAncestor.GetCustomAttributes(typeof(MaskSchemaAttribute), false);
            if (attributes.Length > 0)
            {
               list.AddRange(attributes);
            }
         }

         return list.ToArray();
      }

      private static MaskSchemaAttribute[] GetMaskSchemaAttribute(Type type)
      {
         List<MaskSchemaAttribute> list = new List<MaskSchemaAttribute>();

         MaskSchemaAttribute[] attributes = (MaskSchemaAttribute[])type.GetCustomAttributes(typeof(MaskSchemaAttribute), false);

         if (attributes.Length > 0)
         {
            list.AddRange(attributes);
         }

         return list.ToArray();
      }
   }
}
