using HotelsApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelsApp.Repositories
{
    public class GenericRepo<T> where T : class
    {
        internal DataContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepo(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetSingle(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
