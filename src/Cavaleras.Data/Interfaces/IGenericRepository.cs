using Calaveras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Data.Interfaces
{
    public interface IGenericRepository<T> where T: GenericEntity
    {
        Task delete(int id);
        Task<IList<T>> get();
        Task<T> getById(int id);
        Task<T> insert(T entity);
        Task<T> update(T entity, int id);
    }
}
