using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; } = null!;
    }
}

