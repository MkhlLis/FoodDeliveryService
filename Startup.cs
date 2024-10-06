using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IMappers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;
using FoodDeliveryService.Administration.Handlers;
using FoodDeliveryService.Administration.Mappers;
using FoodDeliveryService.Administration.Repositories;
using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService;

public class Startup
{
    public static WebApplication IntitializeApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);
        var app = builder.Build();
        Configure(app);
        return app;
    }

    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        Configure(builder.Services);
    }

    public static void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }

    private static IServiceCollection Configure(IServiceCollection services)
    {
        services.AddScoped<IAdministrationCommandHandler, AdministrationCommandHandler>();
        services.AddScoped<IAdministrationCommandRepository, AdministrationCommandRepository>();
        services.AddScoped<IAdministrationQueryRepository, AdministrationQueryRepository>();
        services.AddScoped<IAdministrationQueryHandler, AdministrationQueryHandler>();
        services.AddSingleton<IAdministrationMapper<MenuOptionDto, MenuOptionEntity>, AdministrationCommandMapper>();
        return services;
    }
}