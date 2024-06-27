using System;
using WeatherForecastGateway.RabbitMQ;

public class Startup
{
	private readonly IMQDataAccess _mqDataAccess;
	public Startup(IMQDataAccess mQDataAccess)
	{
		_mqDataAccess = mQDataAccess;
	}

	public void Run()
	{
		_mqDataAccess.CreateConnection();

		while (true)
		{
			Thread.Sleep(5000);
		}

	}
}
