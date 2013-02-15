using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class TeacherManager : ITeacherManager
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<Group2Teacher> _groupToTeacherRepository;
        private readonly IGroupManager _groupManager;

        public TeacherManager(IRepository<Teacher> teacherRepository,
                              IRepository<Group2Teacher> groupToTeacherRepository,
                              IGroupManager groupManager)
        {
            this._teacherRepository = teacherRepository;
            this._groupToTeacherRepository = groupToTeacherRepository;
            this._groupManager = groupManager;
        }


        public Teacher GetById(object ID)
        {
            return this._teacherRepository.Get(ID);
        }

        public IQueryable<Teacher> GetAll(object insitutionID)
        {
            return this._teacherRepository.GetAll().Where(x => x.InstitutionID == (ulong)insitutionID);
        }

        public Teacher GetUserId(object ID)
        {
            return this._teacherRepository.GetAll().FirstOrDefault(x => x.UserID == (Guid)ID);
        }

        public bool IsExist(object ID)
        {
            return this._teacherRepository.IsEntityExist(ID);
        }

        public void Add(Teacher teacher, object insitutionID)
        {
            if (this.ValidateEntity(teacher))
            {
                teacher.InstitutionID = (ulong)insitutionID;
                this._teacherRepository.Add(teacher);
                this._teacherRepository.Commit();
            }
        }

        public void Update(Teacher teacher)
        {
            if (this.ValidateEntity(teacher))
            {
                this._teacherRepository.Update(teacher);
                this._teacherRepository.Commit();
            }
        }

        public void Delete(object ID)
        {
            this._teacherRepository.Delete(ID);
            this._teacherRepository.Commit();
        }

        public IQueryable<Teacher> GetByGroup(object groupID)
        {
            var teachersID = this._groupToTeacherRepository
                                 .GetAll()
                                 .Where(x => x.GroupID == (ulong)groupID)
                                 .Select(x => x.TeacherID);

            return this._teacherRepository.GetAll()
                       .Where(x => teachersID.Contains(x.ID));
        }

        private bool ValidateEntity(Teacher entity)
        {
            return true;
        }

        private void AddGropsForTeacher(object teacherID, IEnumerable<object> groupsID)
        {
            foreach (var groupID in groupsID)
            {
                if (this._groupManager.IsExist(groupID))
                {
                    this._groupToTeacherRepository.Add(new Group2Teacher()
                    {
                        TeacherID = (ulong)teacherID,
                        GroupID = (ulong)groupID
                    });
                }
            }
            this._groupToTeacherRepository.Commit();
        }
    }
}
