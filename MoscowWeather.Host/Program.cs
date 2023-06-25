using MoscowWeather.Host.Contracts;
using MoscowWeather.Host.Persistance;
using MoscowWeather.Host.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataExtractService,DataExtractService>();
builder.Services.AddScoped<IWeatherRepository,WeatherRepository>();
builder.Services.AddPersistance(builder.Configuration);
var app = builder.Build();
await app.MigrateDbAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
