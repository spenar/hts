using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HomeTask.Models.Contracts;
using HomeTask.Repository.Contracts;

namespace HomeTask.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            this._context = context;
        }

        private DbSet<TEntity> _base
        {
            get { return _context.Set<TEntity>(); }
        }

        public TEntity Get(object ID)
        {
            return _base.Find(ID);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _base.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            _base.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var dbEntity = this.Get(entity.Id);
            if (dbEntity != null)
            {
                this._context.Entry(dbEntity).CurrentValues.SetValues(dbEntity);
            }
        }

        public void Delete(object ID)
        {
            var dbEntity = this.Get(ID);
            if (dbEntity != null)
            {
                _base.Remove(dbEntity);
            }
        }

        public bool IsEntityExist(object ID)
        {
            return this.Get(ID) != null;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}
