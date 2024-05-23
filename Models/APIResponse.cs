using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Parent model to match weatherapi.com's response
	/// </summary>
	public class APIResponse
	{
		/// <summary>
		/// Contains location fields from weatherapi.com
		/// </summary>
		[JsonPropertyName("location")]
		public Location Location { get; set; }

		/// <summary>
		/// Represents the current weather conditions
		/// </summary>
		[JsonPropertyName("current")]
		public Current Current { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName("forecast")]
		public Forecast Forecast { get; set; }
	}
}
