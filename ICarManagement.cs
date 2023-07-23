namespace WebApplication1
{
    public interface ICarManagement
    {
        public Task GetCarName(string name, HttpContext context);

        public Task GetCarEngine(string engine, HttpContext context);

        public Task GetCarAge(string age, HttpContext context);
    }
}
