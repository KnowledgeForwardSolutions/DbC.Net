namespace DbC.Net.Examples;

public sealed class NotNullOrWhiteSpaceExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must have a non-null/non-empty/non-whitespace value";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "\t   \t";

      // Precondition with default message template and default exception factories.
      value.RequiresNotNullOrWhiteSpace();

      // Precondition with custom message template and default exception factories.
      value.RequiresNotNullOrWhiteSpace(customMessageTemplate);

      // Precondition with default message template and custom null value exception factory.
      value.RequiresNotNullOrWhiteSpace(nullExceptionFactory: customExceptionFactory);

      // Precondition with default message template and custom empty value exception factory.
      value.RequiresNotNullOrWhiteSpace(emptyExceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factories.
      value.RequiresNotNullOrWhiteSpace(customMessageTemplate, customExceptionFactory, customExceptionFactory);


      // Postcondition with default message template and default exception factories.
      value.EnsuresNotNullOrWhiteSpace();

      // Postcondition with custom message template and default exception factories.
      value.EnsuresNotNullOrWhiteSpace(customMessageTemplate);

      // Postcondition with default message template and custom null value exception factory.
      value.EnsuresNotNullOrWhiteSpace(nullExceptionFactory: customExceptionFactory);

      // Postcondition with default message template and custom empty value exception factory.
      value.EnsuresNotNullOrWhiteSpace(emptyExceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factories.
      value.EnsuresNotNullOrWhiteSpace(customMessageTemplate, customExceptionFactory, customExceptionFactory);
   }
}
