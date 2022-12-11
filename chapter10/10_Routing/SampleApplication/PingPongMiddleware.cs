﻿namespace SampleApplication
{
    public class PingPongMiddleware
    {
        public PingPongMiddleware(RequestDelegate next)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("pong");
        }
    }

}
