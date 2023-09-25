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

using System.Collections.Generic;
using System.Threading.Tasks;

using ws3dx.authentication.data;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;

namespace NUnitTestProject
{
   public class EngItemService_Alternate_UnitTests : EngItemServiceSetup
   {
      [TestCase("0012C0507B420000610A3A6F000B3CD5", "221CD96CF43B000064BD8C01000BEBE6")]
      public async Task GetAlternate_IAlternateMask(string engItemId, string alternateId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IAlternateMask ret = await engItemService.GetAlternate<IAlternateMask>(engItemId, alternateId);

         Assert.IsNotNull(ret);
      }

      [TestCase("0012C0507B420000610A3A6F000B3CD5", "221CD96CF43B000064BD8C01000BEBE6")]
      public async Task GetAlternate_IAlternateDetailMask(string engItemId, string alternateId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IAlternateDetailMask ret = await engItemService.GetAlternate<IAlternateDetailMask>(engItemId, alternateId);

         Assert.IsNotNull(ret);
      }

      [TestCase("37DE0CE16865000060EFEEB100025C53")]
      public async Task GetAlternates_IAlternateMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnumerable<IAlternateMask> ret = await engItemService.GetAlternates<IAlternateMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("37DE0CE16865000060EFEEB100025C53")]
      public async Task GetAlternates_IAlternateDetailMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         IEnumerable<IAlternateDetailMask> ret = await engItemService.GetAlternates<IAlternateDetailMask>(engItemId);

         Assert.IsNotNull(ret);
      }
   }
}