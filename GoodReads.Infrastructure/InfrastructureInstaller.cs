using GoodReads.Core.Contracts;
using GoodReads.Core.Repositories;
using GoodReads.Infrastructure.Persistence.Ef;
using GoodReads.Infrastructure.Persistence.Ef.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoodReads.Infrastructure;

/// <summary>
/// Inject all dependencies from infrastructure layer.
/// </summary>
public static class InfrastructureInstaller
{
    /// <summary>
    /// Adds all dependencies related to persistence.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<EfDbContext>(ServiceLifetime.Transient);
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }
}