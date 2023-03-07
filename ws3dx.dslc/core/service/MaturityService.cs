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
using ws3dx.dslc.data;

namespace ws3dx.dslc.core.service
{
   // SDK Service
   public class MaturityService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dslc/";

      public MaturityService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) maturity/changeState
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Change maturity state for a list of objects. You can change maturity to a state only 
      // along a single valid transition on the Maturity graph - to find the list of valid next states, 
      // use the web service getNextStates. Summary: Change maturity states
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<IChangeState>> ChangeState(IChangeStateInput request)
      {
         string resourceURI = $"{GetBaseResource()}maturity/changeState";

         return await PostGroup<IChangeState, IChangeStateOutput, IChangeStateInput>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) maturity/getNextStates
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets the next possible maturity states for a list of objects. Summary: Get next 
      // maturity states
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGetNextStatesOutput> GetNextStates(IIdInput request)
      {
         string resourceURI = $"{GetBaseResource()}maturity/getNextStates";

         return await PostGroup<IGetNextStatesOutput, IIdInput>(resourceURI, request);
      }
   }
}