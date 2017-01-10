    using IntelliTect.Coalesce.Interfaces;
    using IntelliTect.Coalesce.Mapping;
    using IntelliTect.Coalesce.Models;
    using IntelliTect.Coalesce.Helpers.IncludeTree;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Coalesce.Starter.Web.Models;
    using Coalesce.Starter.Data.Models;

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
        public static ApplicationUserDtoGen Create(Coalesce.Starter.Data.Models.ApplicationUser obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null) {
            // Return null of the object is null;
            if (obj == null) return null;
                        
            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for ApplicationUser
            

            // Applicable excludes for ApplicationUser
            

            // Applicable roles for ApplicationUser
            if (user != null)
			{
			}



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj)) 
                return (ApplicationUserDtoGen)objects[obj];

            var newObject = new ApplicationUserDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.ApplicationUserId = obj.ApplicationUserId;
            newObject.Name = obj.Name;
            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public ApplicationUserDtoGen CreateInstance(Coalesce.Starter.Data.Models.ApplicationUser obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null) {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.Starter.Data.Models.ApplicationUser entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for ApplicationUser
            

            // Applicable excludes for ApplicationUser
            

            // Applicable roles for ApplicationUser
            if (user != null)
			{
			}

			entity.Name = Name;
        }

	}
}
