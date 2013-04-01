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
        private readonly IRepository<Institution2User> _institutionToUserRepository; 

        public StudentManager(IRepository<Student> studentRepository, IRepository<Institution2User> institutionToUserRepository)
        {
            this._studentRepository = studentRepository;
            this._institutionToUserRepository = institutionToUserRepository;
        }

        public Student GetByUserID(object userID)
        {
            return this._studentRepository.GetAll().FirstOrDefault(x => x.UserID ==  (Guid)userID);
        }

        public IQueryable<Student> GetByGroudID(object groupID)
        {
            return this._studentRepository.GetAll().Where(x => x.GroupID == (long) groupID);
        }

        public IQueryable<Student> GetByInstitute(object insitutionID)
        {
            var usersId = _institutionToUserRepository.GetAll().Where(x => x.InstitutionID == (long)insitutionID);
            return this._studentRepository.GetAll().Where(x => usersId.Any(z => z.UserID == x.UserID));
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
