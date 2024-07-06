/// Reused from https://github.com/rmja/PolyJson (v1.4.0) (kudos to rmja for this!)
/// while Microsoft doesn't fix its json polymorphism implementation :
/// e.g. current issues with Discriminator not being the first property https://github.com/dotnet/runtime/issues/72604 
/// and even if that one is solved in net9.0 the type attribute (on the C# instance) is not populated so I am not able
/// to know which interface to cast to.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace PolyJson.Converters
{
   internal interface IPolyJsonConverter
   {
      JsonEncodedText DiscriminatorPropertyName { get; set; }
      Type UndefinedOrDefaultType { get; set; }
      Type UnknownOrDefaultType { get; set; }
      Dictionary<JsonEncodedText, Type> SubTypes { get; set; }
   }
}