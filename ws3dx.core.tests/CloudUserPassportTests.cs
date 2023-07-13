using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.auth.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.dseng.core.service;
using ws3dx.dseng.data;
using ws3dx.utils.search;

namespace ws3dx.core.tests
{
   public class Tests
   {
      private const string DS3DXWS_AUTH_USERNAME = "DS3DXWS_AUTH_USERNAME";
      private const string DS3DXWS_AUTH_PASSWORD = "DS3DXWS_AUTH_PASSWORD";

      private const string DS3DXWS_AUTH_TENANT = "DS3DXWS_AUTH_TENANT";

      private string m_username;
      private string m_password;
      private string m_tenant;

      private bool TryGetEnvironmentVariableExists(string _envVarName, ref string __envVarValue)
      {
         if (Environment.GetEnvironmentVariable(_envVarName) == null)
         {
            return false;
         }

         __envVarValue = Environment.GetEnvironmentVariable(_envVarName);

         return false;
      }

      private void SetFromEnvironmentVariable(string _envVarName, ref string __envVarValue)
      {
         if (!TryGetEnvironmentVariableExists(_envVarName, ref __envVarValue))
         {
            throw new Exception($"Missing {_envVarName} environment variable");
         }
      }

      [SetUp]
      public void Setup()
      {
         SetFromEnvironmentVariable(DS3DXWS_AUTH_USERNAME, ref m_username);

         SetFromEnvironmentVariable(DS3DXWS_AUTH_PASSWORD, ref m_password);

         SetFromEnvironmentVariable(DS3DXWS_AUTH_TENANT, ref m_tenant);
      }

      [Test]
      public async Task SimpleLogin()
      {
         CloudUserPassport cloudUserPassport = new CloudUserPassport(m_tenant);

         UserAccess userAccess = await cloudUserPassport.Login(m_username, m_password);

         Assert.Multiple(() =>
         {
            Assert.That(userAccess, Is.Not.Null);

            Assert.That(m_username, Is.EqualTo(userAccess.Uuid));
         });
      }

      [Test]
      public async Task LoginAndGetTenant3DSpaceUrl()
      {
         CloudUserPassport cloudUserPassport = new CloudUserPassport(m_tenant);

         await cloudUserPassport.Login(m_username, m_password);

         string serviceUrl = await cloudUserPassport.Get3DSpaceUrl();

         Assert.That(serviceUrl, Is.Not.Null);
      }

      [Test]
      public async Task LoginAndGetUserInfo()
      {
         CloudUserPassport cloudUserPassport = new CloudUserPassport(m_tenant);

         UserAccess userAccess = await cloudUserPassport.Login(m_username, m_password);

         UserInfo userInfo = await cloudUserPassport.GetUserTenantInfo();

         Assert.Multiple(() =>
         {
            Assert.That(userInfo, Is.Not.Null);

            Assert.That(m_username, Is.EqualTo(userInfo.pid));
         });
      }

      [TestCase("AAA27", 0, 100)]
      public async Task UseCloudUserPassportInService(string _searchCriteria, int _skip, int _top)
      {
         CloudUserPassport cloudUserPassport = new CloudUserPassport(m_tenant);

         UserAccess userAccess = await cloudUserPassport.Login(m_username, m_password);
         Assert.Multiple(() =>
         {
            Assert.That(userAccess, Is.Not.Null);

            Assert.That(m_username, Is.EqualTo(userAccess.Uuid));
         });

         string service3DSpaceUrl = await cloudUserPassport.Get3DSpaceUrl();

         UserInfo userInfo = await cloudUserPassport.GetUserTenantInfo();

         IPassportAuthentication passport = cloudUserPassport.GetPassportAuthentication();

         EngItemService engItemService = new EngItemService(service3DSpaceUrl, passport)
         {
            Tenant = m_tenant,
            SecurityContext = userInfo.preferredcredentials.ToString()
         };

         SearchByFreeText searchByFreeText = new SearchByFreeText(_searchCriteria);

         IEnumerable<IEngItemDefaultMask> ret = await engItemService.Search<IEngItemDefaultMask>(searchByFreeText, _skip, _top);

         Assert.That(ret, Is.Not.Null);
      }
   }
}