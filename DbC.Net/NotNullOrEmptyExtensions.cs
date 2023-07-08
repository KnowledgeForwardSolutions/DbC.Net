namespace DbC.Net;

/// <summary>
///   Extension methods that implement String NotNullOrEmpty requirement.
/// </summary>
public static class NotNullOrEmptyExtensions
{
   private const String _requirementName = RequirementNames.NotNullOrEmpty;

   /// <summary>
   ///   NotNullOrEmpty postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not <see langword="null"/> or 
   ///   <see cref="String.Empty"/> and throw an exception if it is null or 
   ///   empty.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null or empty".
   /// </param>
   /// <param name="nullExceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="emptyExceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see cref="String.Empty"/>. Defaults to 
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
   public static String EnsuresNotNullOrEmpty(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? nullExceptionFactory = null,
      IExceptionFactory? emptyExceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotNullOrEmpty(
         value,
         RequirementType.Postcondition,
         messageTemplate,
         nullExceptionFactory,
         emptyExceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   NotNullOrEmpty precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not <see langword="null"/> or 
   ///   <see cref="String.Empty"/> and throw an exception if it is null or 
   ///   empty.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null or empty".
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
   ///   <see cref="String.Empty"/>. Defaults to 
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
   public static String RequiresNotNullOrEmpty(
      this String value,
      String? messageTemplate = null,
      IExceptionFactory? nullExceptionFactory = null,
      IExceptionFactory? emptyExceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotNullOrEmpty(
         value,
         RequirementType.Precondition,
         messageTemplate,
         nullExceptionFactory,
         emptyExceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckNotNullOrEmpty(
      String? value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? nullExceptionFactory,
      IExceptionFactory? emptyExceptionFactory,
      String valueExpression)
   {
      if (String.IsNullOrEmpty(value))
      {
         messageTemplate ??= MessageTemplates.NotNullOrEmptyTemplate;
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
