using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;

namespace HomeTask.Controllers.Administrator
{
    public class AdministratorInstitutesController : Controller
    {
        private readonly IInstitutionManager _institutionManager;

        public AdministratorInstitutesController(IInstitutionManager institutionManager)
        {
            this._institutionManager = institutionManager;
        }

        public ActionResult Index()
        {
            var viewModel = this._institutionManager.GetAll().Select(InstituteMapper.ToViewModel);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.PartialView("Partial/Add");
        }

        [HttpPost]
        public ActionResult Add(InstitutionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ToModel();
                this._institutionManager.Add(model);
                return this.Json(new { success = true });
            }
            return this.Json(new { success = false });
        }

        [HttpGet]
        public ActionResult Edit(long instituteId)
        {
            var institute = this._institutionManager.Get(instituteId);
            if (institute == null)
            {
                this.HttpNotFound();
            }

            return this.PartialView("Partial/Edit",institute.ToViewModel());
        }

        public ActionResult Edit(InstitutionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = viewModel.ToModel();
                this._institutionManager.Update(model);
                return this.Json(new { success = true });
            }
            return this.Json(new { success = false });
        }

    }
}
