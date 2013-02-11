using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface IGroupManager
    {
        Group GetById(object ID);

        IQueryable<Group> GetAll(object insitutionID);

        void Add(Group group, object insitutionID);

        void Update(Group group);

        void Delete(object ID);

        bool IsExist(object ID);
    }
}
