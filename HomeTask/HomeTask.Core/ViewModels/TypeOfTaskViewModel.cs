using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class TypeOfTaskViewModel
    {
        public ulong ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
