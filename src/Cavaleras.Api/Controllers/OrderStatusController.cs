using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calaveras.Domain.Entities;
using Cavaleras.Service.Interfaces;
using Cavaleras.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cavaleras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderStatusController : ControllerBase
    {
        private readonly IGenericService<OrderStatus> _genericService;
        public OrderStatusController(IGenericService<OrderStatus> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _genericService.get());
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _genericService.getById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderStatus orderStatus)
        {
            try
            {
                return Ok(await _genericService.insert<OrderStatusValidator>(orderStatus));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] OrderStatus orderStatus, int id)
        {
            try
            {
                return Ok(await _genericService.update<OrderStatusUpdateValidator>(orderStatus, id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _genericService.delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}