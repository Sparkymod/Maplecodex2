using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Maplecodex2.Data.Services;
using Maplecodex2.Data.Helpers;
using System.Reflection;
using Maplecodex2.Data.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Custom services
builder.Services.AddSingleton<ItemService>();

// Initialize
ItemStorage.Init();

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
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
