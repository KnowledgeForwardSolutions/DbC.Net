namespace DbC.Net;

/// <summary>
///   Extension methods that implement string MaxLength requirement.
/// </summary>
public static class MaxLengthExtensions
{
   private const String _requirementName = RequirementNames.MaxLength;

   /// <summary>
   ///   String MaxLength postcondition. Confirm that the length of the 
   ///   <paramref name="value"/> is less than or equal to the 
   ///   <paramref name="maxLength"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="maxLength">
   ///   The maximum allowed length of the string <paramref name="value"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must have a maximum length of {MaxLength}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/>'s length is
   ///   greater than <paramref name="maxLength"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="maxLengthExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="maxLength"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="maxLength"/> is negative.
   /// </exception>
   public static String EnsuresMaxLength(
      this String value,
      Int32 maxLength,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(maxLength))] String maxLengthExpression = null!)
   {
      CheckMaxLength(
         value,
         maxLength,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         maxLengthExpression);

      return value;
   }

   /// <summary>
   ///   String MaxLength precondition. Confirm that the length of the 
   ///   <paramref name="value"/> is less than or equal to the 
   ///   <paramref name="maxLength"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="maxLength">
   ///   The maximum allowed length of the string <paramref name="value"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must have a maximum length of {MaxLength}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/>'s length is
   ///   greater than <paramref name="maxLength"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="maxLengthExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="maxLength"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="maxLength"/> is negative.
   /// </exception>
   public static String RequiresMaxLength(
      this String value,
      Int32 maxLength,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(maxLength))] String maxLengthExpression = null!)
   {
      CheckMaxLength(
         value,
         maxLength,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         maxLengthExpression);

      return value;
   }

   private static void CheckMaxLength(
      String value,
      Int32 maxLength,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String maxLengthExpression)
   {
      if (maxLength < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, Messages.MaxLengthIsNegative);
      }

      if ((value?.Length ?? 0) > maxLength)
      {
         messageTemplate ??= MessageTemplates.MaxLengthTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithMaxLength(maxLength, maxLengthExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
