using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Group : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public int QuantityOfPupils { get; set; }

        [ForeignKey("Institution")]
        public long InstitutionID { get; set; }

        public virtual Institution Institution { get; set; }
    }
}
