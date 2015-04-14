using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.Entity;

namespace vNextAngularSPA.Data.Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext dbContext;
        private readonly List<T> _items = new List<T>();

        protected GenericRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected ApplicationDbContext DataContext
        {
            get { return dbContext ?? (dbContext = DatabaseFactory.Get()); }
        }

        public virtual T GetById(Predicate<T> match) 
        {
            return _items.Find(match);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _items;
        }
        public virtual IEnumerable<T> GetMany(Predicate<T> match)
        {
            return _items.FindAll(match);
        }

        public virtual T Add(T entity)
        {
            _items.Add(entity);
            return entity;
        }
        public virtual void Update(T entity)
        {
            _items.Add(entity);
            dbContext.Entry(entity).SetState(EntityState.Modified);
        }
        public virtual void Delete(T entity)
        {
            _items.Remove(entity);
            dbContext.Remove(entity);
        }
        public virtual void Delete(Predicate<T> match)
        {
            _items.RemoveAll(match);
        }

        public virtual void Save()
        {
            dbContext.SaveChanges();
        }

    }
}
