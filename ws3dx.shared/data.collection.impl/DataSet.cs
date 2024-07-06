using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ws3dx.shared.data.collection.impl
{
   public class DataSet<T> : IItems<T>
   {
      [JsonPropertyName("data")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<T> Items { get; set; }
   }
}
