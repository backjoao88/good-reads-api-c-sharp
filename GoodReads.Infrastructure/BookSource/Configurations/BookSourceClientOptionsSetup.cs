using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GoodReads.Infrastructure.BookSource.Configurations;

/// <summary>
/// Sets up a <see cref="BookSourceClientOptions"/>
/// </summary>
internal sealed class BookSourceClientOptionsSetup : IConfigureOptions<BookSourceClientOptions>
{
    private readonly IConfiguration _configuration;
    private const string ConfigurationSectionName = "Modules:Book:ExternalBookSource";

    public BookSourceClientOptionsSetup(IConfiguration configuration) => _configuration = configuration;
    
    /// <inheritdoc/>
    public void Configure(BookSourceClientOptions options) => _configuration.GetSection(ConfigurationSectionName).Bind(options);
}