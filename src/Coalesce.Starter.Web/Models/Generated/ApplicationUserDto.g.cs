
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace Coalesce.Starter.Web.Models
{
    public partial class ApplicationUserDtoGen : GeneratedDto<Coalesce.Starter.Data.Models.ApplicationUser>
    {
        public ApplicationUserDtoGen() { }

        public int? ApplicationUserId { get; set; }
        public string Name { get; set; }

        public override void MapFrom(Coalesce.Starter.Data.Models.ApplicationUser obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Applicable includes for ApplicationUser


            // Applicable excludes for ApplicationUser


            // Applicable roles for ApplicationUser


            // Fill the properties of the object.
            this.ApplicationUserId = obj.ApplicationUserId;
            this.Name = obj.Name;
        }

        // Updates an object from the database to the state handed in by the DTO.
        public override void MapTo(Coalesce.Starter.Data.Models.ApplicationUser entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            // Applicable includes for ApplicationUser


            // Applicable excludes for ApplicationUser


            // Applicable roles for ApplicationUser


            entity.Name = Name;
        }

    }
}
