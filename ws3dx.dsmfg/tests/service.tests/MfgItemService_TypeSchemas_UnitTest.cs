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
using NUnit.Framework;
using System.Threading.Tasks;

using ws3dx.dsmfg.core.service;
using ws3dx.dsmfg.data;

namespace NUnitTestProject
{
   public class MfgItemService_TypeSchemas_UnitTests : MfgItemServiceTestsSetup
   {
      [TestCase("AF8E4289295538006563506E00153753")] //CreateAssembly
      public async Task Get_IMfgItemDetailMask(string mfgItemId)
      {
         MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());
         IMfgAssemblyDetail ret = (IMfgAssemblyDetail)await mfgItemService.Get<IMfgItemDetailMask>(mfgItemId);

         Assert.IsNotNull(ret);
      }
   }
}