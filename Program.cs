
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;

namespace WebApplication1
{
    public delegate void PrintString(string s);
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CarContext>(opt => opt.UseInMemoryDatabase("CarsList"));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICarManagement, CarManagement>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                MockDataGenerator.Initialize(scope.ServiceProvider);
            }

            // app.UseMiddleware<RoutingMiddleware>();

            // Configure the HTTP request pipeline.
            /* if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } */

            PrintString del = GreenTextClass.PrintGreen;
            del("Green text");
            del = YellowTextClass.PrintYellow;
            del("Yellow text");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

    class GreenTextClass
    {
        public static void PrintGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
        }
    }

    class YellowTextClass
    {
        public static void PrintYellow(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
        }
    }
}