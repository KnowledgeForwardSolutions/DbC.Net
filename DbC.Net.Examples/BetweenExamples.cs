namespace DbC.Net.Examples;

public sealed class BetweenExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be greater than (or equal to) {LowerBound} and less than (or equal to) {UpperBound}";
      var customExceptionFactory = new CustomExceptionFactory();

      var number = 42;
      var intLowerBound = 0;
      var intUpperBound = 100;

      // Precondition with default message template and default exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound);

      // Precondition with custom message template and default exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound);

      // Postcondition with custom message template and default exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate, customExceptionFactory);


      var point = new Point { X = 1, Y = 12 };
      var pointLowerBound = new Point { X = 0, Y = 0 };
      var pointUpperBound = new Point { X = 10, Y = 10 };
      var comparer = new PointDistanceFromOriginComparer();

      // Precondition with default message template and default exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer);

      // Precondition with custom message template and default exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer);

      // Postcondition with custom message template and default exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate, customExceptionFactory);


      var str = "ELEPHANT";
      var strLowerBound = "Aardvark";
      var strUpperBound = "Zebra";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
