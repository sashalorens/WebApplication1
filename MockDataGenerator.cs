using Microsoft.EntityFrameworkCore;

using WebApplication1.Models;

namespace WebApplication1
{
    public class MockDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarContext(
                serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if (context.Cars.Any())
                {
                    return;
                }

                context.Cars.AddRange(
                    new Car
                    {
                        Id = 1,
                        Manufacturer = "Volkswagen",
                        Model = "Passat",
                        BodyType = "Sedan",
                        Color = "Black"
                    },
                    new Car
                    {
                        Id = 2,
                        Manufacturer = "Peugeot",
                        Model = "206",
                        BodyType = "Hatchback",
                        Color = "Red"
                    });

                context.SaveChanges();
            }

            using (var context = new PizzaContext(
                serviceProvider.GetRequiredService<DbContextOptions<PizzaContext>>()))
            {
                if (context.Pizzas.Any())
                {
                    return;
                }

                context.Pizzas.AddRange(
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pepperoni",
                        Price = 230.5,
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Name = "Hawaiian",
                        Price = 210.5,
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Name = "Margherita",
                        Price = 180,
                    });

                context.SaveChanges();
            }
        }
    }
}