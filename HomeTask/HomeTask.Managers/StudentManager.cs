using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentManager(IRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Student GetByUserID(object userID)
        {
            return this._studentRepository.GetAll().FirstOrDefault(x => x.UserID ==  (Guid)userID);
        }

        public IQueryable<Student> GetByGroudID(object groupID)
        {
            return this._studentRepository.GetAll().Where(x => x.GroupID == (ulong) groupID);
        }

        public IQueryable<Student> GetByInstitute(ulong instituteID)
        {
            return this._studentRepository.GetAll().Where(x => x.InstitutionID == instituteID);
        }

        public void Add(Student student)
        {
            if (this.Validate(student))
            {
                this._studentRepository.Add(student);
                this._studentRepository.Commit();
            }
        }

        public void Update(Student student)
        {
            if (this.Validate(student))
            {
                this._studentRepository.Update(student);
                this._studentRepository.Commit();
            }
        }

        public void Delete(object ID)
        {
            this._studentRepository.Delete(ID);
        }

        private bool Validate(Student student)
        {
            return true;
        }


    }
}
