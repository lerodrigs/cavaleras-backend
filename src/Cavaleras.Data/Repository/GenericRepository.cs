using Calaveras.Domain.Entities;
using Cavaleras.Data.Context;
using Cavaleras.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cavaleras.Data.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T: GenericEntity
    {
        private readonly CavalerasDbContext _db; 
        public GenericRepository(CavalerasDbContext dbContext)
        {
            _db = dbContext; 
        }

        public  async Task delete(int id)
        {
            try
            {
                T entity = await getById(id);
                _db.Remove<T>(entity);

                await _db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<T>> get()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> getById(int id)
        {
            try
            {
                return await _db.Set<T>().Where(x => x.id == id)
                .FirstOrDefaultAsync();
            }
            catch(Exception e )
            {
                throw e;
            }
        }

        public async Task<T> insert(T entity)
        {
            try
            {
                await _db.AddAsync<T>(entity);
                await _db.SaveChangesAsync();

                return entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<T> update(T entity, int id)
        {
            try
            {
                if(await getById(id) == null)
                {
                    return await insert(entity);
                }

                _db.Update<T>(entity);
                await _db.SaveChangesAsync();

                return entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
