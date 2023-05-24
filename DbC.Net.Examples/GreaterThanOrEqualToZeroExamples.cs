namespace DbC.Net.Examples;

public sealed class GreaterThanOrEqualToZeroExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be greater than or equal to zero";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = Double.Pi;

      // Precondition with default message template and default exception factory.
      value.RequiresGreaterThanOrEqualToZero();

      // Precondition with custom message template and default exception factory.
      value.RequiresGreaterThanOrEqualToZero(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresGreaterThanOrEqualToZero(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresGreaterThanOrEqualToZero(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresGreaterThanOrEqualToZero();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresGreaterThanOrEqualToZero(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresGreaterThanOrEqualToZero(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresGreaterThanOrEqualToZero(customMessageTemplate, customExceptionFactory);
   }
}
