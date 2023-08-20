namespace DbC.Net.Examples;

public sealed class RegexMatchExamples
{
   public void Examples()
   {
      var customMessageTemplate = "\"{Value}\" must match regex \"{Regex}\"";
      var customExceptionFactory = new CustomExceptionFactory();

      var adjacentRepeatedWordRegex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
      var ipAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", RegexOptions.Compiled);

      var ipAddress = "192.168.1.32";
      var adjacentWords = "One one two TWO";


      // Precondition with default message template and default exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex);

      // Precondition with custom message template and default exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex);

      // Postcondition with custom message template and default exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, customMessageTemplate, customExceptionFactory);
   }
}
