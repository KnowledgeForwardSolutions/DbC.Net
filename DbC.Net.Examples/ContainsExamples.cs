namespace DbC.Net.Examples;

public sealed class ContainsExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must contain target substring";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = "This is a test. This is only a test";
      var target = "ONLY";
      var comparisionType = StringComparison.OrdinalIgnoreCase;


      // Precondition with default comparisionType, default message template and default exception factory.
      value.RequiresContains(target);

      // Precondition with default comparisionType, custom message template and default exception factory.
      value.RequiresContains(target, messageTemplate: customMessageTemplate);

      // Precondition with default comparisionType, default message template and custom exception factory.
      value.RequiresContains(target, exceptionFactory: customExceptionFactory);

      // Precondition with default comparisionType, custom message template and custom exception factory.
      value.RequiresContains(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Precondition with comparisionType, default message template and default exception factory.
      value.RequiresContains(target, comparisionType);

      // Precondition with comparisionType, custom message template and default exception factory.
      value.RequiresContains(target, comparisionType, customMessageTemplate);

      // Precondition with comparisionType, default message template and custom exception factory.
      value.RequiresContains(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Precondition with comparisionType, custom message template and custom exception factory.
      value.RequiresContains(target, comparisionType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default comparisionType, default message template and default exception factory.
      value.EnsuresContains(target);

      // Postcondition with default comparisionType, custom message template and default exception factory.
      value.EnsuresContains(target, messageTemplate: customMessageTemplate);

      // Postcondition with default comparisionType, default message template and custom exception factory.
      value.EnsuresContains(target, exceptionFactory: customExceptionFactory);

      // Postcondition with default comparisionType, custom message template and custom exception factory.
      value.EnsuresContains(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


      // Postcondition with comparisionType, default message template and default exception factory.
      value.EnsuresContains(target, comparisionType);

      // Postcondition with comparisionType, custom message template and default exception factory.
      value.EnsuresContains(target, comparisionType, customMessageTemplate);

      // Postcondition with comparisionType, default message template and custom exception factory.
      value.EnsuresContains(target, comparisionType, exceptionFactory: customExceptionFactory);

      // Postcondition with comparisionType, custom message template and custom exception factory.
      value.EnsuresContains(target, comparisionType, customMessageTemplate, customExceptionFactory);
   }
}
