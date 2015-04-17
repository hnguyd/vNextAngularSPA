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
		//Expression<Func<T, bool>> where
		public virtual T GetById(Predicate<T> match) 
        {
			//return DataContext.Set<T>().AsEnumerable<T>().SingleOrDefault();
			return DataContext.Set<T>().ToList<T>().Find(match);
		}
        public virtual IEnumerable<T> GetAll()
        {
			return DataContext.Set<T>().AsEnumerable<T>();
        }
        public virtual IEnumerable<T> GetMany(Predicate<T> match)
        {
			return DataContext.Set<T>().ToList<T>().FindAll(match);
		}

        public virtual T Add(T entity)
        {
			DataContext.Add(entity);
            return entity;
        }
        public virtual void Update(T entity)
        {
			DataContext.Attach(entity);
			DataContext.Entry(entity).SetState(EntityState.Modified);
        }
        public virtual void Delete(T entity)
        {
            DataContext.Remove(entity);
        }
        public virtual void Delete(Predicate<T> match)
        {
			foreach (var entity in GetMany(match)) {
				DataContext.Remove(entity);
			}
		}

        public virtual void Save()
        {
            dbContext.SaveChanges();
        }

    }
}
