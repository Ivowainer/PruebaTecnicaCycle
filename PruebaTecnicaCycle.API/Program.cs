using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaTecnicaCycle.API.Config.Auth;
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
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("MasterKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid Master Key",
        Name = "MasterKey",
        Type = SecuritySchemeType.ApiKey,
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "MasterKey"
                }
            },
            new string[] {}
        }
    });
});

// Repo & Services
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddAuthentication("MasterKey")
            .AddScheme<AuthenticationSchemeOptions, MasterKeyAuthenticationHandler>("MasterKey", options => { });

builder.Services.AddAuthorization(options =>
    {
        options.DefaultPolicy = new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes("MasterKey")
            .RequireAuthenticatedUser()
            .Build();
    });


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
