using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService; 

        public PizzaController(IPizzaService service)
        {
            _pizzaService = service;
        }

        [HttpGet]
        [Route("loadAll")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAsync()
        {
            try
            {
                var result = await _pizzaService.loadAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("loadOne")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _pizzaService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostAsync(string name, double price)
        {
            try
            {
                var newPizza = await _pizzaService.CreateAsync(name, price);
                return Created($"/loadOne?id={newPizza.Id}", newPizza);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(Guid id, PizzaPayload payload)
        {
            try
            {
                var item = await _pizzaService.GetByIdAsync(id);

                if (item == null)
                {
                    return BadRequest();
                }


                item.Name = payload.Name;
                item.Price = payload.Price;

                var result = await _pizzaService.UpdateAsync(item);

                return Created($"/loadOne?id={id}", result);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _pizzaService.DeleteAsync(id);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}