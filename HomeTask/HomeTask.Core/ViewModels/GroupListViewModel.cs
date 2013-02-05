using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask.Core.ViewModels
{
    public class GroupListViewModel : SortableModels.SortableModel<GroupViewModel>
    {
        public GroupListViewModel()
        {
            GroupViewModels = new List<GroupViewModel>();
        }

        public IList<GroupViewModel> GroupViewModels { get; set; }

        protected override IList<GroupViewModel> Elements
        {
            get { return GroupViewModels; }
        }

        protected override IList<GroupViewModel> SortedElements
        {
            get
            {
                switch (this.SortKey)
                {
                    case "Name":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Name).ToList()
                                   : Elements.OrderBy(x => x.Name).ToList();

                    case "Specialty":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Specialty).ToList()
                                   : Elements.OrderBy(x => x.Specialty).ToList();

                    case "QuantityOfPupils":
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.QuantityOfPupils).ToList()
                                   : Elements.OrderBy(x => x.QuantityOfPupils).ToList();

                    default:
                        return this.SortAscending
                                   ? Elements.OrderByDescending(x => x.Name).ToList()
                                   : Elements.OrderBy(x => x.Name).ToList();
                }
            }
        }
    }
}
