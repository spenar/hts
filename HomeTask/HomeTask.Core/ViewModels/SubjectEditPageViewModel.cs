using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HomeTask.Models;

namespace HomeTask.Core.ViewModels
{
    public class SubjectEditPageViewModel : SubjectListViewModel
    {
        public IEnumerable<SelectListItem> InstituteSubjectsList { get; set; }
    }
}
