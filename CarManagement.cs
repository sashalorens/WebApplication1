namespace WebApplication1
{
    public class CarManagement: ICarManagement
    {
        public async Task GetCarName(string name, HttpContext context)
        {
            await context.Response.WriteAsync($"The car name is {name} \n");
        }

        public async Task GetCarEngine(string engine, HttpContext context)
        {
            await context.Response.WriteAsync($"The car has {engine} engine \n");
        }

        public async Task GetCarAge(string age, HttpContext context)
        {
            await context.Response.WriteAsync($"The age of car is {age} years \n");
        }
    }
}
