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
        //[HttpPost("token")]
        //public IActionResult token([FromBody] AuthenticateDto authenticate)
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch(Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpPost("register")]
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