/// Reused from https://github.com/rmja/PolyJson (v1.4.0) (kudos to rmja for this!)
/// while Microsoft doesn't fix its json polymorphism implementation :
/// e.g. current issues with Discriminator not being the first property https://github.com/dotnet/runtime/issues/72604 
/// and even if that one is solved in net9.0 the type attribute (on the C# instance) is not populated so I am not able
/// to know which interface to cast to.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PolyJson.Converters
{
   internal class PolyJsonConverter<T> : JsonConverter<T>, IPolyJsonConverter
   {
      public JsonEncodedText DiscriminatorPropertyName { get; set; }
      public Type UndefinedOrDefaultType { get; set; }
      public Type UnknownOrDefaultType { get; set; }
      public Dictionary<JsonEncodedText, Type> SubTypes { get; set; } = new();

      public override T Read(
          ref Utf8JsonReader reader,
          Type typeToConvert,
          JsonSerializerOptions options
      )
      {
         // Create a reader copy that we can use to find the discriminator value without advancing the original reader
         var nestedReader = reader;

         if (nestedReader.TokenType == JsonTokenType.None)
         {
            nestedReader.Read();
         }

         while (nestedReader.Read())
         {
            if (
                nestedReader.TokenType == JsonTokenType.PropertyName
                && nestedReader.ValueTextEquals(DiscriminatorPropertyName.EncodedUtf8Bytes)
            )
            {
               // Advance the reader to the property value
               nestedReader.Read();

               // Resolve the type from the discriminator value
               var subType = GetSubType(ref nestedReader);

               // Perform the actual deserialization with the original reader
               return (T)JsonSerializer.Deserialize(ref reader, subType, options)!;
            }
            else if (
                nestedReader.TokenType == JsonTokenType.StartObject
                || nestedReader.TokenType == JsonTokenType.StartArray
            )
            {
               // Skip until TokenType is EndObject/EndArray
               // Skip() always throws if IsFinalBlock == false, even when it could actually skip.
               // We therefore use TrySkip() and if that is impossible, we simply return without advancing the original reader.
               // For reference, see:
               // https://stackoverflow.com/questions/63038334/how-do-i-handle-partial-json-in-a-jsonconverter-while-using-deserializeasync-on
               // https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Reader/Utf8JsonReader.cs#L310-L318
               if (!nestedReader.TrySkip())
               {
                  // Do not advance the reader, i.e. do not set reader = nestedReader,
                  // as that would cause us to have an incomplete object available for full final deserialization.

                  // NOTE: This does not actually work.
                  // The System.Text.Json reader will throw that the converter consumed too few bytes.
                  return default!;
               }
            }
            else if (nestedReader.TokenType == JsonTokenType.EndObject)
            {
               // We have exhausted the search within the object for a discriminator but it was not found.
               break;
            }
         }

         if (UndefinedOrDefaultType is not null)
         {
            return (T)JsonSerializer.Deserialize(ref reader, UndefinedOrDefaultType, options)!;
         }

         if (reader.IsFinalBlock)
         {
            throw new JsonException(
                $"Unable to find discriminator property '{DiscriminatorPropertyName}'"
            );
         }

         return default!;
      }

      public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
      {
         JsonSerializer.Serialize<object>(writer, value!, options);
      }

      private Type GetSubType(ref Utf8JsonReader reader)
      {
         if (reader.TokenType != JsonTokenType.String)
         {
            if (reader.TokenType == JsonTokenType.Null && UndefinedOrDefaultType is not null)
            {
               return UndefinedOrDefaultType;
            }

            throw new JsonException(
                $"Expected string discriminator value, got '{reader.TokenType}'"
            );
         }

         foreach (var (subValue, subType) in SubTypes)
         {
            if (reader.ValueTextEquals(subValue.EncodedUtf8Bytes))
            {
               return subType;
            }
         }

         if (UnknownOrDefaultType is not null)
         {
            return UnknownOrDefaultType;
         }

         throw new JsonException($"'{reader.GetString()}' is not a valid discriminator value");
      }
   }
}