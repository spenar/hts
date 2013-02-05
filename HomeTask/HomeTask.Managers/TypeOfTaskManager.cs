using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class TypeOfTaskManager : ITypeOfTaskManager
    {
        private readonly IRepository<TypeOfTask> _typeOfTaskRepository;

        public TypeOfTaskManager(IRepository<TypeOfTask> typeOfTaskRepository)
        {
            this._typeOfTaskRepository = typeOfTaskRepository;
        }

        public TypeOfTask GetById(object ID)
        {
            return this._typeOfTaskRepository.Get(ID);
        }

        public void Add(TypeOfTask typeOfTask, object teacherID)
        {
            if (this.Validate(typeOfTask))
            {
                typeOfTask.TeacherID = (ulong)teacherID;
                this._typeOfTaskRepository.Add(typeOfTask);
                this._typeOfTaskRepository.Commit();
            }
        }

        public void Update(TypeOfTask typeOfTask)
        {
            if (this.Validate(typeOfTask))
            {
                this._typeOfTaskRepository.Update(typeOfTask);
                this._typeOfTaskRepository.Commit();
            }
        }

        private bool Validate(TypeOfTask typeOfTask)
        {
            return true;
        }


        public bool IsExist(object ID)
        {
            return this._typeOfTaskRepository.IsEntityExist(ID);
        }
    }
}
