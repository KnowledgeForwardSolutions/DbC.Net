namespace DbC.Net.Examples;

public sealed class EqualExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be equal to {Target}";
      var customExceptionFactory = new CustomExceptionFactory();

      var totalCount = 99;
      var targetCount = 100;

      // Precondition with default message template and default exception factory.
      totalCount.RequiresEqual(targetCount);

      // Precondition with custom message template and default exception factory.
      totalCount.RequiresEqual(targetCount, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      totalCount.RequiresEqual(targetCount, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      totalCount.RequiresEqual(targetCount, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      totalCount.EnsuresEqual(targetCount);

      // Postcondition with custom message template and default exception factory.
      totalCount.EnsuresEqual(targetCount, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      totalCount.EnsuresEqual(targetCount, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      totalCount.EnsuresEqual(targetCount, customMessageTemplate, customExceptionFactory);


      var box = new Box(1, 2, 3, "Red");
      var targetBox = new Box(2, 2, 2, "Blue");
      var comparer = new BoxVolumeComparer();

      // Precondition with default message template and default exception factory.
      box.RequiresEqual(targetBox, comparer);

      // Precondition with custom message template and default exception factory.
      box.RequiresEqual(targetBox, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      box.RequiresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      box.RequiresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      box.EnsuresEqual(targetBox, comparer);

      // Postcondition with custom message template and default exception factory.
      box.EnsuresEqual(targetBox, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      box.EnsuresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      box.EnsuresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      var str = "asdf";
      var targetStr = "QWERTY";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresEqual(targetStr, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresEqual(targetStr, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.EnsuresEqual(targetStr, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.EnsuresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
