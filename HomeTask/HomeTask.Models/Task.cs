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
        public long Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Type")]
        public long TypeID { get; set; }

        [ForeignKey("Teacher")]
        public long TeacherID { get; set; }

        [ForeignKey("Group")]
        public long GroupID { get; set; }

        [ForeignKey("Subject")]
        public long SubjectID { get; set; }
      
        public virtual TypeOfTask Type { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Group Group { get; set; }
      
        public virtual Subject Subject { get; set; }
    }
}
