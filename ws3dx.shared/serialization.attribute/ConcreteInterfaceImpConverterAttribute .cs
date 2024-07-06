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
using System.Text.Json.Serialization;

namespace ws3dx.serialization.attribute
{
   [AttributeUsage(AttributeTargets.Interface)]
   public class ConcreteInterfaceImpConverterAttribute : JsonConverterAttribute
   {
      /// <summary>
      /// The concrete type to use to convert a given interface type.
      /// </summary>
      public Type ConcreteType { get; set; }

      public ConcreteInterfaceImpConverterAttribute(Type concreteType)
      {
         ConcreteType = concreteType;
      }

      public override JsonConverter CreateConverter(Type typeToConvert)
      {
         // Instantiate converter
         var converterType = typeof(ConcreteInterfaceImpConverter<>).MakeGenericType(ConcreteType);
         var converterInstance = (JsonConverter)Activator.CreateInstance(converterType)!;

         ((IConcreteInterfaceImpConverter)converterInstance).InterfaceType = typeToConvert;

         return converterInstance;
      }
   }
}