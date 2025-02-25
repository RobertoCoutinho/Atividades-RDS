using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Modules.RateLimiterMiddleware
{
    public class RateLimiterMiddleware : IMiddleware
    {
        private static readonly ConcurrentDictionary<string, (int Count, DateTime ResetTime)> _requests = new();
        private const int RequestLimit = 5;
        private const int ResetTimeInSeconds = 60;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var now = DateTime.UtcNow;

            if (!_requests.ContainsKey(ip))
            {
                _requests[ip] = (1, now.AddSeconds(ResetTimeInSeconds));
            }
            else
            {
                var entry = _requests[ip];

                if (now > entry.ResetTime)
                {
                    _requests[ip] = (1, now.AddSeconds(ResetTimeInSeconds)); // Resetando o contador
                }
                else
                {
                    if (entry.Count + 1 > RequestLimit)
                    {
                        context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                        await context.Response.WriteAsync("Muitas requisições. Tente novamente mais tarde.");
                        return;
                    }
                    else
                    {
                        _requests[ip] = (entry.Count + 1, entry.ResetTime);
                    }
                }
            }

            await next(context);
        }
    }
}
