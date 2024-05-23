using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Contains the weather condition of a specific hour
	/// </summary>
	public class Hour
	{
		[JsonPropertyName("condition")]
		public Condition Condition { get; set; }
	}


}
