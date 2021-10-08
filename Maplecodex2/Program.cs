using Maplecodex2;
using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Services;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ItemService>();
builder.WebHost.UseUrls(Settings.GetURL());
builder.Services.AddSignalR();

// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialization
Settings.InitDatabase();

app.Run();