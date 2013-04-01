﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers.InstituteManager
{
    [Authorize(Roles = RolesNames.InstituteAdministrator)]
    public class SubjectManagerController : BaseController
    {
        private readonly ISubjectManager _subjectManager;
        private readonly IInstitutionManager _institutionManager;

        private object GetInstitutionID
        {
            get
            {
                return this._institutionManager.GetByUserID(this.CurrentUserID).Id;
            }
        }

        public SubjectManagerController(ISubjectManager subjectManager, IInstitutionManager institutionManager):base()
        {
            this._subjectManager = subjectManager;
            this._institutionManager = institutionManager;
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

        [HttpGet]
        public ActionResult SubjectEditPage(ulong groupID)
        {
            if (Request.IsAjaxRequest())
            {
                var viewModel = new SubjectEditPageViewModel();
                viewModel.InstituteSubjectsList = this._subjectManager
                                                      .GetByGroup(groupID)
                                                      .Select(x => new SelectListItem()
                                                          {
                                                              Value = x.Id.ToString(),
                                                              Text = x.Name
                                                          });

                viewModel.SubjectViewModels =
                    this._subjectManager.GetByGroup(groupID)
                        .Select(SubjectMapper.ToViewModelExpression.Compile())
                        .ToList();

                return this.PartialView("Partial/EditSubjectOfGroup", viewModel);
            }

            return this.RedirectToAction("Index", "Home");
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
