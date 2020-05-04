using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Service.Interfaces
{
    public interface IGenericService<T> where T: GenericEntity
    {
        Task<T> insert<V>(T entity) where V : AbstractValidator<T>;
        Task<T> update<V>(T entity, int id) where V : AbstractValidator<T>;
        Task<T> getById(int id);
        Task<IEnumerable<T>> get();
        Task delete(int id);
    }
}
