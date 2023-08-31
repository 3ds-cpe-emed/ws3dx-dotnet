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
using ws3dx.authentication.data;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.exception;
using ws3dx.core.redirection;
using ws3dx.dspfl.core.data.impl;
using ws3dx.dspfl.core.service;
using ws3dx.dspfl.data;
using ws3dx.utils.search;

namespace NUnitTestProject
{
   public class ModelVersionServiceTests
   {
      const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";
      const string DS3DXWS_AUTH_PASSPORT = "DS3DXWS_AUTH_PASSPORT";
      const string DS3DXWS_AUTH_ENOVIA = "DS3DXWS_AUTH_ENOVIA";
      const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";
      string m_username = string.Empty;
      string m_password = string.Empty;
      string m_passportUrl = string.Empty;
      string m_serviceUrl = string.Empty;
      string m_tenant = string.Empty;

      UserInfo m_userInfo = null;

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

      public ModelVersionService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         ModelVersionService __modelVersionService = new ModelVersionService(_serviceUrl, _passport);
         __modelVersionService.Tenant = _tenant;
         __modelVersionService.SecurityContext = GetDefaultSecurityContext();
         return __modelVersionService;
      }

      [TestCase("", 0)]
      public async Task GetConfigurationRules(string modelVersionId, int skip)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IMatrixRuleResponse> ret = await modelVersionService.GetConfigurationRules(modelVersionId, skip);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetVariant_IVariantInstanceMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IVariantInstanceMask ret = await modelVersionService.GetVariant<IVariantInstanceMask>(modelVersionId, variantInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetVariant_IVariantInstanceCustomerAttributeMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IVariantInstanceCustomerAttributeMask ret = await modelVersionService.GetVariant<IVariantInstanceCustomerAttributeMask>(modelVersionId, variantInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProductConfiguration_IProductConfigurationMask(string modelVersionId, string productConfigurationId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IProductConfigurationMask ret = await modelVersionService.GetProductConfiguration<IProductConfigurationMask>(modelVersionId, productConfigurationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProductConfiguration_IProductConfigurationCriteriaMask(string modelVersionId, string productConfigurationId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IProductConfigurationCriteriaMask ret = await modelVersionService.GetProductConfiguration<IProductConfigurationCriteriaMask>(modelVersionId, productConfigurationId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetProductConfiguration_IProductConfigurationUnitMask(string modelVersionId, string productConfigurationId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IProductConfigurationUnitMask ret = await modelVersionService.GetProductConfiguration<IProductConfigurationUnitMask>(modelVersionId, productConfigurationId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAll_IModelVersionMask()
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IModelVersionMask> ret = await modelVersionService.GetAll<IModelVersionMask>();

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAll_IModelVersionDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IModelVersionDetailMask> ret = await modelVersionService.GetAll<IModelVersionDetailMask>();

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAll_IModelVersionUnitMask()
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IModelVersionUnitMask> ret = await modelVersionService.GetAll<IModelVersionUnitMask>();

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IModelVersionMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IModelVersionMask ret = await modelVersionService.Get<IModelVersionMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IModelVersionDetailMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IModelVersionDetailMask ret = await modelVersionService.Get<IModelVersionDetailMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task Get_IModelVersionUnitMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IModelVersionUnitMask ret = await modelVersionService.Get<IModelVersionUnitMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetConfigurationRule(string modelVersionId, string configRuleId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IMatrixRuleResponse ret = await modelVersionService.GetConfigurationRule(modelVersionId, configRuleId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetOption_IOptionGroupInstanceMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IOptionGroupInstanceMask ret = await modelVersionService.GetOption<IOptionGroupInstanceMask>(modelVersionId, optionGroupInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetOption_IOptionGroupInstanceCustomerAttributeMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IOptionGroupInstanceCustomerAttributeMask ret = await modelVersionService.GetOption<IOptionGroupInstanceCustomerAttributeMask>(modelVersionId, optionGroupInstanceId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProductConfigurations_IProductConfigurationMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IProductConfigurationMask> ret = await modelVersionService.GetProductConfigurations<IProductConfigurationMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProductConfigurations_IProductConfigurationCriteriaMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IProductConfigurationCriteriaMask> ret = await modelVersionService.GetProductConfigurations<IProductConfigurationCriteriaMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetProductConfigurations_IProductConfigurationUnitMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IProductConfigurationUnitMask> ret = await modelVersionService.GetProductConfigurations<IProductConfigurationUnitMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetVariants_IVariantInstanceMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVariantInstanceMask> ret = await modelVersionService.GetVariants<IVariantInstanceMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetVariants_IVariantInstanceCustomerAttributeMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVariantInstanceCustomerAttributeMask> ret = await modelVersionService.GetVariants<IVariantInstanceCustomerAttributeMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetOptions_IOptionGroupInstanceMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOptionGroupInstanceMask> ret = await modelVersionService.GetOptions<IOptionGroupInstanceMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetOptions_IOptionGroupInstanceCustomerAttributeMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IOptionGroupInstanceCustomerAttributeMask> ret = await modelVersionService.GetOptions<IOptionGroupInstanceCustomerAttributeMask>(modelVersionId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task CreateProductConfiguration_IProductConfigurationMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateProductConfiguration request = new CreateProductConfiguration();

         try
         {
            IEnumerable<IProductConfigurationMask> ret = await modelVersionService.CreateProductConfiguration<IProductConfigurationMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("44C2728FFF280000643143440010CB4A", "AAA27WS3DX - Product Configuration 3")]
      public async Task CreateProductConfiguration_IProductConfigurationCriteriaMask(string modelVersionId, string _pcTitle)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewProductConfiguration newProductConfiguration = new NewProductConfiguration();
         newProductConfiguration.Type = "Product Configuration";
         newProductConfiguration.VersionName = "";
         newProductConfiguration.Attributes = new NewProductConfigurationData();
         newProductConfiguration.Attributes.Title = _pcTitle;

         ICreateProductConfiguration request = new CreateProductConfiguration();
         request.Items = new List<INewProductConfiguration>();
         request.Items.Add(newProductConfiguration);

         try
         {
            IEnumerable<IProductConfigurationCriteriaMask> ret = await modelVersionService.CreateProductConfiguration<IProductConfigurationCriteriaMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddOption_IOptionGroupInstanceMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateOptionGroupInstances request = new CreateOptionGroupInstances();

         try
         {
            IEnumerable<IOptionGroupInstanceMask> ret = await modelVersionService.AddOption<IOptionGroupInstanceMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddOption_IOptionGroupInstanceCustomerAttributeMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateOptionGroupInstances request = new CreateOptionGroupInstances();

         try
         {
            IEnumerable<IOptionGroupInstanceCustomerAttributeMask> ret = await modelVersionService.AddOption<IOptionGroupInstanceCustomerAttributeMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task DetachOption_IInstanceIDMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachOptionGroupInstances request = new DetachOptionGroupInstances();

         try
         {
            IEnumerable<IInstanceIDMask> ret = await modelVersionService.DetachOption<IInstanceIDMask>(modelVersionId, optionGroupInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task DetachOption_IOptionGroupInstanceMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachOptionGroupInstances request = new DetachOptionGroupInstances();

         try
         {
            IEnumerable<IOptionGroupInstanceMask> ret = await modelVersionService.DetachOption<IOptionGroupInstanceMask>(modelVersionId, optionGroupInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AttachConfigurationRule(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IConfigurationRules request = new ConfigurationRules();

         try
         {
            IResponseMessage ret = await modelVersionService.AttachConfigurationRule(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AttachOption_IInstanceIDMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachOptionGroupInstances request = new AttachOptionGroupInstances();

         try
         {
            IEnumerable<IInstanceIDMask> ret = await modelVersionService.AttachOption<IInstanceIDMask>(modelVersionId, optionGroupInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task AttachOption_IOptionGroupInstanceMask(string modelVersionId, string optionGroupInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachOptionGroupInstances request = new AttachOptionGroupInstances();

         try
         {
            IEnumerable<IOptionGroupInstanceMask> ret = await modelVersionService.AttachOption<IOptionGroupInstanceMask>(modelVersionId, optionGroupInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task AddVariant_IVariantInstanceMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateVariantInstances request = new CreateVariantInstances();

         try
         {
            IEnumerable<IVariantInstanceMask> ret = await modelVersionService.AddVariant<IVariantInstanceMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("")]
      public async Task AddVariant_IVariantInstanceCustomerAttributeMask(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateVariantInstances request = new CreateVariantInstances();

         try
         {
            IEnumerable<IVariantInstanceCustomerAttributeMask> ret = await modelVersionService.AddVariant<IVariantInstanceCustomerAttributeMask>(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task DetachVariant_IInstanceIDMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachVariantInstances request = new DetachVariantInstances();

         try
         {
            IEnumerable<IInstanceIDMask> ret = await modelVersionService.DetachVariant<IInstanceIDMask>(modelVersionId, variantInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task DetachVariant_IVariantInstanceMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IDetachVariantInstances request = new DetachVariantInstances();

         try
         {
            IEnumerable<IVariantInstanceMask> ret = await modelVersionService.DetachVariant<IVariantInstanceMask>(modelVersionId, variantInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27WS3DX Model Version")]
      public async Task Create_IModelVersionMask(string _modelVersionTitle)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewModel newModel = new NewModel();
         newModel.Attributes = new ModelVersion();
         newModel.Attributes.Title = _modelVersionTitle;
         newModel.Type        = "Products";
         newModel.VersionName = "A";

         ICreateModel request = new CreateModel();
         request.Items = new List<INewModel>();
         request.Items.Add(newModel);

         try
         {
            IEnumerable<IModelVersionMask> ret = await modelVersionService.Create<IModelVersionMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase()]
      public async Task Create_IModelVersionDetailMask()
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateModel request = new CreateModel();

         try
         {
            IEnumerable<IModelVersionDetailMask> ret = await modelVersionService.Create<IModelVersionDetailMask>(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UpdateProductConfigurationCriteria_IProductConfigurationMask(string modelVersionId, string productConfigurationId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyProductConfiguration request = new ModifyProductConfiguration();

         try
         {
            IEnumerable<IProductConfigurationMask> ret = await modelVersionService.UpdateProductConfigurationCriteria<IProductConfigurationMask>(modelVersionId, productConfigurationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task UpdateProductConfigurationCriteria_IProductConfigurationCriteriaMask(string modelVersionId, string productConfigurationId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyProductConfiguration request = new ModifyProductConfiguration();

         try
         {
            IEnumerable<IProductConfigurationCriteriaMask> ret = await modelVersionService.UpdateProductConfigurationCriteria<IProductConfigurationCriteriaMask>(modelVersionId, productConfigurationId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task DetachConfigurationRule(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IConfigurationRules request = new ConfigurationRules();

         try
         {
            IResponseMessage ret = await modelVersionService.DetachConfigurationRule(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task AttachVariant_IInstanceIDMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachVariantInstances request = new AttachVariantInstances();

         try
         {
            IEnumerable<IInstanceIDMask> ret = await modelVersionService.AttachVariant<IInstanceIDMask>(modelVersionId, variantInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }
      [TestCase("", "")]
      public async Task AttachVariant_IVariantInstanceMask(string modelVersionId, string variantInstanceId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IAttachVariantInstances request = new AttachVariantInstances();

         try
         {
            IEnumerable<IVariantInstanceMask> ret = await modelVersionService.AttachVariant<IVariantInstanceMask>(modelVersionId, variantInstanceId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateConfigurationRule_MatrixRule(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewMatrixRules request = new NewMatrixRules();

         try
         {
            IEnumerable<IMatrixRuleResponse> ret = await modelVersionService.CreateConfigurationRule(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("")]
      public async Task CreateConfigurationRule_ExpressionRule(string modelVersionId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         ICreateExpressionRule request = new CreateExpressionRule();

         try
         {
            IEnumerable<IExpressionRuleResponse> ret = await modelVersionService.CreateConfigurationRule(modelVersionId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UpdateConfigurationRule_MatrixRule(string modelVersionId, string ruleId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyMatrixRule request = new ModifyMatrixRule();

         try
         {
            IEnumerable<IMatrixRuleResponse> ret = await modelVersionService.UpdateConfigurationRule(modelVersionId, ruleId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UpdateConfigurationRule_ExpressionRule(string modelVersionId, string ruleId)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IModifyExpressionRule request = new ModifyExpressionRule();

         try
         {
            IEnumerable<IExpressionRuleResponse> ret = await modelVersionService.UpdateConfigurationRule(modelVersionId, ruleId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("model")]
      public async Task Search_Full(string search)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IModelVersionMask> ret = await modelVersionService.Search<IModelVersionMask>(searchByFreeText);

         Assert.IsNotNull(ret);
      }

      [TestCase("model", 0, 50)]
      public async Task Search_Paged(string search, int skip, int top)
      {
         IPassportAuthentication passport = await Authenticate();

         ModelVersionService modelVersionService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         SearchByFreeText searchByFreeText = new SearchByFreeText(search);

         IEnumerable<IModelVersionMask> ret = await modelVersionService.Search<IModelVersionMask>(searchByFreeText, skip, top);
         Assert.IsNotNull(ret);

         int i = 0;
         foreach (IModelVersionMask modelVersion in ret)
         {
            IModelVersionDetailMask modelVersionDetail = await modelVersionService.Get<IModelVersionDetailMask>(modelVersion.Id);

            Assert.AreEqual(modelVersion.Id, modelVersionDetail.Id);

            i++;

            if (i > 20) return;
         }
      }
   }
}