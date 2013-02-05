using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;

namespace HomeTask.Models
{
    public class Student : IEntity
    {
        [Key]
        public ulong ID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public ulong GroupID { get; set; }

        public Guid UserID { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
