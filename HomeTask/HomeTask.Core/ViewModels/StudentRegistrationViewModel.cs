using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HomeTask.Core.ViewModels
{
    public class StudentRegistrationViewModel : UserViewModel
    {
        public ulong GroupID { get; set; }

        [Compare("Password")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Institutions { get; set; }
    }
}
