using DAL;
using Microsoft.EntityFrameworkCore;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlRepository.Implementation
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context = null;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public bool Delete(int id)
        {
            var entityToDelete = GetById(id);
            _context.Remove(entityToDelete);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

    }
}
