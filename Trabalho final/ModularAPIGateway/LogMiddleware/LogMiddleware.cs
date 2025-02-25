using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Modules.LogMiddleware
{
    public class LogMiddleware : IMiddleware
    {
        private readonly string _logFilePath;

        public LogMiddleware()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\Rober\\OneDrive\\Documentos\\logs\\logs.txt");
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string logEntry = $"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path}\n";
            await File.AppendAllTextAsync(_logFilePath, logEntry, Encoding.UTF8);
            await next(context);
        }
    }
}
