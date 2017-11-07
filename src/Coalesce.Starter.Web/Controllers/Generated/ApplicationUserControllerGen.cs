﻿using Coalesce.Starter.Data;
using Coalesce.Starter.Data.Models;
using Coalesce.Starter.Web;
using IntelliTect.Coalesce.Knockout.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coalesce.Starter.Web.Controllers
{
    [Authorize]
    public partial class ApplicationUserController
        : BaseViewController<Coalesce.Starter.Data.Models.ApplicationUser, AppDbContext>
    {
        public ApplicationUserController() : base() { }

        [Authorize]
        public ActionResult Cards()
        {
            return IndexImplementation(false, @"~/Views/Generated/ApplicationUser/Cards.cshtml");
        }

        [Authorize]
        public ActionResult Table()
        {
            return IndexImplementation(false, @"~/Views/Generated/ApplicationUser/Table.cshtml");
        }


        [Authorize]
        public ActionResult TableEdit()
        {
            return IndexImplementation(true, @"~/Views/Generated/ApplicationUser/Table.cshtml");
        }

        [Authorize]
        public ActionResult CreateEdit()
        {
            return CreateEditImplementation(@"~/Views/Generated/ApplicationUser/CreateEdit.cshtml");
        }

        [Authorize]
        public ActionResult EditorHtml(bool simple = false)
        {
            return EditorHtmlImplementation(simple);
        }

        [Authorize]
        public ActionResult Docs()
        {
            return DocsImplementation();
        }
    }
}