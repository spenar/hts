﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HomeTask.Core.ViewModels;
using HomeTask.Models;
using Omu.ValueInjecter;

namespace HomeTask.Core.Mappers
{
    public static class SubjectMapper
    {
        public static Expression<Func<Subject, SubjectViewModel>> ToViewModelExpression = subject =>
                                                                                          new SubjectViewModel()
                                                                                              {
                                                                                                  ID = subject.ID,
                                                                                                  Name = subject.Name
                                                                                              };

        public static SubjectViewModel ToViewModel(this Subject model)
        {
            var viewModel = new SubjectViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }

        public static Subject ToModel(this Subject viewModel)
        {
            var model = new Subject();
            model.InjectFrom(viewModel);

            return model;
        }
    }
}
