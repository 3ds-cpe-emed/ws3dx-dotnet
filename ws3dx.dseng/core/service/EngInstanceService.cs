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
using ws3dx.dseng.data;
using ws3dx.shared.utils;

namespace ws3dx.dseng.service
{
   // SDK Service
   public class EngInstanceService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dseng/";

      public EngInstanceService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      ///---------------------------------------------------------------------------------------------
      /// <summary>
      /// Gets attributes for multiple Engineering Items Instances without root Id 
      /// Get multiple Engineering Instances which are Indexed. API Works only for Indexed Data.The customer 
      /// attributes are returned only with default sixw mapping ds6wg:TypeName.AttributeName and it is 
      /// not supported if the sixw predicate is changed Maximum of 1000 items can be passed to fetch the 
      /// information. Note: any attribute that has empty values will not be returned
      /// </summary>
      ///---------------------------------------------------------------------------------------------
      /// <remarks>
      /// (POST) dseng:EngInstance/bulkfetch
      /// </remarks>
      ///---------------------------------------------------------------------------------------------
      /// <param name="request">
      /// </param>
      ///---------------------------------------------------------------------------------------------
      public async Task<(IList<IEngInstanceDefaultMask>, IList<string>)> InstanceBulkfetch(string[] request)
      {
         string resourceURI = $"{GetBaseResource()}dseng:EngInstance/bulkfetch";

         IDictionary<string, string> queryParams = new Dictionary<string, string>
         {
            { "$mva", "true" }
         };

         return await PostBulkCollection<IEngInstanceDefaultMask, string[]>(resourceURI, request, queryParams: queryParams);
      }
   }
}