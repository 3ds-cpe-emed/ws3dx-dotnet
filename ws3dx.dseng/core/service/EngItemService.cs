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
using ws3dx.dseng.data;
using ws3dx.shared.data;
using ws3dx.shared.data.dscfg;
using ws3dx.shared.utils;
using ws3dx.utils.search;

namespace ws3dx.dseng.core.service
{
   // SDK Service
   public class EngItemService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dseng/";

      public EngItemService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}dseng:EngItem/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { typeof(IEngItemDefaultMask), typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask) };
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
      // (GET) dseng:EngItem/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Enterprise Reference of an Engineering Item Summary: Gets a Enterprise Reference 
      // of an Engineering Item
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnterpriseItemNumberMask> GetEnterpriseItemNumber(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         return await GetIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Engineering Item Instance Summary: Gets a Engineering Item Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetInstance<T>(string engItemId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Engineering Item Representation Instance Summary: Gets a Engineering Item 
      // Representation Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngRepInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetRepInstance<T>(string engItemId, string repInstanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{repInstanceId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}/dseng:EngRepInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Engineering Item Representation Instance Summary: Gets all the Engineering Item 
      // Representation Instances.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetRepInstances<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Engineering Item Summary: Gets a Engineering Item
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> Get<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngItemDefaultMask), typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the Enabled Criteria and Configuration Contexts of Configured 
      // object Summary: Gets a Object Configuration information
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetConfiguration<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Change Control of an Engineering Item Summary: Gets a Change Control of an 
      // Engineering Item
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IChangeControlStatusMask> GetChangeControl(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await GetIndividual<IChangeControlStatusMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{PID}/dseng:Alternate/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Engineering Item Alternates Summary: Gets a Engineering Item Alternates
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="alternateId">
      // Description: dseng:Alternate object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<T> GetAlternate<T>(string engItemId, string alternateId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlternateMask), typeof(IAlternateDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate/{alternateId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: This extension gets the effectivity of an Object instance/relationship Summary: Gets 
      // a Instance effectivity information.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IFilterableDetailMask>> GetInstanceEffectivity(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable";

         return await GetCollectionFromResponseMemberProperty<IFilterableDetailMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}/dseng:Alternate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets All Alternate items connected to Primary Engieering item. Summary: Gets All 
      // Alternate items connected to Primary Engieering item.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetAlternates<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlternateMask), typeof(IAlternateDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dseng:EngItem/{ID}/dseng:EngInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Engineering Item Instance Summary: Gets all the Engineering Item Instances.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> GetInstances<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dscfg:Configured/attach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to attach a list of configuration context to a single reference. Summary: 
      // Service to attach a list of configuration context to a single reference.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> AttachConfiguration(string engItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured/attach";

         return await PostCollectionFromResponseResourcesProperty<ITypedUriIdentifier, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Activate the Change Control Summary: Activate the Change Control
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string engItemId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/bulkfetch
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get multiple Engineering Items which are Indexed. API Works only for Indexed Data. 
      // The customer attributes or enterprise extension attributes are returned only with default sixw 
      // mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. 
      // Summary: Get multiple Engineering Items which are indexed
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngItemDefaultMask), typeof(IEngItemDetailsMask), typeof(IEngItemCommonMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/bulkfetch";

         return await PostBulkCollection<T, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}/replace
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Replace the Engineering Item Representation Instance Summary: Replace the Engineering 
      // Item Representation Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngRepInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> ReplaceRepInstance<T>(string engItemId, string repInstanceId, IEngRepInstanceReplace request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{repInstanceId}/replace";

         return await PostIndividualFromResponseMemberProperty<T, IEngRepInstanceReplace>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:EngRepInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Engineering Representation Instance to an Engineering Item. Summary: Create 
      // Engineering Representation Instances
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddRepInstance<T>(string engItemId, ICreateEngRepInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngRepInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/bulkupdate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies multiple Engineering Item attributes Summary: Modifies multiple Engineering 
      // Item attributes
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkUpdate<T>(IEngItemBulkUpdateItem[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngItemDefaultMask), typeof(IEngItemDetailsMask), typeof(IEngItemCommonMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/bulkupdate";

         return await PostBulkCollection<T, IEngItemBulkUpdateItem[]>(resourceURI, request);
      }
     
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/set/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivity evolution expression (XML) on a single relationship. 
      // WARNING: Coherency between Evolution and Variant Expression are under users responsibility.<br><br>Please 
      // find below the list of possible error codes and error messages: <br> 102 : The parent reference 
      // of the given instance does not have a Configuration Context. <br>106 : The input instance is 
      // controlled by a Change. Evolution effectivity cannot be edited. <br>117 : The input effectivity 
      // expression or data used in the expression is not correct. <br>118 : Instance's identifier in the 
      // input is not valid or correct. <br>119 : Effectivity cannot be set due to dictionary data. <br>120 
      // : The criteria is not enabled on the parent reference. <br>121 : The root reference is a 3DPart 
      // which is not configurable. <br>122 : The root reference is XCAD controlled which is not configurable. 
      // <br>123 : Model provided in the input expression is not part of Configuration Context. <br>124 
      // : Model provided in the input expression is not accessible or does not exist. <br>125 : Input 
      // expression not well-formatted (No model found). <br>126 : The criteria used in the input expression 
      // is not enabled on parent reference. <br>127 : Error occured during the save of the new effectivities. 
      // <br>128 : Error occured during the update of Configuration Revision effectivities. <br>129 : 
      // Effectivities cannot be set because changing at least one of them would impact frozen evolution 
      // range. <br>130 : The parent reference is not configurable. <br>199 : Failure detected during 
      // operation. <br> Summary: Service to set the effectivities evolution expression (XML).
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ISetEvolutionResponse> SetInstanceEvolutionEffectivity(string engItemId, string instanceId, ISetEvolutionEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/set/evolution";

         return await PostIndividual<ISetEvolutionResponse, ISetEvolutionEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/replace
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Replace the Engineering Item Instance Summary: Replace the Engineering Item Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> ReplaceInstance<T>(string engItemId, string instanceId, IEngInstanceReplace request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceFilterableMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/replace";

         return await PostCollectionFromResponseMemberProperty<T, IEngInstanceReplace>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Creates engineering items. Summary: Creates engineering items.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateEngItem request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngItemDefaultMask), typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem";

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngItem>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dscfg:Configured/detach
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to detach a list of configuration context from a single reference. Summary: 
      // Service to detach a list of configuration context from a single reference.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> DetachConfiguration(string engItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured/detach";

         return await PostCollectionFromResponseResourcesProperty<ITypedUriIdentifier, ITypedUriIdentifier[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/unset/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the variant effectivities. If unsetVariant service is executed under 
      // Work Under (Change Action) then it may lead to a new evolution of existing relationship. Summary: 
      // Service to unset the variant effectivities
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseUnsetVariantEffectivity> UnsetInstanceVariantEffectivity(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/unset/variant";

         return await PostIndividual<IResponseUnsetVariantEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Adding Enterprise Reference to an Engineering Item Summary: Adding Enterprise Reference 
      // to an Engineering Item
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> AttachEnterpriseItemNumber(string engItemId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         return await PostIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/set/variant
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to set the effectivity variant expression (XML) on a single relationship. If 
      // setVariant service is executed under Work Under (Change Action) then it may lead to a new evolution 
      // of existing relationship. WARNING: Coherency between Evolution and Variant Expression are under 
      // users responsibility.<br><br>Please find below the list of possible error codes and error messages: 
      // <br> 102 : The parent reference of the given instance does not have a Configuration Context. 
      // <br>117 : The input effectivity expression or data used in the expression is not correct. <br>118 
      // : Instance's identifier in the input is not valid or correct. <br>119 : Effectivity cannot be 
      // set due to dictionary data. <br>120 : The criteria is not enabled on the parent reference. <br>121 
      // : The root reference is a 3DPart which is not configurable. <br>122 : The root reference is XCAD 
      // controlled which is not configurable. <br>123 : Model provided in the input expression is not 
      // part of Configuration Context. <br>124 : Model provided in the input expression is not accessible 
      // or does not exist. <br>125 : Input expression not well-formatted (No model found). <br>126 : The 
      // criteria used in the input expression is not enabled on parent reference. <br>127 : Error occured 
      // during the save of the new effectivities. <br>128 : Error occured during the update of Configuration 
      // Revision effectivities. <br>129 : Effectivities cannot be set because changing at least one of 
      // them would impact frozen evolution range. <br>130 : The parent reference is not configurable. 
      // <br>199 : Failure detected during operation. <br> Summary: Service to set the effectivities 
      // variant expression (XML).
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<ISetVariantResponse> SetInstanceVariantEffectivity(string engItemId, string instanceId, ISetVariantEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/set/variant";

         return await PostIndividual<ISetVariantResponse, ISetVariantEffectivities>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:EngInstance
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Engineering Item Instance to an Engineering Item. Summary: Create Engineering 
      // Item Instance.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstance<T>(string engItemId, ICreateEngInstances request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance";

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngInstances>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/unset/evolution
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Service to unset the evolution effectivities. Summary: Service to unset the evolution 
      // effectivities.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseUnsetEvolutionEffectivity> UnsetInstanceEvolutionEffectivity(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/unset/evolution";

         return await PostIndividual<IResponseUnsetEvolutionEffectivity>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dseng:EngItem/{ID}/dseng:EnterpriseReference
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Enterprise Reference of an Engineering item. Summary: Modifies the 
      // Enterprise Reference of an Engineering item.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> UpdateEnterpriseItemNumber(string engItemId, IEnterpriseItemNumber request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         return await PatchIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Engineering Item Instance attributes Summary: Modifies the Engineering 
      // Item Instance attributes
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateInstance<T>(string engItemId, string instanceId, IEngInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IEngInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dseng:EngItem/{ID}/dscfg:Configured
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Enables the criteria of single reference Summary: Modifies Configuration Information 
      // of configured object
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateConfiguration<T>(string engItemId, IConfiguredPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IConfiguredDetail), typeof(IConfiguredBasics) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured";

         return await PatchIndividualFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dseng:EngItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Engineering Item attributes Summary: Modifies the Engineering Item 
      // attributes
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string engItemId, IEngItemPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngItemDefaultMask), typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         return await PatchIndividualFromResponseMemberProperty<T, IEngItemPatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modifies the Engineering Item Representation Instance attributes Summary: Modifies 
      // the Engineering Item Representation Instance attributes
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngRepInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<T> UpdateRepInstance<T>(string engItemId, string repInstanceId, IEngRepInstancePatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{repInstanceId}";

         return await PatchIndividualFromResponseMemberProperty<T, IEngRepInstancePatch>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dseng:EngItem/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Engineering Item Summary: Delete a Engineering Item
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dseng:EngItem/{ID}/dslc:changeControl
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deactivate the Change Control. Summary: Deactivate the Change Control.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachChangeControl(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deletes the Engineering Item Representation Instance Summary: Deletes the Engineering 
      // Item Representation Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngRepInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEmpty> DeleteRepInstance(string engItemId, string repInstanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{repInstanceId}";

         return await DeleteIndividual<IEmpty>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dseng:EngItem/{PID}/dseng:Alternate/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Engineering Item Alternates Summary: Delete a Engineering Item Alternates
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="alternateId">
      // Description: dseng:Alternate object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteAlternate(string engItemId, string alternateId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate/{alternateId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Deletes the Engineering Item Instance Summary: Deletes the Engineering Item Instance
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // <param name="instanceId">
      // Description: dseng:EngInstance object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEmpty> DeleteInstance(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         return await DeleteIndividual<IEmpty>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:Alternate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Engineering Item Alternates to an Engineering Item. Summary: Create Engineering 
      // Item Alternates.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternates request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlternateMask), typeof(IAlternateDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternates>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:Alternate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Engineering Item Alternates to an Engineering Item. Summary: Create Engineering 
      // Item Alternates.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternatesParent request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlternateMask), typeof(IAlternateDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternatesParent>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/dseng:Alternate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Engineering Item Alternates to an Engineering Item. Summary: Create Engineering 
      // Item Alternates.
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternatesInstance request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IAlternateMask), typeof(IAlternateDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternatesInstance>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dseng:EngItem/{ID}/expand
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Expand Engineering Item based on the expandDepth and filter specified. By default 
      // expandDepth is 1 and no filter is applied. Only the first 10000 results will be fetched with 
      // default Mask dskern:Mask.Default applied. no option to change the Mask. Summary: Expand Engineering 
      // Item using indexed queries
      // <param name="engItemId">
      // Description: dseng:EngItem object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IExpandResponse> Expand(string engItemId, IExpand request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/expand";

         return await PostIndividual<IExpandResponse, IExpand>(resourceURI, request);
      }
   }
}