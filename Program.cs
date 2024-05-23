using WeatherForecastGateway.Gateway;
using WeatherForecastGateway.RabbitMQ;

var mQDataAccess = new MQDataAccess();
mQDataAccess.CreateConnection();

while (true)
{
	Thread.Sleep(5000);
}

//while (true)
//{
//	Thread.Sleep(5000);
//	mQDataAccess.CheckConnection();
////}
///
//Console.ReadLine();