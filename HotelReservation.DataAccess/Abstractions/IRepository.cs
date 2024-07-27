using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetAll();
        T GetByID(Guid id);
        bool IfEntityExists(Expression<Func<T, bool>> filter);

    }
}
