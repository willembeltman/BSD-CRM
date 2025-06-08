using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StorageServer.Api.Storage;
using StorageServer.Business.Interfaces;
using StorageServer.Data;
using StorageServer.Proxy;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration
                        .GetSection("Application")
                        .Get<AppConfig>()!;

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("Application"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true; // Zet op true in productie
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(appConfig.SuperSecretKeyArray)
    };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddSingleton<ApplicationDbContext>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
