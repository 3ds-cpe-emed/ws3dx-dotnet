//------------------------------------------------------------------------------------------------------------------------------------
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
//------------------------------------------------------------------------------------------------------------------------------------
using System.Text.Json.Serialization;
using ws3dx.dsxcad.data;

namespace ws3dx.dsxcad.core.data.impl
{
   public class FileCheckinTicket : IFileCheckinTicket
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The URL that should be used to upload Example: xxx
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ticketURL")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string TicketURL { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The ticket to use for upload to FCS. Each ticket is valid for the number of files 
      // mandatory for update: 2 for dsxcad:Part and 1 for dsxcad:Representation Example: xxx
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("ticket")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Ticket { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The parameters that should be used to upload Example: __fcs__jobTicket
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      [JsonPropertyName("jobticket")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Jobticket { get; set; }
   }
}