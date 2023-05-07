namespace DbC.Net.Examples;

public sealed class GreaterThanOrEqualExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be greater than or equal to {LowerBound}";
      var customExceptionFactory = new CustomExceptionFactory();

      var changeDate = new DateTime(2023, 1, 1);
      var lowerBoundDate = new DateTime(2023, 1, 1);

      // Precondition with default message template and default exception factory.
      changeDate.RequiresGreaterThanOrEqual(lowerBoundDate);

      // Precondition with custom message template and default exception factory.
      changeDate.RequiresGreaterThanOrEqual(lowerBoundDate, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      changeDate.RequiresGreaterThanOrEqual(lowerBoundDate, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      changeDate.RequiresGreaterThanOrEqual(lowerBoundDate, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      changeDate.EnsuresGreaterThanOrEqual(lowerBoundDate);

      // Postcondition with custom message template and default exception factory.
      changeDate.EnsuresGreaterThanOrEqual(lowerBoundDate, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      changeDate.EnsuresGreaterThanOrEqual(lowerBoundDate, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      changeDate.EnsuresGreaterThanOrEqual(lowerBoundDate, customMessageTemplate, customExceptionFactory);


      var point = new Point { X = 10, Y = 10 };
      var lowerBoundPoint = new Point { X = 1, Y = 12 };
      var comparer = new PointDistanceFromOriginComparer();

      // Precondition with default message template and default exception factory.
      point.RequiresGreaterThanOrEqual(lowerBoundPoint, comparer);

      // Precondition with custom message template and default exception factory.
      point.RequiresGreaterThanOrEqual(lowerBoundPoint, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      point.RequiresGreaterThanOrEqual(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      point.RequiresGreaterThanOrEqual(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      point.EnsuresGreaterThanOrEqual(lowerBoundPoint, comparer);

      // Postcondition with custom message template and default exception factory.
      point.EnsuresGreaterThanOrEqual(lowerBoundPoint, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      point.EnsuresGreaterThanOrEqual(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      point.EnsuresGreaterThanOrEqual(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      var str = "asdf";
      var lowerBoundStr = "asdf";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresGreaterThanOrEqual(lowerBoundStr, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresGreaterThanOrEqual(lowerBoundStr, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresGreaterThanOrEqual(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresGreaterThanOrEqual(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.EnsuresGreaterThanOrEqual(lowerBoundStr, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.EnsuresGreaterThanOrEqual(lowerBoundStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.EnsuresGreaterThanOrEqual(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.EnsuresGreaterThanOrEqual(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
