namespace DbC.Net.Tests.Unit.TestData;

public class CustomException : Exception
{
   public CustomException(String? message) : base(message) { }
}
