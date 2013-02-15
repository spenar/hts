﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Subject : IEntity
    {
        [Key]
        public ulong ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
