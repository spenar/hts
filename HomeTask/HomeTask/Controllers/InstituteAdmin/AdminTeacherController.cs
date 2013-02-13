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

namespace HomeTask.Controllers.InstituteAdmin
{
    [Authorize(Roles = RolesNames.InstituteAdministrator)]
    public class AdminTeacherController : BaseController
    {
        private readonly ITeacherManager _teacherManager;

        public AdminTeacherController(ITeacherManager teacherManager) : base()
        {
            this._teacherManager = teacherManager;
        }

        public ActionResult Index()
        {
            var viewModel = new TeacherListViewModel();
            viewModel.TeacherViewModels =
                this._teacherManager
                    .GetAll(Session.GetInstitutionID())
                    .Select(TeacherMapper.ToViewModelExpression.Compile())
                    .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.PartialView("")
        }

    }
}
