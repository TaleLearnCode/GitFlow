using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string environmentName = Environment.GetEnvironmentVariable("EnvironmentName")!;
string environmentVersion = "1.0.4";


IHost host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(services =>
	{
		services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();
		services.AddSingleton(s => new HelloWorldServices(environmentName, environmentVersion));
	})
	.Build();

host.Run();