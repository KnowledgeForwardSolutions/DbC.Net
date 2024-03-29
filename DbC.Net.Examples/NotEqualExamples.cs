﻿namespace DbC.Net.Examples;

public sealed class NotEqualExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must not be equal to {Target}";
      var customExceptionFactory = new CustomExceptionFactory();

      var currentDate = new DateOnly(2021, 12, 25);
      var targetDate = new DateOnly(2021, 12, 25);

      // Precondition with default message template and default exception factory.
      currentDate.RequiresNotEqual(targetDate);

      // Precondition with custom message template and default exception factory.
      currentDate.RequiresNotEqual(targetDate, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      currentDate.RequiresNotEqual(targetDate, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      currentDate.RequiresNotEqual(targetDate, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      currentDate.EnsuresNotEqual(targetDate);

      // Postcondition with custom message template and default exception factory.
      currentDate.EnsuresNotEqual(targetDate, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      currentDate.EnsuresNotEqual(targetDate, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      currentDate.EnsuresNotEqual(targetDate, customMessageTemplate, customExceptionFactory);


      var box = new Box(1, 1, 8, "Red");
      var targetBox = new Box(2, 2, 2, "Blue");
      var comparer = new BoxVolumeComparer();

      // Precondition with default message template and default exception factory.
      box.RequiresNotEqual(targetBox, comparer);

      // Precondition with custom message template and default exception factory.
      box.RequiresNotEqual(targetBox, comparer, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      box.RequiresNotEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      box.RequiresNotEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      box.EnsuresNotEqual(targetBox, comparer);

      // Postcondition with custom message template and default exception factory.
      box.EnsuresNotEqual(targetBox, comparer, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      box.EnsuresNotEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      box.EnsuresNotEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      var str = "qwerty";
      var targetStr = "QWERTY";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template and default exception factory.
      str.RequiresNotEqual(targetStr, comparisonType);

      // Precondition with custom message template and default exception factory.
      str.RequiresNotEqual(targetStr, comparisonType, customMessageTemplate);

      // Precondition with default message template and custom exception factory.
      str.RequiresNotEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template and custom exception factory.
      str.RequiresNotEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template and default exception factory.
      str.EnsuresNotEqual(targetStr, comparisonType);

      // Postcondition with custom message template and default exception factory.
      str.EnsuresNotEqual(targetStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template and custom exception factory.
      str.EnsuresNotEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template and custom exception factory.
      str.EnsuresNotEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
