using GoodReads.Application;
using GoodReads.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;

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
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        builder.Services.AddAuthorization();
        builder.Services.AddJwt();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}