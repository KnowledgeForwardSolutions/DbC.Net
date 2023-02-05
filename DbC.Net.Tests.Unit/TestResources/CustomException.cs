namespace DbC.Net.Tests.Unit.TestResources;

public class CustomException : Exception
{
    public CustomException(string? message) : base(message) { }
}
