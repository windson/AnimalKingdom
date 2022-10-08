using AnimalKingdom.Services;
using AnimalKingdom.Utils.ConfigOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnimalKingdom.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnimalKingdomContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AnimalKingdomContext") ?? throw new InvalidOperationException("Connection string 'AnimalKingdomContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
