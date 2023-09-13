namespace DbC.Net.Examples;

public sealed class ValidCheckDigitExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} has an invalid check digit";
      var customExceptionFactory = new CustomExceptionFactory();
      var checkDigitAlgorithm = StandardCheckDigitAlgorithms.LuhnAlgorithm;

      var value = "4111111111111111";    // VISA test card number


      // Precondition with default message template and default exception factory.
      value.RequiresValidCheckDigit(checkDigitAlgorithm);

      // Precondition with custom message template and default exception factory.
      value.RequiresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresValidCheckDigit(checkDigitAlgorithm);

      // Postcondition with custom message template and default exception factory.
      value.EnsuresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate, customExceptionFactory);
   }
}
