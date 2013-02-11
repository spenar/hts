using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class StudentListViewModel : SortableModels.SortableModel<StudentViewModel>
    {
        public IList<StudentViewModel> StudentList { get; set; }

        protected override IList<StudentViewModel> Elements
        {
            get { return StudentList; }
        }

        protected override IList<StudentViewModel> SortedElements
        {
            get
            {
                switch (this.SortKey)
                {
                    case "Surname":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Surname).ToList()
                                   : Elements.OrderBy(x => x.Surname).ToList();
                    case "Name":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Name).ToList()
                                   : Elements.OrderBy(x => x.Name).ToList();
                    case "Group":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Group).ToList()
                                   : Elements.OrderBy(x => x.Group).ToList();
                    case "IsConfirmed":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.IsConfirmed).ToList()
                                   : Elements.OrderBy(x => x.IsConfirmed).ToList();
                }
            }
        }
    }
}
