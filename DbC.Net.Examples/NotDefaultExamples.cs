namespace DbC.Net.Examples;

public sealed class NotDefaultExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} can not be default";
      var customExceptionFactory = new CustomExceptionFactory();

      Int64 id = default;

      List<Guid> identifiers = default!;

      // Precondition with default message template and default exception factory.
      id.RequiresNotDefault();

      // Precondition with custom message template and default exception factory.
      id.RequiresNotDefault(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      id.RequiresNotDefault(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      id.RequiresNotDefault(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      identifiers.EnsuresNotDefault();

      // Postcondition with custom message template and default exception factory.
      identifiers.EnsuresNotDefault(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      identifiers.EnsuresNotDefault(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      identifiers.EnsuresNotDefault(customMessageTemplate, customExceptionFactory);
   }
}
