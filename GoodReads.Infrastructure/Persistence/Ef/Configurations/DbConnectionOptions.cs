namespace GoodReads.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// Represents a set of configurations for EFCore.
/// </summary>
public class DbConnectionOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}