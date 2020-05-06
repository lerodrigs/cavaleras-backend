using System;
using System.Threading.Tasks;
using Calaveras.Domain.Dto;
using Calaveras.Domain.Entities;
using Cavaleras.Service.Interfaces;
using Cavaleras.Service.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cavaleras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IIdentityService<User> _identityService;
        public AuthenticateController(IIdentityService<User> identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> token([FromBody] AuthenticateDto authenticate) 
        {
            try
            {
                await Activator.CreateInstance<AuthenticateDtoValidator>()
                    .ValidateAndThrowAsync(authenticate); 

                AuthenticateResponseDto result = await _identityService.token(authenticate);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] User user)
        {
            try
            {
                await Activator.CreateInstance<UserValidator>()
                    .ValidateAndThrowAsync(user);

                AuthenticateResponseDto result = await _identityService.register<UserValidator>(user, user.password);
                return Ok(user);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}