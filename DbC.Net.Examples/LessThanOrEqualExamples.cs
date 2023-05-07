namespace DbC.Net.Examples;

public sealed class LessThanOrEqualExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be less than or equal to {UpperBound}";
      var customExceptionFactory = new CustomExceptionFactory();

      var changeDate = new DateTime(2023, 1, 1);
      var upperBoundDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);

      // Precondition with default message template and default exception factory.
      changeDate.RequiresLessThanOrEqual(upperBoundDate);

      // Precondition with custom message template and default exception factory.
      changeDate.RequiresLessThanOrEqual(upperBoundDate, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      changeDate.RequiresLessThanOrEqual(upperBoundDate, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      changeDate.RequiresLessThanOrEqual(upperBoundDate, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      changeDate.EnsuresLessThanOrEqual(upperBoundDate);

      // Postcondition with custom message template and default exception factory.
      changeDate.EnsuresLessThanOrEqual(upperBoundDate, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      changeDate.EnsuresLessThanOrEqual(upperBoundDate, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      changeDate.EnsuresLessThanOrEqual(upperBoundDate, customMessageTemplate, customExceptionFactory);


      var point = new Point { X = 1, Y = 12 };
      var upperBoundPoint = new Point { X = 10, Y = 10 };
      var comparer = new PointDistanceFromOriginComparer();

      // Precondition with default message template and default exception factory.
      point.RequiresLessThanOrEqual(upperBoundPoint, comparer);

      // Precondition with custom message template and default exception factory.
      point.RequiresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      point.RequiresLessThanOrEqual(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      point.RequiresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      point.EnsuresLessThanOrEqual(upperBoundPoint, comparer);

      // Postcondition with custom message template and default exception factory.
      point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      var str = "QWERTY";
      var upperBoundStr = "asdf";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresLessThanOrEqual(upperBoundStr, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
