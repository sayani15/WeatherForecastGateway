using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Contains data fields from weatherapi.com that represent weather data for a specific day
	/// </summary>
	public class Day
	{
		[JsonPropertyName("maxtemp_c")]
		public double Maxtemp_c { get; set; }

		[JsonPropertyName("mintemp_c")]
		public double Mintemp_c { get; set; }

		[JsonPropertyName("avgtemp_c")]
		public double Avgtemp_c { get; set; }

		[JsonPropertyName("maxwind_mph")]
		public double Maxwind_mph { get; set; }

		[JsonPropertyName("totalprecip_mm")]
		public double Totalprecip_mm { get; set; }

		[JsonPropertyName("avghumidity")]
		public int Avghumidity { get; set; }

		[JsonPropertyName("condition")]
		public Condition Condition { get; set; }

		[JsonPropertyName("uv")]
		public double UV { get; set; }
	}


}
