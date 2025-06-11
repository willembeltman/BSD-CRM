using BSD.Business;
using BSD.Business.CrudServices;
using BSD.Business.Interfaces;
using BSD.Business.Services;
using BSD.Data;
using Microsoft.EntityFrameworkCore;
using Storage.Proxy;

namespace BSD.Api;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        StorageServerConfig.Instance = builder.Configuration
                                .GetSection("StorageServer")
                                .Get<StorageServerConfig>()!;

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        //builder.Services.AddDbContext<ApplicationDbContext>(
        //    options => options.UseInMemoryDatabase("InMemoryDatabase"));

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<IDateTimeService, DateTimeService>();
        builder.Services.AddCrudServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowSpecificOrigin");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}