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

namespace ws3dx.dsdo.data
{
   public interface IDerivedOutputRule
   {
      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 3DEXPERIENCE
      //
      // </summary>
      //----------------------------------------------------------------
      public string Converter { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string TargetToDisplay { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: authoring
      //
      // </summary>
      //----------------------------------------------------------------
      public string InputStreamId { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: SLDDRW
      //
      // </summary>
      //----------------------------------------------------------------
      public string Source { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: UDL
      //
      // </summary>
      //----------------------------------------------------------------
      public string Target { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string SourceToDisplay { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: Drawing
      //
      // </summary>
      //----------------------------------------------------------------
      public string SourceType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: onXCADSave
      //
      // </summary>
      //----------------------------------------------------------------
      public string RuleType { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: authoringvisu
      //
      // </summary>
      //----------------------------------------------------------------
      public string OutputStreamId { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example:
      //
      // </summary>
      //----------------------------------------------------------------
      public string State { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: 9bd24c2657e61137e918f02347c051ef55f4e16fe466ff4e6545b7877964cd3c
      //
      // </summary>
      //----------------------------------------------------------------
      public string RuleId { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: SOLIDWORKS
      //
      // </summary>
      //----------------------------------------------------------------
      public string Category { get; set; }

      //----------------------------------------------------------------
      // <summary>
      //		
      // Example: forcedactive
      //
      // </summary>
      //----------------------------------------------------------------
      public string Activation { get; set; }
   }
}