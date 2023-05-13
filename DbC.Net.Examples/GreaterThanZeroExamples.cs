namespace DbC.Net.Examples;

public sealed class GreaterThanZeroExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be greater than zero";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = Double.Pi;

      // Precondition with default message template and default exception factory.
      value.RequiresGreaterThanZero();

      // Precondition with custom message template and default exception factory.
      value.RequiresGreaterThanZero(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresGreaterThanZero(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresGreaterThanZero(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresGreaterThanZero();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresGreaterThanZero(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresGreaterThanZero(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresGreaterThanZero(customMessageTemplate, customExceptionFactory);
   }
}
