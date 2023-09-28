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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.utils.search;
using ws3dx.dsprcs.core.service;
using ws3dx.dsprcs.data;
using ws3dx.core.exception;
using ws3dx.dsprcs.core.data.impl;
using ws3dx.authentication.data;
using ws3dx.dsmfg;

namespace NUnitTestProject
{
   public class MfgProcessService_MfgProcess_UnitTests : MfgProcessServiceTestsSetup
   {
      [TestCase("")]
      public async Task Get_IMfgProcessMask(string mfgProcessId)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         IMfgProcessMask ret = await mfgProcessService.Get<IMfgProcessMask>(mfgProcessId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgProcessDetailMask(string mfgProcessId)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         IMfgProcessDetailMask ret = await mfgProcessService.Get<IMfgProcessDetailMask>(mfgProcessId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IMfgProcessStructureModelViewIndexMask(string mfgProcessId)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         IMfgProcessStructureModelViewIndexMask ret = await mfgProcessService.Get<IMfgProcessStructureModelViewIndexMask>(mfgProcessId);

         Assert.IsNotNull(ret);
      }

      [TestCase("process", 0, 50)]
      public async Task Search_Paged_IMfgProcessMask(string search, int skip, int top)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Search<IMfgProcessMask>(searchByFreeText, skip, top);
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (IMfgProcessMask process in ret)
            {
               IMfgProcessDetailMask processDetail = await mfgProcessService.Get<IMfgProcessDetailMask>(process.Id);

               Assert.AreEqual(process.Id, processDetail.Id);

               i++;

               if (i > 20) return;
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("process")]
      public async Task Search_Full_IMfgProcessMask(string search)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         try
         {
            IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Search<IMfgProcessMask>(searchByFreeText);
            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IMfgProcessMask()
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            (IList<IMfgProcessMask>, IList<string>) ret = await mfgProcessService.BulkFetch<IMfgProcessMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task BulkFetch_IMfgProcessDetailMask()
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         string[] request = new string[] { };

         try
         {
            (IList<IMfgProcessDetailMask>, IList<string>) ret = await mfgProcessService.BulkFetch<IMfgProcessDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Locate(int top, int skip)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         ILocateMfgProcessRequest request = new LocateMfgProcessRequest();

         try
         {
            IEnumerable<IMfgProcessLocateUTCMask> ret = await mfgProcessService.Locate(top, skip, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddExpand_IMfgProcessExpandMaskV1(string mfgProcessId)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         IMfgProcessExpandRequestPayloadV1 request = new MfgProcessExpandRequestPayloadV1();

         try
         {
            IEnumerable<IMfgProcessExpandMaskV1> ret = await mfgProcessService.Expand<IMfgProcessExpandMaskV1>(mfgProcessId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddExpand_IMfgProcessExpandMaskDetailV1(string mfgProcessId)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         IMfgProcessExpandRequestPayloadV1 request = new MfgProcessExpandRequestPayloadV1();

         try
         {
            IEnumerable<IMfgProcessExpandMaskDetailV1> ret = await mfgProcessService.Expand<IMfgProcessExpandMaskDetailV1>(mfgProcessId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase(MFGResourceNames.WORKPLAN_TYPE, "AAA27 Process Name")]
      public async Task Create_IMfgProcessMask(string _processType, string _processName)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         INewMfgProcess process = new NewMfgProcess();
         process.Attributes = new MfgProcess();
         process.Attributes.Type = _processType;
         process.Attributes.Title = _processName;

         ICreateMfgProcess request = new CreateMfgProcess();
         request.Items = new List<INewMfgProcess>() { process };


         try
         {
            IEnumerable<IMfgProcessMask> ret = await mfgProcessService.Create<IMfgProcessMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase(MFGResourceNames.WORKPLAN_TYPE, "AAA27 Workplan Process Name")]
      public async Task Create_IMfgProcessDetailMask(string _processType, string _processName)
      {
         MfgProcessService mfgProcessService = ServiceFactoryCreate(await Authenticate());

         INewMfgProcess process = new NewMfgProcess();
         process.Attributes = new MfgProcess();
         process.Attributes.Type = _processType;
         process.Attributes.Title = _processName;

         ICreateMfgProcess request = new CreateMfgProcess();
         request.Items = new List<INewMfgProcess>() { process };

         try
         {
            IEnumerable<IMfgProcessDetailMask> ret = await mfgProcessService.Create<IMfgProcessDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

   }
}