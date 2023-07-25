namespace DbC.Net.Examples;

public sealed class EndsWithExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must end with target substring";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "This is a test. This is only a test";
      var target = "test";
      var comparisionType = StringComparison.OrdinalIgnoreCase;


      // Precondition with default comparisionType, default message template and default exception factory.
      value.RequiresEndsWith(target);

      // Precondition with default comparisionType, custom message template and default exception factory.
      value.RequiresEndsWith(target, messageTemplate: customMessageTemplate);

      // Precondition with default comparisionType, default message template and custom exception factory.
      value.RequiresEndsWith(target, exceptionFactory: customExceptionFactory);

      // Precondition with default comparisionType, custom message template and custom exception factory.
      value.RequiresEndsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Precondition with comparisionType, default message template and default exception factory.
      value.RequiresEndsWith(target, comparisionType);

      // Precondition with comparisionType, custom message template and default exception factory.
      value.RequiresEndsWith(target, comparisionType, customMessageTemplate);

      // Precondition with comparisionType, default message template and custom exception factory.
      value.RequiresEndsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Precondition with comparisionType, custom message template and custom exception factory.
      value.RequiresEndsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default comparisionType, default message template and default exception factory.
      value.EnsuresEndsWith(target);

      // Postcondition with default comparisionType, custom message template and default exception factory.
      value.EnsuresEndsWith(target, messageTemplate: customMessageTemplate);

      // Postcondition with default comparisionType, default message template and custom exception factory.
      value.EnsuresEndsWith(target, exceptionFactory: customExceptionFactory);

      // Postcondition with default comparisionType, custom message template and custom exception factory.
      value.EnsuresEndsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Postcondition with comparisionType, default message template and default exception factory.
      value.EnsuresEndsWith(target, comparisionType);

      // Postcondition with comparisionType, custom message template and default exception factory.
      value.EnsuresEndsWith(target, comparisionType, customMessageTemplate);

      // Postcondition with comparisionType, default message template and custom exception factory.
      value.EnsuresEndsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Postcondition with comparisionType, custom message template and custom exception factory.
      value.EnsuresEndsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);
   }
}
