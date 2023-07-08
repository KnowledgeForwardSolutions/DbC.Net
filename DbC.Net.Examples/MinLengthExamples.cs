namespace DbC.Net.Examples;

public sealed class MinLengthExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} may not be less than 10 characters in length";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "ABC";
      var minLength = 10;

      // Precondition with default message template and default exception factory.
      value.RequiresMinLength(minLength);

      // Precondition with custom message template and default exception factory.
      value.RequiresMinLength(minLength, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresMinLength(minLength, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresMinLength(minLength, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresMinLength(minLength);

      // Postcondition with custom message template and default exception factory.
      value.EnsuresMinLength(minLength, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresMinLength(minLength, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresMinLength(minLength, customMessageTemplate, customExceptionFactory);
   }
}
