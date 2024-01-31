using GoodReads.Application;
using GoodReads.Infrastructure;

namespace GoodReads.Api;

/// <summary>
/// Main application entrypoint.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddMediator();
        builder.Services.AddPersistence();
        builder.Services.AddExternalBookSource();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}