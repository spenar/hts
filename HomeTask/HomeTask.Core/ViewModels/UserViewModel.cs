using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class UserViewModel
    {
        public virtual Guid UserId { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
