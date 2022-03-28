using Maplecodex2;
using Maplecodex2.Data.Helpers;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.WebHost.UseUrls(Settings.GetURL());

// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

app.UsePathBase("/codex");
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialization
Settings.InitDatabase();

app.Run();
