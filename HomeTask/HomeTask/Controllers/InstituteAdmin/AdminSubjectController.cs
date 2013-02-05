using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Managers.Contracts;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers.InstituteAdmin
{
    [Authorize(Roles = RolesNames.InstituteAdministrator)]
    public class AdminSubjectController : Controller
    {
        private readonly ISubjectManager _subjectManager;

        public AdminSubjectController(ISubjectManager subjectManager)
        {
            this._subjectManager = subjectManager;
        }

        [ChildActionOnly]
        public ActionResult GetSubjectOfGroup(int groupID)
        {
            var subjects = this._subjectManager.GetByGroup(groupID).Select(x => x.Name);

            return PartialView("Partial/GetSubjectOfGroup",subjects);
        }

    }
}
