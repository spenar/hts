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
    public class TeacherManagerController : BaseController
    {
        private readonly ITeacherManager _teacherManager;

        public TeacherManagerController(ITeacherManager teacherManager) : base()
        {
            this._teacherManager = teacherManager;
        }

        public ActionResult Index()
        {
            var viewModel = new TeacherListViewModel();
            viewModel.TeacherViewModels =
                this._teacherManager
                    .GetAll(this.HttpContext.Cache.GetInstitutionID())
                    .Select(TeacherMapper.ToViewModelExpression.Compile())
                    .ToList();

            return View(viewModel);
        }
    }
}
