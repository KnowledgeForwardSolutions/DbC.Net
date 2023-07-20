namespace DbC.Net;

/// <summary>
///   Extension methods that implement String DigitsOnly requirement.
/// </summary>
public static class DigitsOnlyExtensions
{
   private const String _requirementName = RequirementNames.DigitsOnly;

   /// <summary>
   ///   DigitsOnly postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> contains only radix-10 digit characters 
   ///   ('0' - '9'). A value that is <see langword="null"/> or 
   ///   <see cref="String.Empty"/> will pass the requirement.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain radix-10 digit characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> contains a
   ///   radix-10 digit character ('0' - '9'). Defaults to 
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
   public static String EnsuresDigitsOnly(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckDigitsOnly(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   DigitsOnly precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> contains only radix-10 digit characters 
   ///   ('0' - '9'). A value that is <see langword="null"/> or 
   ///   <see cref="String.Empty"/> will pass the requirement.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain radix-10 digit characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> contains a
   ///   radix-10 digit character ('0' - '9'). Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static String RequiresDigitsOnly(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckDigitsOnly(
         value,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckDigitsOnly(
      String? value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (!value!.IsDigitsOnly())
      {
         messageTemplate ??= MessageTemplates.DigitsOnlyTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
