using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface IInstitutionManager
    {
        Institution Get(object ID);

        Institution GetByUserID(object ID);

        void Add(Institution institution);

        void AddAdministrator(object institutionID, Guid userID);

        void Update(Institution institution);

        void Delete(object ID);
    }
}
