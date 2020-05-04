
using Calaveras.Domain.Entities;
using Cavaleras.Data.Interfaces;
using Cavaleras.Service.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Service.Services
{
    public class GenericService<T>: IGenericService<T> where T: GenericEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository) 
        {
            _genericRepository = genericRepository; 
        }

        public async Task delete(int id)
        {
            await _genericRepository.delete(id);
        }

        public async Task<IEnumerable<T>> get()
        {
            IList<T> result = await _genericRepository.get();
            return result;
        }

        public async Task<T> getById(int id)
        {
            return await _genericRepository.getById(id);
        }

        public async Task<T> insert<V>(T entity) where V : AbstractValidator<T>
        {
            await Activator.CreateInstance<V>()
                .ValidateAndThrowAsync(entity);

            return await _genericRepository.insert(entity);
        }

        public async Task<T> update<V>(T entity, int id) where V : AbstractValidator<T>
        {
            await Activator.CreateInstance<V>()
                .ValidateAndThrowAsync(entity);

            return await _genericRepository.update(entity, id);
        }
    }
}
