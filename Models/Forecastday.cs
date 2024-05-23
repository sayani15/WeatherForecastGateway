using System.Text.Json.Serialization;

namespace WeatherForecastGateway.Models
{
	/// <summary>
	/// Contains the full forcast of a specific day, including an hour-by-hour overview of the weather conditions.
	/// Also contains data about the date and time.
	/// </summary>
	public class Forecastday
	{
		[JsonPropertyName("date")]
		public string Date { get; set; }

		[JsonPropertyName("date_epoch")]
		public int Date_epoch { get; set; }

		[JsonPropertyName("day")]
		public Day Day { get; set; }

		[JsonPropertyName("astro")]
		public Astro Astro { get; set; }

		[JsonPropertyName("hour")]
		public List<Hour> Hour { get; set; }
	}


}
