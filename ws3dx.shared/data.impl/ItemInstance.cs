// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2022 Dassault Systèmes - CPE EMED
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
// ------------------------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;
using ws3dx.shared.data;

namespace ws3dx.data.impl
{
   public class ItemInstance : IItemInstanceMask
   {
      private const string ID = "id";
      private const string TYPE = "type";
      private const string CREATED = "created";
      private const string MODIFIED = "modified";
      //private const string NAME = "name";
      private const string DESCRIPTION = "description";
      private const string TITLE = "title";
      private const string CESTAMP = "cestamp";

      //private string m_title = null;
      //private string m_description = null;

      [JsonPropertyName(ID)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Id { get; set; }

      [JsonPropertyName(TYPE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Type { get; set; }

      [JsonPropertyName(CREATED)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Created { get; set; }

      [JsonPropertyName(MODIFIED)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Modified { get; set; }

      [JsonPropertyName(TITLE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Title { get; set; }

      [JsonPropertyName(CESTAMP)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public virtual string Cestamp { get; set; }

      [JsonPropertyName(DESCRIPTION)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      //public string Description { get => m_description; set => SetProperty(ref m_description, value); }
      public virtual string Description { get; set; }
   }
}
