using GoodReads.Core.Contracts;
using GoodReads.Core.Repositories;
using GoodReads.Infrastructure.ExternalBookSource.Clients;
using GoodReads.Infrastructure.ExternalBookSource.Configurations;
using GoodReads.Infrastructure.ExternalBookSource.Contracts;
using GoodReads.Infrastructure.ExternalBookSource.Implementations;
using GoodReads.Infrastructure.Persistence.Ef;
using GoodReads.Infrastructure.Persistence.Ef.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        services.AddDbContext<EfDbContext>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }

    /// <summary>
    /// Adds all dependencies related to the external book source.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddExternalBookSource(this IServiceCollection services)
    {
        services
            .ConfigureOptions<BookSourceClientOptionsSetup>()
            .AddTransient<IBookSource, BookSource>()
            .AddHttpClient<IBookSourceClient, GoogleBookClient>(((provider, client) =>
            {
                var options = provider.GetService<IOptions<BookSourceClientOptions>>()!.Value;
                client.BaseAddress = new Uri(options.BaseUrl);
            }));
        return services;
    }
}