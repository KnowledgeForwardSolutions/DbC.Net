namespace DbC.Net.Examples;

public sealed class LessThanOrEqualToZeroExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be less than or equal to zero";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = Double.MinValue;

      // Precondition with default message template and default exception factory.
      value.RequiresLessThanOrEqualToZero();

      // Precondition with custom message template and default exception factory.
      value.RequiresLessThanOrEqualToZero(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresLessThanOrEqualToZero(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresLessThanOrEqualToZero(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresLessThanOrEqualToZero();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresLessThanOrEqualToZero(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresLessThanOrEqualToZero(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresLessThanOrEqualToZero(customMessageTemplate, customExceptionFactory);
   }
}
