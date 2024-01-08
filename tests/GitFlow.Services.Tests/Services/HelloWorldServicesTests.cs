namespace JET.GitFlow.Services.Tests;

public class HelloWorldServicesTests
{

	[Fact]
	public void GetHelloWorld_ReturnsHelloWorldWithEnvironmentNameAndVersion()
	{
		// Arrange
		string environmentName = "Test Environment";
		string environmentVersion = "1.0";
		HelloWorldServices helloWorldServices = new(environmentName, environmentVersion);

		// Act
		string result = helloWorldServices.GetHelloWorld();

		// Assert
		Assert.Equal($"Hello World from {environmentName} with version {environmentVersion}", result);
	}

	[Fact]
	public void GetHelloWorld_Fails()
	{

		// Arrange
		string environmentName = "Test Environment";
		string environmentVersion = "1.0";
		HelloWorldServices helloWorldServices = new(environmentName, "2.0");

		// Act
		string result = helloWorldServices.GetHelloWorld();

		// Assert
		Assert.Equal($"Hello World from {environmentName} with version {environmentVersion}", result);

	}

}