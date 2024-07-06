using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ws3dx.shared.data.collection.impl
{
   public class ResultsSet<T> : IItems<T>
   {
      [JsonPropertyName("results")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<T> Items { get; set; }
   }
}
