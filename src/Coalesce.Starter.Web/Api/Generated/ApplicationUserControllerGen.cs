    using IntelliTect.Coalesce.Controllers;
    using IntelliTect.Coalesce.Data;
    using IntelliTect.Coalesce.Mapping;
    using IntelliTect.Coalesce.Helpers.IncludeTree;
    using IntelliTect.Coalesce.Models;
    using IntelliTect.Coalesce.TypeDefinition;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Threading.Tasks;
    using Coalesce.Starter.Web.Models;
    using Coalesce.Starter.Data.Models;
    using Coalesce.Starter.Data;

namespace Coalesce.Starter.Web.Api
{
    [Route("api/[controller]")]
    [Authorize]
    public partial class ApplicationUserController
    : LocalBaseApiController<Coalesce.Starter.Data.Models.ApplicationUser, ApplicationUserDtoGen>
    {
        protected ClassViewModel Model;

        public ApplicationUserController()
        {
            Model = ReflectionRepository.Models.Single(m => m.Name == "ApplicationUser");
        }


        /// <summary>
        /// Returns ApplicationUserDtoGen
        /// </summary>
        [HttpGet("list")]
        [Authorize]
        public virtual async Task<GenericListResult<Coalesce.Starter.Data.Models.ApplicationUser, ApplicationUserDtoGen>> List(
            string includes = null,
            string orderBy = null, string orderByDescending = null,
            int? page = null, int? pageSize = null,
            string where = null,
            string listDataSource = null,
            string search = null,
            // Custom fields for this object.
            string applicationUserId = null,string name = null)
        {

            ListParameters parameters = new ListParameters(null, includes, orderBy, orderByDescending, page, pageSize, where, listDataSource, search);

            // Add custom filters
            parameters.AddFilter("ApplicationUserId", applicationUserId);
            parameters.AddFilter("Name", name);

            var listResult = await ListImplementation(parameters);
            return new GenericListResult<Coalesce.Starter.Data.Models.ApplicationUser, ApplicationUserDtoGen>(listResult);
        }

        /// <summary>
        /// Returns custom object based on supplied fields
        /// </summary>
        [HttpGet("customlist")]
        [Authorize]
        public virtual async Task<ListResult> CustomList(
            string fields = null,
            string includes = null,
            string orderBy = null, string orderByDescending = null,
            int? page = null, int? pageSize = null,
            string where = null,
            string listDataSource = null,
            string search = null,
            // Custom fields for this object.
            string applicationUserId = null,string name = null)
        {

            ListParameters parameters = new ListParameters(fields, includes, orderBy, orderByDescending, page, pageSize, where, listDataSource, search);

            // Add custom filters
            parameters.AddFilter("ApplicationUserId", applicationUserId);
            parameters.AddFilter("Name", name);

            return await ListImplementation(parameters);
        }

        [HttpGet("count")]
        [Authorize]
        public virtual async Task<int> Count(
            string where = null,
            string listDataSource = null,
            string search = null,
            // Custom fields for this object.
            string applicationUserId = null,string name = null)
        {

            ListParameters parameters = new ListParameters(where: where, listDataSource: listDataSource, search: search, fields: null);

            // Add custom filters
            parameters.AddFilter("ApplicationUserId", applicationUserId);
            parameters.AddFilter("Name", name);

            return await CountImplementation(parameters);
        }

        [HttpGet("propertyValues")]
        [Authorize]
        public virtual IEnumerable<string> PropertyValues(string property, int page = 1, string search = "")
        {

            return PropertyValuesImplementation(property, page, search);
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual async Task<ApplicationUserDtoGen> Get(string id, string includes = null, string dataSource = null)
        {

            ListParameters listParams = new ListParameters(includes: includes, listDataSource: dataSource);
            listParams.AddFilter("id", id);
            return await GetImplementation(id, listParams);
        }
        


        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual bool Delete(string id)
        {

            return DeleteImplementation(id);
        }
        

        [HttpPost("save")]
        [Authorize]
        public virtual async Task<SaveResult<ApplicationUserDtoGen>> Save(ApplicationUserDtoGen dto, string includes = null, string dataSource = null, bool returnObject = true)
        {

            if (!dto.ApplicationUserId.HasValue && !Model.SecurityInfo.IsCreateAllowed(User)) {
                var result = new SaveResult<ApplicationUserDtoGen>();
                result.WasSuccessful = false;
                result.Message = "Create not allowed on ApplicationUser objects.";
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return result;
            }
            else if (dto.ApplicationUserId.HasValue && !Model.SecurityInfo.IsEditAllowed(User)) {
                var result = new SaveResult<ApplicationUserDtoGen>();
                result.WasSuccessful = false;
                result.Message = "Edit not allowed on ApplicationUser objects.";
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return result;
            }

            return await SaveImplementation(dto, includes, dataSource, returnObject);
        }

        [HttpPost("AddToCollection")]
        [Authorize]
        public virtual SaveResult<ApplicationUserDtoGen> AddToCollection(int id, string propertyName, int childId)
        {
            return ChangeCollection(id, propertyName, childId, "Add");
        }
        [HttpPost("RemoveFromCollection")]
        [Authorize]
        public virtual SaveResult<ApplicationUserDtoGen> RemoveFromCollection(int id, string propertyName, int childId)
        {
            return ChangeCollection(id, propertyName, childId, "Remove");
        }
        
        /// <summary>
        /// Downloads CSV of ApplicationUserDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual async Task<FileResult> CsvDownload(
            string orderBy = null, string orderByDescending = null,
            int? page = 1, int? pageSize = 10000,
            string where = null,
            string listDataSource = null,
            string search = null,
            // Custom fields for this object.
            string applicationUserId = null,string name = null)
        {
            ListParameters parameters = new ListParameters(null, "none", orderBy, orderByDescending, page, pageSize, where, listDataSource, search);

            // Add custom filters
            parameters.AddFilter("ApplicationUserId", applicationUserId);
            parameters.AddFilter("Name", name);

            var listResult = await ListImplementation(parameters);
            var list = listResult.List.Cast<ApplicationUserDtoGen>();
            var csv = IntelliTect.Coalesce.Helpers.CsvHelper.CreateCsv(list);

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(csv);
            return File(bytes, "application/x-msdownload", "ApplicationUser.csv");
        }

        /// <summary>
        /// Returns CSV text of ApplicationUserDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual async Task<string> CsvText(
            string orderBy = null, string orderByDescending = null,
            int? page = 1, int? pageSize = 10000,
            string where = null,
            string listDataSource = null,
            string search = null,
            // Custom fields for this object.
            string applicationUserId = null,string name = null)
        {
            ListParameters parameters = new ListParameters(null, "none", orderBy, orderByDescending, page, pageSize, where, listDataSource, search);

            // Add custom filters
            parameters.AddFilter("ApplicationUserId", applicationUserId);
            parameters.AddFilter("Name", name);

            var listResult = await ListImplementation(parameters);
            var list = listResult.List.Cast<ApplicationUserDtoGen>();
            var csv = IntelliTect.Coalesce.Helpers.CsvHelper.CreateCsv(list);

            return csv;
        }

    

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("CsvUpload")]
        [Authorize]
        public virtual async Task<IEnumerable<SaveResult<ApplicationUserDtoGen>>> CsvUpload(Microsoft.AspNetCore.Http.IFormFile file, bool hasHeader = true) 
        {
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var reader = new System.IO.StreamReader(stream)) {
                        var csv = reader.ReadToEnd();
                        return await CsvSave(csv, hasHeader);
                    }
                }
            }
            throw new ArgumentException("No files uploaded");
        }

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("CsvSave")]
        [Authorize]
        public virtual async Task<IEnumerable<SaveResult<ApplicationUserDtoGen>>> CsvSave(string csv, bool hasHeader = true) 
        {
            // Get list from CSV
            var list = IntelliTect.Coalesce.Helpers.CsvHelper.ReadCsv<ApplicationUserDtoGen>(csv, hasHeader);
            var resultList = new List<SaveResult<ApplicationUserDtoGen>>();
            foreach (var dto in list){
                // Check if creates/edits aren't allowed
                if (!dto.ApplicationUserId.HasValue && !Model.SecurityInfo.IsCreateAllowed(User)) {
                    var result = new SaveResult<ApplicationUserDtoGen>();
                    result.WasSuccessful = false;
                    result.Message = "Create not allowed on ApplicationUser objects.";
                    Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    resultList.Add(result);
                }
                else if (dto.ApplicationUserId.HasValue && !Model.SecurityInfo.IsEditAllowed(User)) {
                    var result = new SaveResult<ApplicationUserDtoGen>();
                    result.WasSuccessful = false;
                    result.Message = "Edit not allowed on ApplicationUser objects.";
                    Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    resultList.Add(result);
                }
                else {
                    var result = await SaveImplementation(dto, "none", null, false);
                    resultList.Add(result);
                }
            }
            return resultList;
        }
        
        protected override IQueryable<Coalesce.Starter.Data.Models.ApplicationUser> GetListDataSource(ListParameters parameters)
        {

            return base.GetListDataSource(parameters);
        }

        // Methods from data class exposed through API Controller.
    }
}
