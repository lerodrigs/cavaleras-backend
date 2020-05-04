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
    public class DeliveryManController : ControllerBase  
    {
        private readonly IGenericService<DeliveryMan> _genericService; 
        public DeliveryManController(IGenericService<DeliveryMan> genericService)
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
            catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DeliveryMan deliveryMan)
        {
            try
            {
                return Ok(await _genericService.insert<DeliveryManValidator>(deliveryMan));
            }
           catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DeliveryMan deliveryMan, int id)
        {
            try
            {
                return Ok(await _genericService.update<DeliveryManUpdateValidator>(deliveryMan, id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _genericService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}