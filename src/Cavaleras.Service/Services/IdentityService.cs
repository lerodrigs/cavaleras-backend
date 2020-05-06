using Calaveras.Domain.Dto;
using Calaveras.Domain.Entities;
using Cavaleras.Data.Interfaces;
using Cavaleras.Service.Interfaces;
using Cavaleras.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cavaleras.Service.Services
{
    public class IdentityService<T> : IIdentityService<T> where T : User
    {
        private readonly IIdentityRepository<T> _identityRepository;
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IConfiguration _configuration; 
        public IdentityService(IIdentityRepository<T> identityRepository, IConfiguration configuration, IGenericRepository<Address> addressRepository)
        {
            _identityRepository = identityRepository;
            _configuration = configuration;
            _addressRepository = addressRepository;
        }

        public async Task<AuthenticateResponseDto> register<V>(T user, string password) where V : AbstractValidator<T>
        {
            await Activator.CreateInstance<V>()
                .ValidateAndThrowAsync(user);

            await _identityRepository.register(user, password);

            if(user.Addresses?.Count > 0)
            {
                foreach(Address address in user.Addresses)
                {
                    address.idclient = user.Id; 
                    await Activator.CreateInstance<AddressValidator>()
                        .ValidateAndThrowAsync(address);

                    await _addressRepository.insert(address);
                }
            }

            return  new AuthenticateResponseDto()
            {
                token = await generateToken(user.Email), 
                expiration = DateTime.Now.AddDays(1)
            };
        }

        public async Task<User> update<V>(T user, string id) where V : AbstractValidator<T>
        {
            await Activator.CreateInstance<UserUpdateValidator>()
                .ValidateAndThrowAsync(user);

            if(user.Addresses?.Count > 0)
            {
                foreach(Address address in user.Addresses)
                {
                    await Activator.CreateInstance<AddressUpdateValidator>()
                    .ValidateAndThrowAsync(address);

                    await _addressRepository.update(address, address.id);
                }
            }

            return user; 
        }

        public async Task<AuthenticateResponseDto> token(AuthenticateDto user) 
        {
            T result = await _identityRepository.token(user.email, user.password);

            return new AuthenticateResponseDto()
            {
                token = await generateToken(user.email),
                expiration = DateTime.Now.AddDays(1)
            };
        }

        public async Task<string> generateToken(string email)
        {
            IEnumerable<Claim> claims = await _identityRepository.getClaims(email);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtSettings:signingKey"]));
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration["jwtSettings:issuer"],
                audience: _configuration["jwtSettings:audience"],
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return tokenHandler.WriteToken(token);
        }
    }
}
