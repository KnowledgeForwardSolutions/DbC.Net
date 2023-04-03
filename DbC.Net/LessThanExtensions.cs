namespace DbC.Net;

/// <summary>
///   Extension methods that implement LessThan requirement for types that
///   implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class LessThanExtensions
{
   private const String _requirementName = RequirementNames.LessThan;

   /// <summary>
   ///   Value LessThan postcondition. Confirm that <paramref name="value"/>
   ///   is less than <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not equal or 
   ///   exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T EnsuresLessThan<T>(
      this T value,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckLessThan(
         value,
         upperBound,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThan precondition. Confirm that <paramref name="value"/>
   ///   is less than <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not equal or 
   ///   exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresLessThan<T>(
      this T value,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckLessThan(
         value,
         upperBound,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   private static void CheckLessThan<T>(
      T value,
      T upperBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String upperBoundExpression) where T : IComparable<T>
   {
      if ((value is null && upperBound is null)
         || (value is not null && value.CompareTo(upperBound) >= 0))
      {
         messageTemplate ??= MessageTemplates.LessThanTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
