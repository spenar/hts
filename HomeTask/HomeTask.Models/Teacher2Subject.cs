using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HomeTask.Models
{
    public class Teacher2Subject
    {
        [Key]
        public ulong ID { get; set; }

        [Required]
        public ulong TeacherID { get; set; }

        [Required]
        public ulong SubjectID { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }
    }
}
