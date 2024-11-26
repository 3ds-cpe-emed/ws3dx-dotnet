//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2024 Dassault Systèmes - CPE EMED
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
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ws3dx.shared.serialization
{
   public class FlexStringCollectionDeserializer : JsonConverter<IList<string>>
   {
         public override bool CanConvert(Type typeToConvert)
         {
            if (typeToConvert == typeof(IList<string>)) return true;

            return false;
         }

         public override IList<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
         {
            switch (reader.TokenType)
            {
               case JsonTokenType.String:
               {
                  string singleStringArray = (string)JsonSerializer.Deserialize(ref reader, typeof(string), options);

                  return [singleStringArray];
               }

               case JsonTokenType.StartArray:
               {
                  Type collectionWrapperType = typeof(List<string>);

                  return (IList<string>)JsonSerializer.Deserialize(ref reader, collectionWrapperType, options);
               }
            }
         
            throw new NotImplementedException();
         
         }

         public override void Write(Utf8JsonWriter _writer, IList<string> _type, JsonSerializerOptions _options)
         {
               throw new NotImplementedException();
         }
   }
}
