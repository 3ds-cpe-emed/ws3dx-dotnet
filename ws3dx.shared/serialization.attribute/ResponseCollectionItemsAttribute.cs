using System;


namespace ws3dx.serialization.attribute
{
   /// <summary>
   /// Describe the items (must be 
   /// </summary>
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
   public class ResponseCollectionItemsAttribute : Attribute
   {
      public string JsonPropertyName { get; private set; }

      public ResponseCollectionItemsAttribute(string jsonPropertyName)
      {
         JsonPropertyName = jsonPropertyName;
      }
   }
}
