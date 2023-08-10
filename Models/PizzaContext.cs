﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
}

