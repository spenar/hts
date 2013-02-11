using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;
using HomeTask.Models;

namespace HomeTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudentManager _studentManager;
        private readonly IInstitutionManager _institutionManager;

        public AccountController(IStudentManager studentManager, IInstitutionManager institutionManager)
        {
            this._studentManager = studentManager;
            this._institutionManager = institutionManager;
        }

        [HttpGet]
        public ActionResult LogOn(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(UserViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = WebSecurity.Login(viewModel.Username, viewModel.Password);
                if (isSuccess)
                {

                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("Login error!", "Неверный логин или пароль");
                return View(viewModel);
            }
            
            return View(viewModel);
        }

          public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var viewModel = new StudentRegistrationViewModel();
            viewModel.Institutions = this._institutionManager.GetAll().Select(x => new SelectListItem()
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                });

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(StudentRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var status = WebSecurity.Register(viewModel.Username, viewModel.Password, viewModel.Email, true, viewModel.FirstName,
                                     viewModel.LastName);
                if (status == MembershipCreateStatus.Success)
                {
                    this._studentManager.Add(new Student()
                        {
                            Name = viewModel.LastName,
                            GroupID = viewModel.GroupID,
                            IsConfirmed = false,
                            Surname = viewModel.FirstName,
                            InstitutionID = viewModel.InstitutionID,
                            UserID = WebSecurity.GetUserId(viewModel.Username)
                        });

                    return this.RedirectToLocal(@Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("Register error!", "Register error please contact our support team!");
                    return this.View(viewModel);
                }
            }

            return View(viewModel);
        }



        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }


    }
}
