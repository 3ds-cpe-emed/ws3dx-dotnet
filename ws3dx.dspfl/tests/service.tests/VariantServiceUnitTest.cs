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

namespace NUnitTestProject
{
   public class VariantServiceTests
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

      public VariantService ServiceFactoryCreate(IPassportAuthentication _passport, string _serviceUrl, string _tenant)
      {
         VariantService __variantService = new VariantService(_serviceUrl, _passport);
         __variantService.Tenant = _tenant;
         __variantService.SecurityContext = GetDefaultSecurityContext();
         return __variantService;
      }

      [TestCase("")]
      public async Task GetVariant(string variantId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IVariantMask ret = await variantService.GetVariant(variantId);

         Assert.IsNotNull(ret);
      }

      [TestCase("")]
      public async Task GetValues(string variantId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IValueMask> ret = await variantService.GetValues(variantId);

         Assert.IsNotNull(ret);
      }

      [TestCase()]
      public async Task GetAllVariants()
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IVariantMask> ret = await variantService.GetAllVariants();

         Assert.IsNotNull(ret);
      }

      [TestCase("", "")]
      public async Task GetValue(string variantId, string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);
         IEnumerable<IValueMask> ret = await variantService.GetValue(variantId, iD);

         Assert.IsNotNull(ret);
      }

      [TestCase("44C2728F66390000643291E00014089E")]
      public async Task CreateValue(string variantId)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewVariantValue newVariantValue = new NewVariantValue();
         newVariantValue.Type = "Variant Value";
         newVariantValue.VersionName = "";
         newVariantValue.Attributes = new NewVariantValueData();
         newVariantValue.Attributes.SequenceNumber = 1;
         //newVariantValue.Attributes.Title = "Blue";
         newVariantValue.Attributes.Description = "Blue color";
         //newVariantValue.Attributes.Name = "Red";
         //IN THINK TITLE IS MISSING AS AN ATTRIBUTE in NewVariantValueData _ REVIEW
         ICreateVariantValue request = new CreateVariantValue();
         request.Items = new List<INewVariantValue>();
         request.Items.Add(newVariantValue);

         try
         {
            IEnumerable<IValueMask> ret = await variantService.CreateValue(variantId, request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("AAA27WS3DX Color")]
      public async Task Create(string _title)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         INewVariant newVariant = new NewVariant();
         newVariant.Type = "Variant";
         newVariant.VersionName = "";
         newVariant.Attributes = new NewVariantData();
         newVariant.Attributes.Title = _title;
         
         ICreateVariant request = new CreateVariant();
         request.Items = new List<INewVariant>();
         request.Items.Add(newVariant);

         try
         {
            IEnumerable<IVariantMask> ret = await variantService.Create(request);

            Assert.IsNotNull(ret);
         }
         catch (HttpResponseException _ex)
         {
            string errorMessage = await _ex.GetErrorMessage();
            Assert.Fail(errorMessage);
         }
      }

      [TestCase("", "")]
      public async Task UpdateValue(string variantId, string iD)
      {
         IPassportAuthentication passport = await Authenticate();

         VariantService variantService = ServiceFactoryCreate(passport, m_serviceUrl, m_tenant);

         IOrdered request = new Ordered();

         try
         {
            IEnumerable<IValueMask> ret = await variantService.UpdateValue(variantId, iD, request);

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