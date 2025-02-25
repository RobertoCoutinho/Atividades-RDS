using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Modules.AuthMiddleware
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly string _validApiKey;

        public AuthMiddleware()
        {
            _validApiKey = "123456789";
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var apiKey = context.Request.Headers["API-KEY"].FirstOrDefault();

            if (string.IsNullOrEmpty(apiKey) || apiKey != _validApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Acesso negado: API Key inválida ou ausente.");
                return;
            }

            await next(context);
        }
    }

}

