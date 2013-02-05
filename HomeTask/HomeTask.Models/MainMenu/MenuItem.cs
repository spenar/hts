using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HomeTask.Models.MainMenu
{
    using System.Collections.Generic;

    public class MenuItem
    {
        public MenuItem()
        {
            this.SubMenuItems = new List<MenuItem>();
        }

        public string Text { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public bool IsSelected { get; set; }

        public IList<MenuItem> SubMenuItems { get; set; }

        public bool HasSubMenu
        {
            get
            {
                return this.SubMenuItems.Count > 0;
            }
        }
    }
}
