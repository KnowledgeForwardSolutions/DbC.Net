namespace DbC.Net;

/// <summary>
///   Extension methods that implement LessThanZero requirement for numeric 
///   types.
/// </summary>
public static class LessThanZeroExtensions
{
   private const String _requirementName = RequirementNames.LessThanZero;

   /// <summary>
   ///   Value LessThanZero postcondition. Confirm that <paramref name="value"/>
   ///   is less than zero and throw an exception if it is not.
   /// </summary>
   /// <remarks>
   ///   LessThanZero requirements will always fail for unsigned numeric types.
   /// </remarks>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than zero".
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
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T EnsuresLessThanZero<T>(
      this T value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!) where T : INumber<T>
   {
      CheckLessThanZero(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanZero precondition. Confirm that <paramref name="value"/>
   ///   is less than zero and throw an exception if it is not.
   /// </summary>
   /// <remarks>
   ///   LessThanZero requirements will always fail for unsigned numeric types.
   /// </remarks>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than zero".
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
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresLessThanZero<T>(
      this T value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!) where T : INumber<T>
   {
      CheckLessThanZero(
         value,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckLessThanZero<T>(
      T value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression) where T : INumber<T>
   {
      if (value.CompareTo(T.Zero) >= 0)
      {
         messageTemplate ??= MessageTemplates.LessThanZeroTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
