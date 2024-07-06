/// Reused from https://github.com/rmja/PolyJson (v1.4.0) (kudos to rmja for this!)
/// while Microsoft doesn't fix its json polymorphism implementation :
/// e.g. current issues with Discriminator not being the first property https://github.com/dotnet/runtime/issues/72604 
/// and even if that one is solved in net9.0 the type attribute (on the C# instance) is not populated so I am not able
/// to know which interface to cast to.

using System;

namespace PolyJson
{
   public class PolyJsonConverter
   {
      [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
      public class SubTypeAttribute : Attribute
      {
         public Type SubType { get; set; }
         public string DiscriminatorValue { get; set; }

         public SubTypeAttribute(Type subType, string discriminatorValue)
         {
            SubType = subType;
            DiscriminatorValue = discriminatorValue;
         }
      }
   }
}