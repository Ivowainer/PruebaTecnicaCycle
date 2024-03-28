using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCycle.API.Config.ErrorHandler;

using PruebaTecnicaCycle.Application.Services;

using PruebaTecnicaCycle.Domain.Repositories;
using PruebaTecnicaCycle.Domain.Services;
using PruebaTecnicaCycle.Infrastructure.Database;
using PruebaTecnicaCycle.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<CycleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repo & Services
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// Utils
builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
