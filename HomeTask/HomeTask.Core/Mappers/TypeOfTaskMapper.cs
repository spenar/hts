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
    public static class TypeOfTaskMapper
    {
        public static Expression<Func<TypeOfTask, TypeOfTaskViewModel>> ToViewModelExpression = tot =>
                                                                                                new TypeOfTaskViewModel()
                                                                                                    {
                                                                                                        ID = tot.Id,
                                                                                                        Name = tot.Name
                                                                                                    };

        public static TypeOfTask ToModel(this TypeOfTaskViewModel viewModel)
        {
            var model = new TypeOfTask();
            model.InjectFrom(viewModel);

            return model;
        }
    }
}
