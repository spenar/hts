using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Student : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public bool IsConfirmed { get; set; }

        [ForeignKey("Group")]
        public long GroupID { get; set; }

        public Guid UserID { get; set; }
       
        public virtual Group Group { get; set; }
    }
}
