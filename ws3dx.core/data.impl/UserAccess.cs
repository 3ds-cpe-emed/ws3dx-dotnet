// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2023 Dassault Systèmes - CPE EMED
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
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ws3dx.core.data.impl
{
   public class UserAccess
   {
      [JsonPropertyName("id")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      [JsonPropertyName("uuid")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Uuid { get; set; }

      [JsonPropertyName("firstname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string FirstName { get; set; }

      [JsonPropertyName("lastname")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string LastName { get; set; }

      [JsonPropertyName("email")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Email { get; set; }

      [JsonPropertyName("showCoachmark")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? ShowCoachmark { get; set; }

      [JsonPropertyName("platforms")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IEnumerable<PlatformAccess> Platforms { get; set; }

      [JsonPropertyName("admin")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public bool? IsAdmin { get; set; }

      [JsonPropertyName("removedPlatforms")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IEnumerable<object> RemovedPlatforms { get; set; }
   }
}
