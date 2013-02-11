using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface ISubjectManager
    {
        Subject GetById(object ID);

        IQueryable<Subject> GetAll(object insitutionID);

        IQueryable<Subject> GetByGroup(object groupID);

        void Add(Subject subject, object insitutionID);

        void AddSubjectForGroup(IEnumerable<Subject> subjects, object groupID);

        void Update(Subject subject);

        bool IsExist(object ID);
    }
}
