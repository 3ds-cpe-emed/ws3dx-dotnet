using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ws3dx.shared.data.collection.impl
{
   public class ResourcesSet<T> : IItems<T>
   {
      [JsonPropertyName("resources")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<T> Items { get; set; }
   }
}
