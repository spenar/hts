using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface ITypeOfTaskManager
    {
        TypeOfTask GetById(object ID);

        void Add(TypeOfTask typeOfTask, object teacherID);

        void Update(TypeOfTask typeOfTask);

        bool IsExist(object ID);
    }
}
