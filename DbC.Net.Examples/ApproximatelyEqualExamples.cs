namespace DbC.Net.Examples;

public sealed class ApproximatelyEqualExamples
{
   public void Examples()
   {
      var customMessageTemplate = "{ValueExpression} must be close to {Target}";
      var customExceptionFactory = new CustomExceptionFactory();

      var value = Double.Pi;
      var target = 4.0;
      var epsilon = 0.0001;
      var comparer = StandardFloatingPointComparers.DoubleRelativeErrorComparer;


      // Precondition with default message template/default exception factory.
      value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Precondition with custom message template/default exception factory.
      value.RequiresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate);

      // Precondition with default message template/custom exception factory.
      value.RequiresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: customExceptionFactory);

      // Precondition with custom message template/custom exception factory.
      value.RequiresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate, customExceptionFactory);


      // Postcondition with default message template/default exception factory.
      value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Postcondition with custom message template/default exception factory.
      value.EnsuresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate);

      // Postcondition with default message template/custom exception factory.
      value.EnsuresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: customExceptionFactory);

      // Postcondition with custom message template/custom exception factory.
      value.EnsuresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate, customExceptionFactory);
   }
}
