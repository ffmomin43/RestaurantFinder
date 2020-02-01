using System;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantFinder.BusinessLogic.Common
{
    public interface IGenericService<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        //add Picture list
        int insert(T entity);
       
        void Save();
    }
}
