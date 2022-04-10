using Maplecodex2;
using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Services;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Extension method to AddTransient all Services available
builder.Services.AddAllServicesAvailable();

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


_ = DataHelperService.Instance;

// Initialization
Settings.InitDatabase();

app.Run();
