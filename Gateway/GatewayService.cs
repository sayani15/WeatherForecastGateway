using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

		//http://api.weatherapi.com/v1/forecast.json?key=aa4aa1207f2a449c901165157240704&q=London
		//http://api.weatherapi.com/v1/forecast.json?key=aa4aa1207f2a449c901165157240704&q=London&days=10&aqi=no&alerts=no

		public async Task<APIResponse> GetWeatherData(string city)
		{
			var result = new APIResponse();
			var forecastDay = new Forecastday();
			forecastDay.Day = new Day() { Maxtemp_c = 12};

			result.Forecast.Forecastday.Add(forecastDay);

			return result;
			using (var httpClient = new HttpClient())
			{
				var fullURL = $"{_baseURL}/forecast.json?key={_apiKey}&q={city}&days=3";	//TODO: allow user to pick number of days; anything greater than 3 costs money
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
