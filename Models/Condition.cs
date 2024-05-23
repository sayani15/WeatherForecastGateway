using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Contains data fields corresponding to the weather condition from weatherapi.com.
	/// </summary>
	public class Condition
	{
		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("icon")]
		public string Icon { get; set; }

		[JsonPropertyName("code")]
		public int Code { get; set; }
	}


}
