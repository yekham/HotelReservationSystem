using HotelReservation.DataAccess.Abstractions;
using HotelReservation.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(GetByID(id));
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(Guid id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                throw new Exception("Bulunamadı");
            }
            return entity;
        }

        public bool IfEntityExists(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public void Update(T entity)
        {
            _context.SaveChanges();
        }
    }
}
