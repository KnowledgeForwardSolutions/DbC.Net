namespace DbC.Net.Examples;

public sealed class NotNullExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} can not be null";
      var customExceptionFactory = new CustomExceptionFactory();

      String lastName = null!;

      List<Guid> identifiers = null!;

      // Precondition with default message template and default exception factory.
      lastName.RequiresNotNull();

      // Precondition with custom message template and default exception factory.
      lastName.RequiresNotNull(customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      lastName.RequiresNotNull(exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      lastName.RequiresNotNull(customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      identifiers.EnsuresNotNull();

      // Postcondition with custom message template and default exception factory.
      identifiers.EnsuresNotNull(customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      identifiers.EnsuresNotNull(exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      identifiers.EnsuresNotNull(customMessageTemplate, customExceptionFactory);
   }
}
