using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class SubjectViewModel
    {
        public object ID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Name { get; set; }

        public TeacherListViewModel Teachers { get; set; } 
    }
}
