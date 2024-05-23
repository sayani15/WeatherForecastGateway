using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class Forecast
	{
		[JsonPropertyName("forecastday")]
		public List<Forecastday> Forecastday { get; set; }
	}


}
