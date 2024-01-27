using GoodReads.Application.Commands.Books.Create;
using Microsoft.Extensions.DependencyInjection;

namespace GoodReads.Application;

/// <summary>
/// Inject all dependencies from application layer.
/// </summary>
public static class ApplicationInstaller
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));
        return services;
    }
}