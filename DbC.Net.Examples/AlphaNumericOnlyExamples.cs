namespace DbC.Net.Examples;

public sealed class AlphaNumericOnlyExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must contain only letters or digits";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "abc123";

      // Precondition with default message template and default exception factory.
      value.RequiresAlphaNumericOnly();

      // Precondition with custom message template and default exception factory.
      value.RequiresAlphaNumericOnly(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresAlphaNumericOnly(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresAlphaNumericOnly(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresAlphaNumericOnly();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresAlphaNumericOnly(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresAlphaNumericOnly(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresAlphaNumericOnly(customMessageTemplate, customExceptionFactory);
   }
}
