using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IPizzaService
    {
        public Task<List<Pizza>> loadAllAsync();
        public Task<Pizza?> GetByIdAsync(Guid id);
        public Task<Pizza> CreateAsync(string name, double price);
        public Task<Pizza> UpdateAsync(Pizza pizza);
        public Task DeleteAsync(Guid id);
    }
}
