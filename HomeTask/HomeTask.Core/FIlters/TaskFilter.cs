using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HomeTask.Models;


namespace HomeTask.Core.FIlters
{
    public class TaskFilter
    {
        public object GroupID { get; set; }

        public object TeacherID { get; set; }

        public object SubjectID { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public Expression<Func<Task, bool>> GroupFilter
        {
            get { return task => this.GroupID == null || task.GroupID == (long)this.GroupID; }
        }

        public Expression<Func<Task, bool>> TeacherFilter
        {
            get { return task => this.TeacherID == null || task.TeacherID == (long)this.TeacherID; }
        }

        public Expression<Func<Task, bool>> DateFilter
        {
            get { return task => this.GroupID == null || task.Date.Ticks > DateFrom.Value.Ticks && task.Date.Ticks < this.DateTo.Value.Ticks; }
        }

        public Expression<Func<Task, bool>> SubjectFilter
        {
            get { return task => this.SubjectID == null || task.SubjectID == (long) this.SubjectID; }
        }
    }
}
