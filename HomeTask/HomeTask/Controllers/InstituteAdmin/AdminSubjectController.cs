using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
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

        [HttpGet]
        public ActionResult GetSubjectForGroup(ulong groupID)
        {
            if (Request.IsAjaxRequest())
            {
                var viewModel = new SubjectListViewModel();
                viewModel.SubjectViewModels =
                    this._subjectManager.GetByGroup(groupID).Select(SubjectMapper.ToViewModelExpression).ToList();

                return PartialView("Partial/GetSubjectOfGroup", viewModel);
            }
            return RedirectToAction("Index", "AdminGroup");
        }

        [HttpPost]
        public ActionResult AddSubjectForGroup(SubjectEditPageViewModel viewModel, ulong groupID)
        {
            var subjects = viewModel.SubjectViewModels.Select(SubjectMapper.ToModelExpression.Compile());
            this._subjectManager.AddSubjectForGroup(subjects, groupID);

            return this.Json(new {success = true});
        }


    }
}
