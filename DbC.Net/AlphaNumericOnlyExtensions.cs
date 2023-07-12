using DbC.Net.Utility;

namespace DbC.Net;

/// <summary>
///   Extension methods that implement String AlphaNumericOnly requirement.
/// </summary>
public static class AlphaNumericOnlyExtensions
{
   private const String _requirementName = RequirementNames.AlphaNumericOnly;

   /// <summary>
   ///   AlphaNumericOnly postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> contains only alphanumeric characters. A value
   ///   that is <see langword="null"/> or <see cref="String.Empty"/> will pass
   ///   the requirement.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain alphanumeric characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> contains a
   ///   non-letter or non-digit character. Defaults to 
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
   public static String EnsuresAlphaNumericOnly(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckAlphaNumericOnly(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   AlphaNumericOnly precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> contains only alphanumeric characters. A value
   ///   that is <see langword="null"/> or <see cref="String.Empty"/> will pass
   ///   the requirement.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain alphanumeric characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> contains a
   ///   non-letter or non-digit character. Defaults to 
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
   public static String RequiresAlphaNumericOnly(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckAlphaNumericOnly(
         value,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckAlphaNumericOnly(
      String? value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (!value!.IsAlphaNumericOnly())
      {
         messageTemplate ??= MessageTemplates.AlphaNumericOnlyTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
