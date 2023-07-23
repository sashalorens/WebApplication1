namespace WebApplication1
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public RoutingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context, ICarManagement carManager)
        {
            var request = context.Request;
            var path = request.Path;
            var query = request.Query;


           if (!string.IsNullOrWhiteSpace(request.Query["name"]))
            {
                await carManager.GetCarName(request.Query["name"], context);
            }

            if (!string.IsNullOrWhiteSpace(request.Query["age"]))
            {
                await carManager.GetCarAge(request.Query["age"], context);
            }

            if (!string.IsNullOrWhiteSpace(request.Query["engine"]))
            {
                await carManager.GetCarEngine(request.Query["engine"], context);
            }

            /* else
            {
                await requestDelegate.Invoke(context);
            } */
        }
    }
}
