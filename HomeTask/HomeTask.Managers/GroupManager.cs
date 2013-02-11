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

        public void Add(Group group, object insitutionID)
        {
            if (this.Validate(group))
            {
                this._groupRepository.Add(group);
                this._groupRepository.Commit();
            }
        }

        public void Update(Group group)
        {
            if (this.Validate(group))
            {
                this._groupRepository.Update(group);
                this._groupRepository.Commit();

               
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

        private void AddSubjects2Group(object groupID, IEnumerable<object> subjectsID)
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
