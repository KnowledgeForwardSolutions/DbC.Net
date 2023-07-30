namespace DbC.Net.Examples;

public sealed class RegexMatchExamples
{
   public void Examples()
   {
      var customMessageTemplate = "\"{Value}\" must match regex \"{Regex}\"";
      var customExceptionFactory = new CustomExceptionFactory();

      var adjacentRepeatedWordRegex = @"\b(?<word>\w+)\s+(\k<word>)\b";
      var emailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
      var ipAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

      var emailAddress = "abc@xyz.com";
      var ipAddress = "192.168.1.32";
      var adjacentWords = "One one two TWO";


      // Precondition with string regex, default options, default message template and default exception factory.
      emailAddress.RequiresRegexMatch(emailAddressRegex);

      // Precondition with string regex, default options, custom message template and default exception factory.
      emailAddress.RequiresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate);

      // Precondition with string regex, default options, default message template and custom exception factory.
      emailAddress.RequiresRegexMatch(emailAddressRegex, exceptionFactory: customExceptionFactory);

      // Precondition with string regex, default options, custom message template and custom exception factory.
      emailAddress.RequiresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Precondition with string regex, options specified, default message template and default exception factory.
      adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase);

      // Precondition with string regex, options specified, custom message template and default exception factory.
      adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate);

      // Precondition with string regex, options specified, default message template and custom exception factory.
      adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, exceptionFactory: customExceptionFactory);

      // Precondition with string regex, options specified, custom message template and custom exception factory.
      adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate, customExceptionFactory);


      // Precondition with regex object, default message template and default exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex);

      // Precondition with regex object, custom message template and default exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate);

      // Precondition with regex object, default message template and custom exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

      // Precondition with regex object, custom message template and custom exception factory.
      ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);


      // Postcondition with string regex, default options, default message template and default exception factory.
      emailAddress.EnsuresRegexMatch(emailAddressRegex);

      // Postcondition with string regex, default options, custom message template and default exception factory.
      emailAddress.EnsuresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate);

      // Postcondition with string regex, default options, default message template and custom exception factory.
      emailAddress.EnsuresRegexMatch(emailAddressRegex, exceptionFactory: customExceptionFactory);

      // Postcondition with string regex, default options, custom message template and custom exception factory.
      emailAddress.EnsuresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Postcondition with string regex, options specified, default message template and default exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase);

      // Postcondition with string regex, options specified, custom message template and default exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate);

      // Postcondition with string regex, options specified, default message template and custom exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, exceptionFactory: customExceptionFactory);

      // Postcondition with string regex, options specified, custom message template and custom exception factory.
      adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate, customExceptionFactory);


      // Postcondition with regex object, default message template and default exception factory.
      ipAddress.EnsuresRegexMatch(ipAddressRegex);

      // Postcondition with regex object, custom message template and default exception factory.
      ipAddress.EnsuresRegexMatch(ipAddressRegex, customMessageTemplate);

      // Postcondition with regex object, default message template and custom exception factory.
      ipAddress.EnsuresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

      // Postcondition with regex object, custom message template and custom exception factory.
      ipAddress.EnsuresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);
   }
}
