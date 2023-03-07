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
using System.Collections.Generic;
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.data.collection.impl;
using ws3dx.dspfl.data;

namespace ws3dx.dspfl.core.service
{
   // SDK Service
   public class VariabilityGroupService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dspfl/";

      public VariabilityGroupService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:VariabilityGroup
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Variability Groups. Summary: Get all Variability Groups
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IVariabilityGroupMask>> GetVariabilityGroups()
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup";

         return await GetGroup<IVariabilityGroupMask, NlsLabeledItemSet<IVariabilityGroupMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:VariabilityGroup/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Variability Group. Summary: Get a Variability Group
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IVariabilityGroupMask> GetVariabilityGroup(string variabilityGroupId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}";

         return await GetIndividual<IVariabilityGroupMask>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:VariabilityGroup/{PID}/dspfl:Option/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of given Option. Summary: Get a Option
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // <param name="optionId">
      // Description: dspfl:Option object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IOptionMask> GetOption(string variabilityGroupId, string optionId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}/dspfl:Option/{optionId}";

         return await GetIndividual<IOptionMask, NlsLabeledItemSet<IOptionMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /dspfl:VariabilityGroup/{ID}/dspfl:Option
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get details of all Options of given Variability Group. Summary: Get all Options
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<IOptionMask>> GetOptions(string variabilityGroupId)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}/dspfl:Option";

         return await GetGroup<IOptionMask, NlsLabeledItemSet<IOptionMask>>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:VariabilityGroup/{PID}/dspfl:Option/{ID}/modify
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Option sequenceNumber Summary: Modify Option sequenceNumber
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // <param name="ID">
      // Description: dspfl:Option object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IOptionMask>> MoveOption(string variabilityGroupId, string ID, IOrdered request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}/dspfl:Option/{ID}/modify";

         return await PostGroup<IOptionMask, NlsLabeledItemSet<IOptionMask>, IOrdered>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:VariabilityGroup
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Variability Groups. Summary: Create Variability Groups
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IVariabilityGroupMask>> Create(ICreateVariabilityGroup request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup";

         return await PostGroup<IVariabilityGroupMask, NlsLabeledItemSet<IVariabilityGroupMask>, ICreateVariabilityGroup>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /dspfl:VariabilityGroup/{ID}/dspfl:Option
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Create Options. Summary: Create Options
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IOptionMask>> CreateOptions(string variabilityGroupId, ICreateVariabilityOption request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}/dspfl:Option";

         return await PostGroup<IOptionMask, NlsLabeledItemSet<IOptionMask>, ICreateVariabilityOption>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:VariabilityGroup/{PID}/dspfl:Option/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Option attributes. Summary: Modify Option attributes
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // <param name="optionId">
      // Description: dspfl:Option object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IOptionMask> UpdateOption(string variabilityGroupId, string optionId, IUpdateOption request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}/dspfl:Option/{optionId}";

         return await PatchIndividual<IOptionMask, NlsLabeledItemSet<IOptionMask>, IUpdateOption>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PATCH) /dspfl:VariabilityGroup/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Modify Variability Group attributes. Summary: Modify Variability Group attributes
      // <param name="variabilityGroupId">
      // Description: dspfl:VariabilityGroup object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IVariabilityGroupMask>> UpdateVariabilityGroup(string variabilityGroupId, IUpdateVariabilityGroup request)
      {
         string resourceURI = $"{GetBaseResource()}/dspfl:VariabilityGroup/{variabilityGroupId}";

         return await PatchGroup<IVariabilityGroupMask, NlsLabeledItemSet<IVariabilityGroupMask>, IUpdateVariabilityGroup>(resourceURI, request);
      }
   }
}