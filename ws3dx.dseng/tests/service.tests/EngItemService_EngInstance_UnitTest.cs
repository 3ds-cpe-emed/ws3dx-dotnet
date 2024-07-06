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
using System.Linq;
using System.Threading.Tasks;

using ws3dx.authentication.data;
using ws3dx.core.exception;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.dseng.data.impl;
using ws3dx.shared.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemService_EngInstance_UnitTests : EngItemServiceTestsSetup
   {
      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstance_IEngInstanceFilterableMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
            Assert.IsNotNull(ret);

            foreach (IEngInstanceDefaultMask engInstance in ret)
            {
               IEngInstanceFilterableMask engInstanceFilterableMask = await engItemService.GetInstance<IEngInstanceFilterableMask>(engItem.Id, engInstance.Id);

               Assert.IsNotNull(engInstanceFilterableMask);

               Assert.AreEqual(engInstance.Id, engInstanceFilterableMask.Id);
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstance_IEngInstancePositionMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
            Assert.IsNotNull(ret);

            foreach (IEngInstanceDefaultMask engInstance in ret)
            {
               IEngInstancePositionMask engInstancePositionMask = await engItemService.GetInstance<IEngInstancePositionMask>(engItem.Id, engInstance.Id);

               Assert.IsNotNull(engInstancePositionMask);

               Assert.AreEqual(engInstance.Id, engInstancePositionMask.Id);
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstance_IEngInstanceDefaultMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
            Assert.IsNotNull(ret);

            foreach (IEngInstanceDefaultMask engInstance in ret)
            {
               IEngInstanceDefaultMask engInstanceDefaultMask = await engItemService.GetInstance<IEngInstanceDefaultMask>(engItem.Id, engInstance.Id);

               Assert.IsNotNull(engInstanceDefaultMask);

               Assert.AreEqual(engInstance.Id, engInstanceDefaultMask.Id);
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstance_IEngInstanceDetailsMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 10);
            Assert.IsNotNull(ret);

            foreach (IEngInstanceDefaultMask engInstance in ret)
            {
               IEngInstanceDetailsMask engInstanceDetailMask = await engItemService.GetInstance<IEngInstanceDetailsMask>(engItem.Id, engInstance.Id);

               Assert.IsNotNull(engInstanceDetailMask);

               Assert.AreEqual(engInstance.Id, engInstanceDetailMask.Id);
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstances_IEngInstanceFilterableMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.GetInstances<IEngInstanceFilterableMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstances_IEngInstancePositionMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstancePositionMask> ret = await engItemService.GetInstances<IEngInstancePositionMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstances_IEngInstanceDefaultMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task GetInstances_IEngInstanceDetailsMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task ReplaceInstance_IEngInstanceFilterableMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);

            //there should be at least two otherwise the test cannot be performed
            IEnumerable<IEngInstanceDetailsMask> distincEngInstanceRef = ret.DistinctBy(engInstance => engInstance.ReferencedObject.Id);

            if (distincEngInstanceRef.Count() < 2)
            {
               throw new Exception("Need at least two distinct instance references to run this test");
            }

            Assert.IsNotNull(distincEngInstanceRef.First());
            Assert.IsNotNull(distincEngInstanceRef.ElementAt(1));

            IEngInstanceDetailsMask engInstanceIdToBeReplaced = distincEngInstanceRef.First();

            ITypedUriId newEngItemInstanceRef = distincEngInstanceRef.ElementAt(1).ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(newEngItemInstanceRef.Id, engItemService.EnoviaServiceURL);

            EngInstanceReplace newEngInstance = new EngInstanceReplace();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new EngInstanceReplaceAttributes();
            newEngInstance.Attributes.Name = "instance replacement";
            newEngInstance.Attributes.Description = "replaced from the web services";

            try
            {
               IEnumerable<IEngInstanceFilterableMask> retReplacement = await engItemService.ReplaceInstance<IEngInstanceFilterableMask>(engItem.Id, engInstanceIdToBeReplaced.Id, newEngInstance);

               Assert.IsNotNull(retReplacement);
               Assert.IsNotNull(retReplacement.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task ReplaceInstance_IEngInstanceDefaultMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);

            //there should be at least two otherwise the test cannot be performed
            IEnumerable<IEngInstanceDetailsMask> distincEngInstanceRef = ret.DistinctBy(engInstance => engInstance.ReferencedObject.Id);

            if (distincEngInstanceRef.Count() < 2)
            {
               throw new Exception("Need at least two distinct instance references to run this test");
            }

            Assert.IsNotNull(distincEngInstanceRef.First());
            Assert.IsNotNull(distincEngInstanceRef.ElementAt(1));

            IEngInstanceDetailsMask engInstanceIdToBeReplaced = distincEngInstanceRef.First();

            ITypedUriId newEngItemInstanceRef = distincEngInstanceRef.ElementAt(1).ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(newEngItemInstanceRef.Id, engItemService.EnoviaServiceURL);

            EngInstanceReplace newEngInstance = new EngInstanceReplace();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new EngInstanceReplaceAttributes();
            newEngInstance.Attributes.Name = "instance replacement";
            newEngInstance.Attributes.Description = "replaced from the web services";

            try
            {
               IEnumerable<IEngInstanceDefaultMask> retReplacement = await engItemService.ReplaceInstance<IEngInstanceDefaultMask>(engItem.Id, engInstanceIdToBeReplaced.Id, newEngInstance);

               Assert.IsNotNull(retReplacement);
               Assert.IsNotNull(retReplacement.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task ReplaceInstance_IEngInstanceDetailsMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 100);
            Assert.IsNotNull(ret);

            //there should be at least two otherwise the test cannot be performed
            IEnumerable<IEngInstanceDetailsMask> distincEngInstanceRef = ret.DistinctBy(engInstance => engInstance.ReferencedObject.Id);

            if (distincEngInstanceRef.Count() < 2)
            {
               throw new Exception("Need at least two distinct instance references to run this test");
            }

            Assert.IsNotNull(distincEngInstanceRef.First());
            Assert.IsNotNull(distincEngInstanceRef.ElementAt(1));

            IEngInstanceDetailsMask engInstanceIdToBeReplaced = distincEngInstanceRef.First();

            ITypedUriId newEngItemInstanceRef = distincEngInstanceRef.ElementAt(1).ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(newEngItemInstanceRef.Id, engItemService.EnoviaServiceURL);

            EngInstanceReplace newEngInstance = new EngInstanceReplace();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new EngInstanceReplaceAttributes();
            newEngInstance.Attributes.Name = "instance replacement";
            newEngInstance.Attributes.Description = "replaced from the web services";

            try
            {
               IEnumerable<IEngInstanceDetailsMask> retReplacement = await engItemService.ReplaceInstance<IEngInstanceDetailsMask>(engItem.Id, engInstanceIdToBeReplaced.Id, newEngInstance);

               Assert.IsNotNull(retReplacement);
               Assert.IsNotNull(retReplacement.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task AddInstance_IEngInstanceFilterableMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 1);
            Assert.IsNotNull(ret);
            Assert.IsNotNull(ret.First());

            ITypedUriId engItemRefId = ret.First().ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(engItemRefId.Id, engItemService.EnoviaServiceURL);

            NewEngInstance newEngInstance = new NewEngInstance();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new NewEngInstanceAttributes();
            newEngInstance.Attributes.Name = "instance";
            newEngInstance.Attributes.Description = "created from the web services";

            CreateEngInstances request = new CreateEngInstances();
            request.Instances = [newEngInstance];

            try
            {
               IEnumerable<IEngInstanceFilterableMask> retAddInstance = await engItemService.AddInstance<IEngInstanceFilterableMask>(engItem.Id, request);
               Assert.IsNotNull(ret);
               Assert.IsNotNull(ret.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task AddInstance_IEngInstancePositionMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 1);
            Assert.IsNotNull(ret);
            Assert.IsNotNull(ret.First());

            ITypedUriId engItemRefId = ret.First().ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(engItemRefId.Id, engItemService.EnoviaServiceURL);

            NewEngInstance newEngInstance = new NewEngInstance();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new NewEngInstanceAttributes();
            newEngInstance.Attributes.Name = "instance";
            newEngInstance.Attributes.Description = "created from the web services";

            CreateEngInstances request = new CreateEngInstances();
            request.Instances = [newEngInstance];

            try
            {
               IEnumerable<IEngInstancePositionMask> retAddInstance = await engItemService.AddInstance<IEngInstancePositionMask>(engItem.Id, request);
               Assert.IsNotNull(ret);
               Assert.IsNotNull(ret.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task AddInstance_IEngInstanceDefaultMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 1);
            Assert.IsNotNull(ret);
            Assert.IsNotNull(ret.First());

            ITypedUriId engItemRefId = ret.First().ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(engItemRefId.Id, engItemService.EnoviaServiceURL);

            NewEngInstance newEngInstance = new NewEngInstance();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new NewEngInstanceAttributes();
            newEngInstance.Attributes.Name = "instance";
            newEngInstance.Attributes.Description = "created from the web services";

            CreateEngInstances request = new CreateEngInstances();
            request.Instances = [newEngInstance];

            try
            {
               IEnumerable<IEngInstanceDefaultMask> retAddInstance = await engItemService.AddInstance<IEngInstanceDefaultMask>(engItem.Id, request);
               Assert.IsNotNull(ret);
               Assert.IsNotNull(ret.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }

      [TestCase("AAA27 Engineering Configuration Item", "A.1")]
      public async Task AddInstance_IEngInstanceDetailsMask(string _title, string _rev)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport);

         SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

         IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchCriteria);

         foreach (IEngItemDefaultMask engItem in engItemSearchResult)
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItem.Id, 0, 1);
            Assert.IsNotNull(ret);
            Assert.IsNotNull(ret.First());

            ITypedUriId engItemRefId = ret.First().ReferencedObject;

            ITypedUriIdentifier newEngItemRefIdentifier = new EngItemUriIdentitier(engItemRefId.Id, engItemService.EnoviaServiceURL);

            NewEngInstance newEngInstance = new NewEngInstance();
            newEngInstance.ReferencedObject = newEngItemRefIdentifier;
            newEngInstance.Attributes = new NewEngInstanceAttributes();
            newEngInstance.Attributes.Name = "instance";
            newEngInstance.Attributes.Description = "created from the web services";

            CreateEngInstances request = new CreateEngInstances();
            request.Instances = [newEngInstance];

            try
            {
               IEnumerable<IEngInstanceDetailsMask> retAddInstance = await engItemService.AddInstance<IEngInstanceDetailsMask>(engItem.Id, request);
               Assert.IsNotNull(ret);
               Assert.IsNotNull(ret.First());
            }
            catch (HttpResponseException ex)
            {
               Assert.Fail(await ex.GetErrorMessage());
            }
         }
      }
   }
}