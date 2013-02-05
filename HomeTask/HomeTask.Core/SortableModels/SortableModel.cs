using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask.Core.SortableModels
{
    public abstract class SortableModel<TEntity>
    {
        public string SortKey { get; set; }

        public bool SortAscending { get; set; }

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                if (this.Elements.Count > 0)
                {
                    var itemExcess = this.Elements.Count % this.PageSize;
                    int pageCount = itemExcess == 0 ? this.Elements.Count / PageSize : (this.Elements.Count / PageSize) + 1;
                    return pageCount;
                }

                return 1;
            }
        }

        public int CurrentPageIndex { get; set; }

        protected abstract IList<TEntity> Elements { get; }

        protected abstract IList<TEntity> SortedElements { get; }

        public virtual IList<TEntity> ElementsForPage
        {
            get { return SortedElements.Skip(this.CurrentPageIndex == 0 ? CurrentPageIndex : (CurrentPageIndex - 1) * PageSize).Take(PageSize).ToList(); }
        }
    }
}
