using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomeTask.Managers.Contracts;
using HomeTask.Models.MainMenu;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers
{
    public class MainMenuController : BaseController
    {
        private readonly ISubjectManager _subjectManager;
        private readonly IStudentManager _studentManager;

        public MainMenuController(ISubjectManager subjectManager, IStudentManager studentManager)
        {
            this._subjectManager = subjectManager;
            this._studentManager = studentManager;
        }

        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            List<MenuItem> menu = new List<MenuItem>();

            //Menu for students
            if (Roles.IsUserInRole(RolesNames.Student))
            {
                menu = new List<MenuItem>()
                    {
                        new MenuItem() {Action = "Index", Controller = "Home", Text = "Главная"},
                        new MenuItem()
                            {
                                Text = "Предметы",
                                SubMenuItems = _subjectManager
                                .GetByGroup(_studentManager.GetByUserID(this.CurrentUserID).GroupID)
                                .ToList()
                                .Select(x => new MenuItem(){ Action = "Index/" + x.ID, Controller = "Task", Text = x.Name})
                                .ToList()
                            }
                    };
            } 
            

            //Menu for teachers
            if (Roles.IsUserInRole(RolesNames.Teacher))
            {
                menu = new List<MenuItem>()
                    {
                        new MenuItem() {Action = "Index", Controller = "Home", Text = "Главная"},
                        new MenuItem() {Action = "Index", Controller = "Group", Text = "Группы"},
                        new MenuItem() {Action = "Index", Controller = "Subjects", Text = "Предметы"}
                    };
            }


            //Menu for institute administrator
            if (Roles.IsUserInRole(RolesNames.InstituteAdministrator))
            {
                menu = new List<MenuItem>()
                    {
                        new MenuItem() {Action = "Index", Controller = "Home", Text = "Главная"},
                        new MenuItem() {Action = "Index", Controller = "AdminGroup", Text = "Группы"},
                        new MenuItem() {Action = "Index", Controller = "AdminTeacher", Text = "Преподаватели"},
                        new MenuItem() {Action = "Index", Controller = "AdminSubject", Text = "Предметы"},
                        new MenuItem() {Action = "Index", Controller = "AdminStudent", Text = "Студенты"}
                    };
            }


            //Menu for super admin
            if (Roles.IsUserInRole(RolesNames.SuperAdmin))
            {
                menu = new List<MenuItem>()
                    {
                        new MenuItem() {Action = "Institutes", Controller = "AdminInsitutes", Text = "Учебные заведения"},
                    };

            }

            var controller = this.ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            foreach (var item in menu)
            {
                item.IsSelected = item.Controller == controller;
            }

            return this.PartialView("Partial/MainMenu", menu);
        }
    }
}
