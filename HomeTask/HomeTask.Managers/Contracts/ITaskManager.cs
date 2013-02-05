using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Core.FIlters;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface ITaskManager
    {
        Task GetById(object ID);

        IQueryable<Task> GetByFilter(TaskFilter filter);

        void Add(Task task, object teacherID, object groupID, object typeOfTaskID);

        void Update(Task task);

        void Delete(object ID);
    }
}
