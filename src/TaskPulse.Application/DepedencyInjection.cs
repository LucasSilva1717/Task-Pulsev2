using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskPulse.Application.Common.Behaviors; // Ajuste conforme o namespace onde colocou o Behavior

namespace TaskPulse.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Regista o MediatR
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(assembly);
            
            // Regista o Pipeline Behavior de validação automaticamente
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // Regista automaticamente todos os validadores que herdam de AbstractValidator neste assembly
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}