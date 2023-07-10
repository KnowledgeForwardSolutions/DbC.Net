namespace DbC.Net;

/// <summary>
///   Extension methods that implement string MinLength requirement.
/// </summary>
public static class MinLengthExtensions
{
   private const String _requirementName = RequirementNames.MinLength;

   /// <summary>
   ///   String MinLength postcondition. Confirm that the length of the 
   ///   <paramref name="value"/> is greater than or equal to the 
   ///   <paramref name="minLength"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="minLength">
   ///   The minimum allowed length of the string <paramref name="value"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must have a minimum length of {MinLength}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/>'s length is
   ///   less than <paramref name="minLength"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="minLengthExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="minLength"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="minLength"/> is negative.
   /// </exception>
   public static String EnsuresMinLength(
      this String value,
      Int32 minLength,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(minLength))] String minLengthExpression = null!)
   {
      CheckMinLength(
         value,
         minLength,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         minLengthExpression);

      return value;
   }

   /// <summary>
   ///   String MinLength precondition. Confirm that the length of the 
   ///   <paramref name="value"/> is greater than or equal to the 
   ///   <paramref name="minLength"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="minLength">
   ///   The minimum allowed length of the string <paramref name="value"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must have a minimum length of {MinLength}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/>'s length is
   ///   less than <paramref name="minLength"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="minLengthExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="minLength"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="minLength"/> is negative.
   /// </exception>
   public static String RequiresMinLength(
      this String value,
      Int32 minLength,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(minLength))] String minLengthExpression = null!)
   {
      CheckMinLength(
         value,
         minLength,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         minLengthExpression);

      return value;
   }

   private static void CheckMinLength(
      String value,
      Int32 minLength,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String minLengthExpression)
   {
      if (minLength < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(minLength), minLength, Messages.MinLengthIsNegative);
      }

      if ((value?.Length ?? 0) < minLength)
      {
         messageTemplate ??= MessageTemplates.MinLengthTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithMinLength(minLength, minLengthExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
