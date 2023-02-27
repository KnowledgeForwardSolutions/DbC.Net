namespace DbC.Net;

public static class ApproximatelyEqualExtensions
{
   /// <summary>
   ///   Value ApproximatelyEqual postcondition. Confirm that the 
   ///   <see cref="IFloatingPoint{T}"/> <paramref name="value"/> is within
   ///   +/- <paramref name="epsilon"/> of the <paramref name="target"/> and 
   ///   throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be close to..
   /// </param>
   /// <param name="epsilon">
   ///   The allowed error margin. 
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IApproximateEqualityComparer{T}"/> used to check for 
   ///   approximate equality between <paramref name="value"/> and 
   ///   <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be within +/- {Epsilon} of {Target}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="targetExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="target"/>. 
   /// </param>
   /// <param name="epsilonExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="epsilon"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T EnsuresApproximatelyEqual<T>(
      this T value,
      T target,
      T epsilon,
      IApproximateEqualityComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!,
      [CallerArgumentExpression("epsilon")] String epsilonExpression = null!) where T : IFloatingPoint<T>
   {
      CheckApproximatelyEqual(
         value,
         target,
         epsilon,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression,
         epsilonExpression);

      return value;
   }
   /// <summary>
   ///   Value ApproximatelyEqual precondition. Confirm that the 
   ///   <see cref="IFloatingPoint{T}"/> <paramref name="value"/> is within
   ///   +/- <paramref name="epsilon"/> of the <paramref name="target"/> and 
   ///   throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be close to..
   /// </param>
   /// <param name="epsilon">
   ///   The allowed error margin. 
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IApproximateEqualityComparer{T}"/> used to check for 
   ///   approximate equality between <paramref name="value"/> and 
   ///   <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be within +/- {Epsilon} of {Target}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="targetExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="target"/>. 
   /// </param>
   /// <param name="epsilonExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="epsilon"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T RequiresApproximatelyEqual<T>(
      this T value,
      T target,
      T epsilon,
      IApproximateEqualityComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!,
      [CallerArgumentExpression("epsilon")] String epsilonExpression = null!) where T : IFloatingPoint<T>
   {
      CheckApproximatelyEqual(
         value,
         target,
         epsilon,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression,
         epsilonExpression);

      return value;
   }

   private static void CheckApproximatelyEqual<T>(
      T value,
      T target,
      T epsilon,
      IApproximateEqualityComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression,
      String epsilonExpression) where T : IFloatingPoint<T>
   {
      if (!comparer.ApproximatelyEquals(value, target, epsilon))
      {
         messageTemplate ??= MessageTemplates.ApproximatelyEqualTemplate;
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentExceptionFactory
            : StandardExceptionFactories.PostconditionFailedExceptionFactory;
         var data = new Dictionary<String, Object>
         {
            {  DataNames.RequirementType, requirementType },
            {  DataNames.RequirementName, RequirementNames.ApproximatelyEqual },
            {  DataNames.Value, value },
            {  DataNames.ValueExpression, valueExpression },
            {  DataNames.Target, target },
            {  DataNames.TargetExpression, targetExpression },
            {  DataNames.Epsilon, epsilon },
            {  DataNames.EpsilonExpression, epsilonExpression }
         };

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
