namespace DbC.Net.Examples;

public sealed class NotEmptyOrWhiteSpaceExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must have a non-empty/non-whitespace value";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = String.Empty;

      // Precondition with default message template and default exception factory.
      value.RequiresNotEmptyOrWhiteSpace();

      // Precondition with custom message template and default exception factory.
      value.RequiresNotEmptyOrWhiteSpace(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      value.RequiresNotEmptyOrWhiteSpace(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      value.RequiresNotEmptyOrWhiteSpace(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      value.EnsuresNotEmptyOrWhiteSpace();

      // Postcondition with custom message template and default exception factory.
      value.EnsuresNotEmptyOrWhiteSpace(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      value.EnsuresNotEmptyOrWhiteSpace(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      value.EnsuresNotEmptyOrWhiteSpace(customMessageTemplate, customExceptionFactory);
   }
}
