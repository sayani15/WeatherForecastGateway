using WeatherForecastGateway.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecastGateway.Gateway;
using WeatherForecastGateway;


var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
	services.AddSingleton<IGatewayService, GatewayService>();
	services.AddSingleton<IMQDataAccess, MQDataAccess>();
	services.AddSingleton<IAppSettings, AppSettings>();
}).Build();

var svc = ActivatorUtilities.CreateInstance<Startup>(host.Services);
svc.Run();

