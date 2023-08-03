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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7153");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
