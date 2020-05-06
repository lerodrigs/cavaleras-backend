using Calaveras.Domain.Dto;
using Calaveras.Domain.Entities;
using Cavaleras.Data.Context;
using Cavaleras.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Data.Repository
{
    public class IdentityRepository<T> : IIdentityRepository<T> where T: User
    {
        public readonly UserManager<T> _userManager;
        private readonly SignInManager<T> _signInManager;
        private readonly CavalerasDbContext _db;
        public IdentityRepository(UserManager<T> userManager, SignInManager<T> signInManager, CavalerasDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager; 
        }
        public async Task delete(string id)
        {
            try
            {
                IEnumerable<T> user = await get(id);
                if(user == null) return;

                await _userManager.DeleteAsync(user.FirstOrDefault());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Task<IEnumerable<T>> get(string id = null, string email = null)
        {
            IEnumerable<T> userList = _userManager.Users
                    .Where(x => x.Email == email || x.Id == id)
                    .ToList();

            return Task.FromResult(userList);
        }

        public async Task<T> register(T entity, string password)
        {
            try
            {
                IdentityResult result = await _userManager.CreateAsync(entity, password);
                if (!result.Succeeded) throw new Exception("Erro ao criar usuario!");

                await _userManager.AddToRoleAsync(entity, "Cliente");

                return entity;
            }
            catch(Exception e )
            {
                throw e; 
            }
        }

        public async Task<T> token(string email, string password)
        {
            try
            {
                T user = await _userManager.FindByEmailAsync(email);
                SignInResult result = await _signInManager.PasswordSignInAsync(user, password, false, true);

                if (!result.Succeeded) throw new Exception("Login inválido!");

                return user;
            }
            catch(Exception e)
            {
                throw e; 
            }
        }

        public async Task<T> update(T entity, string id)
        {
            try
            {
                await _userManager.UpdateAsync(entity);
                return entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Claim>> getClaims(string email)
        {
            try
            {
                T user = await _userManager.FindByEmailAsync(email);

                IList<Claim> claims = await _userManager.GetClaimsAsync(user);
                IList<string> roles = await _userManager.GetRolesAsync(user);

                claims.Add(new Claim(ClaimTypes.Email, email));
                foreach(string role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                return claims;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
