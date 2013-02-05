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
    public class AdminStudentController : BaseController
    {
        private readonly IStudentManager _studentManager;

        public AdminStudentController(IStudentManager studentManager)
        {
            this._studentManager = studentManager;
        }

        [ChildActionOnly]
        public ActionResult GetStudentsOfGroup(object groupID)
        {
            var students =
                this._studentManager.GetByGroudID(groupID).Select(x => string.Format("{0} {1}", x.Surname, x.Name));

            return PartialView("Partial/GetStudentsOfGroup",students);
        }

    }
}
