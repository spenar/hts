using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface IStudentManager
    {
        Student GetByUserID(object userID);

        IQueryable<Student> GetByGroudID(object groupID);

        IQueryable<Student> GetByInstitute(object insitutionID);

        void Add(Student student);

        void Update(Student student);

        void Delete(object ID);
    }
}
