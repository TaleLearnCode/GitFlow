namespace JET.GitFlow.Functions;

public class HelloWorld(ILoggerFactory loggerFactory, HelloWorldServices helloWorldServices)
{

	private readonly ILogger _logger = loggerFactory.CreateLogger<HelloWorld>();
	private readonly HelloWorldServices _helloWorldServices = helloWorldServices;

	[Function("HelloWorld")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData request)
	{
		try
		{
			return request.CreateResponse(HttpStatusCode.OK, _helloWorldServices.GetHelloWorld());
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while processing the request.");
			return request.CreateErrorResponse(ex);
		}
	}

}