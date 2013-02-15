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
        private readonly IRepository<Teacher2Subject> _teacherToSubjectRepository;
        private readonly IRepository<Group> _groupRepository;

        public SubjectManager(IRepository<Subject> subjectRepository, IRepository<Group2Subject> groupToSubjectRepository, IRepository<Group> groupRepository)
        {
            this._subjectRepository = subjectRepository;
            this._groupToSubjectRepository = groupToSubjectRepository;
            this._groupRepository = groupRepository;
        }

        public Subject GetById(object ID)
        {
            return this._subjectRepository.Get(ID);
        }

        public IQueryable<Subject> GetByTeacher(object teacherID)
        {
            var subject2Teacher = this._teacherToSubjectRepository
                                 .GetAll()
                                 .Where(x => x.TeacherID == (ulong)teacherID);

            return this._subjectRepository
                       .GetAll()
                       .Where(subject => subject2Teacher.Any(x => x.SubjectID == subject.ID));
        }

        public IQueryable<Subject> GetByGroup(object groupID)
        {
            var groupToSubject =
                this._groupToSubjectRepository.GetAll()
                    .Where(x => x.GroupID == (ulong)groupID);

            return this._subjectRepository
                       .GetAll()
                       .Where(x => groupToSubject.Any(z => z.SubjectID == x.ID));

        }

        public void Add(Subject subject)
        {
            if (this.Validate(subject))
            {
                this._subjectRepository.Add(subject);
                this._subjectRepository.Commit();
            }
        }


        public void AddSubjectForGroup(IEnumerable<Subject> subjects, object groupID)
        {
            var isGroupExist = this._groupRepository.IsEntityExist(groupID);
            if (isGroupExist)
            {


                var dbSubjects2Group = this._groupToSubjectRepository.GetAll().Where(x => x.GroupID == (ulong)groupID);
                foreach (var subject in dbSubjects2Group)
                {
                    if (subjects.Any(x => x.ID == subject.SubjectID))
                    {
                        continue;
                    }
                    this._groupToSubjectRepository.Delete(subject.ID);
                }

                foreach (var subject in subjects)
                {
                    if (!dbSubjects2Group.Any(x => x.SubjectID == subject.ID) && this.IsExist(subject.ID))
                    {
                        this._groupToSubjectRepository.Add(new Group2Subject()
                        {
                            GroupID = (ulong)groupID,
                            SubjectID = subject.ID
                        });
                    }
                }

                this._groupToSubjectRepository.Commit();
            }
        }


        public void AddSubjectForTeacher(Subject subject, object teacherID)
        {
            var subjectInDb =
                this._subjectRepository.GetAll()
                    .FirstOrDefault(x => x.Name.Equals(subject.Name, StringComparison.OrdinalIgnoreCase));
            ulong subjectID;

            if (subjectInDb == null)
            {
                this._subjectRepository.Add(subject);
                this._subjectRepository.Commit();
                subjectID = subject.ID;
            }
            else
            {
                subjectID = subjectInDb.ID;
            }

            this._teacherToSubjectRepository.Add(new Teacher2Subject()
            {
                SubjectID = subjectID,
                TeacherID = (ulong)teacherID
            });
        }

        public void Update(Subject subject)
        {
            if (this.Validate(subject))
            {
                this._subjectRepository.Update(subject);
                this._subjectRepository.Commit();
            }
        }

        public bool IsExist(object ID)
        {
            return this._subjectRepository.IsEntityExist(ID);
        }

        private bool Validate(Subject subject)
        {
            return true;
        }


    }
}
