using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class StudentViewModel
    {
        public ulong ID { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Группа")]
        public string Group { get; set; }

        [Display(Name = "Подтвержден")]
        public bool IsConfirmed { get; set; }
    }
}
