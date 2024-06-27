using RabbitMQ.Client;
using WeatherForecastGateway.Models;

namespace WeatherForecastGateway.RabbitMQ
{
	public interface IMQDataAccess
	{
		void CreateConnection();
	}
}