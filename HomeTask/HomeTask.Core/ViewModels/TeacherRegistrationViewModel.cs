using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HomeTask.Core.ViewModels
{
    public class TeacherRegistrationViewModel : UserViewModel
    {
        public TeacherRegistrationViewModel()
        {
            this.Institutions = new List<SelectListItem>();
        }

        [Compare("Password")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        public ulong InstitutionID { get; set; }

        public IEnumerable<SelectListItem> Institutions { get; set; }
    }
}
