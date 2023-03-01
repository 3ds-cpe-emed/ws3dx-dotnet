//------------------------------------------------------------------------------------------------------------------------------------
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
//------------------------------------------------------------------------------------------------------------------------------------
using System.Text.Json.Serialization;
using ws3dx.dslib.data;

namespace ws3dx.dslib.core.data.impl
{
   public class DeclassificationStatusResponse : IDeclassificationStatusResponse
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: number of objects succesfully declassified Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ObjectsDeclassified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int ObjectsDeclassified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: number of objects NOT declassified Example: 1
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ObjectsNotDeclassified")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public int ObjectsNotDeclassified { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: Status details for each object sent to be declassified
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("StatusOfObjects")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IClassificationStatus StatusOfObjects { get; set; }
   }
}