using Calaveras.Domain.Dto;
using Calaveras.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cavaleras.Service.Interfaces
{
    public interface IIdentityService<T> where T: User
    {
        Task<AuthenticateResponseDto> token(AuthenticateDto userAuthenticateDto);
        Task<AuthenticateResponseDto> register<V>(T userRegisterDto, string password) where V: AbstractValidator<T>;
        Task<User> update<V>(T user, string id) where V : AbstractValidator<T>;
        Task<string> generateToken(string email);
    }
}
