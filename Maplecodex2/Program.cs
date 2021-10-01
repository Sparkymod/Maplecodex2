using Maplecodex2;
using Maplecodex2.Data.Services;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
bool InDevelopment = true;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ItemService>();
if (!InDevelopment)
{
    builder.WebHost.UseUrls("http://*:5000");
}


// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialization
Settings.InitDatabase();

app.Run();