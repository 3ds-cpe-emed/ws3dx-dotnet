/// Reused from https://github.com/rmja/PolyJson (v1.4.0) (kudos to rmja for this!)
/// while Microsoft doesn't fix its json polymorphism implementation :
/// e.g. current issues with Discriminator not being the first property https://github.com/dotnet/runtime/issues/72604 
/// and even if that one is solved in net9.0 the type attribute (on the C# instance) is not populated so I am not able
/// to know which interface to cast to.
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PolyJson
{
   public static class DiscriminatorValue<T>
   {
      public static string Value { get; } = DiscriminatorValue.Get(typeof(T));
   }

   public static class DiscriminatorValue
   {
      private static Dictionary<Type, string> _cache = new();
      private static readonly object _lock = new();

      public static string Get(Type type)
      {
         if (_cache.TryGetValue(type, out var value))
         {
            return value;
         }
         Ensure(type);
         return _cache[type];
      }

      private static void Ensure(Type type)
      {
         var attributedType = GetAttributedType(type);
         if (attributedType is null)
         {
            throw new InvalidOperationException(
                $"The type {type} or any of its base class are attributed with the PolyJsonConverter attribute"
            );
         }

         lock (_lock)
         {
            // Test cache once more within the lock before cloning
            if (_cache.ContainsKey(type))
            {
               return;
            }

            var cloned = new Dictionary<Type, string>(_cache);

            var attribute = attributedType.GetCustomAttribute<PolyJsonConverterAttribute>()!;
            if (attribute.DefaultType is not null)
            {
               cloned.Add(attribute.DefaultType, null);
            }
            if (attribute.UnknownType is not null)
            {
               cloned.Add(attribute.UnknownType, null);
            }

            foreach (
                var subType in attributedType.GetCustomAttributes<PolyJsonConverter.SubTypeAttribute>()
            )
            {
               cloned.Add(subType.SubType, subType.DiscriminatorValue);
            }
            _cache = cloned;
         }

         if (!_cache.ContainsKey(type))
         {
            throw new ArgumentException(
                $"The type {type} is not a subtype of {attributedType}"
            );
         }
      }

      private static Type GetAttributedType(Type type)
      {
         while (type.GetCustomAttribute<PolyJsonConverterAttribute>(inherit: false) is null)
         {
            if (type.BaseType is null)
            {
               return null;
            }
            type = type.BaseType;
         }
         return type;
      }
   }
}