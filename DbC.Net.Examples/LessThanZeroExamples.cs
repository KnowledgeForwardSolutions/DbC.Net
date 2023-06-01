namespace DbC.Net.Examples;

public sealed class LessThanZeroExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be less than zero";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = Double.MinValue;

      // Precondition with default message template and default exception factory.
      value.RequiresLessThanZero();

      // Precondition with custom message template and default exception factory.
      value.RequiresLessThanZero(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresLessThanZero(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresLessThanZero(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.RequiresLessThanZero();

      // Postcondition with custom message template and default exception factory.
      value.RequiresLessThanZero(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.RequiresLessThanZero(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.RequiresLessThanZero(customMessageTemplate, customExceptionFactory);
   }
}
