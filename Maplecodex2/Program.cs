
using Maplecodex2;
using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Services;
using RDK.Endpoints;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Settings.Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Extension method to AddTransient all Services available
builder.Services.AddAllServicesAvailable();

// Notification
builder.Services.AddRDKNotification();

builder.WebHost.UseUrls(Settings.GetURL());

// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

// Custom api helpers
app.MapApiHelpers();

app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

_ = DataHelperService.Instance;

app.Run();
