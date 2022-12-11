using SampleApplication.ServicesLayer;

namespace SampleApplication
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ServiceA serviceA;

        public MyMiddleware(RequestDelegate? next, ServiceA serviceA)
        {
            this.next = next;
            this.serviceA = serviceA;
        }

        public async Task Invoke(HttpContext context, ServiceB serviceB)
        {
            await this.next(context);
        }
    }
}
