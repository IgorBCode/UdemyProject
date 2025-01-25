﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category or any other generic model
        // CRUD Methods
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter); // get individual record
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
