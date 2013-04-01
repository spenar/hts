using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class InstitutionViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Директор")]
        public string Director { get; set; }

        [Display(Name = "Акредитация")]
        public string Accreditation { get; set; }
    }
}
