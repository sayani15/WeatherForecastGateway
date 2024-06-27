using WeatherForecastGateway.Models;

namespace WeatherForecastGateway.Gateway
{
	public interface IGatewayService
	{
		Task<APIResponse> GetWeatherData(string city);
	}
}