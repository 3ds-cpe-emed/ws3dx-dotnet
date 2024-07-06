using System.Collections.Generic;


namespace ws3dx.shared.data.collection
{
   public interface IItems<T>
   {
      public IList<T> Items { get; set; }
   }
}
