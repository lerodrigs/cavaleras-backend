using System;
using System.Threading.Tasks;
using Calaveras.Domain.Dto;
using Calaveras.Domain.Entities;
using Cavaleras.Service.Interfaces;
using Cavaleras.Service.Validators;
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
                AuthenticateResponseDto result = await _identityService.token<AuthenticateDtoValidator>(authenticate);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegisterUserDto registerDto)
        {
            try
            {
                AuthenticateResponseDto result = await _identityService.register<RegisterDtoValidator>(registerDto);
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}