namespace DbC.Net.Examples;

public sealed class MaxLengthExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} may not exceed 10 characters in length";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
      var maxLength = 10;

      // Precondition with default message template and default exception factory.
      value.RequiresMaxLength(maxLength);

      // Precondition with custom message template and default exception factory.
      value.RequiresMaxLength(maxLength, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresMaxLength(maxLength, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresMaxLength(maxLength, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.RequiresMaxLength(maxLength);

      // Postcondition with custom message template and default exception factory.
      value.RequiresMaxLength(maxLength, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.RequiresMaxLength(maxLength, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.RequiresMaxLength(maxLength, customMessageTemplate, customExceptionFactory);
   }
}
