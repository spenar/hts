using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Core.ViewModels;
using HomeTask.Models;
using Omu.ValueInjecter;

namespace HomeTask.Core.Mappers
{
    public static class InstituteMapper
    {
        public static Func<Institution, InstitutionViewModel> ToViewModelExtension = institute =>
                                                                      new InstitutionViewModel()
                                                                          {
                                                                              Accreditation = institute.Accreditation,
                                                                              Address = institute.Address,
                                                                              City = institute.City,
                                                                              Country = institute.Country,
                                                                              Director = institute.Director,
                                                                              Id = institute.Id,
                                                                              Name = institute.Name
                                                                          };

        public static Institution ToModel(this InstitutionViewModel viewModel)
        {
            var model = new Institution();
            model.InjectFrom(viewModel);

            return model;
        }

        public static InstitutionViewModel ToViewModel(this Institution model)
        {
            var viewModel = new InstitutionViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }
    }
}
