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
using ws3dx.project.program.data;

namespace ws3dx.project.program.core.service
{
   // SDK Service
   public class ProgramService : SearchService
   {
      private const string BASE_RESOURCE = "/resources/v1/modeler//";

      public ProgramService(string enoviaService, IPassportAuthentication passport) : base(enoviaService, passport)
      {
      }

      protected string GetBaseResource()
      {
         return BASE_RESOURCE;
      }

      #region SearchService overrides
      protected override string GetSearchResource()
      {
         return $"{GetBaseResource()}/programs/search";
      }

      protected override IEnumerable<Type> SearchConstraintTypes()
      {
         return new List<Type>() { };
      }

      protected override string GetSearchSkipParamName()
      {
         return "";
      }

      protected override string GetSearchTopParamName()
      {
         return "";
      }

      protected override string GetSearchCriteriaParamName()
      {
         return "searchStr";
      }
      #endregion
      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /programs/{programId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get a specific Program detail and related data.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseProgram> GetProgram(string programId)
      {
         string resourceURI = $"{GetBaseResource()}/programs/{programId}";

         return await GetUnique<IResponseProgram>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /programs
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get all users Programs.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseProgram> GetAllPrograms()
      {
         string resourceURI = $"{GetBaseResource()}/programs";

         return await GetUnique<IResponseProgram>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (GET) /programs/{programId}/projects
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Get a list of Projects associated to specific Program.
      // </summary>
      //---------------------------------------------------------------------------------------------		
      public async Task<IResponseProject> GetProgramProjects(string programId)
      {
         string resourceURI = $"{GetBaseResource()}/programs/{programId}/projects";

         return await GetUnique<IResponseProject>(resourceURI);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (POST) /programs
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Create Programs.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseProgram> CreateProgram(IPrograms programs)
      {
         string resourceURI = $"{GetBaseResource()}/programs";

         return await PostRequest<IResponseProgram, IPrograms>(resourceURI, programs);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /programs/{programId}/projects
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Add list of Projects associated to specific Program.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseProject> UpdateProgramProjects(string programId, IProjects projects)
      {
         string resourceURI = $"{GetBaseResource()}/programs/{programId}/projects";

         return await PutIndividual<IResponseProject, IProjects>(resourceURI, projects);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (PUT) /programs/{programId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Update a Program and its related data.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseProgram> UpdateProgram(string programId, IPrograms programs)
      {
         string resourceURI = $"{GetBaseResource()}/programs/{programId}";

         return await PutIndividual<IResponseProgram, IPrograms>(resourceURI, programs);
      }

      //---------------------------------------------------------------------------------------------
      // <remarks>
      // (DELETE) /programs/{programId}
      // </remarks>
      //---------------------------------------------------------------------------------------------
      // <summary>
      // Description: Summary: Delete the given Program if it does not contain Projects.
      // </summary>
      //---------------------------------------------------------------------------------------------
      public async Task<IResponseEmpty> DeleteProgram(string programId)
      {
         string resourceURI = $"{GetBaseResource()}/programs/{programId}";

         return await DeleteIndividual<IResponseEmpty>(resourceURI);
      }
   }
}