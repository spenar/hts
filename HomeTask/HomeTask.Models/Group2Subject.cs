using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Group2Subject :IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Group")]
        public long GroupID { get; set; }

        [ForeignKey("Subject")]
        public long SubjectID { get; set; }
       
        public virtual Group Group { get; set; }
        
        public virtual Subject Subject { get; set; }
    }
}
