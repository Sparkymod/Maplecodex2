using Maplecodex2;
using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Services;
using Serilog;
using Microsoft.AspNetCore.Authentication.Certificate;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate().AddCertificateCache();
builder.WebHost.UseUrls("https://*:5001");

// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialization
Settings.InitDatabase();

app.Run();