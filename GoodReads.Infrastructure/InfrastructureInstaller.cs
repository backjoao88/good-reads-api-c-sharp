using GoodReads.Application.Abstractions.BookSource;
using GoodReads.Core.Contracts;
using GoodReads.Core.Repositories;
using GoodReads.Infrastructure.Authentication.Configurations;
using GoodReads.Infrastructure.BookSource.Clients;
using GoodReads.Infrastructure.BookSource.Configurations;
using GoodReads.Infrastructure.BookSource.Contracts;
using GoodReads.Infrastructure.Persistence.Ef;
using GoodReads.Infrastructure.Persistence.Ef.Configurations;
using GoodReads.Infrastructure.Persistence.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
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
        services
            .ConfigureOptions<DbConnectionOptionsSetup>()
            .AddDbContext<EfDbContext>(((provider, builder) =>
            {
                var options = provider.GetService<IOptions<DbConnectionOptions>>()!.Value;
                builder.UseSqlServer(options.ConnectionString);
            }))
            .AddScoped<IUnitOfWork, EfUnitOfWork>()
            .AddScoped<IBookRepository, BookRepository>();
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
            .AddTransient<IBookSource, BookSource.BookSource>()
            .AddHttpClient<IBookSourceClient, GoogleBookClient>(((provider, client) =>
            {
                var options = provider.GetService<IOptions<BookSourceClientOptions>>()!.Value;
                client.BaseAddress = new Uri(options.BaseUrl);
            }));
        return services;
    }

    public static IServiceCollection AddJwt(this IServiceCollection services)
    {
        services
            .ConfigureOptions<JwtOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>();
        return services;
    }
}