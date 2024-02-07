using System.Reflection;
using FluentValidation;
using GoodReads.Application.Behaviors;
using GoodReads.Application.Commands.Books.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GoodReads.Application;

/// <summary>
/// Inject all dependencies from application layer.
/// </summary>
public static class ApplicationInstaller
{
    /// <summary>
    /// Adds Mediator dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly);
        });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }

    /// <summary>
    /// Adds all validators from FluentValidation and dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}