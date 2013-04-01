using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Institution : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Director { get; set; }

        public string Accreditation { get; set; }
    }
}
