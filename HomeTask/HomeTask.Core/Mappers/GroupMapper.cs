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
    public static class GroupMapper
    {
        public static Expression<Func<Group, GroupViewModel>> ToViewModelExpression = group =>
                                                                                      new GroupViewModel()
                                                                                          {
                                                                                              ID = group.Id,
                                                                                              Name = group.Name,
                                                                                              QuantityOfPupils = group.QuantityOfPupils,
                                                                                              Specialty = group.Specialty
                                                                                          };

        public static GroupViewModel ToViewModel(this Group model)
        {
            var viewModel = new GroupViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }

        public static Group ToModel(this GroupViewModel viewModel)
        {
            var model = new Group();
            model.InjectFrom(viewModel);

            return model;
        }
    }
}
