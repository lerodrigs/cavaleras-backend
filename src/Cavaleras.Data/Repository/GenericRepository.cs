using Calaveras.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Repository
{
    public class GenericRepository: IGenericRepository
    {
        public GenericRepository() { }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> get<T>()
        {
            throw new NotImplementedException();
        }

        public T getById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T insert<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public T update<T>(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
