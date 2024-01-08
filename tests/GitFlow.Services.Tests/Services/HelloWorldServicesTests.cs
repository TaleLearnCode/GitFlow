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
		string environmentVersion_Set = "2.0";
		string environmentVersion_Test = "1.0";
		HelloWorldServices helloWorldServices = new(environmentName, environmentVersion_Set);

		// Act
		string result = helloWorldServices.GetHelloWorld();

		// Assert
		Assert.Equal($"Hello World from {environmentName} with version {environmentVersion_Test}", result);

	}

}