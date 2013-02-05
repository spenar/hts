using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask.Repository.Contracts
{
    public interface IRepository<TEntity>
    {
        TEntity Get(object ID);

        bool IsEntityExist(object ID);

        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(object ID);

        void Commit();
    }
}
