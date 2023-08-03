using ClickApi.Application.Handler;
using ClickApi.Application.Queries;
using ClickApi.Domain.Entity;
using ClickApi.Domain.Intefaces.Repository;
using ClickApi.Domain.Intefaces.Service;
using ClickApi.Infrastructure.Data;
using ClickApi.Infrastructure.Repositories;
using ClickApi.Infrastructure.Scripts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connStr);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IRequestHandler<CreateShortenedLinkQuery, ShortenedLink>, CreateShortenedLinkQueryHandler>();
builder.Services.AddScoped<IRequestHandler<RedirectLinkQuery, string>, RedirectLinkQueryHandler>();

builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<ILinkService, LinkService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
