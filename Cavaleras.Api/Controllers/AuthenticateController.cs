using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calaveras.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cavaleras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController() { }

        public IActionResult post([FromBody] AuthenticateDto authenticate)
        {
            try
            {
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult register([FromBody] RegisterUserDto registerDto)
        {
            try
            {
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}