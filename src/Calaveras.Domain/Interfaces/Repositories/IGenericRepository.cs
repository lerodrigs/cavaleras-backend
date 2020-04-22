using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Interfaces.Repositories
{
    public interface IGenericRepository
    {
        T insert<T>(T entity);
        T update<T>(int id, T entity);
        T getById<T>(int id);
        IEnumerable<T> get<T>();
        void delete(int id);
    }
}
