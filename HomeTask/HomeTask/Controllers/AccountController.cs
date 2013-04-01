using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomeTask.Core.Helpers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudentManager _studentManager;
        private readonly IInstitutionManager _institutionManager;
        private readonly ITeacherManager _teacherManager;

        public AccountController(IStudentManager studentManager, IInstitutionManager institutionManager, ITeacherManager teacherManager)
        {
            this._studentManager = studentManager;
            this._institutionManager = institutionManager;
            this._teacherManager = teacherManager;
        }

        [HttpGet]
        public ActionResult LogOn(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;

            return PartialView("Partial/LogOn");
        }

        [HttpPost]
        public ActionResult LogOn(LoginViewModel viewModel, string returnUrl)
        {
            var status = WebSecurity.Register("admin", "123456", "iamspenar@gmail.com", true, "Андрей",
                                    "Зинченко");

            if (status == MembershipCreateStatus.Success)
            {
                var useraId = WebSecurity.GetUserId("admin");
                Roles.AddUserToRole("admin", RolesNames.InstituteAdministrator);
                this.HttpContext.Cache.SetUserID(useraId);
            }
            if (ModelState.IsValid)
            {
                var isSuccess = WebSecurity.Login(viewModel.Username, viewModel.Password);
                if (isSuccess)
                {
                    

                    var userID = WebSecurity.GetUserId(viewModel.Username);
                    this.HttpContext.Cache.SetUserID(userID);
                    InitializeCache();
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("Login error!", "Неверный логин или пароль");
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SelectOfRole()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentRegistration()
        {
            var viewModel = new StudentRegistrationViewModel();
            viewModel.Institutions = this._institutionManager.GetAll().ToList().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return View("Registrations/StudentRegistration",viewModel);
        }

        [HttpPost]
        public ActionResult StudentRegistration(StudentRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var status = WebSecurity.Register(viewModel.Username, viewModel.Password, viewModel.Email, true, viewModel.FirstName,
                                     viewModel.LastName);
                
                if (status == MembershipCreateStatus.Success)
                {
                    var userID = WebSecurity.GetUserId(viewModel.Username);
                    Roles.AddUserToRole(viewModel.Username, RolesNames.Student);
                    this._studentManager.Add(new Student()
                        {
                            Name = viewModel.LastName,
                            GroupID = viewModel.GroupID,
                            IsConfirmed = false,
                            Surname = viewModel.FirstName,
                            UserID = userID
                        });
                    this._institutionManager.AddInstitution2User(viewModel.InstitutionID, userID);
                    this.HttpContext.Cache.SetUserID(userID);

                    return this.RedirectToLocal(Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("Register error!", "Register error please contact our support team!");
                    viewModel.Institutions = this._institutionManager.GetAll().Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    });
                    return this.View("Registrations/StudentRegistration",viewModel);
                }
            }

            viewModel.Institutions = this._institutionManager.GetAll().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return View("Registrations/StudentRegistration", viewModel);
        }


        [HttpGet]
        public ActionResult TeacherRegistration()
        {
            var viewModel = new TeacherRegistrationViewModel();
            viewModel.Institutions = this._institutionManager.GetAll().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View("Registrations/TeacherRegistration", viewModel);
        }

        public ActionResult TeacherRegistration(TeacherRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var status = WebSecurity.Register(viewModel.Username, viewModel.Password, viewModel.Email, true,
                                                  viewModel.FirstName,
                                                  viewModel.LastName);
                if (status == MembershipCreateStatus.Success)
                {
                    var userID = WebSecurity.GetUserId(viewModel.Username);
                    Roles.AddUserToRole(viewModel.Username, RolesNames.Teacher);

                    this._teacherManager.Add(new Models.Teacher()
                        {
                            Name = viewModel.LastName,
                            IsConfirmed = false,
                            Surname = viewModel.FirstName,
                            UserID = userID
                        });

                    this._institutionManager.AddInstitution2User(viewModel.InstitutionID, userID);
                    this.HttpContext.Cache.SetUserID(userID);
                    return this.RedirectToLocal(Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("Register error!", "Register error please contact our support team!");
                    viewModel.Institutions = this._institutionManager.GetAll().Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });

                    return this.View("Registrations/TeacherRegistration", viewModel);
                }
            }

            return this.View("Registrations/TeacherRegistration", viewModel);
        }




        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }

        private void InitializeCache()
        {
            var userName = this.User.Identity.Name;
            var institutionID = this._institutionManager.GetByUserID(this.HttpContext.Cache.GetUserID());
            this.HttpContext.Cache.SetInstitutionID(institutionID);
         
            if (Roles.IsUserInRole(userName, RolesNames.Student))
            {
                var student = this._studentManager.GetByUserID(this.HttpContext.Cache.GetUserID());
                this.HttpContext.Cache.SetStudentID(student.Id);

            }
            else if (Roles.IsUserInRole(RolesNames.Teacher))
            {
                var teacher = this._teacherManager.GetUserId(this.HttpContext.Cache.GetUserID());
                this.HttpContext.Cache.SetTeacherID(teacher.Id);
            }
        }
    }
}
