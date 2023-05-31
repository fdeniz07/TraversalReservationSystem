﻿using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Abstract;

namespace Traversal.CoreLayer.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Insert(T entity)
        {
            // _context.Set<T>().Add(entity);
            _context.Add(entity);
            _context.SaveChanges();

            //using var c = Context();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}