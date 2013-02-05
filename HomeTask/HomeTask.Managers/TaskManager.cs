using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Core.FIlters;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly ITeacherManager _teacherManager;
        private readonly IGroupManager _groupManager;
        private readonly ITypeOfTaskManager _typeOfTaskManager;

        public TaskManager(IRepository<Task> taskRepository, ITeacherManager teacherManager, IGroupManager groupManager, ITypeOfTaskManager typeOfTaskManager)
        {
            this._taskRepository = taskRepository;
            this._teacherManager = teacherManager;
            this._groupManager = groupManager;
            this._typeOfTaskManager = typeOfTaskManager;
        }

        public Task GetById(object ID)
        {
            return _taskRepository.Get(ID);
        }

        public IQueryable<Task> GetByFilter(TaskFilter filter)
        {
            return _taskRepository.GetAll()
                                  .Where(filter.TeacherFilter)
                                  .Where(filter.GroupFilter)
                                  .Where(filter.DateFilter);
        }

        public void Add(Task task, object teacherID, object groupID, object typeOfTaskID)
        {
            var isTeacherExist = this._teacherManager.IsExist(teacherID);
            var isGroupExist = this._groupManager.IsExist(groupID);
            var isTypeOfTask = this._typeOfTaskManager.IsExist(typeOfTaskID);

            if (this.Validate(task)
                && isTeacherExist
                && isGroupExist
                && isTypeOfTask)
            {
                task.TeacherID = (ulong)teacherID;
                task.GroupID = (ulong)groupID;
                task.TypeID = (ulong)typeOfTaskID;
                this._taskRepository.Add(task);
                this._taskRepository.Commit();
            }
        }

        public void Update(Task task)
        {
            if (this.Validate(task))
            {
                this._taskRepository.Update(task);
                this._taskRepository.Commit();
            }
        }

        public void Delete(object ID)
        {
            this._taskRepository.Delete(ID);
        }

        private bool Validate(Task entity)
        {
            return true;
        }
    }
}
