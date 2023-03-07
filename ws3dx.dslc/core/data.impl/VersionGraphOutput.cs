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
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ws3dx.dslc.data;
using ws3dx.serialization.attribute;

namespace ws3dx.dslc.core.data.impl
{
   //------------------------------------------------------------------------------------------------
   // <summary>
   //
   // Example: 
   // [{"versions":[{"maturityState":"IN_WORK","id":"5045B056C51000005EA6A93000166A76","identifier":"5045B056C51000005EA6A93000166A76","type":"VPMReference","source":"https://ve4al702dsy.dsone.3ds.com:443/3DSpace","relativePath":"/resources/v1/modeler/dseng/dseng:EngItem/5045B056C51000005EA6A93000166A76","ancestors":[{"edgeType":"Revision","id":"F718B05686760000926EEB5BE7400900","identifier":"F718B05686760000926EEB5BE7400900","type":"VPMReference","source":"https://ve4al702dsy.dsone.3ds.com:443/3DSpace","relativePath":"/resources/v1/modeler/dseng/dseng:EngItem/F718B05686760000926EEB5BE7400900"}],"revision":"B.1"},{"maturityState":"IN_WORK","id":"F718B05686760000926EEB5BE7400900","identifier":"F718B05686760000926EEB5BE7400900","type":"VPMReference","source":"https://ve4al702dsy.dsone.3ds.com:443/3DSpace","relativePath":"/resources/v1/modeler/dseng/dseng:EngItem/F718B05686760000926EEB5BE7400900","revision":"A.1"}],"id":"F718B05686760000926EEB5BE7400900","identifier":"F718B05686760000926EEB5BE7400900","type":"VPMReference","source":"https://ve4al702dsy.dsone.3ds.com:443/3DSpace","relativePath":"/resources/v1/modeler/dseng/dseng:EngItem/F718B05686760000926EEB5BE7400900"}]
   //
   // </summary>
   //------------------------------------------------------------------------------------------------
   public class VersionGraphOutput : IVersionGraphOutput
   {
      [ResponseCollectionItems("results")]
      [JsonPropertyName("results")]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public IList<IVersionGraph> Results { get; set; }
   }
}