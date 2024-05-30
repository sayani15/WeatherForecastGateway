using WeatherForecastGateway.RabbitMQ;

var mQDataAccess = new MQDataAccess();
mQDataAccess.CreateConnection();

while (true)
{
	Thread.Sleep(5000);
}
