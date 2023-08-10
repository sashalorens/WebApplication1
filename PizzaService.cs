using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1
{
    public class PizzaService: IPizzaService
    {
        private readonly PizzaContext _context;
        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public async Task<List<Pizza>> loadAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza?> GetByIdAsync(Guid id)
        {
            return await _context.Pizzas.FindAsync(id);
        }

        public async Task<Pizza> CreateAsync(string name, double price)
        {
            var newPizza = new Pizza
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };
            _context.Add(newPizza);
            await _context.SaveChangesAsync();
            return newPizza;
        }

        public async Task<Pizza> UpdateAsync(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Pizzas.FindAsync(id);
            if (item != null)
            {
                _context.Pizzas.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
