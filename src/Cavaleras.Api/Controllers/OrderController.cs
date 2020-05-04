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
    public class OrderController : ControllerBase
    {
        private readonly IGenericService<Order> _genericService;
        public OrderController(IGenericService<Order> genericService)
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
            catch (Exception e)
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
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                return Ok(await _genericService.insert<OrderValidator>(order));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Order order, int id)
        {
            try
            {
                return Ok(await _genericService.update<OrderUpdateValidator>(order, id));
            }
            catch (Exception e)
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