using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Data.Entity;

namespace vNextAngularSPA.Data.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Predicate<T> match);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Predicate<T> match);

        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }

}
