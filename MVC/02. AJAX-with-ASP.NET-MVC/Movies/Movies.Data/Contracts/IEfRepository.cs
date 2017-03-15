using System.Collections.Generic;

namespace Movies.Data.Contracts
{
    public interface IEfRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
