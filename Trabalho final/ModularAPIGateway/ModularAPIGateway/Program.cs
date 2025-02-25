using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Modules.LogMiddleware;
using Modules.AuthMiddleware;
using Modules.RateLimiterMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//Injeta os modulos
builder.Services.AddTransient<LogMiddleware>();
builder.Services.AddTransient<AuthMiddleware>();
builder.Services.AddSingleton<RateLimiterMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Adiciona o modulos
app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<RateLimiterMiddleware>();

app.MapControllers();

app.Run();
