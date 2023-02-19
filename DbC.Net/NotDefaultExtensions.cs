namespace DbC.Net;

/// <summary>
///   Extension methods that implement NotDefault requirement.
/// </summary>
public static class NotDefaultExtensions
{
   /// <summary>
   ///   NotDefault postcondition. Confirm that <paramref name="value"/> is not 
   ///   the default for type {T} and throw an exception if it is default for 
   ///   type {T}.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be default({ValueDatatype})".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
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
   public static T EnsuresNotDefault<T>(
      this T value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotDefault(
         value!,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   NotDefault precondition. Confirm that <paramref name="value"/> is not 
   ///   the default for type {T} and throw an exception if it is default for 
   ///   type {T}.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be default({ValueDatatype})".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
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
   public static T RequiresNotDefault<T>(
      this T value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotDefault(
         value!,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckNotDefault<T>(
      T value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (EqualityComparer<T>.Default.Equals(value, default))
      {
         messageTemplate ??= MessageTemplates.NotDefaultTemplate;
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentExceptionFactory
            : StandardExceptionFactories.PostconditionFailedExceptionFactory;
         var data = new Dictionary<String, Object>()
         {
            {  DataNames.RequirementType, requirementType },
            {  DataNames.RequirementName, RequirementNames.NotDefault },
            {  DataNames.ValueExpression, valueExpression },
            {  DataNames.ValueDatatype, typeof(T).Name },
         };

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
