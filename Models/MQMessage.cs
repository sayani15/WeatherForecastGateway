namespace WeatherForecastGateway.Models
{
	public class MQMessage
	{
		public string Message { get; set; }
        public string RoutingKey { get; set; }

    }
}
