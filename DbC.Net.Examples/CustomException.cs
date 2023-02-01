namespace DbC.Net.Examples;

public sealed class CustomException : Exception
{
   public CustomException(String? message) : base(message) { }
}
