namespace DbC.Net.Examples;

public sealed class LessThanExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be less than {UpperBound}";
      var customExceptionFactory = new CustomExceptionFactory();

      var changeDate = new DateTime(2023, 1, 1);
      var upperBoundDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);

      // Precondition with default message template/default exception factory.
      changeDate.RequiresLessThan(upperBoundDate);

      // Precondition with custom message template/default exception factory.
      changeDate.RequiresLessThan(upperBoundDate, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      changeDate.RequiresLessThan(upperBoundDate, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      changeDate.RequiresLessThan(upperBoundDate, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      changeDate.EnsuresLessThan(upperBoundDate);

      // Postcondition with custom message template/default exception factory.
      changeDate.EnsuresLessThan(upperBoundDate, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      changeDate.EnsuresLessThan(upperBoundDate, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      changeDate.EnsuresLessThan(upperBoundDate, customMessageTemplate, customExceptionFactory);


      var point = new Point { X = 1, Y = 12 };
      var upperBoundPoint = new Point { X = 10, Y = 10 };
      var comparer = new PointDistanceFromOriginComparer();

      // Precondition with default message template/default exception factory.
      point.RequiresLessThan(upperBoundPoint, comparer);

      // Precondition with custom message template/default exception factory.
      point.RequiresLessThan(upperBoundPoint, comparer, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      point.RequiresLessThan(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      point.RequiresLessThan(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      point.EnsuresLessThan(upperBoundPoint, comparer);

      // Postcondition with custom message template/default exception factory.
      point.EnsuresLessThan(upperBoundPoint, comparer, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      point.EnsuresLessThan(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      point.EnsuresLessThan(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


      var str = "QWERTY";
      var upperBoundStr = "asdf";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template/default exception factory.
      str.RequiresLessThan(upperBoundStr, comparisonType);

      // Precondition with custom message template/default exception factory.
      str.RequiresLessThan(upperBoundStr, comparisonType, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      str.RequiresLessThan(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      str.RequiresLessThan(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      str.EnsuresLessThan(upperBoundStr, comparisonType);

      // Postcondition with custom message template/default exception factory.
      str.EnsuresLessThan(upperBoundStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      str.EnsuresLessThan(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      str.EnsuresLessThan(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
