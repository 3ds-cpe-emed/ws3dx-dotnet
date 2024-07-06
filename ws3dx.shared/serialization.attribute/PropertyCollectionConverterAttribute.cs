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
using System.Text.Json.Serialization;

namespace ws3dx.serialization.attribute
{
   [AttributeUsage(AttributeTargets.Property)]
   public class PropertyCollectionConverterAttribute : JsonConverterAttribute
   {
      Type CollectionWrapperType { get; }

      public PropertyCollectionConverterAttribute(Type _collectionWrapperType)
      {
         CollectionWrapperType = _collectionWrapperType;
      }

      public override JsonConverter CreateConverter(Type typeToConvert)
      {
         if (!typeToConvert.IsGenericType) throw new Exception("Expecting generic IEnumerable interface"); ;

         if (typeToConvert.GetInterface(nameof(IEnumerable)) == null) throw new Exception("Type doesn't implement IEnumerable interface"); ;

         Type genericType = typeToConvert.GenericTypeArguments[0];

         // Instantiate converter
         var converterType = typeof(PropertyCollectionConverter<>).MakeGenericType(typeToConvert);
         var converterInstance = (JsonConverter)Activator.CreateInstance(converterType)!;

         ((IPropertyCollectionConverter)converterInstance).CollectionWrapperType = CollectionWrapperType;
         ((IPropertyCollectionConverter)converterInstance).GenericTypeForCollection = genericType;

         return converterInstance;
      }
   }
}