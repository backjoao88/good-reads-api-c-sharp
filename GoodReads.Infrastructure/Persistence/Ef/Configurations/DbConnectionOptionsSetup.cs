using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GoodReads.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// Sets up a <see cref="DbConnectionOptions"/> configuration.
/// </summary>
public class DbConnectionOptionsSetup : IConfigureOptions<DbConnectionOptions>
{
    private readonly IConfiguration _configuration;
    private const string DbConnectionSectionName = "Databases:SqlServer";
    
    public DbConnectionOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DbConnectionOptions options)
    {
        _configuration.GetSection(DbConnectionSectionName).Bind(options);
    }
}