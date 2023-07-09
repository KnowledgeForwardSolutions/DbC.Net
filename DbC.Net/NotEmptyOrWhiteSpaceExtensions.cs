namespace DbC.Net;

/// <summary>
///   Extension methods that implement String NotEmptyOrWhiteSpace requirement.
/// </summary>
public static class NotEmptyOrWhiteSpaceExtensions
{
   private const String _requirementName = RequirementNames.NotEmptyOrWhiteSpace;

   /// <summary>
   ///   NotEmptyOrWhiteSpace postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not  <see cref="String.Empty"/> or all 
   ///   whitespace characters and throw an exception if it is empty or whitespace.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be empty or all whitespace characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see cref="String.Empty"/> or all whitespace characters. Defaults to 
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
   public static String EnsuresNotEmptyOrWhiteSpace(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotEmptyOrWhiteSpace(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   NotEmptyOrWhiteSpace precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not  <see cref="String.Empty"/> or all 
   ///   whitespace characters and throw an exception if it is empty or whitespace.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be empty or all whitespace characters".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see cref="String.Empty"/> or all whitespace characters. Defaults to 
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
   public static String RequiresNotEmptyOrWhiteSpace(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotEmptyOrWhiteSpace(
         value,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckNotEmptyOrWhiteSpace(
      String? value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (value is not null && String.IsNullOrWhiteSpace(value))
      {
         messageTemplate ??= MessageTemplates.NotEmptyOrWhiteSpaceTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentNullExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
