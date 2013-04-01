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

        TypeOfTask GetByName(string name);

        IQueryable<TypeOfTask> GetByIdentifiers(IEnumerable<long> identifiers);

        void Add(TypeOfTask typeOfTask);

        void Update(TypeOfTask typeOfTask);

        bool IsExist(object ID);
    }
}
