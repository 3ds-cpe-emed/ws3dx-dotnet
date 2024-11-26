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
using ws3dx.shared.data.primitive;
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

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets all the Engineering Item Instances.
      /// Engineering Item Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dseng:EngInstance
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="top">
      /// Represents the total number of items returned from the get, accepts a maximum value of 2000. The
      /// response will be returned with the default 100 instances if top is given zero or not passed.
      /// </param>
      /// <param name="skip">
      /// Represents the number of items to skip (to be used along with $top query parameter).The response
      /// will be returned with the default 100 instances if skip is passed without the top.
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> GetInstances<T>(string engItemId, int skip = 0, int top = 100, bool withConfiguredInstances = true)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" },
            { "$skip", skip.ToString()},
            { "$top", top.ToString()}
            };

         if (withConfiguredInstances)
         {
            queryParams.Add("$fields", "dsmvcfg:attribute.hasConfiguredInstance");
         }

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Create Engineering Item Instance to an Engineering Item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:EngInstance
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="configurationAuthoringContext">
      /// Work Under Evolution. Will be ignored if DS-Change-Authoring-Context is set
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstance<T>(string engItemId, ICreateEngInstances request, string changeAuthoringContext = null, string configurationAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }
         if (configurationAuthoringContext != null) { headerParams.Add("DS-Configuration-Authoring-Context", configurationAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngInstances>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Engineering Item Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> GetInstance<T>(string engItemId, string instanceId, bool withConfiguredInstances = true)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         if (withConfiguredInstances)
         {
            queryParams.Add("$fields", "dsmvcfg:attribute.hasConfiguredInstance");
         }

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Deletes the Engineering Item Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="configurationAuthoringContext">
      /// Work Under Evolution. Will be ignored if DS-Change-Authoring-Context is set
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEmpty> DeleteInstance(string engItemId, string instanceId, string changeAuthoringContext = null, string configurationAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }
         if (configurationAuthoringContext != null) { headerParams.Add("DS-Configuration-Authoring-Context", configurationAuthoringContext); }

         return await DeleteIndividual<IEmpty>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies the Engineering Item Instance attributes
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{PID}/dseng:EngInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> UpdateInstance<T>(string engItemId, string instanceId, IEngInstancePatch request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PatchIndividualFromResponseMemberProperty<T, IEngInstancePatch>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Replace the Engineering Item Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/replace
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="configurationAuthoringContext">
      /// Work Under Evolution. Will be ignored if DS-Change-Authoring-Context is set
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> ReplaceInstance<T>(string engItemId, string instanceId, IEngInstanceReplace request, string changeAuthoringContext = null, string configurationAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceFilterableMask), typeof(IEngInstanceDetailsMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/replace";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }
         if (configurationAuthoringContext != null) { headerParams.Add("DS-Configuration-Authoring-Context", configurationAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, IEngInstanceReplace>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies list of Engineering Items Instances attributes
      /// Modifies multiple Engineering Item Instances attributes, Maximum of 50 items can be passed to
      /// update the information.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:EngInstance/bulkupdate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddInstanceBulkUpdate<T>(string engItemId, IEngInstanceBulkUpdateItem[] request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngInstanceDefaultMask), typeof(IEngInstanceDetailMask), typeof(IEngInstanceFilterableMask), typeof(IEngInstancePositionMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/bulkupdate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, IEngInstanceBulkUpdateItem[]>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets all the Engineering Item Representation Instances.
      /// Engineering Item Representation Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dseng:EngRepInstance
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="top">
      /// Represents the total number of items returned from the get, accepts a maximum value of 2000. The
      /// response will be returned with the default 100 repinstances if top is given zero or not passed.
      /// </param>
      /// <param name="skip">
      /// Represents the number of items to skip (to be used along with $top query parameter).The response
      /// will be returned with the default 100 repinstances if skip is passed without the top .
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> GetRepInstances<T>(string engItemId, int top = 100, int skip = 0)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$top", top.ToString() },
            { "$skip", skip.ToString() },
            { "$mva", "true" }
         };

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Create Engineering Representation Instances
      /// Create Engineering Representation Instance to an Engineering Item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:EngRepInstance
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddRepInstance<T>(string engItemId, ICreateEngRepInstances request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngRepInstances>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Engineering Item Representation Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngRepInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> GetRepInstance<T>(string engItemId, string instanceId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{instanceId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Deletes the Engineering Item Representation Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngRepInstance object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IAddEmpty> DeleteRepInstance(string engItemId, string instanceId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{instanceId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await DeleteIndividual<IAddEmpty>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies the Engineering Item Representation Instance attributes
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngRepInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> UpdateRepInstance<T>(string engItemId, string instanceId, IEngRepInstancePatch request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{instanceId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PatchIndividualFromResponseMemberProperty<T, IEngRepInstancePatch>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Replace the Engineering Item Representation Instance
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngRepInstance/{ID}/replace
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngRepInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> ReplaceRepInstance<T>(string engItemId, string instanceId, IEngRepInstanceReplace request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngRepInstanceDetailMask), typeof(IEngInstanceDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/{instanceId}/replace";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostIndividualFromResponseMemberProperty<T, IEngRepInstanceReplace>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies list of Engineering Representations Instances attributes
      /// Modifies multiple Engineering Item Instances attributes, Maximum of 50 items can be passed to
      /// update the information.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:EngRepInstance/bulkupdate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddRepInstanceBulkUpdate<T>(string engItemId, IEngRepInstanceBulkUpdateItem[] request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IEngInstanceDefaultMask), typeof(IEngRepInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngRepInstance/bulkupdate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, IEngRepInstanceBulkUpdateItem[]>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Expand Engineering Item using indexed queries
      /// Expand Engineering Item based on the expandDepth and filter specified. By default expandDepth is
      /// 1 and no filter is applied. Only the first 10000 results will be fetched with default Mask
      /// dskern:Mask.Default applied. no option to change the Mask.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/expand
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IList<object>> Expand(string engItemId, IExpand request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/expand";

         return await PostCollectionNoMaskFromResponseMemberProperty<object, IExpand>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Creates engineering items.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateEngItem request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask), typeof(IEngItemDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostCollectionFromResponseMemberProperty<T, ICreateEngItem>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Engineering Item
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> Get<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask), typeof(IEngItemDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Delete a Engineering Item
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> Delete(string engItemId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await DeleteIndividual<IGenericResponse>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies the Engineering Item attributes
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> Update<T>(string engItemId, IEngItemPatch request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask), typeof(IEngItemDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PatchIndividualFromResponseMemberProperty<T, IEngItemPatch>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Get multiple Engineering Items which are Indexed. API Works only for Indexed Data. The customer
      /// attributes or enterprise extension attributes are returned only with default sixw mapping
      /// ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. Maximum
      /// of 1000 items can be passed to fetch the information
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/bulkfetch
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkFetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngItemDefaultMask), typeof(IEngItemDetailsMask), typeof(IEngItemCommonMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/bulkfetch";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostBulkCollection<T, string[]>(resourceURI, request, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies multiple Engineering Item attributes, Maximum of 50 items can be passed to update the
      /// information.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/bulkupdate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<(IList<T>, IList<string>)> BulkUpdate<T>(IEngItemBulkUpdateItem[] request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IEngItemCommonMask), typeof(IEngItemDetailsMask), typeof(IEngItemConfigMask), typeof(IEngItemDefaultMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/bulkupdate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostBulkCollection<T, IEngItemBulkUpdateItem[]>(resourceURI, request, headerParams: headerParams, queryParams: queryParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets where used Parent Engineering Item using indexed queries. Only the first 1000 results will
      /// be fetched with default response. no option to change the Mask.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/locate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IList<ILocatedEngInstances>> Locate(ILocateEngInstances request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/locate";

         return await PostCollectionFromResponseMemberProperty<ILocatedEngInstances, ILocateEngInstances>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets All Alternate items connected to Primary Engieering item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dseng:Alternate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> GetAlternates<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IAlternateMask), typeof(IAlternateDetailMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Create Engineering Item Alternates to an Engineering Item. Maximum of 30 Alternates can be created in one transaction.
      /// in one transaction.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:Alternate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternates request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IAlternateMask), typeof(IAlternateDetailMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternates>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Create Engineering Item Alternates to an Engineering Item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:Alternate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternatesInstance request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IAlternateMask), typeof(IAlternateDetailMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternatesInstance>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Create Engineering Item Alternates to an Engineering Item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:Alternate
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="alternateId">
      /// dseng:Alternate object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> AddAlternate<T>(string engItemId, IAddAlternatesParent request, string changeAuthoringContext = null)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IAlternateMask), typeof(IAlternateDetailMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostCollectionFromResponseMemberProperty<T, IAddAlternatesParent>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Engineering Item Alternates
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:Alternate/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="alternateId">
      /// dseng:Alternate object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> GetAlternate<T>(string engItemId, string alternateId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IAlternateMask), typeof(IAlternateDetailMask)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate/{alternateId}";

         return await GetIndividualFromResponseMemberProperty<T>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Delete a Engineering Item Alternates
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{PID}/dseng:Alternate/{ID}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="alternateId">
      /// dseng:Alternate object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteAlternate(string engItemId, string alternateId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:Alternate/{alternateId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await DeleteIndividual<IGenericResponse>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Enterprise Reference of an Engineering Item
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dseng:EnterpriseReference
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> GetEnterpriseItemNumber(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         return await GetIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Adding Enterprise Reference to an Engineering Item
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dseng:EnterpriseReference
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> AttachEnterpriseItemNumber(string engItemId, IEnterpriseItemNumber request, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies the Enterprise Reference of an Engineering item.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{ID}/dseng:EnterpriseReference
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnterpriseItemNumberMask> UpdateEnterpriseItemNumber(string engItemId, IEnterpriseItemNumber request, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EnterpriseReference";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PatchIndividualFromResponseMemberProperty<IEnterpriseItemNumberMask, IEnterpriseItemNumber>(resourceURI, request, headerParams: headerParams);
      }


      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Description: Add deformable extension to a rigid engineering item.
      /// Summary: Set a rigid engineering item as deformable
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{engItemId}/dseng:deformable"
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      public async Task<IEngItemDefaultMask> SetDeformable(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:deformable";

         return await PostIndividual<IEngItemDefaultMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Description: Set a rigid engineering item as deformed from deformable engineering item or
      /// update by changing the deformable engineering item for the same deformed engineering item.
      /// Summary: Set a rigid engineering item as deformed or update the deformable of a deformed
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{engItemId}/dseng:deformed"
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      public async Task<IEngItemDeformedMask> SetDeformed(string engItemId, IEngItemSetDeformed request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:deformed";

         return await PostIndividual<IEngItemDeformedMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets the details of the deformed engineering item with DeformableReference key. Incase if 
      /// the object is not deformed engineering item then the response will return the default mask.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{engItemId}/dseng:deformed"
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      public async Task<IEngItemDeformedMask> GetDeformed(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:deformed";

         return await GetIndividualFromResponseMemberProperty<IEngItemDeformedMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Delete the deformed extension and the link to deformable from a deformed engineering item(ID)
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{engItemId}/dseng:deformed"
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>>
      public async Task<IEngItemDeformedMask> DeleteDeformed(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:deformed";

         return await DeleteIndividual<IEngItemDeformedMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Change Control of an Engineering Item
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dslc:changeControl
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IChangeControlStatusMask> GetChangeControl(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await GetIndividualFromResponseMemberProperty<IChangeControlStatusMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Activate the Change Control
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dslc:changeControl
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> AttachChangeControl(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await PostIndividual<IGenericResponse>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Deactivate the Change Control.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{ID}/dslc:changeControl
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachChangeControl(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dslc:changeControl";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Instance effectivity information.
      /// This extension gets the effectivity of an Object instance/relationship
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IFilterableDetailMask>> GetInstanceEffectivity(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable";

         return await GetCollectionFromResponseMemberProperty<IFilterableDetailMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to set the effectivities evolution expression (XML).
      /// Service to set the effectivity evolution expression (XML) on a single relationship. WARNING:
      /// Coherency between Evolution and Variant Expression are under users responsibility.
      /// </para>
      /// <para>
      /// Please find below the list of possible error codes and error messages:
      /// 102 : The parent reference of the given instance does not have a Configuration Context.
      /// 106 : The input instance is controlled by a Change. Evolution effectivity cannot be edited.
      /// 117 : The input effectivity expression or data used in the expression is not correct.
      /// 118 : Instance's identifier in the input is not valid or correct.
      /// 119 : Effectivity cannot be set due to dictionary data.
      /// 120 : The criteria is not enabled on the parent reference.
      /// 121 : The root reference is a 3DPart which is not configurable.
      /// 122 : The root reference is XCAD controlled which is not configurable.
      /// 123 : Model provided in the input expression is not part of Configuration Context.
      /// 124 : Model provided in the input expression is not accessible or does not exist.
      /// 125 : Input expression not well-formatted (No model found).
      /// 126 : The criteria used in the input expression is not enabled on parent reference.
      /// 127 : Error occured during the save of the new effectivities.
      /// 128 : Error occured during the update of Configuration Revision effectivities.
      /// 129 : Effectivities cannot be set because changing at least one of them would impact frozen
      /// evolution range.
      /// 130 : The parent reference is not configurable.
      /// 199 : Failure detected during operation.
      /// </para>
      ///
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/set/evolution
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<ISetEvolutionResponse> SetInstanceEvolutionEffectivity(string engItemId, string instanceId, ISetEvolutionEffectivities request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/set/evolution";

         return await PostIndividual<ISetEvolutionResponse, ISetEvolutionEffectivities>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to unset the evolution effectivities.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/unset/evolution
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IResponseUnsetEvolutionEffectivity> UnsetInstanceEvolutionEffectivity(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/unset/evolution";

         return await PostIndividual<IResponseUnsetEvolutionEffectivity>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to set the effectivities variant expression (XML).
      /// setVariant service is executed under Work Under (Change Action) then it may lead to a new
      /// evolution of existing relationship. WARNING: Coherency between Evolution and Variant
      /// Expression are under users responsibility.
      ///
      /// Please find below the list of possible error codes and error messages:
      /// 102 : The parent reference of the given instance does not have a Configuration Context.
      /// 117 : The input effectivity expression or data used in the expression is not correct.
      /// 118 : Instance's identifier in the input is not valid or correct.
      /// 119 : Effectivity cannot be set due to dictionary data.
      /// 120 : The criteria is not enabled on the parent reference.
      /// 121 : The root reference is a 3DPart which is not configurable.
      /// 122 : The root reference is XCAD controlled which is not configurable.
      /// 123 : Model provided in the input expression is not part of Configuration Context.
      /// 124 : Model provided in the input expression is not accessible or does not exist.
      /// 125 : Input expression not well-formatted (No model found).
      /// 126 : The criteria used in the input expression is not enabled on parent reference.
      /// 127 : Error occured during the save of the new effectivities.
      /// 128 : Error occured during the update of Configuration Revision effectivities.
      /// 129 : Effectivities cannot be set because changing at least one of them would impact frozen 
      /// evolution range.
      /// 130 : The parent reference is not configurable.
      /// 199 : Failure detected during operation.
      ///
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/set/variant
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<ISetVariantResponse> SetInstanceVariantEffectivity(string engItemId, string instanceId, ISetVariantEffectivities request, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/set/variant";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostIndividual<ISetVariantResponse, ISetVariantEffectivities>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to unset the variant effectivities. If unsetVariant service is executed under Work Under
      /// (Change Action) then it may lead to a new evolution of existing relationship.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:Filterable/unset/variant
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Change Action physical id Ex: pid:DB4F8256517400005EEC5A6E000FEBBC
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IResponseUnsetVariantEffectivity> UnsetInstanceVariantEffectivity(string engItemId, string instanceId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:Filterable/unset/variant";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostIndividual<IResponseUnsetVariantEffectivity>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Object Configuration information
      /// This extension gets the Enabled Criteria and Configuration Contexts of Configured object
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dscfg:Configured
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> GetConfiguration<T>(string engItemId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IConfiguredDetail), typeof(IConfiguredBasics)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured";

         return await GetCollectionFromResponseMemberProperty<T>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies Configuration Information of configured object
      /// Enables the criteria of single reference
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{ID}/dscfg:Configured
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<T> UpdateConfiguration<T>(string engItemId, IConfiguredPatch request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), [typeof(IConfiguredDetail), typeof(IConfiguredBasics)]);

         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured";

         return await PatchIndividualFromResponseMemberProperty<T, IConfiguredPatch>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to attach a list of configuration context to a single reference.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dscfg:Configured/attach
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> AttachConfiguration(string engItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured/attach";

         return await PostCollectionFromResponseResourcesProperty<ITypedUriIdentifier, ITypedUriIdentifier[]>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to detach a list of configuration context from a single reference.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dscfg:Configured/detach
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<ITypedUriIdentifier>> DetachConfiguration(string engItemId, ITypedUriIdentifier[] request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dscfg:Configured/detach";

         return await PostCollectionFromResponseResourcesProperty<ITypedUriIdentifier, ITypedUriIdentifier[]>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to create a static mapping for an instance.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:ConfiguredInstance/set
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IPhysicalId> SetConfiguredInstance(string engItemId, string instanceId, ISetConfiguredInstance request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:ConfiguredInstance/set";

         return await PostIndividual<IPhysicalId, ISetConfiguredInstance>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to update static mapping for an instance.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:ConfiguredInstance/update
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IPhysicalId> UpdateConfiguredInstance(string engItemId, string instanceId, ISetConfiguredInstance request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:ConfiguredInstance/update";

         return await PostIndividual<IPhysicalId, ISetConfiguredInstance>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to detach static mapping for an instance.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:ConfiguredInstance/unset
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IPhysicalId> UnsetConfiguredInstance(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:ConfiguredInstance/unset";

         return await PostIndividual<IPhysicalId>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to get static mapping for an instance.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:EngInstance/{ID}/dscfg:ConfiguredInstance
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="instanceId">
      /// dseng:EngInstance object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGetConfiguredInstance> GetConfiguredInstance(string engItemId, string instanceId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:EngInstance/{instanceId}/dscfg:ConfiguredInstance";

         return await GetIndividual<IGetConfiguredInstance>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets a Geolocation of an dseng:EngItem
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{ID}/dsgeoloc:Geolocation
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGeolocationMask> GetGeolocation(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dsgeoloc:Geolocation";

         return await GetIndividualFromResponseMemberProperty<IGeolocationMask>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Service to attach geolocation to a single reference.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{ID}/dsgeoloc:Geolocation
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IGeolocationMask>> AddGeolocation(string engItemId, ICreateGeolocation request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dsgeoloc:Geolocation";

         return await PostCollectionFromResponseMemberProperty<IGeolocationMask, ICreateGeolocation>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Delete a Geolocation
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{ID}/dsgeoloc:Geolocation
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteGeolocation(string engItemId)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dsgeoloc:Geolocation";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Modifies the Geolocation of an dseng:EngItem attributes
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{ID}/dsgeoloc:Geolocation
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// dseng:EngItem object ID
      /// </param>
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IGeolocationMask>> UpdateGeolocation(string engItemId, IGeolocationPatch request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dsgeoloc:Geolocation";

         return await PatchCollectionFromResponseMemberProperty<IGeolocationMask, IGeolocationPatch>(resourceURI, request);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets Make From details of a Product
      /// Lists all the make from items of the physical product. If a raw material is used as child in the
      /// Make From, the Quantity details of the raw material will also be displayed.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (GET) dseng:EngItem/{PID}/dseng:MakeFrom
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// The id product for which Make From connections need to be retrived.
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMakeFrom>> GetMakeFrom(string engItemId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:MakeFrom";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await GetCollectionFromResponseMemberProperty<IMakeFrom>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Creates the Make From connection for the specified raw material or child product with the given
      /// physical product.
      /// Creates the Make From connection for the specified raw material or child product with the given
      /// physical product. Quantity details are required in case of adding the raw materials as a child
      /// using the Make From connection.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngItem/{PID}/dseng:MakeFrom
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// The id of a physical product for which the "Make From" connection must be created.
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMakeFrom>> AddMakeFrom(string engItemId, ICreateMakeFromConnection request, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:MakeFrom";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PostCollectionFromResponseMemberProperty<IMakeFrom, ICreateMakeFromConnection>(resourceURI, request, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Remove the Make From connection.
      /// Remove the Make From connection from physcial product to child.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (DELETE) dseng:EngItem/{PID}/dseng:MakeFrom/{makeFromId}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// Physical product Identifier.
      /// </param>
      /// <param name="makeFromId">
      /// MakeFrom Connection Identifier.
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteMakeFrom(string engItemId, string makeFromId, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:MakeFrom/{makeFromId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await DeleteIndividual<IGenericResponse>(resourceURI, headerParams: headerParams);
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Update the existing details of Make From.
      /// Update the Quantity or Reference name of raw material / product for the existing Make From connection.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (PATCH) dseng:EngItem/{PID}/dseng:MakeFrom/{makeFromId}
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="engItemId">
      /// The id of physical product.
      /// </param>
      /// <param name="makeFromId">
      /// The connection id.
      /// </param>
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IMakeFrom>> UpdateMakeFrom(string engItemId, string makeFromId, IUpdateMakeFromConnection request, string changeAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngItem/{engItemId}/dseng:MakeFrom/{makeFromId}";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }

         return await PatchCollectionFromResponseMemberProperty<IMakeFrom, IUpdateMakeFromConnection>(resourceURI, request, headerParams: headerParams);
      }
   }
}