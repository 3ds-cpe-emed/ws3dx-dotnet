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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.dspfl.data;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dspfl.core.service
{
   // SDK Service
   public class ModelVersionService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dspfl/";

      public ModelVersionService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/dspfl:ModelVersion/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IModelVersionMask) };
      }

      protected override string GetSearchSkipParamName()
      {
         return "$skip";
      }

      protected override string GetSearchTopParamName()
      {
         return "$top";
      }

      protected override string GetSearchCriteriaParamName()
      {
         return "$searchStr";
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery)
      {
         return await SearchCollection<T>("member", searchQuery);
      }

      public async Task<IList<T>> Search<T>(SearchQuery searchQuery, long _skip, long _top)
      {
         return await SearchCollection<T>("member", searchQuery, _skip, _top);
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{ID}/dspfl:ConfigurationRule
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get 100 Configuration Rules of a given Model Version in one call. Use $skip to skip 
      // number of rules from starting and get next 100 rules. Summary: Get 100 Configuration Rules of a 
      // given Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="skip">
      // Description: skip given number of rules from start.
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IMatrixRuleResponse>> GetConfigurationRules(string modelVersionId, int skip)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         headerParams.Add("$skip", skip.ToString());

         return await GetCollectionFromResponseArrayProperty<IMatrixRuleResponse>(resourceURI, "member", headerParams: headerParams);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{PID}/dspfl:VariantInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get a allocated Variant with Variant Values. Summary: Get a allocated Variant with 
      // Variant Values
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="variantInstanceId">
      // Description: dspfl:VariantInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetVariant<T>(string modelVersionId, string variantInstanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IVariantInstanceMask), typeof(IVariantInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance/{variantInstanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{PID}/dspfl:ProductConfiguration/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Product Configuration. Summary: Get a Product Configuration
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="productConfigurationId">
      // Description: dspfl:ProductConfiguration object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetProductConfiguration<T>(string modelVersionId, string productConfigurationId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IProductConfigurationMask), typeof(IProductConfigurationCriteriaMask), typeof(IProductConfigurationUnitMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ProductConfiguration/{productConfigurationId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Model Versions. Summary: Get all Model Versions
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetAll<T>()
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IModelVersionMask), typeof(IModelVersionDetailMask), typeof(IModelVersionUnitMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Model Version. Summary: Get a Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string modelVersionId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IModelVersionMask), typeof(IModelVersionDetailMask), typeof(IModelVersionUnitMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{PID}/dspfl:ConfigurationRule/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get a Configuration Rules of a given Model Version. Summary: Get a Configuration 
      // Rules of a given Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="configRuleId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IMatrixRuleResponse> GetConfigurationRule(string modelVersionId, string configRuleId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule/{configRuleId}";

         return await GetIndividualFromResponseMemberProperty<IMatrixRuleResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{PID}/dspfl:OptionGroupInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get a allocated Variability Group with Options. Summary: Get a allocated Variability 
      // Group with Options
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="optionGroupInstanceId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetOption<T>(string modelVersionId, string optionGroupInstanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOptionGroupInstanceMask), typeof(IOptionGroupInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance/{optionGroupInstanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{ID}/dspfl:ProductConfiguration
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Product Configurations of given Model Version Summary: Get all 
      // Product Configurations
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetProductConfigurations<T>(string modelVersionId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IProductConfigurationMask), typeof(IProductConfigurationCriteriaMask), typeof(IProductConfigurationUnitMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ProductConfiguration";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{ID}/dspfl:VariantInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get all allocated Variants and Variant Values of given Model Version. Summary: Get 
      // all allocated Variants and Variant Values
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetVariants<T>(string modelVersionId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IVariantInstanceMask), typeof(IVariantInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:ModelVersion/{ID}/dspfl:OptionGroupInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get all allocated Variability Groups and Options of given Model Version. Summary: 
      // Get all allocated Variability Groups and Options
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetOptions<T>(string modelVersionId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOptionGroupInstanceMask), typeof(IOptionGroupInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{ID}/dspfl:ProductConfiguration
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Product Configurations. Summary: Create Product Configurations
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> CreateProductConfiguration<T>(string modelVersionId, ICreateProductConfiguration request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IProductConfigurationMask), typeof(IProductConfigurationCriteriaMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ProductConfiguration";

         return await PostCollectionFromResponseMemberProperty<T, ICreateProductConfiguration>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{ID}/dspfl:OptionGroupInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Allocate Variability Groups and Options to Model Version. The request will be rejected 
      // if the total number of Options exceeds 100. Summary: Allocate Variability Groups and Options to 
      // Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddOption<T>(string modelVersionId, ICreateOptionGroupInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IOptionGroupInstanceMask), typeof(IOptionGroupInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateOptionGroupInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:OptionGroupInstance/{ID}/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deallocate options of VariabilityGroup from ModelVersion. The request will be rejected 
      // if the total number of options exceeds 100. Summary: Deallocate options of VariabilityGroup from 
      // ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="optionGroupInstanceId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> DetachOption<T>(string modelVersionId, string optionGroupInstanceId, IDetachOptionGroupInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstanceIDMask), typeof(IOptionGroupInstanceMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance/{optionGroupInstanceId}/detach";

         return await PostCollectionFromResponseMemberProperty<T, IDetachOptionGroupInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:ConfigurationRule/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Allocate Configuration Rules to a given ModelVersion. The request will be rejected 
      // if the total number of rules to be attached to given Model Version exceeds 10. Summary: Allocate 
      // Configuration Rules to a given ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseMessage> AttachConfigurationRule(string modelVersionId, IConfigurationRules request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule/attach";

         return await PostIndividual<IResponseMessage, IConfigurationRules>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:OptionGroupInstance/{ID}/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Allocate options of VariabilityGroup to ModelVersion. The request will be rejected 
      // if the total number of Options exceeds 100. Summary: Allocate options of VariabilityGroup to 
      // ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="optionGroupInstanceId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AttachOption<T>(string modelVersionId, string optionGroupInstanceId, IAttachOptionGroupInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstanceIDMask), typeof(IOptionGroupInstanceMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance/{optionGroupInstanceId}/attach";

         return await PostCollectionFromResponseMemberProperty<T, IAttachOptionGroupInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{ID}/dspfl:VariantInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Allocate Variants and Variant Values to Model Version. The request will be rejected 
      // if the total number of Variant Values exceeds 100. Summary: Allocate Variants and Variant Values 
      // to Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddVariant<T>(string modelVersionId, ICreateVariantInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IVariantInstanceMask), typeof(IVariantInstanceCustomerAttributeMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateVariantInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:VariantInstance/{ID}/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deallocate values of Variant from ModelVersion. The request will be rejected if the 
      // total number of values exceeds 100. Summary: Deallocate values of Variant from ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="variantInstanceId">
      // Description: dspfl:VariantInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> DetachVariant<T>(string modelVersionId, string variantInstanceId, IDetachVariantInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstanceIDMask), typeof(IVariantInstanceMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance/{variantInstanceId}/detach";

         return await PostCollectionFromResponseMemberProperty<T, IDetachVariantInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Model Versions. Summary: Create Model Versions
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateModel request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IModelVersionMask), typeof(IModelVersionDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion";

         return await PostCollectionFromResponseMemberProperty<T, ICreateModel>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:ProductConfiguration/{ID}/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Product Configuration selected criteria. Summary: Modify Product Configuration 
      // selected criteria
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="productConfigurationId">
      // Description: dspfl:ProductConfiguration object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> UpdateProductConfigurationCriteria<T>(string modelVersionId, string productConfigurationId, IModifyProductConfiguration request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IProductConfigurationMask), typeof(IProductConfigurationCriteriaMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ProductConfiguration/{productConfigurationId}/modify";

         return await PostCollectionFromResponseMemberProperty<T, IModifyProductConfiguration>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:ConfigurationRule/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deallocate Configuration Rules from a given ModelVersion. Summary: Deallocate 
      // Configuration Rules from a given ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseMessage> DetachConfigurationRule(string modelVersionId, IConfigurationRules request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule/detach";

         return await PostIndividual<IResponseMessage, IConfigurationRules>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:VariantInstance/{ID}/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Allocate values of Variant to ModelVersion. The request will be rejected if the total 
      // number of values exceeds 100. Summary: Allocate values of Variant to ModelVersion
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="variantInstanceId">
      // Description: dspfl:VariantInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AttachVariant<T>(string modelVersionId, string variantInstanceId, IAttachVariantInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IInstanceIDMask), typeof(IVariantInstanceMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance/{variantInstanceId}/attach";

         return await PostCollectionFromResponseMemberProperty<T, IAttachVariantInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:ModelVersion/{PID}/dspfl:ProductConfiguration/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Product Configuration attributes. Summary: Modify Product Configuration 
      // attributes
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="productConfigurationId">
      // Description: dspfl:ProductConfiguration object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> ProductConfiguration<T>(string modelVersionId, string productConfigurationId, IUpdateProductConfiguration request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IProductConfigurationMask), typeof(IProductConfigurationCriteriaMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ProductConfiguration/{productConfigurationId}";

         return await PatchIndividualFromResponseMemberProperty<T, IUpdateProductConfiguration>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:ModelVersion/{PID}/dspfl:OptionGroupInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify OptionGroupInstance sequenceNumber attribute. Summary: Modify OptionGroupInstance 
      // sequenceNumber attribute
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="optionGroupInstanceId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IOptionGroupInstanceMask> UpdateOptionInstance(string modelVersionId, string optionGroupInstanceId, IOrdered request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance/{optionGroupInstanceId}";

         return await PatchIndividualFromResponseMemberProperty<IOptionGroupInstanceMask, IOrdered>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:ModelVersion/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Model Version attributes. Summary: Modify Model Version attributes
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string modelVersionId, IUpdateModelVersion request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IModelVersionMask), typeof(IModelVersionDetailMask) });

         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}";

         return await PatchIndividualFromResponseMemberProperty<T, IUpdateModelVersion>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:ModelVersion/{PID}/dspfl:VariantInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify VariantInstance constraint attribute. Summary: Modify VariantInstance constraint 
      // attribute
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="variantInstanceId">
      // Description: dspfl:VariantInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IVariantInstanceMask> UpdateVariantInstance(string modelVersionId, string variantInstanceId, IUpdateVariantInstance request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance/{variantInstanceId}";

         return await PatchIndividualFromResponseMemberProperty<IVariantInstanceMask, IUpdateVariantInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /dspfl:ModelVersion/{PID}/dspfl:VariantInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a VariantInstance by dellocating Variant and all it's values. The request will 
      // be rejected if the total number of values exceeds 100. Summary: Delete a VariantInstance by 
      // dellocating Variant and all it's values
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="variantInstanceId">
      // Description: dspfl:VariantInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseMessage> DeleteVariantInstance(string modelVersionId, string variantInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:VariantInstance/{variantInstanceId}";

         return await DeleteIndividual<IResponseMessage>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /dspfl:ModelVersion/{PID}/dspfl:OptionGroupInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a OptionGroupInstance by dellocating VariabilitGroup and all it's options. 
      // The request will be rejected if the total number of options exceeds 100. Summary: Delete a 
      // OptionGroupInstance by dellocating VariabilitGroup and all it's options
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="optionGroupInstanceId">
      // Description: dspfl:OptionGroupInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseMessage> DeleteOptionGroupInstance(string modelVersionId, string optionGroupInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:OptionGroupInstance/{optionGroupInstanceId}";

         return await DeleteIndividual<IResponseMessage>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{ID}/dspfl:ConfigurationRule
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Configuration Rule under a Model Version. For Matrix ruleType, The request 
      // will be rejected if the total number of cells with status(Selected/Not Available/Default) exceeds 
      // 10000. For Expression ruleType, The request will be rejected if the total number of operators 
      // used in expression exceeds 2000. Please refer to About Confgiuration Rule for more details. 
      // Summary: Create Configuration Rule under a Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMatrixRuleResponse>> CreateConfigurationRule(string modelVersionId, INewMatrixRules request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule";

         return await PostCollectionFromResponseMemberProperty<IMatrixRuleResponse, INewMatrixRules>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{ID}/dspfl:ConfigurationRule
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Configuration Rule under a Model Version. For Matrix ruleType, The request 
      // will be rejected if the total number of cells with status(Selected/Not Available/Default) exceeds 
      // 10000. For Expression ruleType, The request will be rejected if the total number of operators 
      // used in expression exceeds 2000. Please refer to About Confgiuration Rule for more details. 
      // Summary: Create Configuration Rule under a Model Version
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IExpressionRuleResponse>> CreateConfigurationRule(string modelVersionId, ICreateExpressionRule request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule";

         return await PostCollectionFromResponseMemberProperty<IExpressionRuleResponse, ICreateExpressionRule>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:ConfigurationRule/{ID}/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify a Configuration Rule. For Matrix ruleType, The request will be rejected if 
      // the total number of cells with status(Selected/Not Available/Default) exceeds 10000. For Expression 
      // ruleType, The request will be rejected if the total number of operators used in expression exceeds 
      // 2000. Please refer to About Confgiuration Rule for more details. Summary: Modify a Configuration 
      // Rule
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:ProductConfiguration object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMatrixRuleResponse>> UpdateConfigurationRule(string modelVersionId, string ID, IModifyMatrixRule request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule/{ID}/modify";

         return await PostCollectionFromResponseMemberProperty<IMatrixRuleResponse, IModifyMatrixRule>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:ModelVersion/{PID}/dspfl:ConfigurationRule/{ID}/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify a Configuration Rule. For Matrix ruleType, The request will be rejected if 
      // the total number of cells with status(Selected/Not Available/Default) exceeds 10000. For Expression 
      // ruleType, The request will be rejected if the total number of operators used in expression exceeds 
      // 2000. Please refer to About Confgiuration Rule for more details. Summary: Modify a Configuration 
      // Rule
      // <param name="modelVersionId">
      // Description: dspfl:ModelVersion object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:ProductConfiguration object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IExpressionRuleResponse>> UpdateConfigurationRule(string modelVersionId, string ID, IModifyExpressionRule request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:ModelVersion/{modelVersionId}/dspfl:ConfigurationRule/{ID}/modify";

         return await PostCollectionFromResponseMemberProperty<IExpressionRuleResponse, IModifyExpressionRule>(resourceURI, request);
      }
   }
}