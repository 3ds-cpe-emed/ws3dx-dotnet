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

namespace ws3dx.shared.data.dscfg
{
   public class SetEvolutionResponse : ISetEvolutionResponse
   {
      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The value of this field will be physical id of a relationship. If there is a error 
      // in set evolution effectivity then this field will not be available in output. Example: 
      // F6AF82561E5700005EB271EE0003C500
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string Id { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The value of this field will be a valid error code. This field will be available only 
      // if set evolution failed for a input relationship. In case of set evolution success then this 
      // field will not be available in output. Example: 102
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string ErrorCode { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The value of this field will be a valid NLS error message. This field will be available 
      // only if set evolution failed for a input relationship. In case of set evolution success then this 
      // field will not be available in output. Example: The parent reference of the given instance does 
      // not have a Configuration Context.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string Message { get; set; }

      //------------------------------------------------------------------------------------------------
      //<summary>
      //
      // Description: The value of this field will be the details about the error. This field will be 
      // available only if set evolution failed for a input relationship. In case of set evolution success 
      // then this field will not be available in output. Example: The reference : F6AF82561E5700005EB123650003C100 
      // does not have a model attached.
      //
      //<summary>
      //------------------------------------------------------------------------------------------------
      public string ErrorDetails { get; set; }
   }
}