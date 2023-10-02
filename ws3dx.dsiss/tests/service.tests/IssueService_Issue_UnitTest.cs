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
using ws3dx.core.exception;
using ws3dx.dsiss.core.data.impl;
using ws3dx.dsiss.core.service;
using ws3dx.dsiss.data;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class IssueService_Issue_UnitTests : IssueServiceTestsSetup
   {
      [TestCase("2CDF9777B61A0000600FCD2F000CF036")]
      public async Task Get(string issueId)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         IIssueDetail ret = await issueService.Get(issueId);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_ISearchOutput(string search, int skip, int top)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<ITypedUriIdentifier> ret = await issueService.Search(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("AAA27")]
      public async Task Search_Full_ISearchOutput(string searchCriteria)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         try
         {
            IList<ITypedUriIdentifier> ret = await issueService.Search(new SearchByFreeText(searchCriteria));
            Assert.IsNotNull(ret);

            int i = 0;
            foreach (ITypedUriIdentifier issuedUriIdentifier in ret)
            {
               IIssueDetail issue = await issueService.Get(issuedUriIdentifier.Identifier);

               Assert.AreEqual(issue.Id, issuedUriIdentifier.Identifier);

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

      [TestCase("")]
      public async Task Reject(string issueId)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         IIssueComment request = new IssueComment();

         try
         {
            IIssue ret = await issueService.Reject(issueId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("New Issue AAA27", "Issue created from Web Services")]
      public async Task Create(string issueTitle, string issueDescription)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         ICreateIssue request = new CreateIssue
         {
            Title = issueTitle,
            Description = issueDescription
         };

         try
         {
            IIssue ret = await issueService.Create(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task Approve(string issueId)
      {
         IssueService issueService = ServiceFactoryCreate(await Authenticate());

         IIssueComment request = new IssueComment();

         try
         {
            IIssue ret = await issueService.Approve(issueId, request);

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