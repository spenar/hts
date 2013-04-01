using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.FIlters;
using HomeTask.Core.Helpers;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Models.MainMenu;
using HomeTask.Models.Roles;

namespace HomeTask.Controllers.Teacher
{
    [Authorize(Roles = RolesNames.Teacher)]
    public class TeacherTaskController : BaseController
    {
        private readonly ITaskManager _taskManager;
        private readonly ISubjectManager _subjectManager;
        private readonly ITypeOfTaskManager _typeOfTaskManager;
        private readonly IGroupManager _groupManager;

        public TeacherTaskController(ITaskManager taskManager, ISubjectManager subjectManager, ITypeOfTaskManager typeOfTaskManager, IGroupManager groupManager)
        {
            this._taskManager = taskManager;
            this._subjectManager = subjectManager;
            this._typeOfTaskManager = typeOfTaskManager;
            this._groupManager = groupManager;
        }

        public ActionResult Index(TaskFilter filter)
        {
            var viewModel = new TaskListViewModel();
            viewModel.GroupID = (long?)filter.GroupID ?? 0;
            viewModel.SubjectID = (long?)filter.SubjectID ?? 0;
            viewModel.GroupSubjects = this._subjectManager
                                          .GetByGroup(filter.GroupID)
                                          .Select(SubjectMapper.ToViewModelExpression.Compile());

            filter.TeacherID = this.HttpContext.Cache.GetTeacherID();

            var tasks = this._taskManager.GetByFilter(filter);
            var identifiers = tasks.Select(x => x.TypeID);
            viewModel.Types = this._typeOfTaskManager.GetByIdentifiers(identifiers).Select(TypeOfTaskMapper.ToViewModelExpression);
            viewModel.Tasks = tasks.Select(TaskMapper.ToViewModelExpression);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddTask()
        {
            return PartialView("Partial/AddTask");
        }

        [HttpPost]
        public ActionResult AddTask(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var typeOftask = this._typeOfTaskManager.GetByName(viewModel.TypeName);
                if (typeOftask == null)
                {
                    typeOftask = new TypeOfTask()
                        {
                            Name = viewModel.TypeName
                        };

                    this._typeOfTaskManager.Add(typeOftask);
                }
                var task = viewModel.ToModel();
                task.TypeID = typeOftask.Id;
                this._taskManager.Add(task);
            }

            return this.Json(new {success = false});
        }


        public ActionResult Groups(ulong selectedgroup)
        {
            var groups = this._groupManager.GetAll(this.HttpContext.Cache.GetInstitutionID());
            return PartialView("Partial/GroupsList", groups);
        }
    }
}
