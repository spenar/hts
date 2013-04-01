using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class TaskViewModel
    {

        public object ID { get; set; }

        [Display(Name = "Текст задания")]
        [Required(ErrorMessage = "Поле не можеть быть пустым")]
        public string Text { get; set; }

        [Display(Name = "Тема задания")]
        [Required(ErrorMessage = "Тема задания")]
        public string Title { get; set; }

        public string FileName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        public long TeacherID { get; set; }

        [Required]
        public string GroupID { get; set; }

        [Required]
        public long SubjectID { get; set; }
    }
}
