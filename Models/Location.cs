using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Contains location fields from weatherapi.com
	/// </summary>
	public class Location
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("region")]
		public string Region { get; set; }

		[JsonPropertyName("country")]
		public string Country { get; set; }

		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		[JsonPropertyName("lon")]
		public double Lon { get; set; }

		[JsonPropertyName("tz_id")]
		public string TzId { get; set; }

		[JsonPropertyName("localtime_epoch")]
		public int LocaltimeEpoch { get; set; }

		[JsonPropertyName("localtime")]
		public string Localtime { get; set; }
	}


}
