var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel
                    (
                        options =>
                        {
                            // --urls "http://0.0.0.0:5270;https://0.0.0.0:5270"
                            // nc -v 192.168.0.11 5270
                            options.Listen
                                        (
                                            // ERR_CONNECTION_REFUSED
                                            // System.Net.IPAddress.Parse("0.0.0.0"),
                                            // ERR_CONNECTION_REFUSED
                                            System.Net.IPAddress.Parse("192.168.0.11"),
                                            5270
                                        );
                        }
                    );

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
