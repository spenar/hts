using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Group2Teacher : IEntity
    {
        [Key]
        public ulong ID { get; set; }

        public ulong GroupID { get; set; }

        public ulong TeacherID { get; set; }

        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}
