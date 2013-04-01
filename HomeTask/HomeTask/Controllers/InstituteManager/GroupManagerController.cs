using System;
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
    public class GroupManagerController : BaseController
    {
        private readonly IGroupManager _groupManager;
        private readonly IInstitutionManager _institutionManager;

        private object GetInstitutionID
        {
            get
            {
                return this._institutionManager.GetByUserID(this.CurrentUserID).Id;
            }
        }

        public GroupManagerController(IGroupManager groupManager, IInstitutionManager institutionManager)
        {
            this._groupManager = groupManager;
            this._institutionManager = institutionManager;
        }

        [HttpGet]
        public ActionResult Index(GroupListViewModel viewModel)
        {

            viewModel.GroupViewModels = this._groupManager
                                            .GetAll(this.GetInstitutionID)
                                            .Select(GroupMapper.ToViewModelExpression)
                                            .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddGroup()
        {
            return this.PartialView("Partial/AddGroup");
        }

        [HttpPost]
        public ActionResult AddGroup(GroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ToModel();
                this._groupManager.Add(model, this.GetInstitutionID);

                return this.Json(new { success = true });
            }
            return this.Json(new {success = false});
        }

    }
}
