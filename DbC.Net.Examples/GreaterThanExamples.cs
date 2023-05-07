namespace DbC.Net.Examples;

public sealed class GreaterThanExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be greater than {LowerBound}";
      var customExceptionFactory = new CustomExceptionFactory();

      var changeDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);
      var lowerBoundDate = new DateTime(2023, 1, 1);

      // Precondition with default message template and default exception factory.
      changeDate.RequiresGreaterThan(lowerBoundDate);

      // Precondition with custom message template and default exception factory.
      changeDate.RequiresGreaterThan(lowerBoundDate, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      changeDate.RequiresGreaterThan(lowerBoundDate, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      changeDate.RequiresGreaterThan(lowerBoundDate, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      changeDate.EnsuresGreaterThan(lowerBoundDate);

      // Postcondition with custom message template and default exception factory.
      changeDate.EnsuresGreaterThan(lowerBoundDate, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      changeDate.EnsuresGreaterThan(lowerBoundDate, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      changeDate.EnsuresGreaterThan(lowerBoundDate, customMessageTemplate, customExceptionFactory);


      var point = new Point { X = 10, Y = 10 };
      var lowerBoundPoint = new Point { X = 1, Y = 12 };
      var comparer = new PointDistanceFromOriginComparer();

      // Precondition with default message template and default exception factory.
      point.RequiresGreaterThan(lowerBoundPoint, comparer);

      // Precondition with custom message template and default exception factory.
      point.RequiresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      point.RequiresGreaterThan(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      point.RequiresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      point.EnsuresGreaterThan(lowerBoundPoint, comparer);

      // Postcondition with custom message template and default exception factory.
      point.EnsuresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      point.EnsuresGreaterThan(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      point.EnsuresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      var str = "asdf";
      var lowerBoundStr = "QWERTY";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresGreaterThan(lowerBoundStr, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresGreaterThan(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.EnsuresGreaterThan(lowerBoundStr, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.EnsuresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.EnsuresGreaterThan(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.EnsuresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
