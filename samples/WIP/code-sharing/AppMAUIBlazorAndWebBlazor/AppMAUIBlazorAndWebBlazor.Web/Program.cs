using Microsoft.FluentUI.AspNetCore.Components;
using AppMAUIBlazorAndWebBlazor.Web.Components;
using AppMAUIBlazorAndWebBlazor.Shared.Services;
using AppMAUIBlazorAndWebBlazor.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the AppMAUIBlazorAndWebBlazor.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped
                        (
                            sp => new HttpClient
                                                        {
                                                            // WASM BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                                                            BaseAddress = new Uri("http://localhost:5029")
                                                        }
                        );
builder.Services.AddFluentUIComponents();

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
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(AppMAUIBlazorAndWebBlazor.Shared._Imports).Assembly);

app.Run();
