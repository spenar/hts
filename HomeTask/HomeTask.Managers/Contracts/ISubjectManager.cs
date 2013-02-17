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

        IQueryable<Subject> GetByGroup(object groupID);

        IQueryable<Subject> GetByTeacher(object teacherID);

        void Add(Subject subject);

        void AddSubjectForGroup(IEnumerable<Subject> subjects, object groupID);

        void AddSubjectForTeacher(Subject subject, object teacherID);

        void DeleteSubject2Teacher(object subjectID, object teacherID);

        void Update(Subject subject);

        bool IsExist(object ID);
    }
}
