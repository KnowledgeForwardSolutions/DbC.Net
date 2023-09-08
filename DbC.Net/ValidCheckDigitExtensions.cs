namespace DbC.Net;

/// <summary>
///   Extension methods that implement string ValidCheckDigit requirement.
/// </summary>
public static class ValidCheckDigitExtensions
{
   private const String _requirementName = RequirementNames.ValidCheckDigit;

   /// <summary>
   ///   String ValidCheckDigit postcondition. Confirm that the
   ///   <paramref name="value"/> contains a valid check digit, as defined by
   ///   the supplied <paramref name="checkDigitAlgorithm"/>.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="checkDigitAlgorithm">
   ///   The specific check digit algorithm to apply.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must contain a valid check digit".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> does not 
   ///   contain a valid check digit. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="checkDigitAlgorithm"/> is <see langword="null"/>.
   /// </exception>
   public static String EnsuresValidCheckDigit(
      this String value,
      ICheckDigitAlgorithm checkDigitAlgorithm,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {
      CheckValidCheckDigit(
         value,
         checkDigitAlgorithm ?? throw new ArgumentNullException(nameof(checkDigitAlgorithm), Messages.CheckDigitAlgorithmIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   String ValidCheckDigit precondition. Confirm that the
   ///   <paramref name="value"/> contains a valid check digit, as defined by
   ///   the supplied <paramref name="checkDigitAlgorithm"/>.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="checkDigitAlgorithm">
   ///   The specific check digit algorithm to apply.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must contain a valid check digit".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> does not 
   ///   contain a valid check digit. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="checkDigitAlgorithm"/> is <see langword="null"/>.
   /// </exception>
   public static String RequiresValidCheckDigit(
      this String value,
      ICheckDigitAlgorithm checkDigitAlgorithm,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {
      CheckValidCheckDigit(
         value,
         checkDigitAlgorithm ?? throw new ArgumentNullException(nameof(checkDigitAlgorithm), Messages.CheckDigitAlgorithmIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckValidCheckDigit(
      String value,
      ICheckDigitAlgorithm checkDigitAlgorithm,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (!checkDigitAlgorithm.ValidateCheckDigit(value))
      {
         messageTemplate ??= MessageTemplates.ValidCheckDigitTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithItem(DataNames.CheckDigitAlgorithm, checkDigitAlgorithm.Name)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
