namespace DbC.Net;

/// <summary>
///   Extension methods that implement GreaterThanOrEqualTo requirement for 
///   types that implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class GreaterThanOrEqualToExtensions
{
   private const String _requirementName = RequirementNames.GreaterThanOrEqual;

   /// <summary>
   ///   Value GreaterThanOrEqual postcondition. Confirm that 
   ///   <paramref name="value"/> is greater than or equal to 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
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
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T EnsuresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual precondition. Confirm that 
   ///   <paramref name="value"/> is greater than or equal to 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   private static void CheckGreaterThanOrEqual<T>(
      T value,
      T lowerBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression) where T : IComparable<T>
   {
      if ((value is null && lowerBound is not null)
         || (value is not null && value.CompareTo(lowerBound) < 0))
      {
         messageTemplate ??= MessageTemplates.GreaterThanOrEqualTemplate;
         exceptionFactory ??= GetExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static IExceptionFactory GetExceptionFactory(RequirementType requirementType)
      => requirementType == RequirementType.Precondition
         ? StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
         : StandardExceptionFactories.PostconditionFailedExceptionFactory;
}
