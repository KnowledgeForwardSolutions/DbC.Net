namespace DbC.Net;

/// <summary>
///   Extension methods that implement String NotNullOrWhiteSpace requirement.
/// </summary>
public static class NotNullOrWhiteSpaceExtensions
{
   private const String _requirementName = RequirementNames.NotNullOrWhiteSpace;

   /// <summary>
   ///   NotNullOrWhiteSpace postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not <see langword="null"/>, 
   ///   <see cref="String.Empty"/> or all whitespace characters and throw an 
   ///   exception if it is null, empty or whitespace.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null, empty or all whitespace characters".
   /// </param>
   /// <param name="nullExceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentNullExceptionFactory"/>.
   /// </param>
   /// <param name="emptyExceptionFactory">
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
   public static String EnsuresNotNullOrWhiteSpace(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? nullExceptionFactory = null,
      IExceptionFactory? emptyExceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotNullOrWhiteSpace(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         nullExceptionFactory,
         emptyExceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   NotNullOrWhiteSpace precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not <see langword="null"/>, 
   ///   <see cref="String.Empty"/> or all whitespace characters and throw an 
   ///   exception if it is null, empty or whitespace.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null, empty or all whitespace characters".
   /// </param>
   /// <param name="nullExceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentNullExceptionFactory"/>.
   /// </param>
   /// <param name="emptyExceptionFactory">
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
   public static String RequiresNotNullOrWhiteSpace(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? nullExceptionFactory = null,
      IExceptionFactory? emptyExceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotNullOrWhiteSpace(
         value,
         RequirementType.Precondition,
         messageTemplate,
         nullExceptionFactory,
         emptyExceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckNotNullOrWhiteSpace(
      String? value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? nullExceptionFactory,
      IExceptionFactory? emptyExceptionFactory,
      String valueExpression)
   {
      if (String.IsNullOrWhiteSpace(value))
      {
         messageTemplate ??= MessageTemplates.NotNullOrWhiteSpaceTemplate;
         var exceptionFactory = value is null
            ? nullExceptionFactory ?? StandardExceptionFactories.ResolveArgumentNullExceptionFactory(requirementType)
            : emptyExceptionFactory ?? StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
