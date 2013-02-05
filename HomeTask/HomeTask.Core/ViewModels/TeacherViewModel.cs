using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class TeacherViewModel
    {
        public ulong ID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Имя Отчество")]
        public string Name { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}
