using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class SubjectManager : ISubjectManager
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Group2Subject> _groupToSubjectRepository;

        public SubjectManager(IRepository<Subject> subjectRepository, IRepository<Group2Subject> groupToSubjectRepository)
        {
            this._subjectRepository = subjectRepository;
        }

        public Subject GetById(object ID)
        {
            return this._subjectRepository.Get(ID);
        }

        public IQueryable<Subject> GetAll(object insitutionID)
        {
            return this._subjectRepository.GetAll().Where(x => x.InstitutionID == (ulong)insitutionID);
        }

        public void Add(Subject subject, object insitutionID)
        {
            if (this.Validate(subject))
            {
                subject.InstitutionID = (ulong)insitutionID;
                this._subjectRepository.Add(subject);
                this._subjectRepository.Commit();
            }
        }

        public void Update(Subject subject)
        {
            if (this.Validate(subject))
            {
                this._subjectRepository.Update(subject);
                this._subjectRepository.Commit();
            }
        }

        private bool Validate(Subject subject)
        {
            return true;
        }

        public bool IsExist(object ID)
        {
            return this._subjectRepository.IsEntityExist(ID);
        }


        public IQueryable<Subject> GetByGroup(object groupID)
        {
            var subjectsID =
                this._groupToSubjectRepository.GetAll()
                    .Where(x => x.GroupID == (ulong) groupID)
                    .Select(x => x.SubjectID);

            return this._subjectRepository.GetAll().Where(x => subjectsID.Contains(x.ID));

        }
    }
}
