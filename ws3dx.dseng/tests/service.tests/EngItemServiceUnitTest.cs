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
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.dseng.core.data.impl;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.shared.data;
using ws3dx.shared.data.dscfg;
using ws3dx.shared.data.impl;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class EngItemServiceTests
   {
      private const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      private const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      private const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      private const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      private const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";

      private string m_username = string.Empty;
      private string m_password = string.Empty;
      private string m_passportUrl = string.Empty;
      private string m_serviceUrl = string.Empty;
      private string m_tenant = string.Empty;

      private UserInfo m_userInfo = null;

      private const string PART_NUMBER_TEST = "AAA27:0000002";

      public async Task<IPassportAuthentication> Authenticate()
      {
         UserPassport passport = new UserPassport(m_passportUrl);

         UserInfoRedirection userInfoRedirection = new UserInfoRedirection(m_serviceUrl, m_tenant)
         {
            Current = true,
            IncludeCollaborativeSpaces = true,
            IncludePreferredCredentials = true
         };

         m_userInfo = await passport.CASLoginWithRedirection<UserInfo>(m_username, m_password, false, userInfoRedirection);

         Assert.IsNotNull(m_userInfo);

         StringAssert.AreEqualIgnoringCase(m_userInfo.name, m_username);

         Assert.IsTrue(passport.IsCookieAuthenticated);

         return passport;
      }

      [SetUp]
      public void Setup()
      {
         m_username = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_USERNAME, EnvironmentVariableTarget.User); // e.g. AAA27
         m_password = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSWORD, EnvironmentVariableTarget.User); // e.g. your password
         m_passportUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_PASSPORT, EnvironmentVariableTarget.User); // e.g. https://eu1-ds-iam.3dexperience.3ds.com:443/3DPassport

         m_serviceUrl = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_ENOVIA, EnvironmentVariableTarget.User); // e.g. https://r1132100982379-eu1-space.3dexperience.3ds.com:443/enovia
         m_tenant = Environment.GetEnvironmentVariable(DS3DXWS_AUTH_TENANT, EnvironmentVariableTarget.User); // e.g. R1132100982379
      }

      public string GetDefaultSecurityContext()
      {
         return m_userInfo.preferredcredentials.ToString();
      }

      public EngItemService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         EngItemService __engItemService = new EngItemService(_serviceUrl, _passport);
         __engItemService.Tenant = _tenant;
         __engItemService.SecurityContext = GetDefaultSecurityContext();
         return __engItemService;
      }

      [TestCase("3784C760967A00006409AA5B000160E9")]
      public async Task GetEnterpriseItemNumber(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnterpriseItemNumberMask ret = await engItemService.GetEnterpriseItemNumber(engItemId);

         Assert.IsNotNull(ret);

         Assert.AreEqual(ret.PartNumber, PART_NUMBER_TEST);
      }

      [TestCase("", "")]
      public async Task GetInstance_IEngInstanceMaskFilterable(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngInstanceFilterableMask ret = await engItemService.GetInstance<IEngInstanceFilterableMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IEngInstanceMaskPosition(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngInstancePositionMask ret = await engItemService.GetInstance<IEngInstancePositionMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngInstanceDefaultMask ret = await engItemService.GetInstance<IEngInstanceDefaultMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstance_IEngInstanceDetailsMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngInstanceDetailsMask ret = await engItemService.GetInstance<IEngInstanceDetailsMask>(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IEngItemDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngItemDefaultMask ret = await engItemService.Get<IEngItemDefaultMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IEngItemCommonMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngItemCommonMask ret = await engItemService.Get<IEngItemCommonMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IEngItemDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngItemDetailsMask ret = await engItemService.Get<IEngItemDetailsMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IEngItemConfigMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEngItemConfigMask ret = await engItemService.Get<IEngItemConfigMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IEngItemDefaultMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDefaultMask> ret = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("New Engineering item created from Web Service")]
      public async Task Search_Full_IEngItemDefaultMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDefaultMask> ret = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText);
         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IEngItemDefaultMask engItem in ret)
         {
            IEngItemDetailsMask engItemDetail = await engItemService.Get<IEngItemDetailsMask>(engItem.Id);

            Assert.AreEqual(engItem.Id, engItemDetail.Id);

            i++;

            if (i > 20) return;
         }
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IEngItemCommonMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IEngItemCommonMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemCommonMask> ret = await engItemService.Search<IEngItemCommonMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }
      [TestCase("search", 0, 50)]
      public async Task Search_Paged_IEngItemDetailsMask(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText, skip, top);

         Assert.IsNotNull(ret);
      }

      [TestCase("search")]
      public async Task Search_Full_IEngItemDetailsMask(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IEngItemDetailsMask> ret = await engItemService.Search<IEngItemDetailsMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredDetail(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredDetail> ret = await engItemService.GetConfiguration<IConfiguredDetail>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetConfiguration_IConfiguredBasics(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IConfiguredBasics> ret = await engItemService.GetConfiguration<IConfiguredBasics>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetChangeControl(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IChangeControlStatusMask ret = await engItemService.GetChangeControl(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("0012C0507B420000610A3A6F000B3CD5", "221CD96CF43B000064BD8C01000BEBE6")]
      public async Task GetAlternate_IAlternateMaskDefault(string engItemId, string alternateId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IAlternateMask ret = await engItemService.GetAlternate<IAlternateMask>(engItemId, alternateId);

         Assert.IsNotNull(ret);
      }

      [TestCase("0012C0507B420000610A3A6F000B3CD5", "221CD96CF43B000064BD8C01000BEBE6")]
      public async Task GetAlternate_IAlternateMaskDetail(string engItemId, string alternateId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IAlternateDetailMask ret = await engItemService.GetAlternate<IAlternateDetailMask>(engItemId, alternateId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetInstanceEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IFilterableDetailMask> ret = await engItemService.GetInstanceEffectivity(engItemId, instanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("37DE0CE16865000060EFEEB100025C53")]
      public async Task GetAlternates_IAlternateMaskDefault(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlternateMask> ret = await engItemService.GetAlternates<IAlternateMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("37DE0CE16865000060EFEEB100025C53")]
      public async Task GetAlternates_IAlternateMaskDetail(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IAlternateDetailMask> ret = await engItemService.GetAlternates<IAlternateDetailMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IEngInstanceMaskFilterable(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.GetInstances<IEngInstanceFilterableMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IEngInstanceMaskPosition(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IEngInstancePositionMask> ret = await engItemService.GetInstances<IEngInstancePositionMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IEngInstanceDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.GetInstances<IEngInstanceDefaultMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetInstances_IEngInstanceDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.GetInstances<IEngInstanceDetailsMask>(engItemId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task AttachConfiguration(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<ITypedUriIdentifier> ret = await engItemService.AttachConfiguration(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachChangeControl(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAddEmpty request = new AddEmpty();

         try
         {
            IGenericResponse ret = await engItemService.AttachChangeControl(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task SetInstanceEvolutionEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ISetEvolutionEffectivities request = new SetEvolutionEffectivities();

         try
         {
            ISetEvolutionResponse ret = await engItemService.SetInstanceEvolutionEffectivity(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceMaskFilterable(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.ReplaceInstance<IEngInstanceFilterableMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceDefaultMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.ReplaceInstance<IEngInstanceDefaultMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task ReplaceInstance_IEngInstanceDetailsMask(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEngInstanceReplace request = new EngInstanceReplace();

         try
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.ReplaceInstance<IEngInstanceDetailsMask>(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase()]
      public async Task Create_IEngItemDefaultMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDefaultMask> ret = await engItemService.Create<IEngItemDefaultMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IEngItemCommonMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemCommonMask> ret = await engItemService.Create<IEngItemCommonMask>(request);

            Assert.IsNotNull(ret);

            foreach (IEngItemCommonMask engItem in ret)
            {
               Assert.IsNotNull(engItem.Usage);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IEngItemDetailsMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDetailsMask> ret = await engItemService.Create<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
            foreach (IEngItemDetailsMask engItem in ret)
            {
               Assert.IsNotNull(engItem.EnterpriseAttributes);
               Assert.IsNotNull(engItem.EnterpriseReference);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IEngItemConfigMask()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.Title = "New Engineering item created from Web Service";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemConfigMask> ret = await engItemService.Create<IEngItemConfigMask>(request);

            Assert.IsNotNull(ret);

            foreach (IEngItemConfigMask engItem in ret)
            {
               Assert.IsNotNull(engItem.ConfigurationContext);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachConfiguration(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ITypedUriIdentifier[] request = new TypedUriIdentifier[] { };

         try
         {
            IEnumerable<ITypedUriIdentifier> ret = await engItemService.DetachConfiguration(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceVariantEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IResponseUnsetVariantEffectivity ret = await engItemService.UnsetInstanceVariantEffectivity(engItemId, instanceId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("3784C760967A00006409AA5B000160E9", PART_NUMBER_TEST)]
      public async Task AttachEnterpriseItemNumber(string engItemId, string enterpriseItemNumber)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IEnterpriseItemNumber request = new EnterpriseItemNumber();
         request.PartNumber = enterpriseItemNumber;

         try
         {
            IEnterpriseItemNumberMask ret = await engItemService.AttachEnterpriseItemNumber(engItemId, request);

            Assert.IsNotNull(ret);
            Assert.AreEqual(enterpriseItemNumber, ret.PartNumber);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task SetInstanceVariantEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ISetVariantEffectivities request = new SetVariantEffectivities();

         try
         {
            ISetVariantResponse ret = await engItemService.SetInstanceVariantEffectivity(engItemId, instanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddInstance_IEngInstanceMaskFilterable(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceFilterableMask> ret = await engItemService.AddInstance<IEngInstanceFilterableMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddInstance_IEngInstanceMaskPosition(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstancePositionMask> ret = await engItemService.AddInstance<IEngInstancePositionMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddInstance_IEngInstanceDefaultMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceDefaultMask> ret = await engItemService.AddInstance<IEngInstanceDefaultMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddInstance_IEngInstanceDetailsMask(string engItemId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateEngInstances request = new CreateEngInstances();

         try
         {
            IEnumerable<IEngInstanceDetailsMask> ret = await engItemService.AddInstance<IEngInstanceDetailsMask>(engItemId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UnsetInstanceEvolutionEffectivity(string engItemId, string instanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            IResponseUnsetEvolutionEffectivity ret = await engItemService.UnsetInstanceEvolutionEffectivity(engItemId, instanceId);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IEngItemDetailsMask_WithEnterpriseReference()
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewEngItem newEngItem = new NewEngItem();
         newEngItem.Attributes = new NewEngItemAttributes();
         newEngItem.Attributes.EnterpriseReference = new EnterpriseItemNumber();

         newEngItem.Attributes.Title = "New Engineering item created from Web Service";
         newEngItem.Attributes.EnterpriseReference.PartNumber = "AAA27:000001";

         ICreateEngItem request = new CreateEngItem();
         request.Items = new List<INewEngItem>();
         request.Items.Add(newEngItem);

         try
         {
            IEnumerable<IEngItemDetailsMask> ret = await engItemService.Create<IEngItemDetailsMask>(request);

            Assert.IsNotNull(ret);
            foreach (IEngItemDetailsMask engItem in ret)
            {
               Assert.IsNotNull(engItem.EnterpriseAttributes);
               Assert.IsNotNull(engItem.EnterpriseReference);
            }
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

 
      // Exercises Bulk Fetch by passing the ids of the result of search into it.
      // It does this for all the three masks available types.
      [TestCase( "AAA27", 0, 10 )]
      public async Task BulkFetch(string _search, int _skip, int _top)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            string[] engItemIdArray = engItemSearchResult.Select(engItem => engItem.Id).ToArray<string>();

            IEnumerable<IEngItemDefaultMask> returnSetWithDefaultMask = await engItemService.BulkFetch<IEngItemDefaultMask>(engItemIdArray);

            IEnumerable<IEngItemCommonMask> returnSetWithCommonMask = await engItemService.BulkFetch<IEngItemCommonMask>(engItemIdArray);

            IEnumerable<IEngItemDetailsMask> returnSetWithDetailMask = await engItemService.BulkFetch<IEngItemDetailsMask>(engItemIdArray);

            Assert.AreEqual(returnSetWithDefaultMask.Count(), returnSetWithCommonMask.Count(), returnSetWithDetailMask.Count());
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      // Exercises Bulk Fetch by modifying the description of all results of the search into it.
      // It does this for all the three masks available types.
      [TestCase("AAA27", 0, 5, "bulk update edit description")]
      public async Task BulkUpdate(string _search, int _skip, int _top, string _description_update)
      {
         IPassportAuthentication passport = await Authenticate();

         EngItemService engItemService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         try
         {
            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IEngItemDefaultMask> engItemSearchResult = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

            Tuple<string,string>[] engItemIdArray = engItemSearchResult.Select(engItem => new Tuple<string,string>(engItem.Id, engItem.Cestamp)).ToArray();

            IEngItemBulkUpdateItem[] bulkUpdates = new IEngItemBulkUpdateItem[engItemIdArray.Length];

            for (int i = 0; i < engItemIdArray.Length; i++)
            {
               bulkUpdates[i] = new EngItemBulkUpdateItem();
               bulkUpdates[i].Id = engItemIdArray[i].Item1;
               bulkUpdates[i].Cestamp = engItemIdArray[i].Item2;
               bulkUpdates[i].Description = _description_update;
            }

            IEnumerable<IEngItemDefaultMask> returnSetWithDefaultMask = await engItemService.BulkUpdate<IEngItemDefaultMask>(bulkUpdates);

            Assert.That(returnSetWithDefaultMask, Is.All.Matches<IEngItemDefaultMask>(engItem => engItem.Description.Equals(_description_update)));

         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
   }
}