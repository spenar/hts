using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Teacher : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsConfirmed { get; set; }

        public Guid UserID { get; set; }

        public virtual ICollection<Teacher2Subject> Subjects { get; set; }
        
        [Required]
        public virtual Institution Institution { get; set; }

    }
}
