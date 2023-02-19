namespace DbC.Net.Examples;

public sealed class EqualExamples
{
   public record Box(Int32 Height, Int32 Length, Int32 Width)
   {
      public Int32 Volume => Height * Length * Width;
   }

   public class BoxVolumeComparer : IEqualityComparer<Box>
   {
      public Boolean Equals(Box? x, Box? y)
      {
         if (x is null && y is null) return true;
         else if (x is null || y is null) return false;

         return x!.Volume.Equals(y!.Volume);
      }

      public Int32 GetHashCode([DisallowNull] Box obj) => obj.Volume.GetHashCode();
   }

   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be equal to {Target}";
      var customExceptionFactory = new CustomExceptionFactory();

      var totalCount = 99;
      var targetCount = 100;

      // Precondition with default message template/default exception factory.
      totalCount.RequiresEqual(targetCount);

      // Precondition with custom message template/default exception factory.
      totalCount.RequiresEqual(targetCount, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      totalCount.RequiresEqual(targetCount, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      totalCount.RequiresEqual(targetCount, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      totalCount.EnsuresEqual(targetCount);

      // Postcondition with custom message template/default exception factory.
      totalCount.EnsuresEqual(targetCount, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      totalCount.EnsuresEqual(targetCount, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      totalCount.EnsuresEqual(targetCount, customMessageTemplate, customExceptionFactory);


      var box = new Box(1, 2, 3);
      var targetBox = new Box(2, 2, 2);
      var comparer = new BoxVolumeComparer();

      // Precondition with default message template/default exception factory.
      box.RequiresEqual(targetBox, comparer);

      // Precondition with custom message template/default exception factory.
      box.RequiresEqual(targetBox, comparer, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      box.RequiresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      box.RequiresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      box.EnsuresEqual(targetBox, comparer);

      // Postcondition with custom message template/default exception factory.
      box.EnsuresEqual(targetBox, comparer, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      box.EnsuresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      box.EnsuresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


      var str = "asdf";
      var targetStr = "QWERTY";
      var comparisonType = StringComparison.OrdinalIgnoreCase;

      // Precondition with default message template/default exception factory.
      str.RequiresEqual(targetStr, comparisonType);

      // Precondition with custom message template/default exception factory.
      str.RequiresEqual(targetStr, comparisonType, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      str.RequiresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      str.RequiresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      str.EnsuresEqual(targetStr, comparisonType);

      // Postcondition with custom message template/default exception factory.
      str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      str.EnsuresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
   }
}
