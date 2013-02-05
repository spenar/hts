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

        bool TeacherTeachesGroup(object teacherID, object groupID);

        bool GroupTeachesSubject(object groupID, object subjectID);

        void Add(Group group, IEnumerable<object> subjectsID ,object insitutionID);

        void Update(Group group, IEnumerable<object> subjectsID);

        void Delete(object ID);

        bool IsExist(object ID);
    }
}
