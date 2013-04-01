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
    public static class TeacherMapper
    {
        public static Expression<Func<Teacher, TeacherViewModel>> ToViewModelExpression = teacher =>
                                                                                          new TeacherViewModel()
                                                                                              {
                                                                                                  Name = teacher.Name,
                                                                                                  Surname = teacher.Surname,
                                                                                                  ID = teacher.Id
                                                                                              };

        public static TeacherViewModel ToViewModel(this Teacher model)
        {
            var viewModel = new TeacherViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }

        public static Teacher ToModel(this TeacherViewModel viewModel)
        {
            var model = new Teacher();
            model.InjectFrom(viewModel);

            return model;
        }
    }
}
