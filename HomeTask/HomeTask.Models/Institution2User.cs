using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Institution2User :IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Institution")]
        public long InstitutionID { get; set; }

         [ForeignKey("User")]
        public Guid UserID { get; set; }
       
        public virtual Institution Institution { get; set; }
       
        public virtual User User { get; set; }
    }
}
