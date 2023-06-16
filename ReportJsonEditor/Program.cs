using Microsoft.Extensions.FileProviders;
using ReportJsonEditor.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<AppSettingsOptions>(builder.Configuration.GetSection(AppSettingsOptions.AppSettings));

builder.Services.AddControllers();

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
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Data")),
    RequestPath = new PathString("/Data")
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
