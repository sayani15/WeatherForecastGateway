using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using WeatherForecastGateway.Gateway;
using WeatherForecastGateway.Models;

namespace WeatherForecastGateway.RabbitMQ
{
	public class MQDataAccess : DefaultBasicConsumer, IMQDataAccess
	{
		private IModel _channel;
		private readonly IAppSettings _appSettings;
		private readonly IGatewayService _gatewayService;

		public MQDataAccess(IAppSettings appSettings, IGatewayService gatewayService)
		{
			_gatewayService = gatewayService;
			_appSettings = appSettings;
		}
		public void CreateConnection()
		{
			var hostName = _appSettings.GetStringSetting("MQHostName");
			var factory = new ConnectionFactory()
			{
				HostName = "127.0.0.1",
				UserName = "guest",
				Password = "guest",
				Port = 5672
			};

			var connection = factory.CreateConnection();
			_channel = connection.CreateModel();
			_channel.BasicQos(0, 1, false);
			_channel.BasicConsume("Weather-Request-Queue", false, this);
		}

		public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
		{
			try
			{
				var mqMessage = new MQMessage();
				var bodies = body.ToArray();
				var message = Encoding.UTF8.GetString(bodies);
				mqMessage.Message = message;
				mqMessage.RoutingKey = routingKey;
				ProcessMessage(mqMessage);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			_channel.BasicAck(deliveryTag, false);
			Console.WriteLine("message acknowledged");
		}

		public async void ProcessMessage(MQMessage message)
		{
			var city = JsonConvert.DeserializeObject<City>(message.Message.ToString());
			var weatherData = await _gatewayService.GetWeatherData(city.Location);
			SendMessage(weatherData);
		}

		public void SendMessage(APIResponse message)
		{
			var byteArray = Encoding.Default.GetBytes(JsonConvert.SerializeObject(message));
			_channel.BasicPublish("Weather-Forecast-Exchange", "response.forecast", body: byteArray);
		}
	}
}
