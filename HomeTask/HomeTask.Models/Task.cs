using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Task : IEntity
    {
        [Key]
        public ulong ID { get; set; }

        [Required]
        public string Text { get; set; }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        public ulong TypeID { get; set; }

        public ulong TeacherID { get; set; }

        public ulong GroupID { get; set; }

        public ulong SubjectID { get; set; }

        [ForeignKey("TypeID")]
        public TypeOfTask Type { get; set; }

        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }

        [ForeignKey("GroupID")]
        public Group Group { get; set; }

        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
    }
}
