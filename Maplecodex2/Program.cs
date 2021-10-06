using Maplecodex2;
using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Services;
using Serilog;
using Microsoft.AspNetCore.Rewrite;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ItemService>();


// Set serilog configuration.
builder.Host.UseSerilog(Settings.InitializeSerilog());

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.UseRewriter(new RewriteOptions().AddApacheModRewrite(builder.Environment.ContentRootFileProvider, ".htaccess"));
app.UseRewriter(new RewriteOptions().AddRedirectToHttps());

// Initialization
Settings.InitDatabase();

app.Run();