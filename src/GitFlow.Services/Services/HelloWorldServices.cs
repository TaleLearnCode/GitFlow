namespace JET.GitFlow.Services;

public class HelloWorldServices(string EnvironmentName, string EnvironmentVersion)
{

	private readonly string _environmentName = EnvironmentName;
	private readonly string _environmentVersion = EnvironmentVersion;

	public string GetHelloWorld()
			=> $"Hello World from {_environmentName} with version {_environmentVersion}";

}