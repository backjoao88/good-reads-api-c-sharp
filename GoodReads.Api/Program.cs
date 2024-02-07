using GoodReads.Api.Middlewares;
using GoodReads.Application;
using GoodReads.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

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
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo()
            {
                Contact = new OpenApiContact()
                {
                    Name = "João Paulo Back"
                }
            });
            const string xmlProjectFile = "GoodReads.Api.xml";
            var xmlPath = AppContext.BaseDirectory;
            config.IncludeXmlComments(Path.Combine(xmlPath, xmlProjectFile));
        });
        
        builder.Services.AddScoped<GlobalExceptionMiddleware>();
        builder.Services.AddMediator();
        builder.Services.AddValidators();
        builder.Services.AddPersistence();
        builder.Services.AddExternalBookSource();
        builder.Services.AddJwt();
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        builder.Services.AddAuthorization();
        var app = builder.Build();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        app.Run();
    }
}