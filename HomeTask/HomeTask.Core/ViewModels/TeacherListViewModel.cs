using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Core.SortableModels;

namespace HomeTask.Core.ViewModels
{
    public class TeacherListViewModel : SortableModel<TeacherViewModel>
    {
        public TeacherListViewModel()
        {
            this.TeacherViewModels = new List<TeacherViewModel>();
        }

        public IList<TeacherViewModel> TeacherViewModels { get; set; }

        protected override IList<TeacherViewModel> Elements
        {
            get { return this.TeacherViewModels; }
        }

        protected override IList<TeacherViewModel> SortedElements
        {
            get
            {
                switch (this.SortKey)
                {
                    case "Name":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Name).ToList()
                                   : Elements.OrderBy(x => x.Name).ToList();

                    case "Surname":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Surname).ToList()
                                   : Elements.OrderBy(x => x.Surname).ToList();

                    default:
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Surname).ToList()
                                   : Elements.OrderBy(x => x.Surname).ToList();
                }
            }
        }
    }
}
