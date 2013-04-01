using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

namespace HomeTask.Managers
{
    public class InstitutionManager : IInstitutionManager
    {
        private readonly IRepository<Institution> _institutionRepository;
        private readonly IRepository<Institution2User> _institutionToUserRepository;

        public InstitutionManager(IRepository<Institution> institutionRepository)
        {
            this._institutionRepository = institutionRepository;
        }

        public Institution Get(object ID)
        {
            return this._institutionRepository.Get(ID);
        }

        public Institution GetByUserID(object userID)
        {
            var institution2user = _institutionToUserRepository.GetAll().FirstOrDefault(x => x.UserID == (Guid)userID);

            return _institutionRepository.Get(institution2user.InstitutionID);
        }

        public IQueryable<Institution> GetAll()
        {
            return this._institutionRepository.GetAll();
        }

        public void Add(Institution institution)
        {
            if (this.Validate(institution))
            {
                this._institutionRepository.Add(institution);
                this._institutionRepository.Commit();
            }
        }

        public void AddInstitution2User(object institutionID, Guid userID)
        {
            this._institutionToUserRepository.Add(new Institution2User()
                {
                    InstitutionID = (long)institutionID,
                    UserID = userID
                });
            this._institutionToUserRepository.Commit();
        }

        public void Update(Institution institution)
        {
            if (this.Validate(institution))
            {
                this._institutionRepository.Update(institution);
            }
        }

        public void Delete(object ID)
        {
            this._institutionRepository.Delete(ID);
        }

        private bool Validate(Institution institution)
        {
            return true;
        }


    }
}
