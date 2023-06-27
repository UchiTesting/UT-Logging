using NLog;
using NLog.Web;

// Early init of NLog to allow startup
// and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddControllersWithViews();

	// NLog: Setup NLog for Dependency injection
	builder.Logging.ClearProviders();
	builder.Host.UseNLog(new NLogAspNetCoreOptions
	{
		RemoveLoggerFactoryFilter = true
	});

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days.
		// You may want to change this for production scenarios,
		// see https://aka.ms/aspnetcore-hsts.
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

}
catch (Exception e)
{
	// NLog: catch setup errors
	logger.Error(e, "Stopped program because of exception");
	throw;
}
finally
{
	// Ensure to flush and stop internal timers/threads
	// before application-exit
	// (Avoid segmentation fault on Linux)
	NLog.LogManager.Shutdown();
}