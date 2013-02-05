using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class GroupManager : IGroupManager
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Group2Subject> _groupToSubjectRepository;
        private readonly IRepository<Group2Teacher> _groupToTeacherRepository;
        private readonly ISubjectManager _subjectManager;

        public GroupManager(IRepository<Group> groupRepository, 
                            IRepository<Group2Subject> groupToSubjectRepository, 
                            IRepository<Group2Teacher> groupToTeacherRepository, 
                            ISubjectManager subjectManager)
        {
            this._groupRepository = groupRepository;
            this._groupToSubjectRepository = groupToSubjectRepository;
            this._groupToTeacherRepository = groupToTeacherRepository;
            this._subjectManager = subjectManager;
        }

        public Group GetById(object ID)
        {
            return this._groupRepository.Get(ID);
        }

        public IQueryable<Group> GetAll(object insitutionID)
        {
            return this._groupRepository.GetAll().Where(x => x.InstitutionID == (ulong)insitutionID);
        }

        public void Add(Group group, IEnumerable<object> subjectsID, object insitutionID)
        {
            if (this.Validate(group))
            {
                this._groupRepository.Add(group);
                this._groupRepository.Commit();

                this.AddSubjectsForGroup(group.ID, subjectsID);
            }
        }

        public void Update(Group group, IEnumerable<object> subjectsID)
        {
            if (this.Validate(group))
            {
                this._groupRepository.Update(group);
                this._groupRepository.Commit();

                var dbSubjects2Group = this._subjectManager.GetByGroup(group.ID);
                foreach (var subject in dbSubjects2Group)
                {
                    if (subjectsID.Contains(subject.ID))
                    {
                        continue;
                    }
                    this._groupToSubjectRepository.Delete(subject.ID);
                }

                this.AddSubjectsForGroup(group.ID, subjectsID.Where(x => dbSubjects2Group.Select(s2g => s2g.ID).Contains((ulong)x)));
            }
        }

        public void Delete(object ID)
        {
            this._groupRepository.Delete(ID);
            this._groupRepository.Commit();
        }

        private bool Validate(Group group)
        {
            return true;
        }


        public bool IsExist(object ID)
        {
            return this._groupRepository.IsEntityExist(ID);
        }


        public bool TeacherTeachesGroup(object teacherID, object groupID)
        {
            return
                this._groupToTeacherRepository.GetAll()
                    .Count(x => x.TeacherID == (ulong) teacherID && x.GroupID == (ulong) groupID) > 0;
        }

        public bool GroupTeachesSubject(object groupID, object subjectID)
        {
            return
                this._groupToSubjectRepository.GetAll()
                    .Count(x => x.SubjectID == (ulong) subjectID && x.GroupID == (ulong) groupID) > 0;
        }

        private void AddSubjectsForGroup(object groupID, IEnumerable<object> subjectsID)
        {
            foreach (var subjectID in subjectsID)
            {
                if (this._subjectManager.IsExist(subjectID))
                {
                    this._groupToSubjectRepository.Add(new Group2Subject()
                        {
                            GroupID = (ulong)groupID,
                            SubjectID = (ulong)subjectID
                        }
                        );
                }
            }
            this._groupToSubjectRepository.Commit();
        }
    }
}
