//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2023 Dassault Systèmes - CPE EMED
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
//------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ws3dx.shared.utils
{
   public static class GenericParameterConstraintUtils
   {
      //Unfortunately C# does not fully implement type constraints as below, so this additional check is required.
      //e.g. GetInstance<T>() where T: A, B, C
      public static void CheckConstraints(Type _candidateType, IEnumerable<Type> _constraintTypes, [CallerMemberName] string _caller = null)
      {
         IEnumerator<Type> constraintTypesEnumerator = _constraintTypes.GetEnumerator();

         while (constraintTypesEnumerator.MoveNext())
         {
            if (constraintTypesEnumerator.Current == _candidateType) return;
         }

         throw new ArgumentOutOfRangeException($"The type '{_candidateType}' is not supported by the '{_caller}'");
      }
   }
}
