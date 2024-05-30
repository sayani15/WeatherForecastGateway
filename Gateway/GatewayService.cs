using System.Text.Json;
using WeatherForecastGateway.Models;

namespace WeatherForecastGateway.Gateway
{
	public class GatewayService
	{
		private string _baseURL { get; set; }
		private string _apiKey { get; set; }

		public GatewayService() 
		{
			_baseURL = "http://api.weatherapi.com/v1";
			_apiKey = "aa4aa1207f2a449c901165157240704";
		}
		public async Task<APIResponse> GetWeatherData(string city)
		{
			using (var httpClient = new HttpClient())
			{
				var fullURL = $"{_baseURL}/forecast.json?key={_apiKey}&q={city}&days=3";	
				var response = await httpClient.GetAsync(fullURL);

				var responseString = await response.Content.ReadAsStringAsync();
				var apiResponse = JsonSerializer.Deserialize<APIResponse>(responseString);

				if (apiResponse != null)
				{
					return apiResponse;
				}
				throw new NullReferenceException("apiResponse was null :(");
				
			}
		}
	}
}
