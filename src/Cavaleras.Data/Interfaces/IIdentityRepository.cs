using Calaveras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Data.Interfaces
{
    public interface IIdentityRepository<T> where T: User
    {
        Task delete(string id);
        Task<T> register(T entity, string password);
        Task<T> update(T entity, string id);
        Task<IEnumerable<T>> get(string id = null, string email = null);
        Task<T> token(string email, string password);
        Task<IList<Claim>> getClaims(string email);
    }
}
