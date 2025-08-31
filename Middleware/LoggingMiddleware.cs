using System.Diagnostics;
using Serilog;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Student_Management_System.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var request = context.Request;
                
                Log.Information("Incoming Request: {Method} {Path} from {IP}",
                request.Method, request.Path, context.Connection.RemoteIpAddress);
                await _next(context);

                var response = context.Response;
                stopwatch.Stop();

                Log.Information("Outgoing Response: {StatusCode} {Path} | Time taken: {ElapsedMilliseconds} ms",
               response.StatusCode, request.Path, stopwatch.ElapsedMilliseconds);
            }
            catch(Exception ex)
            {
                Log.Error("An error occurred: {ExceptionMessage}", ex.Message);
                throw;
            }
          

        }



    }
}
