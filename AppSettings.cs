using Microsoft.Extensions.Configuration;

namespace WeatherForecastGateway
{
	public class AppSettings : IAppSettings
	{
		private readonly IConfiguration _config;
		public AppSettings() 
		{
			var builder = new ConfigurationBuilder().AddUserSecrets<SecretsModel>();

			_config = builder.Build();
		}
		public string GetStringSetting(string appSettingsKey) 
		{
			return _config.GetValue<string>(appSettingsKey);
		}
	}

	public interface IAppSettings
	{
		string GetStringSetting(string appSettingsKey);
	}
}
