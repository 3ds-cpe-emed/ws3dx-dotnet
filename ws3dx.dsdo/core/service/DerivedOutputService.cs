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
using ws3dx.dsdo.data;
using ws3dx.shared.data;
using ws3dx.shared.utils;

namespace ws3dx.dsdo.core.service
{
   // SDK Service
   public class DerivedOutputService : EnoviaBaseService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler/dsdo/";

      public DerivedOutputService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) dsdo:DerivedOutputs/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Gets a Derived Output Summary: Gets a Derived Output
      // <param name="doId">
      // Description: dsdo:DerivedOutputs object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IEnumerable<T>> Get<T>(string doId)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDerivedOutputDetailMask), typeof(IDerivedOutputCompleteMask) });

         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs/{doId}";

         return await GetMultiple<T>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsdo:DerivedOutputs
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Add new derived output. Summary: Add new derived output.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Create<T>(ICreateDerivedOutput request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDerivedOutputDetailMask), typeof(IDerivedOutputCompleteMask) });

         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs";

         return await PostRequestMultiple<T, ICreateDerivedOutput>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsdo:DerivedOutputs/{PID}/dsdo:DerivedOutputFiles/{ID}/DownloadTicket
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Download derived output files. Summary: Download derived output files.
      // <param name="doId">
      // Description: dsdo:DerivedOutputs object ID
      // </param>
      // <param name="doFileId">
      // Description: dsdo:DerivedOutputFiles object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IDownloadFileTicketResponse> GetDownloadTicket(string doId, string doFileId, IAddEmpty request)
      {
         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs/{doId}/dsdo:DerivedOutputFiles/{doFileId}/DownloadTicket";

         return await PostRequest<IDownloadFileTicketResponse, IAddEmpty>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsdo:DerivedOutputs/Locate
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Get information of all derived outputs. Summary: Get information of all derived 
      // outputs.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Locate<T>(ILocateDerivedOutputs request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDerivedOutputDetailMask), typeof(IDerivedOutputCompleteMask) });

         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs/Locate";

         return await PostRequestMultiple<T, ILocateDerivedOutputs>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) dsdo:DerivedOutputs/{PID}/dsdo:DerivedOutputFiles/{ID}/Sync
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Update an existing derived output entity on given Representation. Summary: Update 
      // derived output entity.
      // <param name="doId">
      // Description: dsdo:DerivedOutputs object ID
      // </param>
      // <param name="doFileId">
      // Description: dsdo:DerivedOutputFiles object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IEnumerable<T>> Update<T>(string doId, string doFileId, IUpdateDerivedOutput request)
      {
         GenericParameterConstraintUtils.CheckConstraints(typeof(T), new Type[] { typeof(IDerivedOutputDetailMask), typeof(IDerivedOutputCompleteMask) });

         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs/{doId}/dsdo:DerivedOutputFiles/{doFileId}/Sync";

         return await PostRequestMultiple<T, IUpdateDerivedOutput>(resourceURI, request);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) dsdo:DerivedOutputs/{PID}/dsdo:DerivedOutputFiles/{ID}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Delete a Derived Output File Summary: Delete a Derived Output File
      // <param name="doId">
      // Description: dsdo:DerivedOutputs object ID
      // </param>
      // <param name="doFileId">
      // Description: dsdo:DerivedOutputFiles object ID
      // </param>
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IGenericResponse> RemoveFile(string doId, string doFileId)
      {
         string resourceURI = $"{GetBaseResource()}dsdo:DerivedOutputs/{doId}/dsdo:DerivedOutputFiles/{doFileId}";

         return await DeleteIndividual<IGenericResponse>(resourceURI);
      }
   }
}