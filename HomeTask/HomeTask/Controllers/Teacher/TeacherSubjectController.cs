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

namespace HomeTask.Controllers.Teacher
{
    [Authorize(Roles = RolesNames.Teacher)]
    public class TeacherSubjectController : Controller
    {
        private readonly ISubjectManager _subjectManager;

        public TeacherSubjectController(ISubjectManager subjectManager)
        {
            this._subjectManager = subjectManager;
        }

        public ActionResult Index(TeacherSubjectListViewModel viewModel)
        {
            viewModel.SubjectViewModels =
                this._subjectManager.GetByTeacher(Session.GetTeacherID())
                    .Select(SubjectMapper.ToViewModelExpression.Compile())
                    .ToList();
            viewModel.TeacherID = (ulong)Session.GetTeacherID();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add(ulong teacherID)
        {
            return View()
        }
    }
}
