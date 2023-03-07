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
using System.Threading.Tasks;
using ws3dx.authentication.data;
using ws3dx.core.service;
using ws3dx.shared.data;

namespace ws3dx.dsrsc.core.service
{
   // SDK Service
   public class InvokeService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsrsc/";

      public InvokeService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsrsc:getResourcesOccurrencesFromMfgOperationOccurrences
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get Resource Occurrences from Mfg Operation Occurrences Path Summary: Get Resource 
      // Occurrences from Mfg Operation Occurrences Path
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> GetResourcesOccurrencesFromMfgOperationOccurrences(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsrsc:getResourcesOccurrencesFromMfgOperationOccurrences";

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsrsc:deleteWorkerInstances
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach Worker instances from Resource Reference Summary: Detach Worker instances
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteWorkerInstances(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsrsc:deleteWorkerInstances";

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsrsc:deleteOrganizationalResourceInstances
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach Resource instances from Resource Reference Summary: Detach Resource instances
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteOrganizationalResourceInstances(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsrsc:deleteOrganizationalResourceInstances";

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) invoke/dsrsc:deleteResourceItemInstances
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Detach Resource Item instances from Resource Item Reference Summary: Detach Resource 
      // Item instances
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DeleteResourceItemInstances(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dsrsc:deleteResourceItemInstances";

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request);
      }
   }
}