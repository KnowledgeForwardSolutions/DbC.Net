namespace DbC.Net.Examples;

public sealed class DigitsOnlyExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must contain only digits";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "123";

      // Precondition with default message template and default exception factory.
      value.RequiresDigitsOnly();

      // Precondition with custom message template and default exception factory.
      value.RequiresDigitsOnly(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresDigitsOnly(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresDigitsOnly(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresDigitsOnly();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresDigitsOnly(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresDigitsOnly(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresDigitsOnly(customMessageTemplate, customExceptionFactory);
   }
}
