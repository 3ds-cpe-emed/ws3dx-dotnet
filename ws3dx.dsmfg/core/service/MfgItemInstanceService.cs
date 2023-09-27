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
using ws3dx.dsmfg.data;
using ws3dx.shared.utils;

namespace ws3dx.dsmfg.core.service
{
   // SDK Service
   public class MfgItemInstanceService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsmfg/";

      public MfgItemInstanceService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsmfg:MfgItemInstance/bulkFetch
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get Multiple Manufacturing Item Instances which are Indexed.
      //  API Works only for Indexed Data only. 
      //  The customer attributes or enterprise extension attributes are returned only with default sixw 
      // mapping ds6wg:TypeName.AttributeName and it is not supported if the sixw predicate is changed. 
      // Summary: Get Multiple Manufacturing Item Instances which are Indexed.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> BulkFetch<T>(string[] request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IMfgItemInstanceMask), typeof(IMfgItemInstanceDetailMask) });

         string resourceURI = $"{GetBaseResource()}dsmfg:MfgItemInstance/bulkFetch";

         return await PostCollectionFromResponseMemberProperty<T, string[]>(resourceURI, request);
      }
   }
}