using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class TaskListViewModel
    {
        public TaskListViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
            this.Types = new List<TypeOfTaskViewModel>();
            this.GroupSubjects = new List<SubjectViewModel>();
        }

        public ulong GroupID { get; set; }

        public ulong SubjectID { get; set; }

        public IEnumerable<SubjectViewModel> GroupSubjects { get; set; }

        public IEnumerable<TypeOfTaskViewModel> Types { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; } 
    }
}
