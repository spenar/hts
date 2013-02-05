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
        public ulong ID { get; set; }

        public ulong InstitutionID { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey("InstitutionID")]
        public virtual Institution Institution { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
