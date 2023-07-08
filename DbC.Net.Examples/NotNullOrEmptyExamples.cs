namespace DbC.Net.Examples;

public sealed class NotNullOrEmptyExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must have a non-null/non-empty value";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = String.Empty;

      // Precondition with default message template and default exception factories.
      value.RequiresNotNullOrEmpty();

      // Precondition with custom message template and default exception factories.
      value.RequiresNotNullOrEmpty(customMessageTemplate);

      // Precondition with default message template and custom null value exception factory.
      value.RequiresNotNullOrEmpty(nullExceptionFactory: customExceptionFactory);

      // Precondition with default message template and custom empty value exception factory.
      value.RequiresNotNullOrEmpty(emptyExceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factories.
      value.RequiresNotNullOrEmpty(customMessageTemplate, customExceptionFactory, customExceptionFactory);


      // Postcondition with default message template and default exception factories.
      value.EnsuresNotNullOrEmpty();

      // Postcondition with custom message template and default exception factories.
      value.EnsuresNotNullOrEmpty(customMessageTemplate);

      // Postcondition with default message template and custom null value exception factory.
      value.EnsuresNotNullOrEmpty(nullExceptionFactory: customExceptionFactory);

      // Postcondition with default message template and custom empty value exception factory.
      value.EnsuresNotNullOrEmpty(emptyExceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factories.
      value.EnsuresNotNullOrEmpty(customMessageTemplate, customExceptionFactory, customExceptionFactory);
   }
}
