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
    public class AdminGroupController : BaseController
    {
        private readonly IGroupManager _groupManager;
        private readonly IInstitutionManager _institutionManager;

        public AdminGroupController(IGroupManager groupManager, IInstitutionManager institutionManager)
        {
            this._groupManager = groupManager;
            this._institutionManager = institutionManager;
        }

        [HttpGet]
        public ActionResult Index(GroupListViewModel viewModel)
        {
            var institutionID = this._institutionManager.GetByUserID(this.CurrentUserID).ID;

            viewModel.GroupViewModels = this._groupManager
                                        .GetAll(institutionID)
                                        .Select(GroupMapper.ToViewModelExpression)
                                        .ToList();

            return View(viewModel);
        }
    }
}
