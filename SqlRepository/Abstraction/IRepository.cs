using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository.Abstraction
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
