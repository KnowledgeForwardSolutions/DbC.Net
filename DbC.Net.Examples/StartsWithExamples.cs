namespace DbC.Net.Examples;

public sealed class StartsWithExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must start with target substring";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "This is a test. This is only a test";
      var target = "THIS";
      var comparisionType = StringComparison.OrdinalIgnoreCase;


      // Precondition with default comparisionType, default message template and default exception factory.
      value.RequiresStartsWith(target);

      // Precondition with default comparisionType, custom message template and default exception factory.
      value.RequiresStartsWith(target, messageTemplate: customMessageTemplate);

      // Precondition with default comparisionType, default message template and custom exception factory.
      value.RequiresStartsWith(target, exceptionFactory: customExceptionFactory);

      // Precondition with default comparisionType, custom message template and custom exception factory.
      value.RequiresStartsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Precondition with comparisionType, default message template and default exception factory.
      value.RequiresStartsWith(target, comparisionType);

      // Precondition with comparisionType, custom message template and default exception factory.
      value.RequiresStartsWith(target, comparisionType, customMessageTemplate);

      // Precondition with comparisionType, default message template and custom exception factory.
      value.RequiresStartsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Precondition with comparisionType, custom message template and custom exception factory.
      value.RequiresStartsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default comparisionType, default message template and default exception factory.
      value.EnsuresStartsWith(target);

      // Postcondition with default comparisionType, custom message template and default exception factory.
      value.EnsuresStartsWith(target, messageTemplate: customMessageTemplate);

      // Postcondition with default comparisionType, default message template and custom exception factory.
      value.EnsuresStartsWith(target, exceptionFactory: customExceptionFactory);

      // Postcondition with default comparisionType, custom message template and custom exception factory.
      value.EnsuresStartsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Postcondition with comparisionType, default message template and default exception factory.
      value.EnsuresStartsWith(target, comparisionType);

      // Postcondition with comparisionType, custom message template and default exception factory.
      value.EnsuresStartsWith(target, comparisionType, customMessageTemplate);

      // Postcondition with comparisionType, default message template and custom exception factory.
      value.EnsuresStartsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Postcondition with comparisionType, custom message template and custom exception factory.
      value.EnsuresStartsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);
   }
}
