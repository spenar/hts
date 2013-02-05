using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Core.SortableModels;

namespace HomeTask.Core.ViewModels
{
    public class SubjectListViewModel  : SortableModel<SubjectViewModel>
    {
        public SubjectListViewModel()
        {
            this.SubjectViewModels = new List<SubjectViewModel>();
        }

        public IList<SubjectViewModel> SubjectViewModels { get; set; } 

        protected override IList<SubjectViewModel> Elements
        {
            get { return this.SubjectViewModels; }
        }

        protected override IList<SubjectViewModel> SortedElements
        {
            get
            {
                switch (this.SortKey)
                {
                    default: return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Name).ToList()
                                   : Elements.OrderBy(x => x.Name).ToList();
                }
            }
        }
    }
}
