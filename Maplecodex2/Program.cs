using Maplecodex2.Data.Services;
using Serilog;
using Maplecodex2;
using Maplecodex2.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ItemService>();

// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialization
Settings.InitDatabase();

app.Run();