using Curiox.Data.Context;
using Curiox.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected CurioxContext Db { get; set; }

        public Repository()
        {
            Db = new CurioxContext();
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate).AsEnumerable();
        }

        public void Add(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
        }

        public void Edit(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }
    }
}
