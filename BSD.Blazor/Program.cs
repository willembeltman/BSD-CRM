using BSD.Blazor.Components;
using BSD.Business.CrudServices;
using BSD.Data;
using BSD.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Storage.Proxy;
using BSD.Business.Services;
using BSD.Business;

var builder = WebApplication.CreateBuilder(args);

StorageServerConfig.Instance = builder.Configuration
                        .GetSection("StorageServer")
                        .Get<StorageServerConfig>()!;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();
builder.Services.AddCrudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
