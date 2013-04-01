using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class TypeOfTask : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
