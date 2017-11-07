using Coalesce.Starter.Data;
using Coalesce.Starter.Data.Models;
using Coalesce.Starter.Web.Models;
using IntelliTect.Coalesce.Helpers.IncludeTree;
using IntelliTect.Coalesce.Interfaces;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

using static Coalesce.Starter.Data.Models.ApplicationUser;

namespace Coalesce.Starter.Web.Models
{
    public partial class ApplicationUserDtoGen : GeneratedDto<Coalesce.Starter.Data.Models.ApplicationUser, ApplicationUserDtoGen>
        , IClassDto<Coalesce.Starter.Data.Models.ApplicationUser, ApplicationUserDtoGen>
    {
        public ApplicationUserDtoGen() { }

        public Int32? ApplicationUserId { get; set; }
        public System.String Name { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static ApplicationUserDtoGen Create(Coalesce.Starter.Data.Models.ApplicationUser obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return null;
            var includes = context.Includes;

            // Applicable includes for ApplicationUser


            // Applicable excludes for ApplicationUser


            // Applicable roles for ApplicationUser



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && context.TryGetMapping(obj, out ApplicationUserDtoGen existing)) return existing;

            var newObject = new ApplicationUserDtoGen();
            if (tree == null) context.AddMapping(obj, newObject);
            // Fill the properties of the object.
            newObject.ApplicationUserId = obj.ApplicationUserId;
            newObject.Name = obj.Name;
            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public ApplicationUserDtoGen CreateInstance(Coalesce.Starter.Data.Models.ApplicationUser obj, IMappingContext context, IncludeTree tree = null)
        {
            return Create(obj, context, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.Starter.Data.Models.ApplicationUser entity, IMappingContext context)
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
