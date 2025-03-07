using DockerLoadBalancing.UI.Blazor.Components;
using MudBlazor.Services;
using DockerLoadBalancing.Application;
using DockerLoadBalancing.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Libraries
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<HttpClient>();

builder.Services.AddAntiforgery(options =>
{     // Set Cookie properties using CookieBuilder properties†.

    options.Cookie.Expiration = TimeSpan.Zero;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAntiforgery();
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .DisableAntiforgery()
    .AddInteractiveServerRenderMode();

app.Run();
