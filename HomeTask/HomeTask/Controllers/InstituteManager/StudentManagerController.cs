using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Helpers;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers.InstituteManager
{
    [Authorize(Roles = RolesNames.InstituteAdministrator)]
    public class StudentManagerController : BaseController
    {
        private readonly IStudentManager _studentManager;
        private readonly IInstitutionManager _institutionManager;

        private object GetInstitutionID
        {
            get
            {
                return this._institutionManager.GetByUserID(this.CurrentUserID).Id;
            }
        }

        public StudentManagerController(IStudentManager studentManager, IInstitutionManager institutionManager)
        {
            this._studentManager = studentManager;
            this._institutionManager = institutionManager;
        }

        [ChildActionOnly]
        public ActionResult GetStudentsOfGroup(object groupID)
        {
            var students =
                this._studentManager.GetByGroudID(groupID).Select(x => string.Format("{0} {1}", x.Surname, x.Name));

            return PartialView("Partial/GetStudentsOfGroup",students);
        }

        [HttpGet]
        public ActionResult Index(StudentListViewModel viewModel)
        {
            viewModel.StudentList =
                this._studentManager
                    .GetByInstitute(this.HttpContext.Cache.GetInstitutionID())
                    .Select(StudentMapper.ToViewModelExpression.Compile())
                    .ToList();

            return View(viewModel);
        }

    }
}
