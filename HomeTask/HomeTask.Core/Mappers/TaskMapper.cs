using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HomeTask.Core.ViewModels;
using HomeTask.Models;
using Omu.ValueInjecter;

namespace HomeTask.Core.Mappers
{
    public static class TaskMapper
    {
        public static Expression<Func<Task, TaskViewModel>> ToViewModelExpression = task =>
                                                                                    new TaskViewModel()
                                                                                        {
                                                                                            Date = task.Date,
                                                                                            FileName = task.FileName,
                                                                                            GroupID = task.GroupID,
                                                                                            ID = task.ID,
                                                                                            SubjectID = task.SubjectID,
                                                                                            TeacherID = task.TeacherID,
                                                                                            Text = task.Text,
                                                                                            Title = task.Title,
                                                                                            TypeID = task.TypeID
                                                                                        };

        public static TaskViewModel ToViewModel(this Task model)
        {
            var viewModel = new TaskViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }

        public static Task ToModel(this TaskViewModel viewModel)
        {
            var task = new Task();
            task.InjectFrom(viewModel);

            return task;
        }
    }
}
