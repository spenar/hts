﻿using System;
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

        public ActionResult Index(SubjectListViewModel viewModel)
        {
            viewModel.SubjectViewModels =
                this._subjectManager.GetByTeacher(this.HttpContext.Cache.GetTeacherID())
                    .Select(SubjectMapper.ToViewModelExpression.Compile())
                    .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.PartialView("Partial/Add");
        }

        [HttpPost]
        public ActionResult Add(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacherID = this.HttpContext.Cache.GetTeacherID();
                if (teacherID != null)
                {
                    var subject = model.ToModel();
                    this._subjectManager.AddSubjectForTeacher(subject, teacherID);

                    return this.Json(new { success = true });
                }

                return HttpNotFound();
            }

            return this.Json(new {success = false});
        }

        [HttpGet]
        public ActionResult DeleteSubject2Teacher(long subjectID)
        {
            return this.PartialView("Partial/Delete", subjectID);
        }

        [HttpPost]
        public ActionResult Delete(long subjectID)
        {
            this._subjectManager.DeleteSubject2Teacher(subjectID, this.HttpContext.Cache.GetTeacherID());
            return this.Json(new {success = true});
        }
    }
}
