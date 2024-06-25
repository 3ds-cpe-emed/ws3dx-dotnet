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
using ws3dx.shared.data;

namespace ws3dx.dseng.core.service
{
   // SDK Service
   public class InvokeService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dseng/";

      public InvokeService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }


      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Detach engineering item instances from an Engineering Item version.
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) invoke/dseng:detachEngInstances
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      /// <param name="changeAuthoringContext">
      /// Work Under Change Action
      /// </param>
      /// <param name="configurationAuthoringContext">
      /// Work Under Evolution. Will be ignored if DS-Change-Authoring-Context is set
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> DetachInstances(string[] request, string changeAuthoringContext = null, string configurationAuthoringContext = null)
      {
         string resourceURI = $"{GetBaseResource()}invoke/dseng:detachEngInstances";

         IDictionary<string, string> headerParams = new Dictionary<string, string>();
         if (changeAuthoringContext != null) { headerParams.Add("DS-Change-Authoring-Context", changeAuthoringContext); }
         if (configurationAuthoringContext != null) { headerParams.Add("DS-Configuration-Authoring-Context", configurationAuthoringContext); }

         return await PostIndividual<IGenericResponse, string[]>(resourceURI, request, headerParams: headerParams);
      }
   }
}